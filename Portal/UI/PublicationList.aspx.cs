using System;
using System.Collections.Generic;
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
    public partial class PublicationList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication;");
                GridView1.DataSource = x;
                Session["source"] = x;
                GridView1.DataBind();
                Label2.Text = "Count is: " +
                              prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication;");
            }
        }

        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)Session["source"];
            GridView1.DataBind();
        }

        protected void SearchButtonClicked(object sender, EventArgs e)
        {
            //faculty only
            if (FacDropDownList.SelectedValue != "-1" && txtTitle.Text == "" && txtKeywords.Text == "" && txtAuthorName.Text == "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where id_research_area=" + FacDropDownList.SelectedValue + ";");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where id_research_area=" + FacDropDownList.SelectedValue + ";");
                GridView1.DataBind();
            }
            //Author Name only
            else if (txtAuthorName.Text != "" && FacDropDownList.SelectedValue == "-1" && txtTitle.Text == "" && txtKeywords.Text == "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where degree='" + txtAuthorName + "';");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication  where degree='" + txtAuthorName.Text + "';");
                GridView1.DataBind();
            }
            //Title only
            else if (txtAuthorName.Text == "" && FacDropDownList.SelectedValue == "-1" && txtTitle.Text != "" && txtKeywords.Text == "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where title like'%" + txtTitle.Text + "%';");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where  title like'%" + txtTitle.Text + "%';");
                GridView1.DataBind();
            }
            //keywords only
            else if (txtAuthorName.Text == "" && FacDropDownList.SelectedValue == "-1" && txtTitle.Text == "" && txtKeywords.Text != "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where description like'%" + txtKeywords.Text + "%';");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where  description like'%" + txtKeywords.Text + "%';");
                GridView1.DataBind();
            }

                //both faculty and author name 
            else if (FacDropDownList.SelectedValue != "-1" && txtAuthorName.Text != "" && txtTitle.Text == "" && txtKeywords.Text == "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataBind();

            }

                     //both faculty and title 
            else if (FacDropDownList.SelectedValue != "-1" && txtAuthorName.Text == "" && txtTitle.Text != "" && txtKeywords.Text == "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where  title like '%" + txtTitle.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where title like '%" + txtTitle.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataBind();

            }
            //both faculty and keywords 
            else if (FacDropDownList.SelectedValue != "-1" && txtAuthorName.Text == "" && txtTitle.Text == "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where  abstract like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where abstract like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataBind();

            }

//both  degree and Title
            else if (FacDropDownList.SelectedValue == "-1" && txtAuthorName.Text != "" && txtTitle.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and title like '%" + txtTitle.Text.Trim() + "%' ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and title like '%" + txtTitle.Text.Trim() + "%' ;");
                GridView1.DataBind();

            }
            //both  degree and keywords
            else if (FacDropDownList.SelectedValue == "-1" && txtAuthorName.Text != "" && txtTitle.Text == "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and abstrcat like '%" + txtKeywords.Text.Trim() + "%' ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and abstract like '%" + txtKeywords.Text.Trim() + "%' ;");
                GridView1.DataBind();

            }
            //both  title and keywords
            else if (FacDropDownList.SelectedValue == "-1" && txtAuthorName.Text == "" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where title like '%" + txtTitle.Text + "%' and abstract like '%" + txtKeywords.Text.Trim() + "%' ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication where title like '%" + txtTitle.Text + "%' and abstract like '%" + txtKeywords.Text.Trim() + "%' ;");
                GridView1.DataBind();

            }

            //both faculty and degree and Title
            else if (FacDropDownList.SelectedValue != "-1" && txtAuthorName.Text != "" && txtTitle.Text != "" && txtKeywords.Text == "")
            {


                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                GridView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_publication where degree='" + txtAuthorName.Text + "' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");


            }
            //both faculty and title and keywords
            else if (FacDropDownList.SelectedValue != "-1" && txtAuthorName.Text == "" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where abstract like '%" + txtKeywords.Text + "%' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                GridView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_publication where abstract like '%" + txtKeywords.Text + "%' and title like '%" + txtTitle.Text.Trim() + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");


            }
            //both faculty and degree and keywords
            else if (FacDropDownList.SelectedValue != "-1" && txtAuthorName.Text != "" && txtTitle.Text == "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where abstract like '%" + txtKeywords.Text + "%' and degree ='" + txtAuthorName.Text + "' and id_research_area=" + FacDropDownList.SelectedValue + " ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                GridView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_publication where abstract like '%" + txtKeywords.Text + "%' and degree ='" + txtAuthorName.Text + "' and id_research_area=" + FacDropDownList.SelectedValue + " ;");


            }
            //both degree and title and keywords
            else if (FacDropDownList.SelectedValue == "-1" && txtAuthorName.Text != "" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where title like '%" + txtTitle.Text + "%' and degree ='" + txtAuthorName.Text + "' and description like '%" + txtKeywords.Text + "%' ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                GridView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_publication where title like '%" + txtTitle.Text + "%' and degree ='" + txtAuthorName.Text + "' and description like '%" + txtKeywords.Text + "%' ;");


            }
            //both faculty and degree and title and keywords
            else if (FacDropDownList.SelectedValue != "-1" && txtAuthorName.Text  != "" && txtTitle.Text != "" && txtKeywords.Text != "")
            {

                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication where title like '%" + txtTitle.Text + "%' and degree ='" + txtAuthorName.Text + "' and abstract like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + "  ;");
                GridView1.DataSource = x;
                Session["source"] = x;
                GridView1.DataBind();
                Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*)  from publications.jos_jresearch_publication where title like '%" + txtTitle.Text + "%' and degree ='" + txtAuthorName.Text + "' and abstract like '%" + txtKeywords.Text + "%' and id_research_area=" + FacDropDownList.SelectedValue + " ;");


            }
            //not faculty and degree and title and keywords
            else if (FacDropDownList.SelectedValue == "-1" && txtAuthorName.Text == "" && txtTitle.Text == "" && txtKeywords.Text == "")
            {
                DataTable x = prtl_ThesisUtility.Query("select * from publications.jos_jresearch_publication;");
                GridView1.DataSource = x;
                Session["source"] = x;
                GridView1.DataBind(); Label2.Text = "Count is: " + prtl_ThesisUtility.CountRaws("SELECT COUNT(*) FROM publications.jos_jresearch_publication;");
            }
        }

        protected string GetAuthorsByPublicationID(int p_id)
        {
            return prtl_ThesisUtility.StaticQuery2("select author_name from publications.jos_jresearch_publication_external_author where id_publication=" + p_id + " ORDER BY jos_jresearch_publication_external_author.order;");
            
        }
    }
}