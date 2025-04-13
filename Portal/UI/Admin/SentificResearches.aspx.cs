using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.BLL.Portal_BLL;
using Portal_DAL;
using MisBLL;

namespace MnfUniversity_Portals.UI
{
    public partial class SentificResearches : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {




                if (!IsPostBack)
                {
                    //Prtl_UsersUtility.updateuser();

                    var dc=new PortalDataContextDataContext ();
                    Guid x = URLBuilder.CurrentOwnerid(Page.RouteData);
                       int  c=(from d in dc.prtl_Owners where d.Owner_ID ==x select d.Type ).SingleOrDefault ();

                    if (c !=3)
                    {
                        panelsss.Visible =true ;
                        Label9.Visible = false;
                        AsyncFileUpload1.Visible = false;
                    var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
                    var DepAbbr = URLBuilder.CurrentDepAbbr(Page.RouteData);
                    if (FacAbbr == null)
                    {
                        FacDropDownList00.Items.Clear();
                        FacDropDownList00.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
                    }
                    else
                    {
                        decimal id = Prtl_OwnersUtility.getFacIDByAbbr(FacAbbr);
                        FacDropDownList00.SelectedValue = id.ToString();
                        FacDropDownList00.DataBind();
                        FacDropDownList00.Enabled = false;
                        var datasource = Staff_Utility.GetMembersByFac(Convert.ToDecimal(FacDropDownList00.SelectedValue),
                                                                   StaticUtilities.Currentlanguage(Page), Page);
                        ListView100.DataSource = datasource;
                        ListView100.DataBind();
                        if (Convert.ToInt32(FacDropDownList00.SelectedValue) != -1)
                        {
                            DepDropDownList00.Enabled = true;
                        }
                        DepDropDownList00.Items.Clear();
                        DepDropDownList00.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
                        DepDropDownList00.DataSource =
                            Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList00.SelectedValue),
                                                         StaticUtilities.Currentlanguage(Page));
                        DepDropDownList00.DataTextField = "DepName";
                        DepDropDownList00.DataValueField = "ID";
                        DepDropDownList00.DataBind();
                    }
                    }else
                    {
                        Label9.Visible = true ;
                        AsyncFileUpload1.Visible = true ;
                        panelsss.Visible =false ;
                    }
                }
            }
        }
        protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            ListView100.SelectedIndex = e.NewSelectedIndex;

            string pid = ListView100.SelectedDataKey.Value.ToString();

            //string pid = ListView1.DataKeys[e.NewSelectedIndex].Value.ToString();

           // Label1.Text = "Selected Product ID: " + pid;

            //BindData();

            var dc = new PortalDataContextDataContext();
            Guid x =Prtl_OwnersUtility.GetOwnerIDByAbbr(pid );
            int c = (from d in dc.prtl_Owners where d.Owner_ID == x select d.ID ).SingleOrDefault();

            Session["newStaffID"] = c;
            panelaaaa.Visible = true;
        } 
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Guid x = Prtl_OwnersUtility.GetOwnerIDByAbbr(pid);
            var dc = new PortalDataContextDataContext();
            Guid xx = URLBuilder.CurrentOwnerid(Page.RouteData);
            int c = (from d in dc.prtl_Owners where d.Owner_ID == xx select d.ID).SingleOrDefault();

           // int id = Convert.ToInt32(Session["newStaffID"]);
            int id = c;
           int x=   prtl_SecResUtillity.Insert_Stf_Research_Fields(id, txtName.Text, txtCoOuther.Text, txtTitle.Text,
                txtJour.Text, txtVloum.Text, txtNum.Text, txtPagen.Text, txtyear.Text,txtAbstar .Text ,txtAbsten.Text ,  id.ToString( ));


            txtName.Text = "";
            txtCoOuther.Text = "";
            txtTitle.Text = "";
            txtJour.Text = "";
            txtVloum.Text = "";
            txtNum.Text = "";
            txtPagen.Text = "";
            txtyear.Text = "";
            txtAbstar.Text = "";
            txtAbsten.Text = "";

            if (x !=0)
            {

                if (AsyncFileUpload1.HasFile)
                {
                    URLBuilder.GetURLIfExists2(Page, SiteFolders.SentficResearches, AsyncFileUpload1.PostedFile.FileName);
               
                    
                    string z=    StaticUtilities.UploadFiles(Page, AsyncFileUpload1.PostedFile ,SiteFolders.SentficResearches);       
                    //string z = StaticUtilities.UploadFileswithRename(Page, AsyncFileUpload1.PostedFile, SiteFolders.SentficResearches,x.ToString());       
                 
    
                }
            }

            string Where = "Staff_ID ==@StaffID";
            LinqDataSource1.WhereParameters.Add("StaffID",DbType.Int32, id.ToString( ));
          
            LinqDataSource1.Where = Where;
            LinqDataSource1.DataBind();

            GridView1.DataSource = LinqDataSource1;
            GridView1.DataBind();

            Session["datasource"] = LinqDataSource1;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
       {
        //To display the user info in the detailsview in editing mode.
        try
        {

            if (GridView1.SelectedDataKey != null)
            {
                int g =Convert .ToInt32(  GridView1.SelectedDataKey.Value);

                   var dc = new PortalDataContextDataContext();
                List<Prtl_SecntificResearch> xx = (from x in dc.Prtl_SecntificResearches where x.ID   == g select x).ToList();
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.Visible = true;
              //  DetailsView1.Fields[1].Visible = true;
                DetailsView1.DataSource = xx;
                DetailsView1.DataBind();
            }
        }
        catch
        {
        }
    }
        public void GetUrl(object id)
        {
            
         
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            //if (GridView1.SelectedDataKey != null)
            //{
            Button Button1 = (Button)GridView1.FindControl("Button1");

                var dc = new PortalDataContextDataContext();
                List<Prtl_SecntificResearch> xx =
                    (from x in dc.Prtl_SecntificResearches where x.ID == Convert .ToInt32( Button1.CommandArgument)  select x).ToList();
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.Visible = true;
                //  DetailsView1.Fields[1].Visible = true;
                DetailsView1.DataSource = xx;
                DetailsView1.DataBind();
            }
        //}
        protected void Details_OnClick(object sender, EventArgs e)
        {
             
            LinkButton btnButton = sender as LinkButton;
            GridViewRow gvRow = (GridViewRow)btnButton.NamingContainer;
            LinkButton Details = (LinkButton) gvRow.FindControl("Details");   
               
            
            
            var dc = new PortalDataContextDataContext();
                List<Prtl_SecntificResearch> xx =(from x in dc.Prtl_SecntificResearches where x.ID ==Convert .ToInt32( Details .CommandArgument) select x).ToList();
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.Visible = true;
                //  DetailsView1.Fields[1].Visible = true;
                DetailsView1.DataSource = xx;
                DetailsView1.DataBind();
          //  }
        }

         protected void LinkButton4_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Visible = false;
        }
        catch
        {
        }
    }

   

    #region update user

    protected void btnmodfy_Click(object sender, EventArgs e)
    {
        try
        {
            int labelID =Convert .ToInt32(  DetailsView1.GetControl<Label >("labelID").Text );
           string  txtAuthorName = DetailsView1.GetControl<TextBox>("txtAuthorName").Text ;
           string txtCo_Authors = DetailsView1.GetControl<TextBox>("txtCo_Authors").Text ;
           string txtTitle = DetailsView1.GetControl<TextBox>("txtTitle").Text ;
              string  txtJournal = DetailsView1.GetControl<TextBox>("txtJournal").Text ;
              string  txtVolume = DetailsView1.GetControl<TextBox>("txtVolume").Text ;

              string  txtNumber = DetailsView1.GetControl<TextBox>("txtNumber").Text ;

              string txtpageNum = DetailsView1.GetControl<TextBox>("txtpageNum").Text ;

              string txtYear = DetailsView1.GetControl<TextBox>("txtYear").Text ;
              string absa = DetailsView1.GetControl<TextBox>("txtabstract_ar").Text;

              string abse = DetailsView1.GetControl<TextBox>("txtabstract_en").Text;
            
            var AsyncFileUpload1 = DetailsView1.GetControl<AsyncFileUpload>("AsyncFileUpload1");

            prtl_SecResUtillity.Update(labelID, txtAuthorName, txtCo_Authors, txtTitle, txtJournal, txtVolume, txtNumber, txtpageNum, txtYear,absa ,abse );
            DetailsView1.Visible = false;
            GridView1.DataSource = Session["datasource"] ;
            GridView1.DataBind();
             
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    #endregion update user

    #region cancel edit

    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Visible = false;
        }
        catch
        {
        }
    }

    #endregion cancel edit

        protected void GridView1_OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView1.PageIndex = e.NewSelectedIndex ;
           // GridView1.SelectedIndex = e.NewSelectedIndex;
            GridView1.DataSource = Session["datasource"];
            GridView1.DataBind();
        }


          

        /************************/
        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataPager pager = ListView100.FindControl("DataPager1") as DataPager;
                if (pager != null)
                {
                    //pager.PageSize = pager.TotalRowCount;
                    pager.PageSize = 20;
                    pager.SetPageProperties(0 * pager.PageSize, pager.MaximumRows, true);
                }
            }
        }
        protected void Button1_Click00(object sender, EventArgs e)
        {
            //not select any condition
            if (FacDropDownList00.SelectedValue == "-1" && DepDropDownList00.SelectedValue == "-1" && TextBox100.Text == "")
            {
            }

                //search by faculty only
            else if (FacDropDownList00.SelectedValue != "-1" && DepDropDownList00.SelectedValue == "-1" && TextBox100.Text == "")
            {
                var datasource = Staff_Utility.GetMembersByFac(Convert.ToDecimal(FacDropDownList00.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);

                ListView100.DataSource = datasource;
                ListView100.DataBind();
            }
            //search by faculty and department
            else if (FacDropDownList00.SelectedValue != "-1" && DepDropDownList00.SelectedValue != "-1" &&
                     TextBox100.Text == "")
            {
                var datasource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList00.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);

                ListView100.DataSource = datasource;
                ListView100.DataBind();
            }

                //search by faculty & name
            else if (FacDropDownList00.SelectedValue != "-1" && DepDropDownList00.SelectedValue == "-1" &&
                     TextBox100.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByFacAndName(Convert.ToDecimal(FacDropDownList00.SelectedValue),
                                                         StaticUtilities.Currentlanguage(Page),
                                                         TextBox100.Text.Trim(), Page);

                ListView100.DataSource = datasource;
                ListView100.DataBind();
            }
            //search by faculty and department and name
            else if (FacDropDownList00.SelectedValue != "-1" && DepDropDownList00.SelectedValue != "-1" &&
                     TextBox100.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByDepAndName(
                        Convert.ToDecimal(DepDropDownList00.SelectedValue),
                        StaticUtilities.Currentlanguage(Page), TextBox100.Text.Trim(), Page);

                ListView100.DataSource = datasource;
                ListView100.DataBind();
            }


                //search by name only
            else if (FacDropDownList00.SelectedValue == "-1" && DepDropDownList00.SelectedValue == "-1" &&
                     TextBox100.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByName(StaticUtilities.Currentlanguage(Page),
                                                   TextBox100.Text.Trim(), Page);

                ListView100.DataSource = datasource;
                ListView100.DataBind();
            }
        }



        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList00.SelectedValue) != -1)
            {
                DepDropDownList00.Enabled = true;
            }
            DepDropDownList00.Items.Clear();
            DepDropDownList00.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList00.DataSource = Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList00.SelectedValue),
                                                                      StaticUtilities.Currentlanguage(Page));

            DepDropDownList00.DataBind();
        }



        //protected void Page_Load(object sender, EventArgs e)
        //{


        //    // StaffUsers_Utility.InsertNewStaffMembers(Page);
        //    //this. DataBind();
        //    // DataList1.DataBind();
        //    if (!IsPostBack)
        //    {
        //        //Prtl_UsersUtility.updateuser();
        //        var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
        //        var DepAbbr = URLBuilder.CurrentDepAbbr(Page.RouteData);
        //        if (FacAbbr == null)
        //        {
        //            FacDropDownList00.Items.Clear();
        //            FacDropDownList00.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
        //        }
        //        else
        //        {
        //            decimal id = Prtl_OwnersUtility.getFacIDByAbbr(FacAbbr);
        //            FacDropDownList00.SelectedValue = id.ToString();
        //            FacDropDownList00.DataBind();
        //            FacDropDownList00.Enabled = false;
        //            var datasource = Staff_Utility.GetMembersByFac(Convert.ToDecimal(FacDropDownList00.SelectedValue),
        //                                                       StaticUtilities.Currentlanguage(Page), Page);
        //            ListView100.DataSource = datasource;
        //            ListView100.DataBind();
        //            if (Convert.ToInt32(FacDropDownList00.SelectedValue) != -1)
        //            {
        //                DepDropDownList00.Enabled = true;
        //            }
        //            DepDropDownList00.Items.Clear();
        //            DepDropDownList00.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
        //            DepDropDownList00.DataSource =
        //                Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList00.SelectedValue),
        //                                             StaticUtilities.Currentlanguage(Page));
        //            DepDropDownList00.DataTextField = "DepName";
        //            DepDropDownList00.DataValueField = "ID";
        //            DepDropDownList00.DataBind();
        //        }


        //        //if (DepAbbr != null)
        //        //{

        //        //    decimal depid = Prtl_OwnersUtility.getDepIDByAbbr(FacAbbr, DepAbbr);
        //        //    DepDropDownList.SelectedValue = depid.ToString();
        //        //    DepDropDownList.DataBind();
        //        //    DepDropDownList.Enabled = false;
        //        //}

        //    }


        //}

        protected string StaffUrl(string abbr)
        {
            return "http://" + Request.Url.Authority + "/" + abbr + "/StaffDetails/1/" + StaticUtilities.Currentlanguage(Page);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           // LinkButton btn = (LinkButton)(sender);
           // string ID = btn.CommandArgument;


           ////  string Where = "ID ==@StaffID";
           //// LinqDataSource1.WhereParameters.Add("StaffID", DbType.Int32,ID );


           //// GridView1.DataSource = LinqDataSource1;
           ////     GridView1.DataBind();
           ////     Session["datasource"] = LinqDataSource1;

           // Session["StaffID"] = ID;
           // ffffffff.Visible = true;
           //// UpdatePanel1.Visible = true;

        }


       
    }
    
   
}