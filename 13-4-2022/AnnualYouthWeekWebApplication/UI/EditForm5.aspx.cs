using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using AnnualYouthWeekWebApplication.BLL;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class EditForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["source"]) == "edit")
            {
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                LinkButton1.Visible = true;
                LinkButton2.Visible = false;
                //DropDownList at = (DropDownList)DetailsView1.FindControl("DropDownList1");
                //at.SelectedValue = StudentsUtilty.getadmintype(Convert.ToInt32(Request.QueryString["ID"]));
if (!IsPostBack)
            {
               int id= Convert.ToInt32(Request.QueryString["ID"]);
                DropDownList att = (DropDownList)DetailsView1.FindControl("DropDownList11");
                att.SelectedValue = StudentsUtilty.getcurrentyearid(id).ToString();
                DropDownList atttt = (DropDownList)DetailsView1.FindControl("DropDownList1111");
                atttt.SelectedValue = StudentsUtilty.getcurrentFieldid(id).ToString();
            }
            }
            else
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                LinkButton1.Visible = false;
                LinkButton2.Visible = true;
            }
            



        }

        protected string getgender(int id)
        {
            DropDownList att = (DropDownList)DetailsView1.FindControl("DropDownList3");
            if (StudentsUtilty.getadmingender3(id))
            {
                return "true";
            }
            else { return "false"; }
        }
        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {

            TextBox serialno = (TextBox)DetailsView1.FindControl("txtname3331");
            TextBox name = (TextBox)DetailsView1.FindControl("txtname1");
            TextBox nid = (TextBox)DetailsView1.FindControl("txtnid1");
            TextBox phno = (TextBox)DetailsView1.FindControl("txtphno1");
            TextBox bd = (TextBox)DetailsView1.FindControl("EditNewsDateTextBox");
            TextBox bp = (TextBox)DetailsView1.FindControl("txtbp1");
            TextBox add = (TextBox)DetailsView1.FindControl("txtadd1");
            TextBox em = (TextBox)DetailsView1.FindControl("txtem1");
            DropDownList aa = (DropDownList)DetailsView1.FindControl("DropDownList3");
            DropDownList at = (DropDownList)DetailsView1.FindControl("DropDownList1");
            DropDownList att = (DropDownList)DetailsView1.FindControl("DropDownList11");
            DropDownList attt = (DropDownList)DetailsView1.FindControl("DropDownList111");
            DropDownList atttt = (DropDownList)DetailsView1.FindControl("DropDownList1111");
            AsyncFileUpload aa1 = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload1");
            AsyncFileUpload aa2 = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload2");


            if (aa1.HasFile && !aa2.HasFile)
            {

                StudentsUtilty.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Request.QueryString["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(aa.SelectedValue),
                    phno.Text, add.Text, em.Text, (string)Session["pi"], null, Convert.ToInt32(at.SelectedValue), Convert.ToInt32(att.SelectedValue), Convert.ToInt32(attt.SelectedValue), Convert.ToInt32(atttt.SelectedValue));

            }
            else if (!aa1.HasFile && aa2.HasFile)
            {

                StudentsUtilty.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Request.QueryString["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(aa.SelectedValue), phno.Text, add.Text, em.Text, null, (string)Session["ni"], Convert.ToInt32(at.SelectedValue), Convert.ToInt32(att.SelectedValue), Convert.ToInt32(attt.SelectedValue), Convert.ToInt32(atttt.SelectedValue));

            }
            else if (aa1.HasFile && aa2.HasFile)
            {

                StudentsUtilty.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Request.QueryString["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(aa.SelectedValue), phno.Text, add.Text, em.Text, (string)Session["pi"], (string)Session["ni"], Convert.ToInt32(at.SelectedValue), Convert.ToInt32(att.SelectedValue), Convert.ToInt32(attt.SelectedValue), Convert.ToInt32(atttt.SelectedValue));

            }
            else
            {
                StudentsUtilty.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Request.QueryString["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(aa.SelectedValue), phno.Text, add.Text, em.Text, null, null, Convert.ToInt32(at.SelectedValue), Convert.ToInt32(att.SelectedValue), Convert.ToInt32(attt.SelectedValue), Convert.ToInt32(atttt.SelectedValue));

            }
            Response.Redirect("ControlStudents.aspx");
        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {

            staticUtility.uploadfile1(this, DetailsView1);

           
        }
       
        protected void AsyncFileUpload2_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            staticUtility.uploadfile2(this, DetailsView1);
           
        }

        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ControlStudents.aspx");
        }

        


        protected string getgender(object bind)
        {
            if (Convert.ToBoolean(bind))
            {
                return "أنثي";
            }
            else
            {
                return "ذكر";
            }
        }

      
    }
}