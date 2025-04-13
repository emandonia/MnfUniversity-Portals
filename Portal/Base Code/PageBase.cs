using System.Text;
using Portal_DAL;
using System.Web.Routing;

namespace App_Code
{
    using BLL;
    using Common;
    using Resources;
    using System;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    using Image = System.Drawing.Image;

    /// <summary>
    /// The Central part of the project that inintializes Page Langauage , Theme and contains common methods for usage in all pages in the project.
    /// </summary>
    public class PageBase : Page
    {
        #region Properties

        public static string LastErrorMessage
        {
            get { return StaticUtilities.GetSessionValueOrDefault(HttpContext.Current.Session, "LastErrorMessage", ""); }
            set { HttpContext.Current.Session["LastErrorMessage"] = value; }
        }

        public prtl_Owner CurrentOwner
        {
            get
            {
                const string sessionName = "CurrentOwner";

                var currentowner = Session[sessionName] as prtl_Owner;
                if (currentowner == null ||
                        (CurrentOwnerParent == null && currentowner.Abbr != URLBuilder.OwnerAbbr(RouteData)) ||
                        (CurrentOwnerParent != null && CurrentOwnerParent.Abbr + "." + currentowner.Abbr != URLBuilder.OwnerAbbr(RouteData)))
                {
                    var owner = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.OwnerAbbr(RouteData));
                    Session[sessionName] = owner;
                    Session["CurrentOwnerParent"] = owner;
                }

                return (prtl_Owner)Session[sessionName];
            }
        }

        /// <summary>
        /// Gets or Sets the URL that the user is redirected to after Login when the user has tried before to access a protected page
        /// </summary>
        public string ReturnUrl
        {
            get { return StaticUtilities.GetSessionValueOrDefault(this, URLBuilder.OwnerAbbr(RouteData) + "ReturnUrl", ""); }
            private set { Session[URLBuilder.OwnerAbbr(RouteData) + "ReturnUrl"] = value; }
        }

        /// <summary>
        /// Gets the 2-letter representation of the Current Langugage in the page which appears in the URL of the webpage
        /// </summary>
        public string CurrentLanguage
        {
            get { return StaticUtilities.Currentlanguage(RouteData); }
        }

        protected string ShowAccessDenied
        {
            get { return StaticUtilities.GetSessionValueOrDefault(this, "ShowAccessDenied", ""); }
            set { Session["ShowAccessDenied"] = value; }
        }

        protected string ShowLogin
        {
            get { return StaticUtilities.GetSessionValueOrDefault(this, "ShowLogin", ""); }
            set { Session["ShowLogin"] = value; }
        }

        private string Cookiename
        {
            get { return URLBuilder.OwnerAbbr(Page.RouteData) + "UserTheme"; }
        }

        private Guid? CurrentOwnerID
        {
            get { return CurrentOwner.Owner_ID; }
        }
        private prtl_Owner CurrentOwnerParent
        {
            get
            {
                return StaticUtilities.GetSessionValueOrDefault<prtl_Owner>(Page, "CurrentOwnerParent", null);
            }
        }

        #endregion Properties

        #region Methods


        protected T GetViewStateValueOrDefault<T>(string name, T defaultvalue)
        {
            return ViewState[name] == null ? defaultvalue : (T)ViewState[name];
        }

        /// <summary>
        ///  A Start place to primarily determine language the page is displayed in and other objectives
        /// </summary>
        protected override void InitializeCulture()
        {
            if (!IsPostBack)
            {
                //RedirectToErrorPage();
                if (User.Identity.IsAuthenticated && !StaticUtilities.CheckuserVaild(Page.User.Identity.Name, Page))
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.RawUrl);
                    Prtl_UsersUtility.Update(Page.User.Identity.Name, false);
                }
                RedirectToHomeIfAccessDenied();
                SetCurrentCulture();
                StaticUtilities.SetOwnerID(this, CurrentOwnerID);
                SetPageTitle();
            }
            base.InitializeCulture();
        }


        protected override void OnPreInit(EventArgs e)
        {
            StaticUtilities.ChooseMaster(Page);
            Page.Theme = "Default";
            base.OnPreInit(e);
        }



        private static string[] aspNetFormElements = new string[]
    {
        "__EVENTTARGET",
        "__EVENTARGUMENT",
        "__VIEWSTATE",
        "__EVENTVALIDATION",
        "__VIEWSTATEENCRYPTED",
    };

        protected override void Render(HtmlTextWriter writer)
        {

            StringWriter stringWriter = new StringWriter();

            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

            base.Render(htmlWriter);

            string html = stringWriter.ToString();

            int formStart = html.IndexOf("<form");

            int endForm = -1;

            if (formStart >= 0)

                endForm = html.IndexOf(">", formStart);


            if (endForm >= 0)
            {

                StringBuilder viewStateBuilder = new StringBuilder();

                foreach (string element in aspNetFormElements)
                {

                    int startPoint = html.IndexOf("<input type=\"hidden\" name=\"" + element + "\"");

                    if (startPoint >= 0 && startPoint > endForm)
                    {

                        int endPoint = html.IndexOf("/>", startPoint);

                        if (endPoint >= 0)
                        {

                            endPoint += 2;

                            string viewStateInput = html.Substring(startPoint, endPoint - startPoint);

                            html = html.Remove(startPoint, endPoint - startPoint);

                            viewStateBuilder.Append(viewStateInput).Append("\r\n");

                        }

                    }

                }


                if (viewStateBuilder.Length > 0)
                {

                    viewStateBuilder.Insert(0, "\r\n");

                    html = html.Insert(endForm + 1, viewStateBuilder.ToString());

                }

            }

            writer.Write(html);
        }
        protected void PrepareFileUpload()
        {
            StaticUtilities.PrepareFileUpload(this);
        }



        private bool IsValidSubOwner()
        {
            if (CurrentOwner != null)
            {
                return CurrentOwner.Type != 2 || RouteData.Values.ContainsKey("parentowner1");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Redirect to Error Page if there is an error or the owner does not exist
        /// </summary>
        private void RedirectToErrorPage()
        {
            if (Prtl_OwnersUtility.OwnerExists(URLBuilder.CurrentOwnerAbbr(RouteData)) &&
                 IsValidSubOwner())
            {
                LastErrorMessage = "Owner_Not_Exist";
                var exception = Server.GetLastError();
                if (exception != null)
                {
                    //LogErrorToXml(exception);
                }
                return;

                // Response.Redirect(URLBuilder.URLFormat("~", "Home", CurrentLanguage));

                // Response.Redirect(URLBuilder.URLFormat("~", "ErrorPage", CurrentLanguage));
                //when add not write in file  Response.Redirect("~/ErrorPage.aspx");
            }
        }
        private void LogErrorToXml(Exception exception)
        {
            try
            {
                string filePath = Server.MapPath("~/App_Data/ErrorLogs.xml");
                XmlDocument xmlDoc = new XmlDocument();

                // Check if the file exists
                if (File.Exists(filePath))
                {
                    xmlDoc.Load(filePath);
                }
                else
                {
                    // Create the XML structure if the file doesn't exist
                    XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    xmlDoc.AppendChild(xmlDeclaration);

                    XmlElement root = xmlDoc.CreateElement("Errors");
                    xmlDoc.AppendChild(root);
                }

                // Create new log entry
                XmlElement logEntry = xmlDoc.CreateElement("Error");

                // Create elements for time, error message, and stack trace
                XmlElement timeElement = xmlDoc.CreateElement("Time");
                timeElement.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                logEntry.AppendChild(timeElement);

                XmlElement messageElement = xmlDoc.CreateElement("Message");
                messageElement.InnerText = exception.Message;
                logEntry.AppendChild(messageElement);

                XmlElement stackTraceElement = xmlDoc.CreateElement("StackTrace");
                stackTraceElement.InnerText = exception.StackTrace;
                logEntry.AppendChild(stackTraceElement);

                // If there is an inner exception, log it as well
                if (exception.InnerException != null)
                {
                    XmlElement innerExceptionMessage = xmlDoc.CreateElement("InnerExceptionMessage");
                    innerExceptionMessage.InnerText = exception.InnerException.Message;
                    logEntry.AppendChild(innerExceptionMessage);

                    XmlElement innerExceptionStackTrace = xmlDoc.CreateElement("InnerExceptionStackTrace");
                    innerExceptionStackTrace.InnerText = exception.InnerException.StackTrace;
                    logEntry.AppendChild(innerExceptionStackTrace);
                }

                // Append the new log entry to the root
                xmlDoc.DocumentElement.AppendChild(logEntry);

                // Save the XML document
                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    //LogErrorToXml(ex);
                }
                // Handle any errors that occur while logging to XML
                // You can log this exception or handle it differently
                Console.WriteLine("Error logging to XML: " + ex.Message);
            }
        }


        private void RedirectToHomeIfAccessDenied()
        {
            var QReturnUrl = Page.Request.QueryString["ReturnUrl"];
            if (string.IsNullOrEmpty(QReturnUrl)) return;
            if (!string.IsNullOrEmpty(URLBuilder.VirtualPath(this)))
                QReturnUrl = QReturnUrl.Replace(URLBuilder.VirtualPath(this), "");

            var c = RouteUtils.GetRouteDataByUrl("~" + QReturnUrl);
            if (User.Identity.IsAuthenticated)
                ShowAccessDenied = "Show";
            else
            {
                ReturnUrl = QReturnUrl;
                ShowLogin = "Show";
            }
            var exception = Server.GetLastError();
            if (exception != null)
            {
                //LogErrorToXml(exception);
            } 
            Response.Redirect(URLBuilder.LoginURL(Page, c));

            // Response.Redirect("~/ErrorPage.aspx");
        }

        private void SetCurrentCulture()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture =
                                                  CultureInfo.CreateSpecificCulture(CurrentLanguage);
            Page.Culture = Page.UICulture = CurrentLanguage;
            //Page.Culture = Page.UICulture ;
        }

        private void SetPageTitle()
        {
            // ReSharper disable ResourceItemNotResolved
            // ReSharper disable PossibleNullReferenceException

            string maintitle = Page.Request.AppRelativeCurrentExecutionFilePath.Contains("View") && RouteData.Values.ContainsKey("ArticleAbbr")
                                   ? prtl_ArticlesUtility.GetArticleTitle(
                                       RouteData.Values["ArticleAbbr"].ToString(),
                                       CurrentLanguage, GlobalStrings.NoTranslation)
                                   : (GetLocalResourceObject("PageResource1.Title") == null
                                          ? "Please Set PageResource1.Title in your resx file"
                                          : GetLocalResourceObject("PageResource1.Title").ToString());
            Title = string.Format("{0}  {1}", maintitle, URLBuilder.OwnersNamesString(RouteData, CurrentLanguage));
        }

        #endregion Methods
    }
}