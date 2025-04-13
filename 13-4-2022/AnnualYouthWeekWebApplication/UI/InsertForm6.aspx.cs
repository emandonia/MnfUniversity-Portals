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
    public partial class InsertForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
        }

        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ControlMembers.aspx");
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

          
            if (Session["pi"] != null && Session["ni"] == null)
            {
                MemberUtility.insertMember(serialno.Text, name.Text, nid.Text, bd.Text, bp.Text,
                    phno.Text, add.Text, em.Text, (string)Session["pi"], null,
                    3);
            }
            else if (Session["ni"] != null && Session["pi"] == null)
            {
                MemberUtility.insertMember(serialno.Text, name.Text, nid.Text, bd.Text, bp.Text,
                    phno.Text, add.Text, em.Text, null, (string)Session["ni"],
                    3);
            }
            else if (Session["ni"] != null && Session["pi"] != null)
            {
                MemberUtility.insertMember(serialno.Text, name.Text, nid.Text, bd.Text, bp.Text,
                    phno.Text, add.Text, em.Text, (string)Session["pi"], (string)Session["ni"],
                    3);
            }
            else
            {
                MemberUtility.insertMember(serialno.Text, name.Text, nid.Text, bd.Text, bp.Text,
                    phno.Text, add.Text, em.Text, null, null,
                    3);
            }
            Editor_DetailsView1.DataBind();
            Response.Redirect("ControlMembers.aspx");
        }
    }
}