using System;
using System.Linq;
using System.Web.UI.WebControls;
using BLL;
using Common;
using FancyImageZoom;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;


namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class NewsViewerControl : UserControlBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ViewerID"] = ID;
            if (!IsPostBack)
            {
                if (Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData)).Type == 1)
                {
                    NewsLinqDataSource.TableName = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";
                    NewsLinqDataSource.OrderBy = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) +
                                                 ".News_date desc";
                    Session["TbName2"] = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";
                    Session["TbName3"] = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) +
                                                 ".News_date desc";
                }
                else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null && this.ID == "NewsViewerControl1")
                {
                    NewsLinqDataSource.TableName = "prtl_news_univ_trans";
                    NewsLinqDataSource.OrderBy = "prtl_news_univ.News_date desc";
                    Session["TbName2"] = "prtl_news_univ_trans";
                    Session["TbName3"] = "prtl_news_univ.News_date desc";
                }
                else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null && this.ID == "NewsViewerControl2")
                {
                    NewsLinqDataSource.TableName = "prtl_News_Translations";
                    NewsLinqDataSource.OrderBy = "prtl_New.News_date desc";
                    Session["TbName2"] = "prtl_News_Translations";
                    Session["TbName3"] = "prtl_New.News_date desc";
                }
                else
                {
                    NewsLinqDataSource.TableName = "prtl_News_Translations";
                    NewsLinqDataSource.OrderBy = "prtl_New.News_date desc";
                    Session["TbName2"] = "prtl_News_Translations";
                    Session["TbName3"] = "prtl_New.News_date desc";
                }
            }
            else
            {
                NewsLinqDataSource.TableName =  (string) Session["TbName2"];
                NewsLinqDataSource.OrderBy = (string) Session["TbName3"];
            }


        }

        private ImageZoom NewsImageZoom
        {
            get
            {
                return (ImageZoom)NewsImageZoom;
            }
        }


        public int TopNewsCounter
        {
            private get
            {
                return ViewState["TopNewsCounter"] == null ? -1 : (int)ViewState["TopNewsCounter"];
            }
            set
            {
                ViewState["TopNewsCounter"] = value;
            }
        }

        public string NewsViewerID
        {
             get
            {
                return this.ID;
            }
           
        }
        public DateTime FilterDate
        {
            private get
            {
                return ViewState["FilterDate"] == null ? DateTime.MinValue : (DateTime)ViewState["FilterDate"];
            }
            set
            {
                ViewState["FilterDate"] = value;
            }
        }


        public DateTime FilterDate2
        {
            private get
            {
                return ViewState["FilterDate2"] == null ? DateTime.MinValue : (DateTime)ViewState["FilterDate2"];
            }
            set
            {
                ViewState["FilterDate2"] = value;
            }
        }


        protected void AddNewsItemButton_Click(object sender, EventArgs e)
        {
            InlineNewsDetailsViewControl.ShowInsert(StaticUtilities.OwnerID(Page), "0");
        }

        protected string BigImageURL(object id,string abbr)
        {
            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            if (ID == "NewsViewerControl1")
            {
                if (abbr == null && type == 0)
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_univ_NewsByID(Convert.ToInt32(id)).News_img + "");

                }
                else if (abbr != null && (abbr.ToLower() == "fci" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_fci_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_fee_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_eng_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_nur_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_edu_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_sci_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_edv_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_agr_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_hec_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_law_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_fpe_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                //***************
                else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_VMed_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_Pharm_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                //*************************
                else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_fas_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_art_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_hos_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_med_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_liv_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_com_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                //12121212
                else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_ecedu_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_media_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr != null && (abbr.ToLower() == "ai" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_ai_NewsByID(Convert.ToInt32(id)).News_img + "");
                }//fatma6-6-2022
                else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.Get_dent_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                        Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(id)).News_img + "");
                }
            }
            else
            {
                //return URLBuilder.GetURLIfExists(Page, SiteFolders.News,
                //        Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(id)).News_img + "");
                string url= "http://" + Request.Url.Authority + "/PrtlFiles/Sectors/" + Prtl_NewsUtility.GetOwnerByNewsID(Convert.ToInt32(id)).Abbr + "/Portal/Images/" +Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(id)).News_img ;
                return url;
            }


        }
        protected string SmallImageURL(object id,string abbr)
        {
            if (ID == "NewsViewerControl1")
            {
                if (abbr == null)
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_univ_NewsByID(Convert.ToInt32(id)).News_img + "");

                }
                else if (abbr.ToLower() == "fci")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_fci_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "fee")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_fee_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "eng")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_eng_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "nur")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_nur_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "edu")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_edu_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "sci")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_sci_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "edv")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_edv_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "agr")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_agr_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "hec")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_hec_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "law")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_law_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "fpe")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_fpe_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                //*********************
                else if (abbr.ToLower() == "pharm")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_Pharm_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "vmed")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_VMed_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                //*************************
                else if (abbr.ToLower() == "fa")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_fas_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "art")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_art_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "ho")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_hos_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "med")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_med_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "liv")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_liv_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "com")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_com_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_ecedu_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "media")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_media_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else if (abbr.ToLower() == "ai")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_ai_NewsByID(Convert.ToInt32(id)).News_img + "");
                }//fatma 6-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.Get_dent_NewsByID(Convert.ToInt32(id)).News_img + "");
                }
                else
                {
                    return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(id)).News_img + "");
                }
            }
            else
            {
                return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb,
                        Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(id)).News_img + "");
            }

        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var l = (LinkButton)sender;
            Prtl_NewsUtility.DeleteItem(int.Parse(l.CommandArgument), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
            NewsListView.DataBind();
        }

        protected void DeleteTranslationLinkButton_Click(object sender, EventArgs e)
        {
            var l = (LinkButton)sender;
            Prtl_NewsTransUtility.DeleteTranslastion(int.Parse(l.CommandArgument), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
            NewsListView.DataBind();
        }

        protected bool DeleteTransVisible(int eval,string abbr)
        {
            return Prtl_NewsTransUtility.GetNewsTranslationCount(eval,abbr) != 1;
        }

        protected void EditImageButton_Click(object sender, EventArgs e)
        {
            ShowEditorAtMode(sender, DetailsViewMode.Edit);
        }

        protected void InlineNewsDetailsViewControl_ItemAdded(object sender, DetailsViewInsertedEventArgs e)
        {
            NewsListView.DataBind();
        }

        protected void InlineNewsDetailsViewControl_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            NewsListView.DataBind();
        }

        protected void InsertTranslation_Click(object sender, EventArgs e)
        {
            ShowEditorAtMode(sender, DetailsViewMode.Insert);
        }

        protected void ManageImageButton_Click(object sender, EventArgs e)
        {
            ShowEditorAtMode(sender, DetailsViewMode.ReadOnly);
        }

        protected void ManageNewsItemPanel_Load(object sender, EventArgs e)
        {
            var panel = (Panel)sender;
            StaticUtilities.PrepareFileUpload(this);
            StaticUtilities.SetPanelVisibility(panel, StaticUtilities.NewseditorRoles, this, false);
        }

        protected void NewsLinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            
            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            if (this.ID == "NewsViewerControl1")
            {
                if (abbr == null && type == 0)
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_univ_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);



                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_univ_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_univ_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }


                else if (abbr != null && (abbr.ToLower() == "fci" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_fci_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_fci_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_fci_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_fee_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_fee_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_fee_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_eng_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_eng_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_eng_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_nur_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_nur_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_nur_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_edu_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_edu_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_edu_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_sci_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_sci_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_sci_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_edv_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_edv_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_edv_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_agr_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_agr_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_agr_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_hec_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_hec_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_hec_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_law_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_law_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_law_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_fpe_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_fpe_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_fpe_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                //***************************
                else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_VMed_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_VMed_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_VMed_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_Pharm_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_Pharm_ByDate(
                                StaticUtilities.Currentlanguage(Page), FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_Pharm_News(StaticUtilities.Currentlanguage(Page),
                            OwnerID);
                    }
                }
                ///***************************
                else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_fas_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_fa_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_fas_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_art_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_art_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_art_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_ho_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_ho_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_hos_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_med_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_med_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_med_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_liv_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_liv_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_liv_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_com_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_com_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_com_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                //12121212
                else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_ecedu_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_ecedu_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_ecedu_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }

                else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_media_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_media_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_media_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }

                else if (abbr != null && (abbr.ToLower() == "ai" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_ai_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_ai_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_ai_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
                //fatma 6-6-2022
                else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTop_dent_News(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNews_dent_ByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAll_dent_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }

                else
                {
                    if (TopNewsCounter != -1)
                    {
                        e.Result = Prtl_NewsTransUtility.GetTopNews(StaticUtilities.Currentlanguage(Page),
                            TopNewsCounter, OwnerID);
                    }
                    else if (FilterDate != DateTime.MinValue)
                    {
                        if (Page.IsValid)
                            e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page),
                                FilterDate,
                                FilterDate2, OwnerID);
                    }
                    else
                    {
                        e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                    }
                }
            }
            else if (this.ID == "NewsViewerControl2")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_Featured_News(StaticUtilities.Currentlanguage(Page),
                        TopNewsCounter, OwnerID);
                }
            }





        }

        private void ShowEditorAtMode(object sender, DetailsViewMode Mode)
        {
            var l = (LinkButton)sender;
            InlineNewsDetailsViewControl.Show(StaticUtilities.OwnerID(Page), l.CommandArgument, Mode);
        }

        protected string GetNewsAbbr(string eval)
        {
            if (eval.Length < 120)
            {
                return eval;
            }
            else if (eval.Length > 120)
            {
                return eval.Substring(0, 120);
            }
            else
            {
                return eval;
            }
        }

        protected string getNewsDate(object id, string abbr)
        {
            return Prtl_NewsUtility.GetNewsDateByIDAbbr(id, abbr,ID);
        }
    }
}