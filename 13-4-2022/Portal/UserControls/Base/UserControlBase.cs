using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI;
using BLL;
using Common;
using HtmlAgilityPack;

namespace MnfUniversity_Portals.UserControls.Base
{
    public abstract class UserControlBase : UserControl
    {
        protected string floatleft
        {
            get { return StaticUtilities.FloatLeft; }
        }

        protected string floatright
        {
            get { return StaticUtilities.FloatRight; }
        }

        protected Guid? OwnerID
        {
            get { return StaticUtilities.OwnerID(Page); }
        }


        protected T Control<T>(string id) where T : Control
        {
            if (id != null)
                return (T)FindControl(id);
            return null;
        }

        /// <summary>
        /// Decode data retrieved from the non html form to an html form.  ( &gt; -> >)
        /// </summary>
        /// <param name="data">Data in Encoded form</param>
        /// <returns> Data in HTML form</returns>
        public string Decode(object data)
        {
            return Page.Server.HtmlDecode(data == null ? "" : data.ToString());
        }

        /// <summary>
        /// Decode data retrieved from the non html form to an html form.  ( &gt; -> >)
        /// </summary>
        /// <param name="data">Data in Encoded form</param>
        /// <param name="articleTranslationID"></param>
        /// <returns> Data in HTML form</returns>
        public string Decode(object data, int articleTranslationID)
        {
            // Load the Html into the agility pack
            var doc = new HtmlDocument();
            doc.LoadHtml(data.ToString());
            var imagenodes = doc.DocumentNode.SelectNodes("//img");
            if (imagenodes != null)
            {
                // Now, using LINQ to get all Images
                var imageNodes = (imagenodes.Where(node =>
                    node.Name.ToLowerInvariant() == "img")).ToList();
                foreach (HtmlNode node in imageNodes)
                {
                    var src = node.Attributes["src"].Value;
                    if (src.StartsWith("/") || (!string.IsNullOrEmpty(URLBuilder.FilesHomeServer) && src.StartsWith(URLBuilder.FilesHomeServer))) continue;
                    // For speed of dev, I use a WebClient
                    var client = new WebClient();
                    var name = Path.GetFileName(src);
                    if (File.Exists(URLBuilder.Path(Page, PathType.Local, SiteFolders.News, name)))
                    {
                        name = "1_" + name;
                    }
                    client.DownloadFile(src, URLBuilder.Path(Page, PathType.Local, SiteFolders.News, name));

                    node.Attributes["src"].Value = URLBuilder.Path(Page, PathType.WebServer, SiteFolders.News, name);
                }
                data = doc.DocumentNode.InnerHtml;
                Prtl_ArticlesTranslationUtility.UpdateArticleTranslation(articleTranslationID, data.ToString());
            }
            return Page.Server.HtmlDecode(data.ToString());
        }
        protected string GetCommonWebResource(string imagename)
        {
            return "~/styles/UserControlImages/" + imagename + ".png";

            //Page.ClientScript.GetWebResourceUrl(typeof(StaticUtilities), "Common.Images." + imagename + ".png");
        }

        /// <summary>
        /// Find a control by the user of its ID in the Controls found inside <param name="control"></param>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        protected T GetControl<T>(string id, Control control) where T : Control
        {
            EnsureChildControls();
            return control.GetControl<T>(id);
        }

        protected T GetViewStateValueOrDefault<T>(string name, T defaultvalue)
        {
            return ViewState[name] == null ? defaultvalue : (T)ViewState[name];
        }

        #region images url

        [UrlProperty]
        public string ciurl
        {
            get
            {
                return GetViewStateValueOrDefault("ciurl", GetCommonWebResource("cancel"));
            }
            set
            {
                ViewState["ciurl"] = value;
            }
        }

        [UrlProperty]
        public string diurl
        {
            get
            {
                return GetViewStateValueOrDefault("diurl", GetCommonWebResource("delete"));
            }
            set
            {
                ViewState["diurl"] = value;
            }
        }

        [UrlProperty]
        public string eiurl
        {
            get
            {
                return GetViewStateValueOrDefault("eiurl", GetCommonWebResource("edit"));
            }
            set
            {
                ViewState["eiurl"] = value;
            }
        }

        [UrlProperty]
        public string ieurl
        {
            get
            {
                return GetViewStateValueOrDefault("ieurl", GetCommonWebResource("insert"));
            }
            set
            {
                ViewState["ieurl"] = value;
            }
        }

        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable UnusedMember.Global
        // ReSharper disable MemberCanBeProtected.Global
        [UrlProperty]
        public string MaximizeImageButtonURL
        {
            get
            {
                return GetViewStateValueOrDefault("MaximizeImageButtonURL", GetCommonWebResource("maximize"));
            }
            set
            {
                ViewState["MaximizeImageButtonURL"] = value;
            }
        }

        [UrlProperty]
        public string uiurl
        {
            get
            {
                return GetViewStateValueOrDefault("uiurl", GetCommonWebResource("update"));
            }
            set
            {
                ViewState["uiurl"] = value;
            }
        }

        #endregion images url
    }
}