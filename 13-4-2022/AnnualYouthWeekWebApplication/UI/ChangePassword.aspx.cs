using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;
using Label = System.Reflection.Emit.Label;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            if (UsersUtility.checkPass(TextBox1.Text))
            {
                UsersUtility.updatepassword(UsersUtility.getuser((string)Session["UserName"], TextBox1.Text).ID, TextBox2.Text);
                Label1.Visible = true;
                Label1.Text = "تم تغيير كلمة السر بنجاح";
            }
            else
            {
                Label1.Visible = false;
            }
           
        }
    }
}