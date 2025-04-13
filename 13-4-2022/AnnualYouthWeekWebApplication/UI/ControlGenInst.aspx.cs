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
    public partial class ControlGenInst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           ListView1.DataBind();
        }

       

        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
            LinkButton x = (LinkButton)sender;
            Session["ID"] = x.CommandArgument;Session["source"] = "edit";
            Response.Redirect("EditForm2.aspx?ID=" + Session["ID"]);
           
        }

        protected void ArticleEditorControlInsertClicked(object sender, EventArgs e)
        {
            //Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
            //Editor_ModalPopupExtender.Show();
            LinkButton x = (LinkButton)sender;
            Session["ID"] = x.CommandArgument;
            Response.Redirect("InsertForm2.aspx");
        }

       
       

        protected void Delete_LinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton x = (LinkButton)sender;
            Session["ID"] = x.CommandArgument;

            if (Session["pi"] != null && Session["ni"] == null)
            {
                File.Delete((string)Session["path1"]);
            }
            else if (Session["ni"] != null && Session["pi"] == null)
            {
                File.Delete((string)Session["path2"]);
            }
            else if (Session["ni"] != null && Session["pi"] != null)
            {
                File.Delete((string)Session["path1"]);
                File.Delete((string)Session["path2"]);
            }
            GeneralInstUtility.DeleteAdmin(Convert.ToInt32(Session["ID"]));
            ListView1.DataBind();

        }

        protected void Editor_ImageButton_Click2(object sender, EventArgs e)
        {
            LinkButton x = (LinkButton)sender;
            Session["ID"] = x.CommandArgument; Session["source"] = "readonly";
            Response.Redirect("EditForm2.aspx?ID=" + Session["ID"]);
           
        }


        protected string getadmintype2(object eval)
        {
            return GeneralInstUtility.getadmintype2(Convert.ToInt32(eval));
        }

        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CommitteControlPanel.aspx");
        }
    }
}