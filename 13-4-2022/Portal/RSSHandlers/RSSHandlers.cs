using System.Collections.Generic;
using System.Web;
using BLL;
using Common;

public class EventsRSSHandler : RSSGenerator
{
    public EventsRSSHandler()
    {
        Title = (CurrentLanguage != "ar")
                    ? (RssOwnerTitle + "'s " + Resources.EventsRSSHandler.NewsFeedTitle)
                    : Resources.EventsRSSHandler.NewsFeedTitle + " " + RssOwnerTitle;
        Description = Resources.EventsRSSHandler.FeedDescription + RssOwnerTitle;
    }

    protected override void PopulateFeed()
    {
        IEnumerable<Prtl_HighlightsUtility.Data> data = Prtl_HighlightsUtility.GetDateAndDetails(CurrentLanguage);
        foreach (Prtl_HighlightsUtility.Data prtlEvent in data)
        {
            AddItem(new RSSItem
                        {
                            Date = prtlEvent.Date,
                            Description = HttpUtility.HtmlDecode(prtlEvent.Details),
                        });
        }
    }
}

public class NewsRSSHandler : RSSGenerator
{
    public NewsRSSHandler()
    {
        Title = (CurrentLanguage != "ar")
                    ? (RssOwnerTitle + "'s " + Resources.NewsRSSHandler.NewsFeedTitle)
                    : Resources.NewsRSSHandler.NewsFeedTitle + " " + RssOwnerTitle;
        Description = Resources.NewsRSSHandler.FeedDescription + RssOwnerTitle;

    }

    protected override void PopulateFeed()
    {
        IEnumerable<Prtl_NewsTransUtility.NewsDetails> c = Prtl_NewsTransUtility.GetNewsDetails(CurrentLanguage,URLBuilder.CurrentOwnerAbbr(CurrentRouteData),
                                                                                                CurrentOwnerID);
        var im = "http://mu.menofia.edu.eg/PrtlFiles/uni/Portal/Images/";  
        foreach (var prtlNew in c)
        {
            AddItem(new RSSItem
                        {
                            Date = prtlNew.Date,
                            Title = prtlNew.Head,
                            //"<![CDATA[<img src=" + prtlNew.Image +"/>]]>"

                            Description = "<![CDATA[Image inside RSS<img src=" + im + prtlNew.Image + " alt=" + "my image" + "/>]><br/>" + HttpUtility.HtmlDecode(prtlNew.Abbr),
                            Link = ResolveServerUrl(URLBuilder.NewItemUrl(CurrentRouteData, prtlNew.ID,URLBuilder.CurrentOwnerAbbr(CurrentRouteData)).ToLower().TrimStart('~'))
                        
                        });
        }
    }
}