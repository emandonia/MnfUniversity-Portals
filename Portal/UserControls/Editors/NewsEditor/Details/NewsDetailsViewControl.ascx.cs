using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BLL;
using CKEditor.NET;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.NewsEditor.Details
{
    public partial class NewsDetailsViewControl : DetailsViewBasedUserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData)).Type == 1)
                {
                    NewsTranslationsLinqDataSource.TableName = "prtl_news_" +
                                                               URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";
                    Session["TbName2"] = "prtl_news_" +
                                         URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";
                }
                else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
                {
                    NewsTranslationsLinqDataSource.TableName = "prtl_news_univ_trans";
                    Session["TbName2"] = "prtl_news_univ_trans";
                }
                else
                {
                    NewsTranslationsLinqDataSource.TableName = "prtl_News_Translations";
                    Session["TbName2"] = "prtl_News_Translations"; 
                    NewsTranslationsLinqDataSource.DataBind();
                }
            }
            else
            {
                NewsTranslationsLinqDataSource.TableName = (string)Session["TbName2"];
            }
        }


        protected override string DefaultValueForFiltering
        {
            get { return "0"; }
        }

        protected override string FilterValueName
        {
            get { return "News_Id"; }
        }

        public override string EditorClientID
        {
            get
            {
                return GetClientIDs( "News_BodyTextBox");
             }
        }


        private DataControlField DateField
        {
            get { return EditorDetailsView.Fields[1]; }
        }

        private DataControlField ImageField
        {
            get { return EditorDetailsView.Fields[2]; }
        }

        protected override void DataBound(object sender, EventArgs e)
        {
            var CalendarExtender1 = GetDVControl<CalendarExtender>("InsertCalendarExtender1");
            if (CalendarExtender1 != null) CalendarExtender1.Format = StaticUtilities.DateTimeFormat;
          //  ImageField.Visible = EditorDetailsView.CurrentMode == DetailsViewMode.Edit || Mode == DetailsViewMode.Insert;
            DateField.Visible = ImageField.Visible = EditorDetailsView.CurrentMode == DetailsViewMode.Edit || Mode == DetailsViewMode.Insert;

        }

        protected override IEnumerable<prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_NewsTransUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata,URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            // ReSharper restore PossibleInvalidOperationException
        }

        protected override object EditorTitle
        {
            get { return GetLocalResourceObject("Title"); }
        }

        protected override void ItemInserting(DetailsView  detailsview, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {
                var filename = StaticUtilities.UploadImage(detailsview, "InsertAsyncFileUpload1", SiteFolders.News, e);
                if (e.Cancel)
                {
                    EditorModalPopupExtender.Show(); return;
                }
                var newsdate = EditorDetailsView.GetControl<TextBox>("InsertNewsDateTextBox");
                var currentnewsdate = DateTime.Now.Date;
                var x = detailsview.GetControl<CheckBox>("CheckBox1");
                var xx = detailsview.GetControl<CheckBox>("CheckBox2");
                Prtl_NewsUtility.InsertNewNewsItem(e, filename, CurrentOwnerID, FilterValueName,StaticUtilities.ExtractDate( newsdate.Text),currentnewsdate,x.Checked,URLBuilder.CurrentOwnerAbbr(Page.RouteData),xx.Checked);
            }
            else
            {
                e.Values[FilterValueName] = FilterValue;
            }
            var langddl = EditorDetailsView.GetControl<DropDownList>("LangDropDownList");
            e.Values["News_Abbr"] = e.Values["News_Abbr"].ToString().Replace("\n", "<br/>");
            e.Values["Lang_id"] = langddl.SelectedValue;
        }

        protected override void ItemUpdating(DetailsView detailsview, DetailsViewUpdateEventArgs e)
        {
            var filename = "";
             var EditNewsDateTextBox = GetDVControl<TextBox>("EditNewsDateTextBox");
           
            var News_Id = GetDVControl<HiddenField>("News_Id");
            var EditAsyncFileUpload1 = GetControl<AsyncFileUpload>("EditAsyncFileUpload1", detailsview);
            if (EditAsyncFileUpload1.HasFile)
            {
                filename = StaticUtilities.UploadImage(detailsview, "EditAsyncFileUpload1",
                                                           SiteFolders.News, e);
                if (e.Cancel)
                {
                    EditorModalPopupExtender.Show();
                    return;
                }
            }
             CheckBox x = detailsview.GetControl<CheckBox>("CheckBox1");
             CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox2");
             Prtl_NewsUtility.UpdateNewsItemWithPublish(Convert.ToInt32(News_Id.Value), x.Checked, URLBuilder.CurrentOwnerAbbr(Page.RouteData),xx.Checked);
             var oldname = Prtl_NewsUtility.UpdateNewsItem(News_Id.Value, filename, StaticUtilities.ExtractDate(EditNewsDateTextBox.Text), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
            if (oldname != filename)
            {
                StaticUtilities.DeleteImage(Page, oldname, SiteFolders.News);

                StaticUtilities.DeleteImage(Page, oldname, SiteFolders.News_Thumb);
            }
        }

        protected override int TranslationsCount
        {
            get { return Prtl_NewsTransUtility.GetNewsTranslationCount(int.Parse(FilterValue), URLBuilder.CurrentOwnerAbbr(Page.RouteData)); }
        }

        protected void Test(object sender, EventArgs e)
        {
      
        }

        protected bool GetChecked(object id, string abbr)
        {
            return Prtl_NewsUtility.GetCheckedByIDAbbr(id, abbr);
        }

        protected string getNewsDate(object id, string abbr)
        {
            return Prtl_NewsUtility.GetNewsDateByIDAbbr(id, abbr, "NewsViewerControl1");
        }

        protected bool Get_IsFeatured_Checked(object id, string abbr)
        {
            return Prtl_NewsUtility.Get_Is_Featured_CheckedByIDAbbr(id, abbr);
        }

        protected void NewsTranslationsLinqDataSource_OnDataBinding(object sender, EventArgs e)
        {
            NewsTranslationsLinqDataSource.TableName = (string)Session["TbName2"];
        }
    }
}