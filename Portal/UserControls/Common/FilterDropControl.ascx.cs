using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Editors.Base;

namespace MnfUniversity_Portals.UserControls.Common
{
    public partial class FilterDropControl : UserControl
    {
        public event EventHandler SearchClicked;

        public bool FacultySelected
        {
            get { return FacultyDropDownList.SelectedIndex != 0 && DeparmentDropDownList.SelectedIndex == 0; }
        }

        public Guid GetFilteredOwner_ID
        {
            get
            {
                if (DepartmentSelected)
                    return Guid.Parse(DeparmentDropDownList.SelectedValue);
                if (FacultySelected)
                    return Guid.Parse(FacultyDropDownList.SelectedValue);

                if (OwnerSelected && !CommonChoosen)
                    return Guid.Parse(OwnerTypeDropDownList.SelectedValue);
                return URLBuilder.CurrentOwnerid(Page.RouteData);
            }
        }

        private bool CommonChoosen { get { return OwnerTypeDropDownList.SelectedValue == "Common"; } }

        private bool DepartmentSelected
        {
            get { return DeparmentDropDownList.SelectedIndex != 0 && DeparmentDropDownList.SelectedIndex != -1; }
        }

        private ListViewBasedUserControl GetEditor
        {
            get { return Parent.Controls.OfType<ListViewBasedUserControl>().SingleOrDefault(); }
        }

        private bool OwnerSelected
        {
            get { return OwnerTypeDropDownList.SelectedIndex != 0 && !DepartmentSelected && !FacultySelected; }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            FilterEditor();
            if (SearchClicked != null)
            {
                SearchClicked(this, e);
            }
        }

        protected void FacDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FacultyDropDownList.SelectedIndex != 0)
            {
                DeparmentDropDownList.DataSource = Prtl_OwnersUtility.GetAllSubOwnerNamesAndIDs(
                    StaticUtilities.Currentlanguage(Page), FacultyDropDownList.SelectedValue, 2);
                DeparmentDropDownList.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                OwnerTypeDropDownList.DataSource = Prtl_OwnersUtility.GetAllSubOwnerNamesAndIDs(
                    StaticUtilities.Currentlanguage(Page), "", (int)OwnerTypes.University);
                OwnerTypeDropDownList.DataBind();
                OwnerTypeDropDownList.Items.Insert(0, "Choose An Owner");
                if (GetEditor != null)
                    OwnerTypeDropDownList.Items.Insert(1, new ListItem("Common", null));
                SetDropDownListsValues();
                FilterEditor();
            }
            base.OnInit(e);
        }

        protected void OwnerTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OwnerTypeDropDownList.SelectedIndex != 0 && !CommonChoosen)
            {
                FacultyDropDownList.DataSource =
                    Prtl_OwnersUtility.GetAllSubOwnerNamesAndIDs(StaticUtilities.Currentlanguage(Page),
                                                                 OwnerTypeDropDownList.SelectedValue);
                FacultyDropDownList.DataBind();
                FacDropDown_SelectedIndexChanged(null, null);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetVisibility();
        }

        private void FilterEditor()
        {
            if (GetEditor != null)
            {
                if (OwnerSelected && CommonChoosen)
                    GetEditor.FilterOwnerID = null;
                else GetEditor.FilterOwnerID = GetFilteredOwner_ID;
            }
        }

        private void SetDropDownListsValues()
        {
            var currentownerid = URLBuilder.CurrentOwnerid(Page.RouteData).ToString();
            switch (StaticUtilities.GetOwnerType(URLBuilder.OwnerAbbr(Page.RouteData)))
            {
                case OwnerTypes.University:
                    OwnerTypeDropDownList.SelectedValue = currentownerid;
                    OwnerTypeDropDownList_SelectedIndexChanged(null, null);
                    break;

                case OwnerTypes.Faculty:
                    OwnerTypeDropDownList.SelectedValue =
                        Prtl_OwnersUtility.GetParentOwnerID(currentownerid);
                    OwnerTypeDropDownList_SelectedIndexChanged(null, null);
                    FacultyDropDownList.SelectedValue = currentownerid;
                    FacDropDown_SelectedIndexChanged(null, null);
                    break;

                case OwnerTypes.Department:
                    OwnerTypeDropDownList.SelectedValue =
                        Prtl_OwnersUtility.GetParentOwnerID(Prtl_OwnersUtility.GetParentOwnerID(currentownerid));
                    OwnerTypeDropDownList_SelectedIndexChanged(null, null);
                    FacultyDropDownList.SelectedValue =
                        Prtl_OwnersUtility.GetParentOwnerID(currentownerid);
                    FacDropDown_SelectedIndexChanged(null, null);
                    DeparmentDropDownList.SelectedValue = currentownerid;

                    break;
            }
        }

        private void SetVisibility()
        {
            OwnerTypeDropDownList.Visible = ChooseOwnerLabel.Visible =
                                            Page.User.Identity.Name.ToLower() == StaticUtilities.Superadmin;

            var rolesTobeInvisibleAt = new[] { "DepAdmin", "DepCoAdmin", "FacCoAdmin", "UniCoAdmin", "StaffRole" };

            if (rolesTobeInvisibleAt.Any(r => Page.User.IsInRole(r)))
            {
                Visible = false;
            }
            else if (Page.User.IsInRole("FacAdmin"))
            {
                ChooseFacultyLabel.Visible = FacultyDropDownList.Visible = false;
            }
        }
    }
}