using System;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.UserControls.Base;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class LoginControlContainer : ViewersBase
    {
        protected void LoginStatus1_Loggedout(object sender, EventArgs e)
        {
            Prtl_UsersUtility.Update(Page.User.Identity.Name, false);
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["UserName"] = null;



        }

    }
}