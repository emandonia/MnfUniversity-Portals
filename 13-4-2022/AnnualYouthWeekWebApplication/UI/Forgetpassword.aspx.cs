using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class Forgetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {
            if (UsersUtility.checkuserIfExists(TextBox1.Text))
            {
                UsersUtility.resetpassword(TextBox1.Text, "123");
                Label1.Visible = true;
                Label1.Text = "كلمة المرور الجديدة هي  " + "123";
            }
            else
            {
                Label1.Text = "اسم المستخدم غير موجود";
                Label1.Visible = true;
            }
            
        }
    }
}