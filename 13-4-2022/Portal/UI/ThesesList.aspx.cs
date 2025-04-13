using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using MySql.Data.MySqlClient;
using MySql.Web;

namespace MnfUniversity_Portals.UI
{
    public partial class ThesesList : PageBase
    {
        protected void ListView2_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager p = (DataPager)ListView1.FindControl("DataPager1");
            p.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ListView1.DataSource = (DataTable)Session["datasource"];
            ListView1.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis;");
                ListView1.DataSource = x;
                Session["source"] = x;
                ListView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis;");
            }

        }

       

        
       
        
        public static string GetFacName(Object facid)
        {

           return prtl_ThesisUtility.StaticQuery1("select name from publications.jos_jresearch_research_area where id =" + Convert.ToInt32(facid) + ";");

           
        }
        protected void SearchButtonClicked(object sender, EventArgs e)
        {
            //faculty only
            if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" && txtTitle.Text == "" &&  txtKeywords.Text == "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where id_research_area=" + FacDropDownList.SelectedValue + ";");
            ListView1.DataSource = x;
                Session["source"] = x;
            Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where id_research_area="+FacDropDownList.SelectedValue+";");
            ListView1.DataBind();
            }
            //degree only
            else if (DropDownList2.SelectedValue != "-1" && FacDropDownList.SelectedValue == "-1" && txtTitle.Text == "" &&  txtKeywords.Text == "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "';");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "';");
                ListView1.DataBind();
            }
            //Title only
            else if (DropDownList2.SelectedValue == "-1" && FacDropDownList.SelectedValue == "-1" && txtTitle.Text != "" &&  txtKeywords.Text == "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where title like'%" +txtTitle .Text  + "%';");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where  title like'%" + txtTitle.Text + "%';");
                ListView1.DataBind();
            }
            //keywords only
            else if (DropDownList2.SelectedValue == "-1" && FacDropDownList.SelectedValue == "-1" && txtTitle.Text == "" &&  txtKeywords.Text !="")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where description like'%" + txtKeywords.Text + "%';");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where  description like'%" + txtKeywords.Text + "%';");
                ListView1.DataBind();
            }
           
                //both faculty and degree 
            else if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" && txtTitle .Text =="" &&  txtKeywords.Text =="")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and id_research_area="+FacDropDownList.SelectedValue+" ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataBind();

                           }

                     //both faculty and title 
            else if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" && txtTitle .Text !=""&&  txtKeywords.Text =="")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where  title like '%"+txtTitle .Text+ "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where title like '%" + txtTitle.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataBind();

            }
            //both faculty and keywords 
            else if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" && txtTitle.Text == "" &&  txtKeywords.Text !="")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where  description like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where description like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataBind();

            }

//both  degree and Title
            else if (FacDropDownList.SelectedValue == "-1" && DropDownList2.SelectedValue != "-1" && txtTitle .Text !="")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and title like '%" + txtTitle.Text.Trim() + "%' ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and title like '%" + txtTitle.Text.Trim() + "%' ;");
                ListView1.DataBind();

            }
            //both  degree and keywords
            else if (FacDropDownList.SelectedValue == "-1" && DropDownList2.SelectedValue != "-1" && txtTitle.Text == "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and description like '%" + txtKeywords.Text.Trim() + "%' ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and description like '%" + txtKeywords.Text.Trim() + "%' ;");
                ListView1.DataBind();

            }
            //both  title and keywords
            else if (FacDropDownList.SelectedValue == "-1" && DropDownList2.SelectedValue == "-1" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where title like '%" + txtTitle.Text + "%' and description like '%" + txtKeywords.Text.Trim() + "%' ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis where title like '%" + txtTitle.Text + "%' and description like '%" + txtKeywords.Text.Trim() + "%' ;");
                ListView1.DataBind();

            }

            //both faculty and degree and Title
            else if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" && txtTitle.Text != "" && txtKeywords.Text == "")
            {

          
                DataTable x =  prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataSource = x;
                Session["source"] = x;
          ListView1.DataBind(); 
 Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_thesis where degree='" + DropDownList2.SelectedValue + "' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
            

            }
            //both faculty and title and keywords
            else if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                 DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where description like '%" + txtKeywords.Text + "%' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataSource = x;
                Session["source"] = x;
               ListView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_thesis where description like '%" + txtKeywords.Text + "%' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");


            }
            //both faculty and degree and keywords
            else if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" && txtTitle.Text == "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where description like '%" + txtKeywords.Text + "%' and degree ='" + DropDownList2.SelectedValue + "' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                ListView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_thesis where description like '%" + txtKeywords.Text + "%' and degree ='" + DropDownList2.SelectedValue + "' and id_research_area=" + FacDropDownList.SelectedValue + " ;");


            }
            //both degree and title and keywords
            else if (FacDropDownList.SelectedValue == "-1" && DropDownList2.SelectedValue != "-1" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where title like '%" + txtTitle.Text + "%' and degree ='" + DropDownList2.SelectedValue + "' and description like '%" + txtKeywords.Text + "%' ;");
                ListView1.DataSource = x;
                Session["source"] = x;
                ListView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_thesis where title like '%" + txtTitle.Text + "%' and degree ='" + DropDownList2.SelectedValue + "' and description like '%" + txtKeywords.Text + "%' ;");


            }  
            //both faculty and degree and title and keywords
            else if (FacDropDownList.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                 DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis where title like '%" + txtTitle.Text + "%' and degree ='" + DropDownList2.SelectedValue + "' and description like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + "  ;");
                ListView1.DataSource = x;
                Session["source"] = x;
               ListView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_thesis where title like '%" + txtTitle.Text + "%' and degree ='" + DropDownList2.SelectedValue + "' and description like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");


            }
            //not faculty and degree and title and keywords
            else if (FacDropDownList.SelectedValue == "-1" && DropDownList2.SelectedValue == "-1" && txtTitle.Text == "" && txtKeywords.Text == "")
            { DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_thesis;");
                ListView1.DataSource = x; 
                Session["source"] = x;
                ListView1.DataBind(); Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_thesis;"); 
            }
        }

        //protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    //FillGrid();
        //    ListView1.PageIndex = e.NewPageIndex;
        //    ListView1.DataSource =(DataTable) Session["source"];
        //    ListView1.DataBind();
        //}
    }
}