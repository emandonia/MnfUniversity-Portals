using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using Mis_DAL;
using MnfUniversity_Portals.BLL.MIS_BLL;
using MnfUniversity_Portals.BLL.Portal_BLL;

namespace MnfUniversity_Portals.UI
{
    public partial class Researches : PageBase
    {



        
        protected void Page_Load(object sender, EventArgs e)
        {
            //string abbr = URLBuilder.CurrentFacAbbr(RouteData);


            if (!IsPostBack)
            {
                var datasource = ResearchUtility.GetAllResearches();
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
        }



        

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            //search without filter
            if (DropDownList1.SelectedValue == "-1" && TextBox1.Text == "" && TextBox2.Text == "")
            {
                
                var datasource = ResearchUtility.GetAllResearches();
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string) GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
                // fac only
            else if (DropDownList1.SelectedValue != "-1" && TextBox1.Text == "" && TextBox2.Text == "")
            {
                var datasource = ResearchUtility.GetResearchByFacId(Convert.ToDecimal(DropDownList1.SelectedValue));
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
                // title only
            else if (DropDownList1.SelectedValue == "-1" && TextBox1.Text != "" && TextBox2.Text == "")
            {
                var datasource = ResearchUtility.GetResearchByTitle(TextBox1.Text);
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
            // author only
            else if (DropDownList1.SelectedValue == "-1" && TextBox1.Text == "" && TextBox2.Text != "")
            {
                var datasource = ResearchUtility.GetResearchByAuthor(TextBox2.Text);
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
                // fac & title
            else if (DropDownList1.SelectedValue != "-1" && TextBox1.Text != "" && TextBox2.Text == "")
            {
                var datasource = ResearchUtility.GetResearchByTitlefac(TextBox1.Text, Convert.ToDecimal(DropDownList1.SelectedValue));
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
            // fac & author
            else if (DropDownList1.SelectedValue != "-1" && TextBox1.Text == "" && TextBox2.Text != "")
            {
                var datasource = ResearchUtility.GetResearchByAuthorfac(TextBox2.Text, Convert.ToDecimal(DropDownList1.SelectedValue));
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
            // title & author
            else if (DropDownList1.SelectedValue == "-1" && TextBox1.Text != "" && TextBox2.Text != "")
            {
                var datasource = ResearchUtility.GetResearchByTitleAuthor(TextBox1.Text, TextBox2.Text);
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
            // fac & title & author
            else if (DropDownList1.SelectedValue != "-1" && TextBox1.Text != "" && TextBox2.Text != "")
            {
                var datasource = ResearchUtility.GetResearchByTitlefacAuthor(TextBox1.Text, Convert.ToDecimal(DropDownList1.SelectedValue), TextBox2.Text);
                Session["datasource"] = datasource;
                ListView1.DataSource = datasource;
                ListView1.DataBind();
                CountLbl.Text = (string)GetLocalResourceObject("Researches_Button1_OnClick_Count_is___") + datasource.Count;
            }
            
        }
        protected void ListView2_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager p = (DataPager)ListView1.FindControl("DataPager1");
            p.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ListView1.DataSource = (List<SA_RESEARCH_TEAM>)Session["datasource"];
            ListView1.DataBind();

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/Publication/ResearchField/" + StaticUtilities.Currentlanguage(Page));

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/Publication/Search_Research_Fields/" + StaticUtilities.Currentlanguage(Page));

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/Publication/ResFieldsReports/" + StaticUtilities.Currentlanguage(Page));

        }



        protected string StaffUrl(string stfid)
        {

            return "http://" + Request.Url.Authority + "/" + Prtl_OwnersUtility.getStaffAbbrFromId(stfid) + "/StaffDetails/1/" + StaticUtilities.Currentlanguage(Page);
        }



        //protected string geturl1()
        //{
        //    return "http://" + Request.Url.Authority + "/Publication/ResearchField/" + StaticUtilities.Currentlanguage(Page);
        //}

        //protected string geturl2()
        //{

        //    return "http://" + Request.Url.Authority + "/Publication/Search_Research_Fields/" + StaticUtilities.Currentlanguage(Page);
        //}


        //protected string geturl3()
        //{
        //    return "http://" + Request.Url.Authority + "/Publication/ResFieldsReports/" + StaticUtilities.Currentlanguage(Page);
        //}


    }
}