using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Xml;
using Common;
using System.ServiceModel.Syndication;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable IntroduceOptionalParameters.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable CheckNamespace

#region RSSItem class

/// <summary>
/// An RSS feed item.
/// </summary>
public class RSSItem
{
    /// <summary>
    /// Gets or sets the author of the item.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets the date of the item.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the description for the item.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the URL for the item.
    /// </summary>
    /// automatic property
    public string Link
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the title for the item.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Gets or sets the image for the item.
    /// </summary>
    public string Image { get; set; }
}

#endregion RSSItem class

#region RSSItemComparer class

internal class RSSItemComparer : IComparer<RSSItem>
{
    public int Compare(RSSItem x, RSSItem y)
    {
        return -(x.Date.CompareTo(y.Date));
    }
}

#endregion RSSItemComparer class

#region RSSGenerator class

/// <summary>
/// Helper class to generate RSS feeds.
/// </summary>
public class RSSGenerator : IHttpHandler
{
    /// <summary>

    /// Returns a site relative HTTP path from a partial path starting out with a ~.

    /// Same syntax that ASP.Net internally supports but this method can be used

    /// outside of the Page framework.

    ///

    /// Works like Control.ResolveUrl including support for ~ syntax

    /// but returns an absolute URL.

    /// </summary>

    /// <param name="originalUrl">Any Url including those starting with ~</param>

    /// <returns>relative url</returns>

    /// <summary>Category for RSS properties</summary>
    protected const string RSSCategory = "RSS";

    private List<RSSItem> items = new List<RSSItem>();

    /// <summary>
    /// This method returns a fully qualified absolute server Url which includes
    /// the protocol, server, port in addition to the server relative Url.
    ///
    /// Works like Control.ResolveUrl including support for ~ syntax
    /// but returns an absolute URL.
    /// </summary>
    /// <returns></returns>
    public RSSGenerator()
    {
        Thread.CurrentThread.CurrentUICulture =
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(CurrentLanguage);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    protected string CurrentLanguage
    {
        get { return StaticUtilities.Currentlanguage(CurrentRouteData); }
    }

    protected Guid CurrentOwnerID
    {
        get { return URLBuilder.CurrentOwnerid(CurrentRouteData); }
    }

    protected RouteData CurrentRouteData
    {
        get { return HttpContext.Current.Request.RequestContext.RouteData; }
    }

    protected string RssOwnerTitle
    {
        get
        {
            return URLBuilder.OwnersNamesString(CurrentRouteData, CurrentLanguage);
        }
    }

    public static string ResolveServerUrl(string serverUrl, bool forceHttps)
    {
        // *** Is it already an absolute Url?

        if (serverUrl.IndexOf("://", StringComparison.Ordinal) > -1)

            return serverUrl;

        // *** Start by fixing up the Url an Application relative Url

        string newUrl = ResolveUrl(serverUrl);

        Uri originalUri = HttpContext.Current.Request.Url;

        newUrl = (forceHttps ? "https" : originalUri.Scheme) +

                 "://" + originalUri.Authority + newUrl;

        return newUrl;
    }

    /// <summary>
    /// This method returns a fully qualified absolute server Url which includes
    /// the protocol, server, port in addition to the server relative Url.
    ///
    /// It work like Page.ResolveUrl, but adds these to the beginning.
    /// This method is useful for generating Urls for AJAX methods
    /// </summary>
    /// <returns></returns>
    public static string ResolveServerUrl(string serverUrl)
    {
        return ResolveServerUrl(serverUrl, false);
    }

    public static string ResolveUrl(string originalUrl)
    {
        if (originalUrl == null)

            return null;

        // *** Absolute path - just return

        if (originalUrl.IndexOf("://", StringComparison.Ordinal) != -1)

            return originalUrl;

        // *** Fix up image path for ~ root app dir directory

        if (originalUrl.StartsWith("~"))
        {
            string newUrl;

            if (HttpContext.Current != null)

                newUrl = HttpContext.Current.Request.ApplicationPath +

                      originalUrl.Substring(1).Replace("//", "/");

            else

                // *** Not context: assume current directory is the base directory

                throw new ArgumentException("Invalid URL: Relative URL not allowed.");

            // *** Just to be sure fix up any double slashes

            return newUrl;
        }

        return originalUrl;
    }

    /// <summary>
    /// Adds an RSS item to the feed.
    /// </summary>
    public void AddItem(RSSItem item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Clears the RSS items from the feed.
    /// </summary>
    public void ClearItems()
    {
        items.Clear();
    }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";

        string rss = RSSFeedXml();
        context.Response.Write(rss);
    }

    #region properties

    private string description;
    private string link;
    private string title;
    private string image;

    /// <summary>
    /// Gets or sets the description for this feed.
    /// </summary>
    [Description("Description of the feed")]
    [Category(RSSCategory)]
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    /// <summary>
    /// Gets or sets the URL for the website associated with this feed.
    /// </summary>
    [Description("The URL of the homepage for this feed")]
    [Category(RSSCategory)]
    public string Link
    {
        get { return link; }
        set { link = value; }
    }

    /// <summary>
    /// Gets or sets the title of the feed.
    /// </summary>
    [Description("The title of the RSS feed")]
    [Category(RSSCategory)]
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    /// <summary>
    /// Gets or sets the image of the feed.
    /// </summary>
    [Description("The image of the RSS feed")]
    [Category(RSSCategory)]
    public string Image
    {
        get { return image; }
        set { image = value; }
    }
    #endregion properties

    /// <summary>
    /// Returns the XML for the RSS feed.
    /// </summary>
    public string RSSFeedXml()
    {
        PopulateFeed();

        var stringWriter = new StringWriter();
        var writer = new XmlTextWriter(stringWriter);

        // start document
        writer.WriteStartElement("rss");
        writer.WriteAttributeString("version", "2.0");

        // channel
        writer.WriteStartElement("channel");

        writer.WriteElementString("title", title);
       
        writer.WriteElementString("link", link);
        writer.WriteElementString("description", description);
       
        items.Sort(new RSSItemComparer());
        foreach (RSSItem item in items)
        {
            writer.WriteStartElement("item");
            writer.WriteElementString("title", item.Title);
            writer.WriteElementString("image", item.Image);
            writer.WriteElementString("description", item.Description);
            writer.WriteElementString("pubDate", item.Date.ToString("r"));
            writer.WriteElementString("author", item.Author);
            writer.WriteElementString("link", item.Link);
            writer.WriteEndElement(); // item
        }

        // end channel
        writer.WriteEndElement(); //channel

        // end document
        writer.WriteEndElement(); //rss

        writer.Flush();
        return stringWriter.ToString();
    }

    /// <summary>
    /// Populates the feed. Override to populate the feed
    /// </summary>
    protected virtual void PopulateFeed()
    {
    }
}

#endregion RSSGenerator class

public class MyHandlerRouteHandler<T> : IRouteHandler where T : RSSGenerator, new()
{
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        return new T();
    }
}