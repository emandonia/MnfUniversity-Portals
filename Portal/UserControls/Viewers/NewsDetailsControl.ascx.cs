using System;
using System.Data;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;


namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class NewsDetailsControl : ViewersBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var x = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                if (x.Type == 1)
                {
                   

                        NewsDetailsDataSource.TableName = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) +
                                                          "_trans";
                        NewsDetailsDataSource.Where = "News_Id == @id and prtl_Language.LCID == @lang and prtl_news_" +
                                                      URLBuilder.CurrentOwnerAbbr(Page.RouteData) +
                                                      ".Published == True and prtl_news_" +
                                                      URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "" +
                                                      ".prtl_Owner.abbr.ToLower() == @owner";

                        NewsDetailsDataSource.WhereParameters.Add("id", DbType.Int32,
                            Page.RouteData.Values["id"].ToString());
                        NewsDetailsDataSource.WhereParameters.Add("lang", DbType.String,
                            Page.RouteData.Values["lang"].ToString());
                        NewsDetailsDataSource.WhereParameters.Add("owner", DbType.String,
                            Page.RouteData.Values["currentowner"].ToString());

                    }
                    else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
                    {
                        NewsDetailsDataSource.TableName = "prtl_news_univ_trans";
                        NewsDetailsDataSource.Where = "News_Id == @id and prtl_Language.LCID == @lang and" +
                                                      " prtl_news_univ.Published == True";
                        NewsDetailsDataSource.WhereParameters.Add("id", DbType.Int32,
                            Page.RouteData.Values["id"].ToString());
                        NewsDetailsDataSource.WhereParameters.Add("lang", DbType.String,
                            Page.RouteData.Values["lang"].ToString());


                    }
                    else
                    {
                        NewsDetailsDataSource.TableName = "prtl_News_Translations";
                        NewsDetailsDataSource.Where =
                            "News_Id == @id and prtl_Language.LCID == @lang and prtl_New.Published == True and prtl_New.prtl_Owner.abbr.ToLower() == @owner";
                        NewsDetailsDataSource.WhereParameters.Add("id", DbType.Int32,
                            Page.RouteData.Values["id"].ToString());
                        NewsDetailsDataSource.WhereParameters.Add("lang", DbType.String,
                            Page.RouteData.Values["lang"].ToString());
                        NewsDetailsDataSource.WhereParameters.Add("owner", DbType.String,
                            Page.RouteData.Values["currentowner"].ToString());
                    }
                }
            }

        
        protected string BigImageURL(object id, string abbr)
        {

            if (abbr == null)
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_univ_NewsByID(Convert.ToInt32(id)).News_img + "");

            }
            else if (abbr.ToLower() == "fci")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_fci_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "fee")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_fee_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "eng")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_eng_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "nur")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_nur_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "edu")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_edu_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "sci")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_sci_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "edv")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_edv_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "agr")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_agr_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "hec")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_hec_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "law")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_law_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "fpe")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_fpe_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
                //********************
            else if (abbr.ToLower() == "pharm")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_Pharm_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "vmed")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_VMed_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
                //******************************
            else if (abbr.ToLower() == "fa")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_fas_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "art")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_art_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "ho")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_hos_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "med")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_med_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "liv")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_liv_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "com")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_com_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_ecedu_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "media")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_media_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "dent")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.Get_dent_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News, Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(id)).News_img + "");
            }


        }
        protected string SmallImageURL(object id, string abbr)
        {
            if (abbr == null)
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_univ_NewsByID(Convert.ToInt32(id)).News_img + "");

            }
            else if (abbr.ToLower() == "fci")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_fci_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "fee")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_fee_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "eng")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_eng_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "nur")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_nur_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "edu")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_edu_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "sci")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_sci_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "edv")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_edv_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "agr")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_agr_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "hec")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_hec_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "law")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_law_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "fpe")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_fpe_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
                //*****************
            else if (abbr.ToLower() == "pharm")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_Pharm_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "vmed")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_VMed_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
                //**********************
            else if (abbr.ToLower() == "fa")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_fas_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "art")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_art_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "ho")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_hos_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "med")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_med_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "liv")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_liv_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "com")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_com_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_ecedu_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "media")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_media_NewsByID(Convert.ToInt32(id)).News_img + "");
            }
            else if (abbr.ToLower() == "dent")
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.Get_dent_NewsByID(Convert.ToInt32(id)).News_img + "");
            }

            else
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(id)).News_img + "");
            }

        }

        protected string getNewsDate(object id, string abbr)
        {
            return Prtl_NewsUtility.GetNewsDateByIDAbbr(id, abbr, "NewsViewerControl1");
        }
    }
}