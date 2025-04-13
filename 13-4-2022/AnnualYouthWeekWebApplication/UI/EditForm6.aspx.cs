using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using AnnualYouthWeekWebApplication.BLL;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class EditForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["source"]) == "edit")
            {
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                LinkButton1.Visible = true;
                LinkButton2.Visible = false;
                //DropDownList at = (DropDownList)DetailsView1.FindControl("DropDownList1");
                //at.SelectedValue = InstructorsUtility.getadmintype(Convert.ToInt32(Session["ID"]));

            }
            else
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                LinkButton1.Visible = false;
                LinkButton2.Visible = true;
            }




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

           
            AsyncFileUpload aa = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload1");
            AsyncFileUpload aa2 = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload2");

            if (aa.HasFile && !aa2.HasFile)
            {

                MemberUtility.UpdateMember(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, phno.Text, add.Text, em.Text, (string)Session["pi"]
                    , null);

            }
            else if (!aa.HasFile && aa2.HasFile)
            {

                MemberUtility.UpdateMember(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text
                    , phno.Text, add.Text, em.Text, null, (string)Session["ni"]);

            }
            else if (aa.HasFile && aa2.HasFile)
            {

                MemberUtility.UpdateMember(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, phno.Text, add.Text, em.Text,
                    (string)Session["pi"], (string)Session["ni"]);

            }
            else
            {
                MemberUtility.UpdateMember(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text
                    , phno.Text, add.Text, em.Text, null, null);

            }
            Response.Redirect("ControlMembers.aspx");
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
            Response.Redirect("ControlMembers.aspx");
        }

       
    }
}