using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using FancyImageZoom;
using MnfUniversity_Portals.UserControls.Base;
using System.Data;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class NewsSearchControl : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData)).Type == 1)
                {
                    NewsLinqDataSource.TableName = "prtl_news_" +
                                                               URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";
                    Session["TbName2"] = "prtl_news_" +
                                                               URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";
                    NewsLinqDataSource.OrderBy = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) +
                                                 ".News_date desc";
                }
                else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
                {
                    NewsLinqDataSource.TableName = "prtl_news_univ_trans";
                    Session["TbName2"] = "prtl_news_univ_trans";
                    NewsLinqDataSource.OrderBy = "prtl_news_univ.News_date desc";
                }
                else
                {
                    NewsLinqDataSource.TableName = "prtl_News_Translations";
                    Session["TbName2"] = "prtl_News_Translations";
                    NewsLinqDataSource.OrderBy = "prtl_New.News_date desc";


                    string Where = "Owner_ID ==@Owner_ID";
                    NewsLinqDataSource.WhereParameters.Add("Owner_ID", DbType.Guid, StaticUtilities.OwnerID (Page).ToString ());

                    //NewsLinqDataSource.Where = Where;
                    NewsLinqDataSource.DataBind();
                }
            }
            else
            {
                NewsLinqDataSource.TableName = (string)Session["TbName2"];
            }
        }
     
        public string UniNewItemUrl2(Page page, int id)
        {
            if (URLBuilder.CurrentOwnerAbbr(page.RouteData) != null)
            {
                return "http://mu.menofia.edu.eg/" + URLBuilder.CurrentOwnerAbbr(page.RouteData) + "/NewsDetails/" + id + "/" + StaticUtilities.Currentlanguage(page.RouteData);
            }
            else
            {
                return "http://mu.menofia.edu.eg/" + "NewsDetails/" + id + "/" + StaticUtilities.Currentlanguage(page.RouteData);
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
        public LinqDataSource NewsLinqDataSourcee
        {
            private get
            {
                return NewsLinqDataSource;
            }
            set
            {
                NewsLinqDataSource = value;
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

        protected string BigImageURL(object imageName)
        {
            return URLBuilder.GetURLIfExists(Page, SiteFolders.News, imageName + "");
        }
        protected string SmallImageURL(object imageName)
        {
            return URLBuilder.GetURLIfExists(Page, SiteFolders.News_Thumb, imageName + "");
        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var l = (LinkButton)sender;
            Prtl_NewsUtility.DeleteItem(int.Parse(l.CommandArgument),URLBuilder.CurrentOwnerAbbr(Page.RouteData));
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
            if (abbr == null)
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_univ_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_univ_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID,abbr).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_univ_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID,abbr).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }

            else if (abbr.ToLower() == "fci")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_fci_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_fci_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_fci_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "fee")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_fee_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_fee_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_fee_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "eng")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_eng_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_eng_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_eng_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "nur")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_nur_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_nur_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_nur_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "edu")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_edu_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_edu_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_edu_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "sci")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_sci_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_sci_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_sci_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "edv")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_edv_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_edv_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_edv_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "agr")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_agr_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_agr_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_agr_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "hec")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_hec_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_hec_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_hec_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "law")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_law_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_law_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_law_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "fpe")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_fpe_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_fpe_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_fpe_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
                //**********************
            else if (abbr.ToLower() == "vmed")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_VMed_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_VMed_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_VMed_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "pharm")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_Pharm_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_Pharm_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_Pharm_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
                //**********************************
            else if (abbr.ToLower() == "fa")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_fas_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_fa_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_fas_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "art")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_art_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_art_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_art_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "ho")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_ho_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_ho_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_hos_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "med")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_med_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_med_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_med_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "liv")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_liv_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_liv_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_liv_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "com")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_com_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_com_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_com_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_ecedu_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_ECEDU_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_ECEDU_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            else if (abbr.ToLower() == "media")
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTop_media_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNews_media_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAll_media_News(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }
            //else if (abbr.ToLower() == "dent")
            //{
            //    if (TopNewsCounter != -1)
            //    {
            //        e.Result = Prtl_NewsTransUtility.GetTop_com_News(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
            //            OwnerID);
            //    }
            //    else if (FilterDate != DateTime.MinValue)
            //    {
            //        if (Page.IsValid)
            //            //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
            //            e.Result = Prtl_NewsTransUtility.GetNews_com_ByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
            //                FilterDate2, OwnerID);
            //        lblCounter.Text = "Count is : " +
            //                          Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
            //                              FilterDate, FilterDate2, OwnerID, abbr.ToLower()).ToString();
            //    }
            //    else
            //    {
            //        e.Result = Prtl_NewsTransUtility.GetAll_com_News(StaticUtilities.Currentlanguage(Page), OwnerID);
            //        lblCounter.Text = "Count is : " +
            //                          Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
            //                              OwnerID, abbr.ToLower()).ToString();
            //        //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
            //    }
            //}
            else
            {
                if (TopNewsCounter != -1)
                {
                    e.Result = Prtl_NewsTransUtility.GetTopNews(StaticUtilities.Currentlanguage(Page), TopNewsCounter,
                        OwnerID);
                }
                else if (FilterDate != DateTime.MinValue)
                {
                    if (Page.IsValid)
                        //  e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate, FilterDate2, OwnerID);
                        e.Result = Prtl_NewsTransUtility.GetNewsByDate(StaticUtilities.Currentlanguage(Page), FilterDate,
                            FilterDate2, OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountNewsByDate(StaticUtilities.Currentlanguage(Page),
                                          FilterDate, FilterDate2, OwnerID,abbr.ToLower()).ToString();
                }
                else
                {
                    e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                    lblCounter.Text = "Count is : " +
                                      Prtl_NewsTransUtility.GetCountAllNews(StaticUtilities.Currentlanguage(Page),
                                          OwnerID, abbr.ToLower()).ToString();
                    //  e.Result = Prtl_NewsTransUtility.GetAllNews(StaticUtilities.Currentlanguage(Page), OwnerID);
                }
            }


        }



        private void ShowEditorAtMode(object sender, DetailsViewMode Mode)
        {
            var l = (LinkButton)sender;
            InlineNewsDetailsViewControl.Show(StaticUtilities.OwnerID(Page), l.CommandArgument, Mode);
        }


        protected void NewsLinqDataSource_OnDataBinding(object sender, EventArgs e)
        {
            NewsLinqDataSource.TableName = (string)Session["TbName2"];
        }


        protected string getNewsDate(object id, string abbr)
        {
            return Prtl_NewsUtility.GetNewsDateByIDAbbr(id, abbr, "NewsViewerControl1");
        }

        protected void NewsListView_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (NewsListView.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            NewsListView.DataBind();
        }
    }
}