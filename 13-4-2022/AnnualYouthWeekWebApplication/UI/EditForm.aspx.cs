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
    public partial class EditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["source"]) == "edit")
            {
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                LinkButton1.Visible = true;
                LinkButton2.Visible = false;
                //DropDownList at = (DropDownList) DetailsView1.FindControl("DropDownList2");
                //at.SelectedValue = HigherAdminsUtility.getadmintype(Convert.ToInt32(Session["ID"]));
               
            }
            else
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                LinkButton1.Visible = false;
                LinkButton2.Visible = true; flag = 0;
            }

           
            

        }

        public int flag;
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
            
            DropDownList at = (DropDownList)DetailsView1.FindControl("DropDownList2");

            AsyncFileUpload aa = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload1");
            
            if (aa.HasFile   )
            {

                HigherAdminsUtility.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, phno.Text, add.Text, em.Text,(string) Session["pi"], at.SelectedValue);

            }
           
            else
            {
                HigherAdminsUtility.UpdateHigherAdmin(Convert.ToInt32(serialno.Text), Convert.ToInt32(Session["ID"]), name.Text, nid.Text, bd.Text, bp.Text, phno.Text, add.Text, em.Text, null, at.SelectedValue);

            }
                        Response.Redirect("ControlUniAdmins.aspx");
        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {

            staticUtility.uploadfile1(this, DetailsView1);
            //string strPath = MapPath("~/Images/PersonalImages/") + Path.GetFileName(e.FileName);
            // AsyncFileUpload aa = (AsyncFileUpload)DetailsView1.FindControl("AsyncFileUpload1");
            // if (aa.HasFile)
            // {
            //     string savePath = MapPath("~/Images/PersonalImages/");


            //     // Get the name of the file to upload.
            //     string fileName = aa.FileName;


            //     // Create the path and file name to check for duplicates.
            //     string pathToCheck = savePath + fileName;


            //     // Create a temporary file name to use for checking duplicates.
            //     string tempfileName = "";


            //     // Check to see if a file already exists with the
            //     // same name as the file to upload.
            //     if (System.IO.File.Exists(pathToCheck))
            //     {
            //         int counter = 1;
            //         while (System.IO.File.Exists(pathToCheck))
            //         {
            //             // if a file with this name already exists,
            //             // prefix the filename with a number.
            //             tempfileName = fileName + counter;
            //             pathToCheck = savePath + tempfileName;
            //             counter++;
            //         }


            //         fileName = tempfileName;
            //         savePath += fileName;

            //         aa.SaveAs(savePath);
            //         Session["pi"] = fileName;
            //         Session["path1"] = savePath;

            //     }
            //     else
            //     {
            //         aa.SaveAs(strPath);
            //         Session["pi"] = e.FileName;
            //         Session["path1"] = strPath;
            //     }
            // }
            // else
            // {
            //     Session["pi"] = null;
            //     Session["path1"] = null;

            // }


        }
   
       

        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ControlUniAdmins.aspx");
        }

        protected string GetadminType(object eval)
        {
           return HigherAdminsUtility.getadmintype2(Convert.ToInt32(eval));
        }

        protected object GetpImagePath(object eval)
        {
            if (eval != null)
            {
                return "../Images/PersonalImages/" + eval;
            }
            else
            {
                return "";
            }
        }
        protected object GetnImagePath(object eval)
        {if (eval != null)
            {
            return "../Images/NatIDImages/" + eval;
            }
        else
        {
            return "";
        }
        }
    }
}