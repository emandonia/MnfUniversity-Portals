using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using MnfUniversity_Portals.UserControls.Base;

namespace MnfUniversity_Portals.UserControls.Editors.ResearchsEditor.Details
{
    public partial class ResearchesDetailsViewControl : DetailsViewBasedUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected  void ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            
            if(resid!=0){
                Prtl_ResearchTransUtility.UpdateResearcherName(resid, Convert.ToInt32(e.Values["LangID"]), getStaffNameFromResID(Convert.ToInt32(resid), Page));
            }else
            {
                Prtl_ResearchTransUtility.UpdateResearcherName(Convert.ToInt32(FilterValue), Convert.ToInt32(e.Values["LangID"]), getStaffNameFromResID(Convert.ToInt32(FilterValue), Page));
               
            }
        }

        private string getStaffNameFromResID(int ResID,Page page)
        {
            return Prtl_ResearchTransUtility.getstaffnameByResID(ResID, page);
        }

        public int resid = 0;
      //  public DropDownList dropdown;
        protected override void ItemInserting(DetailsView detailsView, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {

                var x = detailsView.GetControl<CheckBox>("CheckBox1");
               var dropdown = detailsView.GetControl<DropDownList>("DropDownList1");
                Session["StaffName"] = dropdown.SelectedItem.Text;
                Session["StaffOwner"] = dropdown.SelectedValue;
                var ResDate = EditorDetailsView.GetControl<TextBox>("InsertResDateTextBox");
              
                
                resid = Prtl_ResearchUtility.InsertNewResearch(e, (Guid) CurrentOwnerID, dropdown.SelectedValue,
                                                                       StaticUtilities.ExtractDate(ResDate.Text),
                                                                       InsertPrimaryKey, x.Checked);
                
               
            }
            else
            {
                e.Values[InsertPrimaryKey] = FilterValue;
            }
            var langddl = GetDVControl<DropDownList>("LangDropDownList");
            e.Values["LangID"] = langddl.SelectedValue;
        }
        protected override void DataBound(object sender, EventArgs e)
        {
            if (EditorDetailsView.CurrentMode == DetailsViewMode.Insert)
            {
                SetFieldsVisibility(DetailsViewMode.Insert);
            }
            else
            {
                SetFieldsVisibility(DetailsViewMode.Edit);
            }
        }

        private void SetFieldsVisibility(DetailsViewMode mode)
        {
            var viewall = Mode != DetailsViewMode.Insert && mode == DetailsViewMode.Insert;
            var viewallinedit = (Mode == DetailsViewMode.Edit || Mode == DetailsViewMode.ReadOnly) && (mode == DetailsViewMode.Edit || mode == DetailsViewMode.ReadOnly);
            var headers = new[] { "Research Date", "Main Researcher Name" };
            foreach (
                var field in
                    EditorDetailsView.Fields.Cast<DataControlField>().Where(field => headers.Contains(field.HeaderText)))
            {
                if (viewallinedit)
                {
                    field.Visible = true;
                }
                else
                {
                    field.Visible = !viewall;
                }
            }
        }
        protected override void ItemUpdating(DetailsView detailsview, DetailsViewUpdateEventArgs e)
        {
            var Res_ID = detailsview.GetControl<HiddenField>("ResIDD");
            var x = detailsview.GetControl<CheckBox>("CheckBox1");
            var dropdown = detailsview.GetControl<DropDownList>("DropDownList1");
           
            var EditResDateTextBox = detailsview.GetControl<TextBox>("EditResDateTextBox");
            Prtl_ResearchUtility.UpdateResearch(Convert.ToInt32(Res_ID.Value), StaticUtilities.ExtractDate(EditResDateTextBox.Text), x.Checked, dropdown.SelectedItem.Text, new Guid(dropdown.SelectedValue), Page);

        }
        protected override int TranslationsCount
        {
            get { return Prtl_ResearchTransUtility.GetCountTranslations(FilterValue); }
        }
        protected override string DefaultValueForFiltering
        {
            get { return "0"; }
        }

        protected override string FilterValueName
        {
            get { return "ResearchTranslation_ID"; }
        }

        public override string EditorClientID
        {
            get
            {
                return GetClientIDs("Summary");
            }

        }


        //private DataControlField EditorField
        //{
        //    get { return EditorDetailsView.Fields[3]; }
        //}
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //EditorField.HeaderText = GetPreViewHeaderText();
        }




        private string InsertPrimaryKey
        {
            get { return "ResID"; }
        }


        protected override IEnumerable<Portal_DAL.prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_ResearchTransUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata);

            // ReSharper restore PossibleInvalidOperationException
        }
        protected  object StaffSelectorDataSource(object eval,Page page)
        {
            return Prtl_ResearchTransUtility.getstaffbyfacid(new Guid(eval.ToString()), page);
        }
        protected object StaffSelectorDataSource2( Page page)
        {
            return Prtl_ResearchTransUtility.getstaffbyfacid(new Guid(Session["ResearchesOwner_ID"].ToString()), page);
        }

        protected void oniteminserted(object sender, DetailsViewInsertedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}