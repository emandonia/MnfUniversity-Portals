﻿using System.IO;
using HtmlAgilityPack;

namespace App_Code
{
    public static class OneTimeUsageUtilities
    {
        //public static void ConvertNewsAbbrHtmlToText()
        //{
        //    var dc = new Portal_DAL.PortalDataContextDataContext();
        //    foreach (var prtlNewsTranslation in dc.prtl_News_Translations)
        //        prtlNewsTranslation.News_Abbr = ConvertHtml(prtlNewsTranslation.News_Abbr);
        //    dc.SubmitChanges();

        //}

        private static string ConvertHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
          
            var sw = new StringWriter();
            ConvertTo(doc.DocumentNode, sw);
            sw.Flush();
            return sw.ToString();
        }

        private static void ConvertTo(HtmlNode node, TextWriter outText)
        {
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:
                    // don't output comments
                    break;

                case HtmlNodeType.Document:
                    ConvertContentTo(node, outText);
                    break;

                case HtmlNodeType.Text:
                    // script and style must not be output
                    var parentName = node.ParentNode.Name;
                    if ((parentName == "script") || (parentName == "style"))
                        break;

                    // get text
                    var html = ((HtmlTextNode)node).Text;

                    // is it in fact a special closing node output as text?
                    if (HtmlNode.IsOverlappedClosingElement(html))
                        break;

                    // check the text is meaningful and not a bunch of whitespaces
                    if (html.Trim().Length > 0)
                    {
                        outText.Write(HtmlEntity.DeEntitize(html));
                    }
                    break;

                case HtmlNodeType.Element:
                    switch (node.Name)
                    {
                        case "p":
                            // treat paragraphs as crlf
                            outText.Write("\r\n");
                            break;
                    }

                    if (node.HasChildNodes)
                    {
                        ConvertContentTo(node, outText);
                    }
                    break;
            }
        }
        private static void ConvertContentTo(HtmlNode node, TextWriter outText)
        {
            foreach (var subnode in node.ChildNodes)
            {
                ConvertTo(subnode, outText);
            }
        }
    }
}