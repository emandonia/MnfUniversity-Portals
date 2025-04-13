using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.Base_Code;
using Portal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.Masterpages
{
    public partial class SpecialUnitsMaster : MasterBase
    {
        private void AddJsFiles(Page page)
        {
            string[] jsFiles = { "~/Scripts/js/jquery-1.6.3.min.js",
                                 "~/Scripts/js/jquery.min.js",
                                  "~/Scripts/js.js",
                                 "~/Styles/University_Master/jquery/login.js",
                                 "~/Scripts/languageswitcher.js",
                                 "~/Scripts/jquery.easing.1.3.js",
                                 "~/Scripts/jquery.skitter.js",
                                 "~/Scripts/jquery.skitter.min.js",
                                 "~/Scripts/test.js",


                                 };
            foreach (var jsFile in jsFiles)
            {
                var scriptTag = new HtmlGenericControl { TagName = "script" };
                scriptTag.Attributes.Add("type", "text/javascript");
                scriptTag.Attributes.Add("src", page.ResolveClientUrl(jsFile));
                page.Header.Controls.Add(scriptTag);
            }
        }
        private void AddLangToURL(MenuItem item)
        {
            if (string.IsNullOrEmpty(item.NavigateUrl))
                item.NavigateUrl = URLBuilder.StaffDetailUrl(Page.RouteData, item.Value);
            foreach (MenuItem childItem in item.ChildItems)
            {
                if (string.IsNullOrEmpty(childItem.NavigateUrl))
                    childItem.NavigateUrl = URLBuilder.StaffDetailUrl(Page.RouteData, item.Value);
                AddLangToURL(childItem);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/News/" + StaticUtilities.Currentlanguage(Page));
        }
        protected void Page_Load(object sender, EventArgs e)
        {








            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {

                Div1.Style.Clear();
                Div1.Style.Add("margin-left", "270px");

            }

            else
            {

                Div1.Style.Clear();
                Div1.Style.Add("margin-right", "150px");

            }

            
            string sPath = HttpContext.Current.Request.Url.AbsolutePath;
            string[] strarry = sPath.Split('/');
            int lengh = strarry.Length;
            string sRet = strarry[lengh - 2];

            if (sRet != "Home")
            {
                MyDiv.Visible = true;
            }
            else
            {
                MyDiv.Visible = false;
            }
            if (Session.SessionID == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }

            if (Page.Request["__ASYNCPOST"] != "true")
            {

                //SubEntitiesLabel.Text = SubEntitiesViewer.Label;
                StaticUtilities.AddSiteIcon(Page);
            }
            if (!Page.IsPostBack)
            {
                AddJsFiles(Page);
                ShowErrorMessage();

            }
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            var login = (Login)sender;
            Prtl_UsersUtility.Update(login.UserName, true);
            Session["UserName"] = login.UserName;
            string returnUrl = ((PageBase)Page).ReturnUrl;
            if (string.IsNullOrEmpty(returnUrl)) return;
            Page.Response.Redirect(returnUrl);
            //  ShowLogin(false);
        }

        protected void Login1_LoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
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
                    // ShowLogin();
                    return;
                }
            }
            e.Cancel = !StaticUtilities.CheckuserVaild(login.UserName, Page);
            if (!e.Cancel) return;
            // ShowLogin();
        }
        protected void LoginStatus1_LoggedOut1(object sender, EventArgs e)
        {

            Prtl_UsersUtility.Update(Page.User.Identity.Name, false);

        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["UserName"] = null;

        }




    }
    }
