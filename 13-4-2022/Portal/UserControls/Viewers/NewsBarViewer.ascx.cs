using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class NewsBarViewer : ViewersBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["__ASYNCPOST"] != "true")
            {
                FillNews(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
            }
        }
        private void FillNews(string abbr)
        {
            
            if (abbr == null)
            {
                IEnumerable<prtl_news_univ_tran> news =
           Prtl_NewsTransUtility.GetTop_univ_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });

            }
            else if (abbr == "fci")
            {
                IEnumerable<prtl_news_fci_tran> news =
           Prtl_NewsTransUtility.GetTop_fci_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
                //333333333333333
            else if (abbr.ToLower() == "media")
            {
                IEnumerable<prtl_news_media_tran> news =
           Prtl_NewsTransUtility.GetTop_media_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "fee")
            {
                IEnumerable<prtl_news_fee_tran> news =
           Prtl_NewsTransUtility.GetTop_fee_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "eng")
            {
                IEnumerable<prtl_news_eng_tran> news =
           Prtl_NewsTransUtility.GetTop_eng_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "nur")
            {
                IEnumerable<prtl_news_nur_tran> news =
            Prtl_NewsTransUtility.GetTop_nur_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "edu")
            {
                IEnumerable<prtl_news_edu_tran> news =
           Prtl_NewsTransUtility.GetTop_edu_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "sci")
            {
                IEnumerable<prtl_news_sci_tran> news =
           Prtl_NewsTransUtility.GetTop_sci_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "edv")
            {
                IEnumerable<prtl_news_edv_tran> news =
            Prtl_NewsTransUtility.GetTop_edv_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "agr")
            {
                IEnumerable<prtl_news_agr_tran> news =
            Prtl_NewsTransUtility.GetTop_agr_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "hec")
            {
                IEnumerable<prtl_news_hec_tran> news =
            Prtl_NewsTransUtility.GetTop_hec_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "law")
            {
                IEnumerable<prtl_news_law_tran> news =
           Prtl_NewsTransUtility.GetTop_law_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "fpe")
            {
                IEnumerable<prtl_news_fpe_tran> news =
            Prtl_NewsTransUtility.GetTop_fpe_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
                //**********************
            else if (abbr == "vmed")
            {
                IEnumerable<prtl_news_VMed_tran> news =
            Prtl_NewsTransUtility.GetTop_VMed_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "pharm")
            {
                IEnumerable<prtl_news_Pharm_tran> news =
            Prtl_NewsTransUtility.GetTop_Pharm_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
                //*******************************
            else if (abbr == "fa")
            {
                IEnumerable<prtl_news_fa_tran> news =
            Prtl_NewsTransUtility.GetTop_fas_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "art")
            {
                IEnumerable<prtl_news_art_tran> news =
            Prtl_NewsTransUtility.GetTop_art_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "ho")
            {
                IEnumerable<prtl_news_ho_tran> news =
            Prtl_NewsTransUtility.GetTop_ho_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "med")
            {
                IEnumerable<prtl_news_med_tran> news =
           Prtl_NewsTransUtility.GetTop_med_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "liv")
            {
                IEnumerable<prtl_news_liv_tran> news =
            Prtl_NewsTransUtility.GetTop_liv_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr == "com")
            {
                IEnumerable<prtl_news_com_tran> news =
           Prtl_NewsTransUtility.GetTop_com_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            ////12121212
            else if (abbr.ToLower() == "ECEDU".ToLower())
            {
                IEnumerable<prtl_news_ECEDU_tran> news =
           Prtl_NewsTransUtility.GetTop_ecedu_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr.ToLower() == "dent".ToLower())
            {
                IEnumerable<prtl_news_dent_tran> news =
           Prtl_NewsTransUtility.GetTop_dent_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr.ToLower() == "ai".ToLower())
            {
                IEnumerable<prtl_news_AI_tran> news =
           Prtl_NewsTransUtility.GetTop_ai_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else if (abbr.ToLower() == "media".ToLower())
            {
                IEnumerable<prtl_news_media_tran> news =
           Prtl_NewsTransUtility.GetTop_media_News(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
            else
            {
                IEnumerable<prtl_News_Translation> news =
           Prtl_NewsTransUtility.GetTopNews(StaticUtilities.Currentlanguage(Page), 5, StaticUtilities.OwnerID(Page));
                StaticUtilities.FillShow(news, NewsShow, y => new HyperLink
                {
                    Text = y.News_Head,
                    NavigateUrl = URLBuilder.NewItemUrl(Page.RouteData, y.News_Id, URLBuilder.CurrentOwnerAbbr(Page.RouteData))
                });
            }
           
        }
    }
}