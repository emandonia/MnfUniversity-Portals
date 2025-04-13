using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MisBLL;
using System.Web.Security;
using MnfUniversity_Portals.BLL.Portal_BLL;
using Portal_DAL;

namespace MnfUniversity_Portals.UI
{
    public partial class Thesis : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // this.DataBind();
            //ListView2.Items.Clear();
            //LinqDataSource2.Where = "Faculty == " + DropDownList1.SelectedValue;
            //ListView2.DataSource = LinqDataSource2;
            //ListView2.DataBind();
            // 
            //   this.DataBind();
            
            if (!IsPostBack)
            {
                var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);

                if (FacAbbr == null)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
                }
                else
                {
                    string s = Prtl_OwnersUtility.getSPapersFacIDByAbbr(FacAbbr);
                    DropDownList1.SelectedValue = s;
                    DropDownList1.DataBind();
                    DropDownList1.Enabled = false;

                }
            }
            //InsertLinkButton.DataBind();
            //Label2.DataBind();
            ////if(!IsPostBack)
  

            //{
            //    InsertLinkButton.Visible = false;


            //}
        }



        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
            var Linkbutton = (LinkButton) sender;



            var ds = Prtl_SCPapersUtility.GetSCPaperByPaperId(Convert.ToInt32(Linkbutton.CommandArgument), Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);
                Editor_DetailsView.DataSource = ds;
                Editor_DetailsView.DataBind();
                Editor_ModalPopupExtender.Show();
            
        }



        #region search button
        protected void SearchButtonClicked(object sender, EventArgs e)
        {

            //faculty only
            if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" &&
                DropDownList3.SelectedValue == "-1")
            {
                ListView2.Items.Clear();
                ListView2.DataBind();
                string Where = "Prtl_Thesi.Owner_ID ==@owner and Lang_Id==@lang";
                LinqDataSource2.WhereParameters.Add("owner", DbType.Guid, DropDownList1.SelectedValue);
                LinqDataSource2.WhereParameters.Add("lang", DbType.Int32, Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id.ToString());
                LinqDataSource2.Where = Where;
                LinqDataSource2.DataBind();
                Session["datasource"] = LinqDataSource2;
                ListView2.DataSource = LinqDataSource2;
                ListView2.DataBind();
                //Session["test"] = LinqDataSource2;
                Label10.Text = (string) GetLocalResourceObject("Papers") + " " +
                               Prtl_SCPapersUtility.GetPapersCountByFacorDegOrSearchType(
                                   Guid.Parse(DropDownList1.SelectedValue), null, null, Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);
            }
                //degree only
            else if (DropDownList2.SelectedValue != "-1" && DropDownList1.SelectedValue == "-1" &&
                     DropDownList3.SelectedValue == "-1")
            {
                ListView2.Items.Clear();
                LinqDataSource2.Where = "Prtl_Thesi.StudyTypee == " + Convert.ToBoolean(DropDownList2.SelectedValue)
                    + " and Lang_Id==" + Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id.ToString();
                Session["datasource"] = LinqDataSource2;
                ListView2.DataSource = LinqDataSource2;
                ListView2.DataBind();
               
                Label10.Text = (string)GetLocalResourceObject("Papers") + " " +
                               Prtl_SCPapersUtility.GetPapersCountByFacorDegOrSearchType(null,
                                   Convert.ToBoolean(DropDownList2.SelectedValue), null, Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);

            }
            //    //Search Type only
            else if (DropDownList2.SelectedValue == "-1" && DropDownList1.SelectedValue == "-1" &&
                     DropDownList3.SelectedValue != "-1")
            {
                ListView2.Items.Clear();

                LinqDataSource2.Where = "Prtl_Thesi.ResearchType == " + Convert.ToBoolean(DropDownList3.SelectedValue)
                    + " and Lang_Id==" + Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id.ToString();
                Session["datasource"] = LinqDataSource2;
                ListView2.DataSource = LinqDataSource2;
                    ListView2.DataBind();
                   
                    Label10.Text = (string) GetLocalResourceObject("Papers") + " " +
                                   Prtl_SCPapersUtility.GetPapersCountByFacorDegOrSearchType(null,null,
                                       Convert.ToBoolean(DropDownList3.SelectedValue), Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);
                

            }
               //both faculty and degree
            else if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" &&
                     DropDownList3.SelectedValue == "-1")
            {
                ListView2.Items.Clear();
                ListView2.DataBind();

                string Where = "Prtl_Thesi.StudyTypee == @studytype and  Prtl_Thesi.Owner_ID == @owner  and Lang_Id==@lang";
                                          
                LinqDataSource2.WhereParameters.Add("owner", DbType.Guid, DropDownList1.SelectedValue);
                LinqDataSource2.WhereParameters.Add("studytype", DbType.Boolean, DropDownList2.SelectedValue);
                LinqDataSource2.WhereParameters.Add("lang", DbType.Int32, Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id.ToString());

                LinqDataSource2.Where = Where;
                LinqDataSource2.DataBind();
                //Session["datasource"] = LinqDataSource2;
                //LinqDataSource2.Where = "Prtl_Thesi.StudyTypee == " + Convert.ToBoolean(DropDownList2.SelectedValue) + "&& Prtl_Thesi.Owner_ID == " +
                //                        Guid.Parse(DropDownList1.SelectedValue);
                ListView2.DataSource = LinqDataSource2;
                
                ListView2.DataBind();
                Label10.Text = (string)GetLocalResourceObject("Papers") + " " +
                               Prtl_SCPapersUtility.GetPapersCountByFacorDegOrSearchType(
                                  Guid.Parse( DropDownList1.SelectedValue),
                                   Convert.ToBoolean(DropDownList2.SelectedValue), null, Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);
            }
            //    //fac & search type
            else if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" &&
                     DropDownList3.SelectedValue != "-1")
            {
                
                    ListView2.Items.Clear();
                    string Where = " Prtl_Thesi.Owner_ID == @owner and Prtl_Thesi.ResearchType == @ResearchType and Lang_Id==@lang";
                                            
                    LinqDataSource2.WhereParameters.Add("owner", DbType.Guid, DropDownList1.SelectedValue);
                    LinqDataSource2.WhereParameters.Add("ResearchType", DbType.Boolean, DropDownList3.SelectedValue);
                    LinqDataSource2.WhereParameters.Add("lang", DbType.Int32, Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id.ToString());

                LinqDataSource2.Where = Where;
                LinqDataSource2.DataBind();
                Session["datasource"] = LinqDataSource2;
                    //LinqDataSource2.Where = " Prtl_Thesi.Owner_ID == " + Guid.Parse(DropDownList1.SelectedValue) + "&& Prtl_Thesi.ResearchType == " +
                    //                    Convert.ToBoolean(DropDownList3.SelectedValue);
                    ListView2.DataSource = LinqDataSource2;
                   
                    ListView2.DataBind();
                    Label10.Text = (string)GetLocalResourceObject("Papers") + " " +
                                   Prtl_SCPapersUtility.GetPapersCountByFacorDegOrSearchType(
                                      Guid.Parse(DropDownList1.SelectedValue),null,
                                       Convert.ToBoolean(DropDownList3.SelectedValue), Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);
              
            }
               //deg & search type
            else if (DropDownList1.SelectedValue == "-1" && DropDownList2.SelectedValue != "-1" &&
                     DropDownList3.SelectedValue != "-1")
            {
                
                    ListView2.Items.Clear();
                    LinqDataSource2.Where = " Prtl_Thesi.StudyTypee == " + Convert.ToBoolean(DropDownList2.SelectedValue) + "&& Prtl_Thesi.ResearchType == " +
                                        Convert.ToBoolean(DropDownList3.SelectedValue) + " and Lang_Id==" + Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id.ToString();
                    Session["datasource"] = LinqDataSource2;
                ListView2.DataSource = LinqDataSource2;
                    
                    ListView2.DataBind();
                    Label10.Text = (string) GetLocalResourceObject("Papers") + " " +
                                   Prtl_SCPapersUtility.GetPapersCountByFacorDegOrSearchType(null,
                                       Convert.ToBoolean(DropDownList2.SelectedValue),
                                       Convert.ToBoolean(DropDownList3.SelectedValue), Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);

            } 
            //deg & search type & fac
            else if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" &&
                     DropDownList3.SelectedValue != "-1")
            {
                
                    ListView2.Items.Clear();
                    string Where = " Prtl_Thesi.StudyTypee == @StudyTypee and Prtl_Thesi.Owner_ID ==@owner and Prtl_Thesi.ResearchType ==@ResearchType and Lang_Id==@lang";
                    LinqDataSource2.WhereParameters.Add("owner", DbType.Guid, DropDownList1.SelectedValue);
                    LinqDataSource2.WhereParameters.Add("StudyTypee", DbType.Boolean, DropDownList2.SelectedValue);
                    LinqDataSource2.WhereParameters.Add("ResearchType", DbType.Boolean, DropDownList3.SelectedValue);
                    LinqDataSource2.WhereParameters.Add("lang", DbType.Int32, Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id.ToString());

                LinqDataSource2.Where = Where;
                LinqDataSource2.DataBind();
                Session["datasource"] = LinqDataSource2;
                    //LinqDataSource2.Where = " Prtl_Thesi.StudyTypee == " + Convert.ToBoolean(DropDownList2.SelectedValue) + "&& Prtl_Thesi.Owner_ID ==" + Guid.Parse(DropDownList1.SelectedValue) +
                    //                        "&& Prtl_Thesi.ResearchType ==" + Convert.ToBoolean(DropDownList3.SelectedValue);
                    ListView2.DataSource = LinqDataSource2;
                    
                    ListView2.DataBind();
                    Label10.Text = (string)GetLocalResourceObject("Papers") + " " +
                                   Prtl_SCPapersUtility.GetPapersCountByFacorDegOrSearchType(
                                       Guid.Parse(DropDownList1.SelectedValue),
                                       Convert.ToBoolean(DropDownList2.SelectedValue),
                                       Convert.ToBoolean(DropDownList3.SelectedValue), Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page.RouteData)).Lang_Id);
                
            }

        }
#endregion

        public string GetSUpervisors1(object eval)
        {
            return Prtl_SCPapersUtility.GetSupervisors1(eval.ToString());
        }

        public string GetSUpervisors2(object eval)
        {
            return Prtl_SCPapersUtility.GetSupervisors2(eval.ToString());
        }

        public string InsertImageURL
        {
            get { return ViewState["InsertImageURL"].ToString(); }
            set { ViewState["InsertImageURL"] = value; }
        }
         
        //public bool checkuser()
        //{

        //    return Page.User.Identity.Name.ToLower() == StaticUtilities.Superadmin;

        //    InsertLinkButton.DataBind();
        //    Label2.DataBind();

        //}


        



        //protected void getallresults(object sender, ListViewSelectEventArgs e)
        //{
        //    // DataPager p = (DataPager) ListView2.FindControl("DataPager1");
        //    ListView2.SelectedIndex = e.NewSelectedIndex;
        //        ListView2.DataSource = test;
        //    ListView2.DataBind();
        //}

        protected void getallresults2(object sender, EventArgs e)
        {
            ListView2.DataSource = (LinqDataSource) Session["test"];
            ListView2.DataBind();
        }

        

        protected object ThesisFile(object eval)
        {
            return URLBuilder.ImageURLBase + "/uni/Portal/Thesis/" +
                   prtl_ThesisUtility.GetThesisFile(Convert.ToInt32(eval));
        }


        protected void ListView2_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
           DataPager p=(DataPager) ListView2.FindControl("DataPager1");
            p.SetPageProperties(e.StartRowIndex,e.MaximumRows,false);
            ListView2.DataSource = (LinqDataSource)Session["datasource"] ;
            ListView2.DataBind();
            
        }

        //protected void ListView2_OnDataBinding(object sender, EventArgs e)
        //{
        //    ListView2.DataSource = (LinqDataSource)Session["datasource"];
        //    ListView2.DataBind();
        //}

      
    }

}