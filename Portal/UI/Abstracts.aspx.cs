using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.BLL.Portal_BLL;


namespace MnfUniversity_Portals.UI
{
    public partial class Abstracts : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
                
                
                if (FacAbbr == null)
                {
                    FacDropDownList.Items.Clear();
                    FacDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
                }
                else
                {
                    decimal id = Prtl_OwnersUtility.getFacIDByAbbr(FacAbbr);
                    FacDropDownList.SelectedValue = id.ToString();
                    FacDropDownList.DataBind();
                    FacDropDownList.Enabled = false;
                    var datasource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(FacDropDownList.SelectedValue), Page);
                    AbstractListView.DataSource = datasource;
                    AbstractListView.DataBind();
                }


              

            }
        }
        public string DeleteImageURL
        {
            get { return ViewState["DeleteImageURL"].ToString(); }
            set { ViewState["DeleteImageURL"] = value; }
        }

        public string EditImageURL
        {
            get { return ViewState["EditImageURL"].ToString(); }
            set { ViewState["EditImageURL"] = value; }
        }

        public string InsertImageURL
        {
            get { return ViewState["InsertImageURL"].ToString(); }
            set { ViewState["InsertImageURL"] = value; }
        }

        protected void FileAbstractEditorControlInsertClicked(object sender, EventArgs e)
        {


            Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
            Editor_ModalPopupExtender.Show();

            DropDownList DropDownList1 = (DropDownList)Editor_DetailsView1.FindControl("InnerFacDropDownList");
            DropDownList1.SelectedValue = FacDropDownList.SelectedValue;
            DropDownList1.DataBind();
            DropDownList1.Enabled = false;
           
            GridView GridView1 = (GridView)Editor_DetailsView1.FindControl("GridView1");

            GridView1.DataSource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(DropDownList1.SelectedValue), Page);
          

            GridView1.DataBind();

        }
        public bool checkuser()
        {
            return Roles.IsUserInRole(Page.User.Identity.Name.ToLower(), "FacAdmin");
        }
        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var datasource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(FacDropDownList.SelectedValue), Page);
            AbstractListView.DataSource = datasource;
            AbstractListView.DataBind();
           
        }


        protected string FileAbstractUrl(object staffid)
        {
            // HiddenField y = (HiddenField) AbstractListView.FindControl("staffid");
            //return URLBuilder.GetURLIfExists2(Page, SiteFolders.Abstracts,
            //                                  Prtl_OwnersUtility.GetStaffAbstractFromPortal(Convert.ToDecimal(staffid)) +
            //                                  "");
            string s = URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/Images/" + Prtl_OwnersUtility.GetStaffAbstractFromPortal(Convert.ToDecimal(staffid));
            return s;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            deselct_radiobutton();
            RadioButton r = (RadioButton)sender;
            r.Checked = true;
        }

        public void deselct_radiobutton()
        {
            int i = 0;
            GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            foreach (var row in g.Rows)
            {
                RadioButton b = (RadioButton)g.Rows[i].FindControl("RadioButton1");
                b.Checked = false;
                i++;
            }
        }

        protected void GridViewPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            g.PageIndex = e.NewPageIndex;
            g.DataSource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(FacDropDownList.SelectedValue), Page);
           

            g.DataBind();
        }

        protected void InsertButtonClicked(object sender, EventArgs e)
        {

            string memberid = "";
            if (Editor_DetailsView1.CurrentMode == DetailsViewMode.Insert)
            {
                string filename = StaticUtilities.UploadFile(Editor_DetailsView1, "AsyncFileUpload1",
                                                             SiteFolders.Abstracts);
                if (filename != null)
                {
                    int i = 0;
                    GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
                    foreach (var row in g.Rows)
                    {
                        RadioButton b = (RadioButton)g.Rows[i].FindControl("RadioButton1");

                        if (b.Checked)
                        {
                            memberid = b.ToolTip;
                        }
                        i++;
                    }
                    if (memberid != "")
                    {
                        Prtl_AbstractsUtility.UpdateStaffAbstractFiles(Convert.ToDecimal(memberid), filename);
                        var datasource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(FacDropDownList.SelectedValue), Page);
                        AbstractListView.DataSource = datasource;
                        AbstractListView.DataBind();
                    }
                }
            }
        }


        protected void uploadedcomplete(object sender, AsyncFileUploadEventArgs e)
        {
            string s = e.FileName;
        }

        protected string insertbuttonid()
        {
            LinkButton g = (LinkButton)Editor_DetailsView1.FindControl("LinkButton1");
            return g.ID;
        }

        protected string FileName(object memberid)
        {
           return Prtl_AbstractsUtility.getFile(Convert.ToDecimal(memberid));
        }

        protected void DeleteAbstractFile(object sender, EventArgs e)
        {
            string memberid = "";
            int i = 0;
            GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            foreach (var row in g.Rows)
            {
                RadioButton b = (RadioButton)g.Rows[i].FindControl("RadioButton1");

                if (b.Checked)
                {
                    memberid = b.ToolTip;
                }
                i++;
            }
            if (memberid != "")
            {
                StaticUtilities.DeleteImage(Page, FileName(Convert.ToDecimal(memberid)), SiteFolders.Abstracts);
                Prtl_AbstractsUtility.deleteFile(Convert.ToDecimal(memberid));
                var datasource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(FacDropDownList.SelectedValue), Page);
                AbstractListView.DataSource = datasource;
                AbstractListView.DataBind();
            }
        }


        protected void InsertSpecsButtonClicked(object sender, EventArgs e)
        {
            //var FilePath = URLBuilder.GetURLIfExists2(Page, SiteFolders.Course_Specs,
            //                        Path.GetFileName(FileUpload1.FileName));
            //var FileName = Path.GetFileName(FilePath);

            //FileUpload1.SaveAs(FilePath);
            StaticUtilities.UploadFile2(Page, "FileUpload1", SiteFolders.Course_Specs)
                ;
        }
    }
}