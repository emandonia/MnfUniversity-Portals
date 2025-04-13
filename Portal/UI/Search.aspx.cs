using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using Portal_DAL;

namespace MnfUniversity_Portals.UI
{
    public partial class Search :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void SearchButtonClicked(object sender, EventArgs e)
        {
            //if (RadioButtonList1.SelectedValue == "1")
            //{
               
            //    ListView1.Items.Clear();
               
            //     var dc = new PortalDataContextDataContext()
            //var langg = dc.prtl_Languages.Single(xx => xx.LCID == Page.RouteData.Values["lang"].ToString()).Lang_Id;
            //    var s =
            //       Page.Server.HtmlDecode( dc.prtl_Articles_Translations.SingleOrDefault(
            //            xx => xx.Article_ID == 80).Actual_Content);
            //var x = (from c in dc.prtl_Articles_Translations
            //         where c.Lang_Id == langg && c.prtl_Article.Owner_ID == URLBuilder.CurrentOwnerid(Page.RouteData)
            //         select new {ID=c.Article_ID,
            //                     Body = dc.HighLightSearch(Page.Server.HtmlDecode(c.Actual_Content), TextBox1.Text,
            //                               "font-weight:bold; background-color:green", 500),Title=dc.HighLightSearch(c.Title, TextBox1.Text,
            //                               "font-weight:bold; background-color:green", 100)});
            //    ListView1.DataSource = x;
            //    ListView1.DataBind();
            //}
            //else if (RadioButtonList1.SelectedValue == "2")
            //{
            //    ListView1.Items.Clear();
            //    //ListView1.DataSource = Prtl_SearchUtility.SearchNews(TextBox1.Text,
            //    //                                                         Page.RouteData.Values["lang"].ToString(),
            //    //                                                         URLBuilder.CurrentOwnerid(Page.RouteData));
            //    //ListView1.DataBind();

            //                var dc = new PortalDataContextDataContext()
            //var langg = dc.prtl_Languages.Single(xx => xx.LCID == Page.RouteData.Values["lang"].ToString()).Lang_Id;
            //var x = (from c in dc.prtl_News_Translations
            //         where c.Lang_Id == langg && c.prtl_New.Owner_ID == URLBuilder.CurrentOwnerid(Page.RouteData)
            //         select new
            //         {
            //             ID = c.News_Id,
            //             Body = dc.HighLightSearch(Page.Server.HtmlDecode(c.News_Body), TextBox1.Text,
            //                 "font-weight:bold; background-color:green", 500),
            //             Title = dc.HighLightSearch(c.News_Head, TextBox1.Text,
            //                 "font-weight:bold; background-color:green", 100)
            //         });
            //    ListView1.DataSource = x;
            //    ListView1.DataBind();
            //}
       
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
            //ListView r = (ListView)Editor_DetailsView.FindControl("ListView1");
            //r.Items.Clear();
            //r.DataSource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(DropDownList1.SelectedValue), Page); ;

            //r.DataBind();
            GridView GridView1 = (GridView)Editor_DetailsView1.FindControl("GridView1");

            GridView1.DataSource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(DropDownList1.SelectedValue), Page);
            ;

            GridView1.DataBind();

        }
        public bool checkuser()
        {
            return Page.User.Identity.Name.ToLower() == StaticUtilities.Superadmin;
        }
        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var datasource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(FacDropDownList.SelectedValue), Page);
            AbstractListView.DataSource = datasource;
            AbstractListView.DataBind();
            //LinkButton InsertLinkButton = (LinkButton)AbstractListView.FindControl("InsertLinkButton");

            //Label Label1 = (Label)AbstractListView.FindControl("Label1");

            //Label1.Visible = InsertLinkButton.Visible = x;
        }


        protected string FileAbstractUrl(object staffid)
        {
            // HiddenField y = (HiddenField) AbstractListView.FindControl("staffid");
            return URLBuilder.GetURLIfExists2(Page, SiteFolders.Abstracts,
                                              Prtl_OwnersUtility.GetStaffAbstractFromPortal(Convert.ToDecimal(staffid)) +
                                              "");
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
            ;

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
                    if (memberid != null)
                        Prtl_AbstractsUtility.UpdateStaffAbstractFiles(Convert.ToDecimal(memberid), filename);
                }
            }
        }


        protected void uploadedcomplete(object sender, AsyncFileUploadEventArgs e)
        {
            string s = e.FileName;
        }
      

        //protected void InsertButtonClicked(object sender, EventArgs e)
        //{
        //    string filename = StaticUtilities.UploadFile(Editor_DetailsView1, "AsyncFileUpload1",
        //                                                     SiteFolders.Abstracts);
        //}

       
       
    }
}