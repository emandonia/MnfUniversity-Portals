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
    public partial class InsertForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
            //Editor_ModalPopupExtender.Show();
        }

        protected void InsertButtonClicked(object sender, EventArgs e)
        {
            TextBox serialno = (TextBox)Editor_DetailsView1.FindControl("txtnamee");
            TextBox name = (TextBox)Editor_DetailsView1.FindControl("txtname");
            TextBox nid = (TextBox)Editor_DetailsView1.FindControl("txtnid");
            TextBox phno = (TextBox)Editor_DetailsView1.FindControl("txtphno");
            TextBox bd = (TextBox)Editor_DetailsView1.FindControl("InsertNewsDateTextBox");
            TextBox bp = (TextBox)Editor_DetailsView1.FindControl("txtbp");
            TextBox add = (TextBox)Editor_DetailsView1.FindControl("txtadd");
            TextBox em = (TextBox)Editor_DetailsView1.FindControl("txtem");
            DropDownList aa = (DropDownList)Editor_DetailsView1.FindControl("DropDownList3");
            int xx;
            if (Session["acid"] != null)
            {
                 xx = Convert.ToInt32(Session["acid"]);
            }
            else
            {
                 xx = 1;
            }
            AsyncFileUpload aa1 = (AsyncFileUpload)Editor_DetailsView1.FindControl("AsyncFileUpload1");
            AsyncFileUpload aa2 = (AsyncFileUpload)Editor_DetailsView1.FindControl("AsyncFileUpload2");

            DropDownList att = (DropDownList)Editor_DetailsView1.FindControl("DropDownList11");
            DropDownList at2t = (DropDownList)Editor_DetailsView1.FindControl("DropDownList121");
            DropDownList atttt = (DropDownList)Editor_DetailsView1.FindControl("DropDownList1111");
            if (aa1.HasFile && !aa2.HasFile)
            {
                StudentsUtilty.insertGeneralInst(serialno.Text,name.Text, nid.Text, bd.Text, Convert.ToBoolean(aa.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, (string)Session["pi"], null, Convert.ToInt32(at2t.SelectedValue), Convert.ToInt32(att.SelectedValue), xx, Convert.ToInt32(atttt.SelectedValue),
                    (int)Session["UniID"]);
            }
            else if (!aa1.HasFile && aa2.HasFile)
            {
                StudentsUtilty.insertGeneralInst(serialno.Text, name.Text, nid.Text, bd.Text, Convert.ToBoolean(aa.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, null, (string)Session["ni"], Convert.ToInt32(at2t.SelectedValue), Convert.ToInt32(att.SelectedValue), xx, Convert.ToInt32(atttt.SelectedValue),
                    (int)Session["UniID"]);
            }
            else if (aa1.HasFile && aa2.HasFile)
            {
                StudentsUtilty.insertGeneralInst(serialno.Text, name.Text, nid.Text, bd.Text, Convert.ToBoolean(aa.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, (string)Session["pi"], (string)Session["ni"], Convert.ToInt32(at2t.SelectedValue), Convert.ToInt32(att.SelectedValue), xx, Convert.ToInt32(atttt.SelectedValue),
                    (int)Session["UniID"]);
            }
            else
            {
                StudentsUtilty.insertGeneralInst(serialno.Text, name.Text, nid.Text,bd.Text, Convert.ToBoolean(aa.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, null, null, Convert.ToInt32(at2t.SelectedValue), Convert.ToInt32(att.SelectedValue), xx, Convert.ToInt32(atttt.SelectedValue),
                    (int)Session["UniID"]);
            }
            Editor_DetailsView1.DataBind();
            Response.Redirect("ControlStudents.aspx");
            //ListView1.DataBind();
        }

        

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            staticUtility.uploadfile1(this, Editor_DetailsView1);

        }
        protected void AsyncFileUpload2_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            staticUtility.uploadfile2(this, Editor_DetailsView1);

        }

        protected string getactiname()
        {
            if (Session["acid"] != null)
            {
                return StudentsUtilty.getacfromacid(Convert.ToInt32(Session["acid"]));
            }
            else
            {
                return StudentsUtilty.getacfromacid(1);
            }
        }
        
        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ControlStudents.aspx");
        }
    }
}