using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.Base_Code;
using Portal_DAL;
using BLL;

namespace MnfUniversity_Portals.Masterpages
{
    public partial class ItUnitsMaster : MasterBase
    {
        private void AddJsFiles(Page page)
        {
            string[] jsFiles = { "~/Scripts/jquery-1.9.1.min.js",
                                
                                  "~/Scripts/js.js",
                                 "~/Styles/University_Master/jquery/login.js",
                                 "~/Scripts/languageswitcher.js"
                                 };
            foreach (var jsFile in jsFiles)
            {
                var scriptTag = new HtmlGenericControl { TagName = "script" };
                scriptTag.Attributes.Add("type", "text/javascript");
                scriptTag.Attributes.Add("src", page.ResolveClientUrl(jsFile));
                page.Header.Controls.Add(scriptTag);
            }
        }

        public bool checkuser()
        {
            return Page.User.Identity.Name.ToLower() == StaticUtilities.Superadmin;
        }

        public string LoginDivFloat
        {
            get { return (StaticUtilities.Currentlanguage(Page) == "ar") ? "margin-left:270px" : "margin-right:270px"; }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/News/" + StaticUtilities.Currentlanguage(Page));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDepartment();

            }
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
                err.Style.Clear();
                Div2.Style.Clear();
                Div2.Style.Add("margin-left", "290px");
                err.Style.Add("text-align", "right");
                dep_name.Style.Clear();
                //dep_name.Style.Add("float", "right");

            }

            else
            {
                err.Style.Clear();
                Div2.Style.Clear();
                Div2.Style.Add("margin-right", "235px");
                err.Style.Add("text-align", "left");
                dep_name.Style.Clear();
                //  dep_name.Style.Add("float", "right");
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


            //HtmlGenericControl MyDiv2 = (HtmlGenericControl)Page.FindControl("Div2");

            if (Page.Request["__ASYNCPOST"] != "true")
            {

                //SubEntitiesLabel.Text = SubEntitiesViewer.Label;
                //StaticUtilities.AddSiteIcon(Page);
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




        //private  void ShowLogin(bool show = true)
        //{

        //    Login.FindControl("FailureText").Visible = show;
        //    if (Parent == null || Parent.Parent == null || Parent.Parent.Parent == null) return;
        //    var control = Parent.Parent.Parent as HtmlGenericControl;
        //    if (control != null)
        //        control.Style["display"] = show ? "block" : "none";
        //}


        protected void logot(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Prtl_UsersUtility.Update(Page.User.Identity.Name, false);
        }

        protected void LoginStatus1_LoggedOut1(object sender, EventArgs e)
        {

            Prtl_UsersUtility.Update(Page.User.Identity.Name, false);

        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["UserName"] = null;

        }
        public void GetDepartment()
        {

            string x = URLBuilder.OwnerAbbr(Page.RouteData);
            prtl_Owner o = Prtl_OwnersUtility.GetOwnerByAbbr2(x);
            int y = o.Type;
            if (y == 2)
            {
                int l = Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page)).Lang_Id;
                prtl_Translation c = Prtl_TranslationUtility.GetTranslationsByTranslationID_Lang(o.Owner_ID, l);
                LblDep.Text = c.Translation_Data;
                LblDep.Visible = true;
            }
            else
            {
                LblDep.Text = "";
                LblDep.Visible = false;
            }
        }


        protected string GetLoginDivFloat()
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {

                return "margin-left:270px;";

            }
            else
            {
                return "margin-right:270px;";
            }
        }

        public string GetYouTubeUrl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "https://www.youtube.com/channel/UCfFmKc3AGVSdsOGPIEgC_lg";
                        break;
                    case "fee":
                        return "http://www.youtube.com/channel/UCHyX0_F4MbDsbwXQ7SdAttA";
                        break;
                    case "liv":

                        return "https://www.youtube.com/channel/UC1JRsj7pR05yDy0L4vEgvPw";
                        break;
                    case "eng":

                        return "http://www.youtube.com/channel/UC3bngViaqe5x8v6NxhfKxTA";
                        break;
                    case "agr":
                        return "http://www.youtube.com/user/agrimenoufia";
                        break;
                    case "art":
                        return "http://www.youtube.com/channel/UCz227cmlzNxcvLv-n8VhsMw?guided_help_flow=3&ytsession=yO7aptJrTr4bNEIPHwiqv99rzoPDLMbm328zLS30dtm4YSAAKvC6v3bgrhE5Tf77-02jhfAX4NmdOHBWRb07xkq7WVaUu6FOAgE0tDHNEWx-L5Qhhqw6yJt0su2ZNnXcIl2Tkw9Pdwvib_OZ18hGi9BW1qR9_i_C3tOOxYuqU-XrGCNjVoXA_SGuf56XY7GbwVvCRN5lzivKxo48EiI3cmFGPvxh7TmZTLEKnSIIER14I_BIlK7EI2YSWDkZI6Jj9_RbRHy5xR0eGqr5t-tnmYM6LcyuHkM1x4C5oWZez6IgmGLBfueNIJvAvLcWhs1Ot30R0o7o1pZJfogsYJV4dg";
                        break;
                    case "com":
                        return "";
                        break;
                    case "edu":
                        return "http://www.youtube.com/channel/UCxWshd_aVb1oL8_YRxLjmmw";
                        break;
                    case "hec":
                        return "http://www.youtube.com/user/MenofiaHomeEconomics";
                        break;
                    case "law":
                        return " https://www.youtube.com/channel/UCzj9FnYczmbKJ_-ED0hxnMA";
                        break;
                    case "med":
                        return "https://www.youtube.com/channel/UCBs3wQq8fpMLchAQPGVI0QQ/feed?view_as=public";
                        break;
                    case "nur":
                        return "http://www.youtube.com/channel/UC7FgblZex7yuQw-_x6ZrE2g";
                        break;
                    case "sci":
                        return " http://www.youtube.com/channel/UCP_9cM4zMkE-pO79APPSVtA/feed";
                        break;
                    case "edv":
                        return "http://www.youtube.com/channel/UCGkELgfwH-4rwlioHG9cXSg";
                        break;
                    case "ho":
                        return "";
                        break;
                    default:
                        return "https://www.youtube.com/channel/UCfNjVPVBEGhj2YiUZGo-UuQ";
                }

            }
            else
            {
                switch (abb)
                {
                    case "fci":
                        return "https://www.youtube.com/channel/UCfFmKc3AGVSdsOGPIEgC_lg";
                        break;
                    case "fee":
                        return "http://www.youtube.com/channel/UCHyX0_F4MbDsbwXQ7SdAttA";
                        break;
                    case "liv":
                        return "https://www.youtube.com/channel/UC1JRsj7pR05yDy0L4vEgvPw";
                        break;
                    case "eng":
                        return "http://www.youtube.com/channel/UC3bngViaqe5x8v6NxhfKxTA";
                        break;
                    case "agr":
                        return "http://www.youtube.com/user/agrimenoufia";
                        break;
                    case "art":
                        return "http://www.youtube.com/channel/UCz227cmlzNxcvLv-n8VhsMw?guided_help_flow=3&ytsession=yO7aptJrTr4bNEIPHwiqv99rzoPDLMbm328zLS30dtm4YSAAKvC6v3bgrhE5Tf77-02jhfAX4NmdOHBWRb07xkq7WVaUu6FOAgE0tDHNEWx-L5Qhhqw6yJt0su2ZNnXcIl2Tkw9Pdwvib_OZ18hGi9BW1qR9_i_C3tOOxYuqU-XrGCNjVoXA_SGuf56XY7GbwVvCRN5lzivKxo48EiI3cmFGPvxh7TmZTLEKnSIIER14I_BIlK7EI2YSWDkZI6Jj9_RbRHy5xR0eGqr5t-tnmYM6LcyuHkM1x4C5oWZez6IgmGLBfueNIJvAvLcWhs1Ot30R0o7o1pZJfogsYJV4dg";
                        break;
                    case "com":
                        return "";
                        break;
                    case "edu":
                        return "http://www.youtube.com/channel/UCxWshd_aVb1oL8_YRxLjmmw";
                        break;
                    case "hec":
                        return "http://www.youtube.com/user/MenofiaHomeEconomics";
                        break;
                    case "law":
                        return " https://www.youtube.com/channel/UCzj9FnYczmbKJ_-ED0hxnMA";
                        break;
                    case "med":
                        return "https://www.youtube.com/channel/UCBs3wQq8fpMLchAQPGVI0QQ/feed?view_as=public";
                        break;
                    case "nur":
                        return "http://www.youtube.com/channel/UC7FgblZex7yuQw-_x6ZrE2g";
                        break;
                    case "sci":
                        return " http://www.youtube.com/channel/UCP_9cM4zMkE-pO79APPSVtA/feed";
                        break;
                    case "edv":
                        return "http://www.youtube.com/channel/UCGkELgfwH-4rwlioHG9cXSg";
                        break;
                    case "ho":
                        return "";
                        break;
                    default:
                        return "https://www.youtube.com/channel/UCfNjVPVBEGhj2YiUZGo-UuQ";
                }

            }

        }



        public string GetFaceUl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "https://www.facebook.com/pages/Faculty-of-Computer-and-information-AR/544711865604435";
                        break;
                    case "fee":
                        return "https://www.facebook.com/pages/Faculty-of-Electronic-Engineering-AR/484702644970018";
                        break;
                    case "liv":

                        return "https://www.facebook.com/pages/National-Liver-Institute-AR/168939899980029";
                        break;
                    case "eng":

                        return "https://www.facebook.com/pages/College-of-Engineering-AR/1396993707203262";
                        break;
                    case "agr":
                        return "https://www.facebook.com/pages/Faculty-of-Agriculture-Ar/1415136288703948";
                        break;
                    case "art":
                        return "https://www.facebook.com/pages/Faculty-of-Arts-AR/210034369169970";
                        break;
                    case "com":
                        return "https://www.facebook.com/pages/Faculty-of-Commerce-AR/172709372931334";
                        break;
                    case "edu":
                        return "https://www.facebook.com/pages/Faculty-of-Education-AR/455924747851880";
                        break;
                    case "hec":
                        return "https://www.facebook.com/pages/Faculty-of-Home-Economics-AR/672350809451467";
                        break;
                    case "law":
                        return "https://www.facebook.com/pages/Faculty-of-Law-AR/683611584984509";
                        break;
                    case "med":
                        return "https://www.facebook.com/pages/Faculty-of-Medicine-AR/522652734489270";
                        break;
                    case "nur":
                        return "https://www.facebook.com/pages/Faculty-of-Nursing-AR/693021430710175";
                        break;
                    case "sci":
                        return "https://www.facebook.com/pages/Faculty-of-Science-AR/226699537499016";
                        break;
                    case "edv":
                        return "https://www.facebook.com/pages/Faculty-of-Specific-Education-AR/192511060932432";
                        break;
                    case "ho":
                        return "https://www.facebook.com/pages/University-Hospitals-AR/377890699007600";
                        break;
                    default:
                        return "https://www.facebook.com/pages/Menoufia-University-AR/383381225125142";
                }

            }
            else
            {
                switch (abb)
                {
                    case "fci":
                        return "https://www.facebook.com/pages/Faculty-of-Computer-Informations-Menoufia-University/536877019721622";
                        break;
                    case "fee":
                        return "https://www.facebook.com/pages/Faculty-of-Electronic-Engineering-Menoufia-University/252427431571589";
                        break;
                    case "liv":
                        return "https://www.facebook.com/pages/National-Institute-of-Liver-Menoufia-University/168948776632329";
                        break;
                    case "eng":
                        return "https://www.facebook.com/pages/Faculty-of-Engineering-Menoufia-University/604151972964686";
                        break;
                    case "agr":
                        return "https://www.facebook.com/pages/Faculty-of-Agriculture-Menoufia-University/190486477805085";
                        break;
                    case "art":
                        return "https://www.facebook.com/pages/Faculty-of-Arts-Menoufia-University/562167610499864";
                        break;
                    case "com":
                        return "https://www.facebook.com/pages/Faculty-of-Commerce-Menoufia-University/191287224392034";
                        break;
                    case "edu":
                        return "https://www.facebook.com/pages/Faculty-of-Education-Menoufia-University/647035068674514";
                        break;
                    case "hec":
                        return "https://www.facebook.com/pages/Faculty-of-Home-Economy-Menoufia-University/168436800018090";
                        break;
                    case "law":
                        return "https://www.facebook.com/pages/Faculty-of-Law-Menoufia-University/554546471284693";
                        break;
                    case "med":
                        return "https://www.facebook.com/pages/Faculty-of-Medicine-Menoufia-University/363857187078506";
                        break;
                    case "nur":
                        return "https://www.facebook.com/pages/Faculty-of-Nursing-Menoufia-University/200005350178682";
                        break;
                    case "sci":
                        return "https://www.facebook.com/pages/Faculty-of-Science-Menoufia-University/526827600732073";
                        break;
                    case "edv":
                        return "https://www.facebook.com/pages/Faculty-of-Specifie-Education-Menoufia-University/657974400910083";
                        break;
                    case "ho":
                        return "https://www.facebook.com/pages/University-Hospitals-Menoufia-University/532535293493290";
                        break;
                    default:
                        return "https://www.facebook.com/pages/Menoufia-University- Page/1374780889427831";
                }

            }

        }

        public string GetTwitterUrl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "https://twitter.com/fci_ar";

                    case "fee":
                        return "https://twitter.com/fee_ar";
                    case "liv":
                        return "https://twitter.com/Liver_Institute";
                    case "eng":
                        return "https://twitter.com/ar_engg";

                    case "agr":
                        return "https://twitter.com/mnfportal_agr";

                    case "art":
                        return "https://twitter.com/facartAr";
                    case "com":
                        return "https://twitter.com/Comm_ar";

                    case "edu":
                        return "https://twitter.com/ar_educ";

                    case "hec":
                        return "https://twitter.com/ar_hec";
                    case "law":
                        return "https://twitter.com/Mnfportal_law";
                    case "med":
                        return "https://twitter.com/ar_medc";
                    case "nur":
                        return "https://twitter.com/ar_nurs";
                    case "sci":
                        return "https://twitter.com/sci_ar";

                    case "edv":
                        return "https://twitter.com/edv_ar";

                    case "ho":
                        return "https://twitter.com/ar_hos";

                    default:
                        return "https://twitter.com/ar_uni";


                }

            }
            else
            {


                switch (abb)
                {
                    case "fci":
                        return "https://twitter.com/fci_en";

                    case "fee":
                        return "https://twitter.com/en_fee";
                    case "liv":
                        return "https://twitter.com/liv_en";
                    case "eng":
                        return "https://twitter.com/engg_en";

                    case "agr":
                        return "https://twitter.com/agr_en";

                    case "art":
                        return "https://twitter.com/facartEn";
                    case "com":
                        return "https://twitter.com/comm_en";

                    case "edu":
                        return "https://twitter.com/en_educ";

                    case "hec":
                        return "https://twitter.com/en_hec";
                    case "law":
                        return "https://twitter.com/law_en";
                    case "med":
                        return "https://twitter.com/en_medc";
                    case "nur":
                        return "https://twitter.com/en_nurs";
                    case "sci":
                        return "https://twitter.com/sci_en";

                    case "edv":
                        return "https://twitter.com/EnEdv";

                    case "ho":
                        return "https://twitter.com/en_hosp";

                    default:
                        return "https://twitter.com/en_uni";
                }

            }

        }
    }
}