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
    public partial class InsertForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
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

            DropDownList at = (DropDownList)Editor_DetailsView1.FindControl("DropDownList1");
            DropDownList att = (DropDownList)Editor_DetailsView1.FindControl("DropDownList3");

            if (Session["pi"] != null && Session["ni"] == null)
            {
                CompanionsUtilty.insertGeneralInst(serialno.Text, name.Text, nid.Text, bd.Text, Convert.ToBoolean(att.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, (string)Session["pi"], null, Convert.ToInt32(at.SelectedValue),
                    (int)Session["UniID"]);
            }
            else if (Session["ni"] != null && Session["pi"] == null)
            {
                CompanionsUtilty.insertGeneralInst(serialno.Text, name.Text, nid.Text, bd.Text, Convert.ToBoolean(att.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, null, (string)Session["ni"], Convert.ToInt32(at.SelectedValue),
                    (int)Session["UniID"]);
            }
            else if (Session["ni"] != null && Session["pi"] != null)
            {
                CompanionsUtilty.insertGeneralInst(serialno.Text, name.Text, nid.Text, bd.Text, Convert.ToBoolean(att.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, (string)Session["pi"], (string)Session["ni"], Convert.ToInt32(at.SelectedValue),
                    (int)Session["UniID"]);
            }
            else
            {
                CompanionsUtilty.insertGeneralInst(serialno.Text, name.Text, nid.Text, bd.Text, Convert.ToBoolean(att.SelectedValue), bp.Text,
                    phno.Text, add.Text, em.Text, null, null, Convert.ToInt32(at.SelectedValue),
                    (int)Session["UniID"]);
            }
            Editor_DetailsView1.DataBind();
            Response.Redirect("ControlCompanions.aspx");
        }
        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            string strPath = MapPath("~/Images/PersonalImages/") + Path.GetFileName(e.FileName);
            AsyncFileUpload aa = (AsyncFileUpload)Editor_DetailsView1.FindControl("AsyncFileUpload1");
            aa.SaveAs(strPath);
            Session["pi"] = e.FileName;
            Session["path1"] = strPath;

        }
        protected void AsyncFileUpload2_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            string strPath = MapPath("~/Images/NatIDImages/") + Path.GetFileName(e.FileName);
            AsyncFileUpload aa = (AsyncFileUpload)Editor_DetailsView1.FindControl("AsyncFileUpload2");
            aa.SaveAs(strPath);
            Session["ni"] = e.FileName;
            Session["path2"] = strPath;

        }
        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ControlCompanions.aspx");
        }
    }
}