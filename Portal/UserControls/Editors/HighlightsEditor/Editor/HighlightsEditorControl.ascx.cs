using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BLL;
using Common;
using FancyImageZoom;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.HighlightsEditor.Editor
{
    public partial class HighlightsEditorControl : ListViewBasedUserControl
    {
        protected override string FilterSessionName
        {
            get { return "EventOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "EventsLinqDataSource"; }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);
            var data = Prtl_HighlightsUtility.SelectByTransID(Guid.Parse(GetCommandArgForListItem(listViewItem)));

            #region Databinding in Controls

            var StartDateLabel = GetControl<Label>("StartDateLabel", listViewItem);
            StartDateLabel.Text = StaticUtilities.FormatDate(data.Start_Date);
            var EndDateLabel = GetControl<Label>("EndDateLabel", listViewItem);
            EndDateLabel.Text = StaticUtilities.FormatDate(data.End_Date);
            var PreviewImage = GetControl<ImageZoom>("EventImageZoom", listViewItem);
            PreviewImage.BigImageURL =
                URLBuilder.Path(Page, PathType.WebServer,
                SiteFolders.Events, data.Image ?? URLBuilder.DefaultImageName);
            PreviewImage.SmallImageURL =
                URLBuilder.Path(Page, PathType.WebServer,
                SiteFolders.Events_Thumb, data.Image ?? URLBuilder.DefaultImageName);

            #endregion Databinding in Controls
        }

        protected void EventEditorControl_insertClicked(object sender, EventArgs e)
        {
            EventDetailsViewControl1.ShowInsert(StaticUtilities.OwnerID(Page));
        }

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var prt_event = Prtl_HighlightsUtility.SelectByID(Convert.ToInt32(e.Keys["Highlight_Id"].ToString()));
            StaticUtilities.DeleteImage(Page, prt_event.Image, SiteFolders.Events);
            Prtl_TranslationUtility.DeleteTranslations(prt_event.Translation_ID,URLBuilder.CurrentOwnerAbbr(Page.RouteData));
        }

        protected override int TranslationCount(object data, [Optional] string abbr )
        {
            return Prtl_TranslationUtility.TranslationsCount(((prtl_Highlight)data).Translation_ID.ToString(),abbr);
        }

        protected override bool Published(object data, string abbr = null)
        {
            return Prtl_HighlightsUtility.GetPublishedState(data.ToString());
        }

        #region ImagesURL Properties

        protected override string DetailsViewBasedName
        {
            get { return "EventDetailsViewControl1"; }
        }

        protected override string ListViewName
        {
            get { return "EditorListView"; }
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data, string abbr = null)
        {
            return Prtl_TranslationUtility.LangsNotTranslated(CurrentTranslationID, ((prtl_Highlight)data).Translation_ID.ToString());
        }

        #endregion ImagesURL Properties
    }
}