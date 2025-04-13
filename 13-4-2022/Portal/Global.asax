<%@ Application CodeBehind="Global.asax.cs" Language="C#" Inherits="MnfUniversity_Portals.Global" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Mis_DAL" %>
<%@ Import Namespace="MnfUniversity_Portals" %>
<%@ Import Namespace="Portal_DAL" %>
<%-- ReSharper disable EmptyGeneralCatchClause --%>


<script RunAt="server">

   

    private void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
       
        URLBuilder.BuildRoutes<NewsRSSHandler, EventsRSSHandler>(RouteTable.Routes, Server);
        //string ServerSoftware = Context.Request.ServerVariables["SERVER_SOFTWARE"];
        //string server = Context.Request.ServerVariables["SERVER_NAME"];
        //string port = Context.Request.ServerVariables["SERVER_PORT"];
        //HttpRuntime.Cache.Insert("basePath", "http://" + server + ":" + port + "/");
        
        // ...
        //P_dc=new PortalDataContextDataContext()
    M_dc = new MisDataContext();
    }
    
    
    private void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

        try
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "") { Expires = DateTime.Now.AddYears(-1) };
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            var cookie2 = new HttpCookie("ASP.NET_SessionId", "") { Expires = DateTime.Now.AddYears(-1) };
            Response.Cookies.Add(cookie2);

            FormsAuthentication.RedirectToLoginPage();
           //P_dc.Dispose();
            M_dc.Dispose();
        }
        catch
        {

        }

    }

    private void Application_Error(object sender, EventArgs e)
    {
        var exception = Server.GetLastError();
        if (exception == null) return;
        var x = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;
        
       
        //bool t = x.IsMatch(SeatnoTextBox1.Text);
        if (!x.EndsWith("en") || !x.EndsWith("ar")|| char.IsDigit(x,x.Length-1)|| exception.InnerException != null && (Prtl_LoggingUtility.CheckErrorInnerException((exception.InnerException != null) ? exception.InnerException.Message : null) || exception.InnerException.Message==exception.InnerException.StackTrace))
        {
            Prtl_LoggingUtility.UpdateExceptionCounter((exception.InnerException != null) ? exception.InnerException.Message : null, HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath);
        }
        else
        {
            try
            {
                Prtl_LoggingUtility.InsertNewErrorLog(Session["UserName"] as string,
                    exception.Message, ((exception.InnerException != null) ? exception.InnerException.Message : null),
                    exception.StackTrace, ((exception.InnerException != null) ? exception.InnerException.StackTrace : null),
                    HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath);
                PageBase.LastErrorMessage = (exception.InnerException == null) ? exception.Message : exception.InnerException.Message;
                Response.Redirect(URLBuilder.URL("~", HttpContext.Current.Request.RequestContext.RouteData, "Home"));

            }
            catch
            {

            }
        }
    }

   
    private void Session_Start(object sender, EventArgs e)
    {
        Session.Timeout = 12000;
        
        // Code that runs when a new session is started
    }

    private void Session_End(object sender, EventArgs e)
    {
        if (Session["UserName"] == null) return;
        Prtl_UsersUtility.Update((string)Session["UserName"], false);
        Session["UserName"] = null;
        Session.Clear();
    }

</script>
<%-- ReSharper restore EmptyGeneralCatchClause --%>
