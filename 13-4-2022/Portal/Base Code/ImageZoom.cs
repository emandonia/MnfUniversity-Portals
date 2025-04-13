using System;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Common;

namespace App_Code
{
    [ToolboxData("<{0}:ImageZoom runat=server></{0}:ImageZoom>")]
    public class ImageZoom : CompositeControl
    {
        private Page page;
       
        public string BigImageURL { get { return (ViewState["BigImageURL"] == null) ? "" : ViewState["BigImageURL"].ToString(); } set { ViewState["BigImageURL"] = value; } }

        public String ImageAltText { get; set; }

        public String ImageClass { get; set; }

        public String ImageTitle { get; set; }

        public new Page Page
        {
            get { return page ?? (page = base.Page); }
            set { page = value; }
        }

        public string SmallImageURL { get { return (ViewState["SmallImageURL"] == null) ? "" : ViewState["SmallImageURL"].ToString(); } set { ViewState["SmallImageURL"] = value; } }

        protected override void OnInit(EventArgs e)
        {
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("FancyImageZoom.jquery.fancybox-1.3.4.pack.js"))
            {
                Page.ClientScript.RegisterClientScriptResource(GetType(), "FancyImageZoom.jquery.fancybox-1.3.4.pack.js");
            }
           
            //if (!Page.ClientScript.IsClientScriptIncludeRegistered("FancyImageZoom.jquery-1.4.3.min.js"))
            //{
            //    Page.ClientScript.RegisterClientScriptResource(GetType(), "FancyImageZoom.jquery-1.4.3.min.js");
            //}
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("FancyImageZoom.jquery.fancybox-1.3.4.js"))
            {
                Page.ClientScript.RegisterClientScriptResource(GetType(), "FancyImageZoom.jquery.fancybox-1.3.4.js");
            }
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Page.Header.Controls.OfType<HtmlLink>().SingleOrDefault(hl => hl.Attributes["href"] == "../Scripts/fancybox/jquery.fancybox-1.3.4.css") == null)
            {
                var fancyBoxCSSLink = new HtmlLink();
                fancyBoxCSSLink.Attributes.Add("rel", "stylesheet");
                fancyBoxCSSLink.Attributes.Add("type", "text/css");
                fancyBoxCSSLink.Attributes.Add("media", "screen");
                fancyBoxCSSLink.Attributes.Add("href", "../Scripts/fancybox/jquery.fancybox-1.3.4.css");

                Page.Header.Controls.Add(fancyBoxCSSLink);
            }


            base.OnLoad(e);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            OnInit(EventArgs.Empty);
            OnLoad(EventArgs.Empty);
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "imagebox");
            writer.AddAttribute(HtmlTextWriterAttribute.Href, BigImageURL == null ? "" : Page.ResolveUrl(BigImageURL));
            writer.AddAttribute(HtmlTextWriterAttribute.Title, ImageTitle);
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, ImageClass);
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, ImageAltText);
            writer.AddAttribute(HtmlTextWriterAttribute.Src, SmallImageURL == null ? "" : Page.ResolveUrl(SmallImageURL));
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();//Img
            writer.RenderEndTag();//A
        }
    }
}