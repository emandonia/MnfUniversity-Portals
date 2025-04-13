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
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.IO" %>

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
        catch (Exception ex)
        {
            if (ex != null)
            {
                //LogErrorToXml(ex);
            }
        }

    }

    //private void Application_Error(object sender, EventArgs e)
    //{
    //    var exception = Server.GetLastError();
    //    if (exception == null) return;
    //    var x = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;

    //    // Check if the request path ends with "en" or "ar", or if it's a number or exception inner exception message.
    //    if (!x.EndsWith("en") || !x.EndsWith("ar") || char.IsDigit(x, x.Length - 1) || exception.InnerException != null && (Prtl_LoggingUtility.CheckErrorInnerException((exception.InnerException != null) ? exception.InnerException.Message : null) || exception.InnerException.Message == exception.InnerException.StackTrace))
    //    {
    //        Prtl_LoggingUtility.UpdateExceptionCounter((exception.InnerException != null) ? exception.InnerException.Message : null, HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath);
    //    }
    //    else
    //    {
    //        try
    //        {
    //            // Log the error details
    //            //LogErrorToXml(exception);

    //            // Other logging
    //            Prtl_LoggingUtility.InsertNewErrorLog(Session["UserName"] as string,
    //                exception.Message, ((exception.InnerException != null) ? exception.InnerException.Message : null),
    //                exception.StackTrace, ((exception.InnerException != null) ? exception.InnerException.StackTrace : null),
    //                HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath);

    //            // Set the last error message
    //            PageBase.LastErrorMessage = (exception.InnerException == null) ? exception.Message : exception.InnerException.Message;

    //            // Redirect to error page
    //            Response.Redirect(URLBuilder.URL("~", HttpContext.Current.Request.RequestContext.RouteData, "ErrorPage"));
    //        }
    //        catch
    //        {
    //            // Handle any exceptions that might occur while logging
    //        }
    //    }

    //    Exception exception0 = Server.GetLastError();
    //    // Handle or log the last exception
    //    Response.Redirect(URLBuilder.URL("~", HttpContext.Current.Request.RequestContext.RouteData, "ErrorPage"));
    //}

    // Method to log error details to an XML file
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
            messageElement.InnerText ="==========Message============"+ exception.Message;
            logEntry.AppendChild(messageElement);

            XmlElement stackTraceElement = xmlDoc.CreateElement("StackTrace");
            stackTraceElement.InnerText ="==========StackTrace============"+ exception.StackTrace;
            logEntry.AppendChild(stackTraceElement);

            // If there is an inner exception, log it as well
            if (exception.InnerException != null)
            {
                XmlElement innerExceptionMessage = xmlDoc.CreateElement("InnerExceptionMessage");
                innerExceptionMessage.InnerText ="==========InnerException============"+exception.InnerException.Message;
                logEntry.AppendChild(innerExceptionMessage);

                XmlElement innerExceptionStackTrace = xmlDoc.CreateElement("InnerExceptionStackTrace");
                innerExceptionStackTrace.InnerText ="=============InnerExceptionStackTrace================"+ exception.InnerException.StackTrace;
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

    //old log 
    private void Application_Error(object sender, EventArgs e)

    {
        var exception = Server.GetLastError();
        if (exception == null) return;
        var x = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;
        if (exception != null)
        {
            //LogErrorToXml(exception);
        }
        //bool t = x.IsMatch(SeatnoTextBox1.Text);
        if (!x.EndsWith("en") || !x.EndsWith("ar") || char.IsDigit(x, x.Length - 1) || exception.InnerException != null && (Prtl_LoggingUtility.CheckErrorInnerException((exception.InnerException != null) ? exception.InnerException.Message : null) || exception.InnerException.Message == exception.InnerException.StackTrace))
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

               // Response.Redirect(URLBuilder.URL("~", HttpContext.Current.Request.RequestContext.RouteData, "ErrorPage"));

                //  Response.Redirect(URLBuilder.URL("~", HttpContext.Current.Request.RequestContext.RouteData, "Home"));

            }
            catch (Exception exception1)
            {
                if (exception1 != null)
                {
                    //LogErrorToXml(exception1);
                }
            }
        }
        Exception exception0 = Server.GetLastError();
        if (exception0 != null)
        {
            //LogErrorToXml(exception0);
        }
        // Log the error or handle as needed

        // Redirect to a custom error page

        //  Response.Redirect(URLBuilder.URL("~", HttpContext.Current.Request.RequestContext.RouteData, "Home"));
       // Response.Redirect(URLBuilder.URL("~", HttpContext.Current.Request.RequestContext.RouteData, "ErrorPage"));


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
