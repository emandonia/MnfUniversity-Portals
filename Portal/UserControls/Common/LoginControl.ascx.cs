using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Common
{
    public partial class LoginControl : ViewersBase
    {



        protected void MainLogin_LoggedIn(object sender, EventArgs e)
        {
            var login = (Login)sender;
            Prtl_UsersUtility.Update(login.UserName, true);
            Session["UserName"] = login.UserName;
            string returnUrl = ((PageBase)Page).ReturnUrl;
            if (string.IsNullOrEmpty(returnUrl)) return;
            Page.Response.Redirect(returnUrl);
            ShowLogin(false);
        }

        protected void MainLogin_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            var login = (Login)sender;

            //test if user loged before
            aspnet_User user = Prtl_UsersUtility.GetAspUser(login.UserName);
            if (user != null)
            {
                if (user.LoginStatus != null && (bool)user.LoginStatus)
                {
                    e.Cancel = true;
                    Prtl_UsersUtility.Update(login.UserName, false);
                    ShowLogin();
                    return;
                }
            }
            e.Cancel = !StaticUtilities.CheckuserVaild(login.UserName, Page);
            if (!e.Cancel) return;
            ShowLogin();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            var loginButton = MainLogin.FindControl("LoginButton");
            LoginPanel.DefaultButton = loginButton.UniqueID;
            StaticUtilities.FloatControls(MainLogin, StaticUtilities.FloatRight, "usernameFieldLabel", "UserName", "passwordFieldLabel", "PasswordLabel");
            StaticUtilities.FloatControls(MainLogin, StaticUtilities.FloatLeft, "UserNameRequired", "PasswordRequired");

        }

        private void ShowLogin(bool show = true)
        {

            MainLogin.FindControl("FailureText").Visible = show;
            if (Parent == null || Parent.Parent == null || Parent.Parent.Parent == null) return;
            var control = Parent.Parent.Parent as HtmlGenericControl;
            if (control != null)
                control.Style["display"] = show ? "block" : "none";
        }

        protected void MainLogin_LoginError(object sender, EventArgs e)
        {
            ShowLogin();
        }
    }
}