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
    public partial class EditForm3 : System.Web.UI.Page
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

        protected string getgender(int id)
        {
            DropDownList att = (DropDownList)DetailsView1.FindControl("DropDownList3");
            if (InstructorsUtility.getadmingender3(id))
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

            DropDownList at = (DropDownList)DetailsView1.FindControl("DropDownList1");
            DropDownList att = (DropDownList)DetailsView1.FindControl("DropDownList3");
            DropDownList attt = (DropDownList)DetailsView1.FindControl("DropDownList3541");
            AsyncFileUpload aa = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload1");
            AsyncFileUpload aa2 = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload2");
           
            if (aa.HasFile && !aa2.HasFile)
            {

                InstructorsUtility.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(att.SelectedValue), phno.Text, add.Text, em.Text, (string)Session["pi"]
                    , null, at.SelectedValue, Convert.ToInt32(attt.SelectedValue));

            }
            else if (!aa.HasFile && aa2.HasFile)
            {

                InstructorsUtility.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(att.SelectedValue)
                    , phno.Text, add.Text, em.Text, null, (string)Session["ni"], at.SelectedValue, Convert.ToInt32(attt.SelectedValue));

            }
            else if (aa.HasFile&& aa2.HasFile)
            {

                InstructorsUtility.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(att.SelectedValue), phno.Text, add.Text, em.Text,
                    (string)Session["pi"], (string)Session["ni"], at.SelectedValue, Convert.ToInt32(attt.SelectedValue));

            }
            else
            {
                InstructorsUtility.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, Convert.ToBoolean(att.SelectedValue)
                    , phno.Text, add.Text, em.Text, null, null, at.SelectedValue, Convert.ToInt32(attt.SelectedValue));

            }
            Response.Redirect("ControlInst.aspx");
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
            Response.Redirect("ControlInst.aspx");
        }

        protected string GetadminType(object eval)
        {
            return InstructorsUtility.getadmintype2(Convert.ToInt32(eval));
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

        protected string GetInsField(object eval)
        {
            return InstructorsUtility.GetInsField(Convert.ToInt32(eval));
        }
    }
}