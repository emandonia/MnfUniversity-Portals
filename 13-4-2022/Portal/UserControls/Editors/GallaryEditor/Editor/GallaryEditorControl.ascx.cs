using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BLL;
using Common;
using FancyImageZoom;
using MnfUniversity_Portals.BLL.Portal_BLL;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.GallaryEditor.Editor
{
    public partial class GallaryEditorControl : ListViewBasedUserControl
    {
        protected override string FilterSessionName
        {
            get { return "GallaryOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "GallaryLinqDataSource"; }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);
           // var data = Prtl_GalaryUtility.SelectByTransID(Convert.ToInt32(GetCommandArgForListItem(listViewItem)));

           
        }

        protected void GallaryEditorControl_insertClicked(object sender, EventArgs e)
        {
            //GallaryDetailsViewControl1.ShowInsert(StaticUtilities.OwnerID(Page));
        }

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            //var prt_event = Prtl_HighlightsUtility.SelectByID(Convert.ToInt32(e.Keys["Highlight_Id"].ToString()));
            //StaticUtilities.DeleteImage(Page, prt_event.Image, SiteFolders.Events);
            //Prtl_TranslationUtility.DeleteTranslations(prt_event.Translation_ID);
        }

        protected override int TranslationCount(object data, string abbr = null)
        {
            return Prtl_GalaryUtility.TranslationsCount(((prtl_Gallary)data).Translation_ID.ToString());
        }

        protected override bool Published(object data, string abbr = null)
        {
            return Prtl_GalaryUtility.GetPublishedState(data.ToString());
        }

        #region ImagesURL Properties

        protected override string DetailsViewBasedName
        {
            get { return "EventDetailsViewControl1"; }
        }

        protected override string ListViewName
        {
            get { return "EditorListVieww"; }
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data,[Optional]string abbr)
        {
            return Prtl_GalaryUtility.LangsNotTranslated(CurrentTranslationID, data.ToString());
        }

        #endregion ImagesURL Properties
    }
}