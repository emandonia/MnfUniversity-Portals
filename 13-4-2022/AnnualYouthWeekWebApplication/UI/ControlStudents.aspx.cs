using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using AnnualYouthWeekWebApplication.BLL;
using DBAdmin;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class ControlStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dc = new MyDataContext().Students.Where(x => x.University_id == Convert.ToInt32(Session["UniID"]));
            ListView1.DataSource = dc;
            ListView1.DataBind();

        }



        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
            LinkButton x = (LinkButton)sender;
            Session["ID"] = x.CommandArgument; Session["source"] = "edit";
            Session["acid"] = DropDownList5.SelectedValue;
            Response.Redirect("EditForm5.aspx?ID=" + Session["ID"]);


        }

        protected void ArticleEditorControlInsertClicked(object sender, EventArgs e)
        {
            //Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
            //Editor_ModalPopupExtender.Show();
            LinkButton x = (LinkButton)sender;
            Session["ID"] = x.CommandArgument;
            Session["acid"] = DropDownList5.SelectedValue;
            Response.Redirect("InsertForm.aspx?actid=" + DropDownList5.SelectedValue);
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
            StudentsUtilty.DeleteAdmin(Convert.ToInt32(Session["ID"]));
            Response.Redirect("ControlStudents.aspx");

        }

        protected void Editor_ImageButton_Click2(object sender, EventArgs e)
        {
            LinkButton x = (LinkButton)sender;
            Session["ID"] = x.CommandArgument; Session["source"] = "readonly";
            Response.Redirect("EditForm5.aspx?ID=" + Session["ID"]);

        }


        

        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CommitteControlPanel.aspx");
        }

       

        protected string getfacname()
        {
            return StudentsUtilty.getfacfromfacid(Convert.ToInt32(Session["facid"]));
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

        protected void DropDownList5_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["acid"] = DropDownList5.SelectedValue;
            var dc = new MyDataContext().Students.Where(x => x.University_id == Convert.ToInt32(Session["UniID"]) && x.Activity_id == Convert.ToInt32(Session["acid"]));
            ListView1.DataSource = dc;
            ListView1.DataBind();
        }
    }
}