using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using App_Code;
using Portal_DAL;
namespace MnfUniversity_Portals.UI
{
    public partial class SGradeCouncil : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FacDropDownList.DataSource = Prtl_OwnersUtility.getFac(StaticUtilities.Currentlanguage(Page));

            FacDropDownList.DataBind();
        }
        protected void GridViewPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = Session["dataSource"];


            GridView1.DataBind();
        }
        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
            }
            DepDropDownList.Items.Clear();
            DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList.DataSource = Prtl_OwnersUtility.getDepsOfFac(Convert.ToInt32(FacDropDownList.SelectedValue), StaticUtilities.Currentlanguage(Page));

            DepDropDownList.DataTextField = "Key";
            DepDropDownList.DataValueField = "Value";


            DepDropDownList.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //To display the user info in the detailsview in editing mode.
            try
            {
                if (GridView1.SelectedDataKey != null)
                {
                    var g = (Int32)GridView1.SelectedDataKey.Value;

                    prtl_Student xx = gradeUtility.getsBID(g);
                    DetailsView1.ChangeMode(DetailsViewMode.Edit);
                    DetailsView1.Visible = true;
                    DetailsView1.Fields[1].Visible = true;
                    DetailsView1.DataSource = xx;
                    DetailsView1.DataBind();
                }
            }
            catch
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int fac = Convert.ToInt32(FacDropDownList.SelectedValue);
            int dep = Convert.ToInt32(DepDropDownList.SelectedValue);
            string n = txtName.Text;
            //get All
            if (FacDropDownList.SelectedValue == "-1" && DepDropDownList.SelectedValue == "-1" && txtName.Text == "")
            {

                GridView1.DataSource = gradeUtility.getsBu();
                GridView1.DataBind();



            }
            //get by fac and department and name
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue != "-1" && txtName.Text != "")
            {
                GridView1.DataSource = gradeUtility.getsBfdn(fac, dep, n);
                GridView1.DataBind();

                Session["dataSource"] = gradeUtility.getsBfdn(fac, dep, n);
            }//search by fac and name
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue == "-1" && txtName.Text != "")
            {
                GridView1.DataSource = gradeUtility.getsBfn(fac, n);
                GridView1.DataBind();
                Session["dataSource"] = gradeUtility.getsBfn(fac, n);
            }//search by name
            else if (FacDropDownList.SelectedValue == "-1" && DepDropDownList.SelectedValue == "-1" && txtName.Text != "")
            {
                GridView1.DataSource = gradeUtility.getsBn(n);
                GridView1.DataBind();
                Session["dataSource"] = gradeUtility.getsBn(n);
            }//by fac
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue == "-1" && txtName.Text == "")
            {
                GridView1.DataSource = gradeUtility.getsBf(fac);
                GridView1.DataBind();
                Session["dataSource"] = gradeUtility.getsBf(fac);
            }//by fac and depaertment
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue != "-1" && txtName.Text == "")
            {
                GridView1.DataSource = gradeUtility.getsBfd(fac, dep);
                GridView1.DataBind();
                Session["dataSource"] = gradeUtility.getsBfd(fac, dep);
            }





        }

        //protected void DetailsView1_Load(object sender, EventArgs e)
        //{


        //        if (CurrentLanguage == "ar")
        //        {
        //            DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            DetailsView1.HeaderRow.Cells[1].Text = "اسم الطالب باللغة الانجليزية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //        }
        //        else
        //        {
        //            DetailsView1.HeaderRow.Cells[0].Text = "Student Name English";
        //            DetailsView1.HeaderRow.Cells[1].Text = "Student Name Arabic";
        //        }

        //}

        //protected void DetailsView1_Init(object sender, EventArgs e)
        //{

        //        if (CurrentLanguage == "ar")
        //        {
        //            DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            DetailsView1.HeaderRow.Cells[1].Text = "اسم الطالب باللغة الانجليزية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //            //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
        //        }
        //        else
        //        {
        //            DetailsView1.HeaderRow.Cells[0].Text = "Student Name English";
        //            DetailsView1.HeaderRow.Cells[1].Text = "Student Name Arabic";
        //        }

        //}

        protected void DetailsView1_DataBinding(object sender, EventArgs e)
        {


            //if (DetailsView1.CurrentMode == DetailsViewMode.Edit )
            //{

            //    if (CurrentLanguage == "ar")
            //    {
            //        //DetailsView1.HeaderText[0]  = 'c';
            //        //DetailsView1.HeaderText[1]  = "اسم الطالب باللغة الانجليزية";
            //        ////DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
            //        //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
            //        //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
            //        //DetailsView1.HeaderRow.Cells[0].Text = "اسم الطالب باللغة العربية";
            //    }
            //    else
            //    {
            //        DetailsView1. HeaderText[0]  = "Student Name English";
            //        DetailsView1.HeaderText[1] = "Student Name Arabic";
            //    }
            //}

        }


        //protected string getHeader1()
        //{
        //    if (CurrentLanguage == "ar")
        //    {
        //        return "اسم الطالب باللغة العربية";
        //    }
        //    else
        //    {
        //        return "Student Name English";
        //    }

        //}
    
    }
}