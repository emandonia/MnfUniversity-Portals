using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.Base_Code;
using Portal_DAL;

namespace MnfUniversity_Portals.Masterpages
{
    public partial class StaffMaster : MasterBase
    {
        private void AddJsFiles(Page page)
        {
            string[] jsFiles =
            {
                "~/Scripts/jquery-1.4.3.min.js",
                "~/Styles/University_Master/jquery/jquery-1.4.4.min.js",
                "~/Scripts/js.js",
                "~/Styles/University_Master/jquery/login.js",
                "~/Scripts/languageswitcher.js"
            };
            foreach (var jsFile in jsFiles)
            {
                var scriptTag = new HtmlGenericControl {TagName = "script"};
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


        protected void Page_Load(object sender, EventArgs e)
        {
            //StaffMenu.FindItem("99").NavigateUrl = "http://" + Request.Url.Authority +
            //                                       URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/StaffSenRes/" +
            //                                       StaticUtilities.Currentlanguage(Page.RouteData);

            StaffMenu.Items[0].NavigateUrl = "http://" + Request.Url.Authority+"/" +
                                                   URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/StaffSenRes/" +
                                                   StaticUtilities.Currentlanguage(Page.RouteData);
            
            
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {

                Div1.Style.Clear();
                Div1.Style.Add("margin-left", "85px");

            }

            else
            {

                Div1.Style.Clear();
                Div1.Style.Add("margin-right", "40px");

            }

            if (!IsPostBack)
            {
                //string url = "http://" + Request.Url.Authority + "/" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/PasswordRecovery/" + StaticUtilities.Currentlanguage(Page);
                //LinkButton1.PostBackUrl = url;
                foreach (MenuItem menuItem in StaffMenu.Items)
                    AddLangToURL(menuItem);
                if (StaticUtilities.IsRTL)
                    StaffMenu.StaticPopOutImageUrl =
                        StaffMenu.DynamicPopOutImageUrl = "~/styles/CommonImages/Menu_Popout.gif";
                foreach (MenuItem menuItem in Menu1.Items)
                    AddLangToURL(menuItem);
                if (StaticUtilities.IsRTL)
                    Menu1.StaticPopOutImageUrl =
                        Menu1.DynamicPopOutImageUrl = "~/styles/CommonImages/Menu_Popout.gif";
            }
            string sPath = HttpContext.Current.Request.Url.AbsolutePath;
            string[] strarry = sPath.Split('/');
            int lengh = strarry.Length;
            string sRet = strarry[lengh - 2];

            //if (sRet != "Home")
            //{

            //    MyDiv.Visible = true;
            //}
            //else
            //{
            //    MyDiv.Visible = false;
            //}
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

        public string login_pass
        {
            get { return Session["UserName1"].ToString(); }
        }

        protected void logot(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Prtl_UsersUtility.Update(Page.User.Identity.Name, false);
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            var login = (Login) sender;
            Prtl_UsersUtility.Update(login.UserName, true);
            Session["UserName"] = login.UserName;
            Session["UserName1"] = login.PasswordLabelText;
            string returnUrl = ((PageBase) Page).ReturnUrl;
            if (string.IsNullOrEmpty(returnUrl)) return;
            Page.Response.Redirect(returnUrl);
            //  ShowLogin(false);
        }

        protected void Login1_LoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            var login = (Login) sender;

            //test if user loged before
            aspnet_User user = Prtl_UsersUtility.GetAspUser(login.UserName);
            if (user != null)
            {
                if (user.LoginStatus != null && (bool) user.LoginStatus)
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

        protected void  GetUrl( )
        {
            //<%--<asp:MenuItem Text="الابحاث العلمية" NavigateUrl = <%= "http://" + Request.Url.Authority + URLBuilder.CurrentOwnerAbbr(Page.RouteData)+ "/StaffSenRes/" + StaticUtilities.Currentlanguage(Page.RouteData)%>  ></asp:MenuItem>--%>


            string x = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            Response .Redirect(  "http://" + Request.Url.Authority + "/" + x + "/StaffSenRes/" +
                   StaticUtilities.Currentlanguage(Page.RouteData));
        }

        protected void StaffMenu_OnDataBound(object sender, EventArgs e)
        {
            if (Session["Translator"] != null)
            {
                if (StaffMenu.Items.Count > 0)
                {
                    foreach (MenuItem mi in StaffMenu.Items)
                    {
                        if (mi.Text  == "قائمة الابحاث العلمية")
                        {
                            mi.NavigateUrl = "http://" + Request.Url.Authority + "/" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/StaffSenRes/" + StaticUtilities.Currentlanguage(Page.RouteData); ;
                            
                        }
                    }
                }
            }

        }

        protected void Menu1_OnMenuItemClick(object sender, MenuEventArgs e)
        {
            StaffMenu.Items[0].NavigateUrl = "http://" + Request.Url.Authority + "/" +
                                                  URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/StaffSenRes/" +
                                                  StaticUtilities.Currentlanguage(Page.RouteData);
          
        }

        protected void Details_OnClick(object sender, EventArgs e)
        {
            string x = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            Response.Redirect("http://" + Request.Url.Authority + "/" + x + "/StaffSenRes/" +
                   StaticUtilities.Currentlanguage(Page.RouteData));
        }
    }
}