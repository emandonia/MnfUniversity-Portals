using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BLL;
using Common;
using FancyImageZoom;
using MnfUniversity_Portals.UserControls.Editors.Base;
using MnfUniversity_Portals.UserControls.Editors.NewsEditor.Details;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.NewsEditor.Editor
{
    public partial class NewsEditorControl : ListViewBasedUserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                var x = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                if (x.Type == 1)
                {
                    if (x.Abbr.EndsWith("s"))
                    {
                        NewsLinqDataSource.TableName = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData);
                        Session["TbName"] = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) ;
                    }
                    else
                    {
                        NewsLinqDataSource.TableName = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "s";
                        Session["TbName"] = "prtl_news_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "s";
                    }
                }
                else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
                {
                    NewsLinqDataSource.TableName = "prtl_news_univs";
                    Session["TbName"] = "prtl_news_univs";
                }
                else
                {
                    NewsLinqDataSource.TableName = "prtl_News";
                    Session["TbName"] = "prtl_News";
                }
            }
            else
            {
                NewsLinqDataSource.TableName = (string)Session["TbName"];
            }


        }



        protected override string DetailsViewBasedName
        {
            get { return "NewsDetailsViewControl"; }
        }

        protected override string FilterSessionName
        {
            get { return "NewsOwner_ID"; }
        }

        /// <summary>
        /// The name of LinqDataSource associated with the ListView Control
        /// </summary>
        protected override string ListViewLinqDataSourceName
        {
            get { return "NewsLinqDataSource"; }
        }

        protected override string ListViewName
        {
            get { return "NewsListView"; }
        }

        private NewsDetailsViewControl NewsDetailsViewControl1
        {
            get
            {
                return (NewsDetailsViewControl)DetailsViewControl;
            }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if ( abbr== null)
            {
                var data = Prtl_NewsUtility.Get_univ_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
            var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
            deleteImage.ImageUrl = DeleteImageURL;
            var EditorImage = GetControl<Image>("EditorImage", listViewItem);
            EditorImage.ImageUrl = EditorImageURL;
            var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
            NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
            var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
            PreviewImage.BigImageURL =
                URLBuilder.Path(Page, PathType.WebServer,
                                         SiteFolders.News,
                                         data.News_img ?? URLBuilder.DefaultImageName);
            PreviewImage.SmallImageURL =
                URLBuilder.Path(Page, PathType.WebServer,
                                         SiteFolders.News_Thumb,
                                         data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "fci")
            {
                var data = Prtl_NewsUtility.Get_fci_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "fee")
            {
                var data = Prtl_NewsUtility.Get_fee_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "eng")
            {
                var data = Prtl_NewsUtility.Get_eng_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "nur")
            {
                var data = Prtl_NewsUtility.Get_nur_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "edu")
            {
                var data = Prtl_NewsUtility.Get_edu_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "sci")
            {
                var data = Prtl_NewsUtility.Get_sci_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "edv")
            {
                var data = Prtl_NewsUtility.Get_edv_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "agr")
            {
                var data = Prtl_NewsUtility.Get_agr_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "hec")
            {
                var data = Prtl_NewsUtility.Get_hec_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "law")
            {
                var data = Prtl_NewsUtility.Get_law_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "fpe")
            {
                var data = Prtl_NewsUtility.Get_fpe_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
                //*******************
            else if (abbr.ToLower() == "vmed")
            {
                var data = Prtl_NewsUtility.Get_VMed_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "pharm")
            {
                var data = Prtl_NewsUtility.Get_Pharm_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
                //*****************************
            else if (abbr.ToLower() == "fa")
            {
                var data = Prtl_NewsUtility.Get_fas_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "art")
            {
                var data = Prtl_NewsUtility.Get_art_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "ho")
            {
                var data = Prtl_NewsUtility.Get_hos_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "med")
            {
                var data = Prtl_NewsUtility.Get_med_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "liv")
            {
                var data = Prtl_NewsUtility.Get_liv_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            //121212121212
            else if (abbr.ToLower() == "ecedu")
            {
                var data = Prtl_NewsUtility.Get_ecedu_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "media")
            {
                var data = Prtl_NewsUtility.Get_media_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            //14-4-2022
            else if (abbr.ToLower() == "ai")
            {
                var data = Prtl_NewsUtility.Get_ai_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            //fatma 6-6-2022
            else if (abbr.ToLower() == "dent")
            {
                var data = Prtl_NewsUtility.Get_dent_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else if (abbr.ToLower() == "com")
            {
                var data = Prtl_NewsUtility.Get_com_NewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            else
            {
                var data = Prtl_NewsUtility.GeNewsByID(int.Parse(GetCommandArgForListItem(listViewItem)));
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var EditorImage = GetControl<Image>("EditorImage", listViewItem);
                EditorImage.ImageUrl = EditorImageURL;
                var NewsDateLabel = GetControl<Label>("NewsDateLabel", listViewItem);
                NewsDateLabel.Text = StaticUtilities.FormatDate(data.News_date);
                var PreviewImage = GetControl<ImageZoom>("NewsItemImageZoom", listViewItem);
                PreviewImage.BigImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News,
                                             data.News_img ?? URLBuilder.DefaultImageName);
                PreviewImage.SmallImageURL =
                    URLBuilder.Path(Page, PathType.WebServer,
                                             SiteFolders.News_Thumb,
                                             data.News_img ?? URLBuilder.DefaultImageName);
            }
            
        }

        /// <summary>
        /// Called when an Item is being deleted in the ListView Control The full implementation is done at the child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (abbr == null)
            {
                var prt_news = Prtl_NewsUtility.Get_univ_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);

            }
            else if (abbr.ToLower() == "fci")
            {
                var prt_news = Prtl_NewsUtility.Get_fci_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "fee")
            {
                var prt_news = Prtl_NewsUtility.Get_fee_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "eng")
            {
                var prt_news = Prtl_NewsUtility.Get_eng_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "nur")
            {
                var prt_news = Prtl_NewsUtility.Get_nur_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "edu")
            {
                var prt_news = Prtl_NewsUtility.Get_edu_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "sci")
            {
                var prt_news = Prtl_NewsUtility.Get_sci_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "edv")
            {
                var prt_news = Prtl_NewsUtility.Get_edv_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "agr")
            {
                var prt_news = Prtl_NewsUtility.Get_agr_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "hec")
            {
                var prt_news = Prtl_NewsUtility.Get_hec_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "law")
            {
                var prt_news = Prtl_NewsUtility.Get_law_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "fpe")
            {
                var prt_news = Prtl_NewsUtility.Get_fpe_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
                //**********************
            else if (abbr.ToLower() == "vmed")
            {
                var prt_news = Prtl_NewsUtility.Get_VMed_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "pharm")
            {
                var prt_news = Prtl_NewsUtility.Get_Pharm_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
                //********************************
            else if (abbr.ToLower() == "fa")
            {
                var prt_news = Prtl_NewsUtility.Get_fas_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "art")
            {
                var prt_news = Prtl_NewsUtility.Get_art_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "ho")
            {
                var prt_news = Prtl_NewsUtility.Get_hos_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "med")
            {
                var prt_news = Prtl_NewsUtility.Get_med_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "liv")
            {
                var prt_news = Prtl_NewsUtility.Get_liv_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else if (abbr.ToLower() == "com")
            {
                var prt_news = Prtl_NewsUtility.Get_com_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            //121212121212
            else if (abbr.ToLower() == "ecedu")
            {
                var prt_news = Prtl_NewsUtility.Get_ecedu_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
                //33333333333
            else if (abbr.ToLower() == "media")
            {
                var prt_news = Prtl_NewsUtility.Get_media_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            //14-4-2022
            else if (abbr.ToLower() == "ai")
            {
                var prt_news = Prtl_NewsUtility.Get_ai_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }//fatma 6-6-2022
            else if (abbr.ToLower() == "dent")
            {
                var prt_news = Prtl_NewsUtility.Get_dent_NewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            else
            {
                var prt_news = Prtl_NewsUtility.GeNewsByID(Convert.ToInt32(e.Keys["News_Id"]));
                StaticUtilities.DeleteImage(Page, prt_news.News_img, SiteFolders.News);
            }
            
        }

        protected void NewsEditorControl_insertClicked(object sender, EventArgs e)
        {
            NewsDetailsViewControl1.ShowInsert(FilterOwnerID, "0");
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data,string abbr)
        {
            return Prtl_NewsTransUtility.LangsNotTranslated(CurrentTranslationID, data.ToString(),URLBuilder.CurrentOwnerAbbr(Page.RouteData));
        }

        protected override int TranslationCount(object data,[Optional]string abbr)
        {
            return Prtl_NewsTransUtility.GetNewsTranslationCount( int.Parse( data.ToString()),abbr);
        }

        protected override bool Published(object data,[Optional]string abbr)  
        {
            return Prtl_NewsUtility.GetPublishedState(data.ToString(), abbr);
         
        }
        public string GetNewsHead(int id,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                var news = Prtl_NewsTransUtility.Get_univ_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "fci")
            {
                var news = Prtl_NewsTransUtility.Get_fci_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "fee")
            {
                var news = Prtl_NewsTransUtility.Get_fee_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "eng")
            {
                var news = Prtl_NewsTransUtility.Get_eng_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "nur")
            {
                var news = Prtl_NewsTransUtility.Get_nur_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "edu")
            {
                var news = Prtl_NewsTransUtility.Get_edu_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "sci")
            {
                var news = Prtl_NewsTransUtility.Get_sci_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "edv")
            {
                var news = Prtl_NewsTransUtility.Get_edv_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "agr")
            {
                var news = Prtl_NewsTransUtility.Get_agr_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "hec")
            {
                var news = Prtl_NewsTransUtility.Get_hec_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "law")
            {
                var news = Prtl_NewsTransUtility.Get_law_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "fpe")
            {
                var news = Prtl_NewsTransUtility.Get_fpe_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
                //******************
            else if (abbr.ToLower() == "pharm")
            {
                var news = Prtl_NewsTransUtility.Get_Pharm_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "vmed")
            {
                var news = Prtl_NewsTransUtility.Get_VMed_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
                //************************
            else if (abbr.ToLower() == "fa")
            {
                var news = Prtl_NewsTransUtility.Get_fas_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "art")
            {
                var news = Prtl_NewsTransUtility.Get_art_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "ho")
            {
                var news = Prtl_NewsTransUtility.Get_hos_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "med")
            {
                var news = Prtl_NewsTransUtility.Get_med_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "liv")
            {
                var news = Prtl_NewsTransUtility.Get_liv_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else if (abbr.ToLower() == "com")
            {
                var news = Prtl_NewsTransUtility.Get_com_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            //121212121212
            else if (abbr.ToLower() == "ecedu")
            {
                var news = Prtl_NewsTransUtility.Get_ecedu_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
                //33333
            else if (abbr.ToLower() == "media")
            {
                var news = Prtl_NewsTransUtility.Get_media_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            //14-4-2022
            else if (abbr.ToLower() == "ai")
            {
                var news = Prtl_NewsTransUtility.Get_ai_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }//fatma 6-6-2022
            else if (abbr.ToLower() == "dent")
            {
                var news = Prtl_NewsTransUtility.Get_dent_NewsByID(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
            else
            {
                var news = Prtl_NewsTransUtility.GetNewsById(id, StaticUtilities.Currentlanguage(Page));
                return (news == null) ? "Not_Translated" : news.News_Head;
            }
           
        }
    }
}