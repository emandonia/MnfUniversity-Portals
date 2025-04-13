using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;

namespace AnnualYouthWeekWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null && Convert.ToInt32(Session["usertype"])==1)
            {
                Response.Redirect("UI/SuperAdminControlPanel.aspx");
            }
            else if (Session["uid"] != null && Convert.ToInt32(Session["usertype"]) == 2)
            {
                Response.Redirect("UI/CommitteControlPanel.aspx");
            }
            else if (Session["uid"] != null && Convert.ToInt32(Session["usertype"]) == 3)
            {
                Response.Redirect("UI/HigherAdminsControlPanel.aspx");
            }
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            

            //check if user exists
            if (UsersUtility.checkuserIfExists(TextBox1.Text))
            {
                //if so check if the user is a valid username & password
                if (UsersUtility.getuser(TextBox1.Text, TextBox2.Text) != null)
                {
                    UsersUtility.updateloginstate(UsersUtility.getuser(TextBox1.Text, TextBox2.Text).ID,true);
                    //if so get that user
                    int usertype = UsersUtility.getuser(TextBox1.Text, TextBox2.Text).user_type_id;
                    Session["usertype"] = usertype;
                    Session["uid"] = UsersUtility.getuser(TextBox1.Text, TextBox2.Text).ID;
                    Session["UserName"] = TextBox1.Text;
                    Session["Password"] = TextBox2.Text;
                    if (usertype == 1)
                    {
                        Response.Redirect("UI/SuperAdminControlPanel.aspx");
                    }
                    else if (usertype == 2)
                    {
                        Response.Redirect("UI/CommitteControlPanel.aspx");
                    }
                    else if (usertype == 3)
                    {
                        Response.Redirect("UI/HigherAdminsControlPanel.aspx");
                    }
                }
                //if username is right but the password is not
                else if (!UsersUtility.checkPass(TextBox2.Text))

                {
                    if (Session["loginclient"] != null)
                    {
                        if (Convert.ToInt32(Session["loginclient"]) == 3)
                            Response.Redirect("~/UI/Forgetpassword.aspx");
                        else
                        {
                            Session["loginclient"] = Convert.ToInt32(Session["loginclient"]) + 1;

Label1.Text = "كلمة السر خاطئة .اقصي عدد من المحاولات 3 وهذه محاولة رقم " + Session["loginclient"];
                            //Response.Redirect("Default.aspx"); 
                           // Label1.Visible = true;
                            
                        }
                    }
                    else
                    {
                        Session["loginclient"] = 1;
                        Label1.Text = "كلمة السر خاطئة . اقصي عدد من المحاولات 3 وهذه محاولة رقم " + Session["loginclient"];
                    }
                }
            }
            else
            {

                Label1.Text = "اسم المستخدم غير موجود";
            }
            
        }

        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("UI/Forgetpassword.aspx");
        }
    }
}