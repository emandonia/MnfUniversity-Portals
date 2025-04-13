using System;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web.UI.WebControls;
using BLL;
using Common;
using FancyImageZoom;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.ThesisEditor
{
    public partial class ThesisEditorUserControl : ListViewBasedUserControl
    {
        protected override string DetailsViewBasedName
        {
            get { return "ThesisDetailsViewControl1"; }
        }

        protected override string FilterSessionName
        {
            get { return "ThesisOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "ThesisLinqDataSource"; }
        }

        protected override string ListViewName
        {
            get { return "ThesisListView"; }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);

            var data = prtl_ThesisUtility.GetThesisByID(int.Parse(GetCommandArgForListItem(listViewItem)));

            var StudentName_label = GetControl<Label>("StudentName_label", listViewItem);
            StudentName_label.Text = ThesisStudentName(data.ID);

            var Address_label = GetControl<Label>("Address_label", listViewItem);
            Address_label.Text = ThesisAddress(data.ID);
             
        }

        protected void ThesisEditorControlInsertClicked(object sender, EventArgs e)
        {
            ThesisDetailsViewControl1.ShowInsert(FilterOwnerID, "0");
        }

        protected string ThesisStudentName(object Thesis_ID)
        {
            var Thesis = Prtl_ThesisTranslationUtility.GetThesisTranslation(StaticUtilities.Currentlanguage(Page), Thesis_ID);
            return (Thesis == null) ? "Not_Translated" : Thesis.StudentName;
        }

        protected string ThesisAddress(object Thesis_ID)
        {
            var Thesis = Prtl_ThesisTranslationUtility.GetThesisTranslation(StaticUtilities.Currentlanguage(Page), Thesis_ID);
            return (Thesis == null) ? "Not_Translated" : Thesis.Address;
        }
     

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            prtl_ThesisUtility.delete_thesis_translation(e.Keys["ID"].ToString());
            prtl_ThesisUtility.delete_thesis_map_super(e.Keys["ID"].ToString());
            prtl_ThesisUtility.delete_thesis_map_supervisor(e.Keys["ID"].ToString());
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data, string abbr = null)
        {
            return Prtl_ThesisTranslationUtility.LangsNotTranslated(CurrentTranslationID, data.ToString());
        }

        protected override int TranslationCount(object data, string abbr = null)
        {
            return Prtl_ThesisTranslationUtility.GetCountTranslations(data.ToString());
        }


        protected override bool Published(object data, string abbr = null)
        {
            return true;
        }


       
    }
}