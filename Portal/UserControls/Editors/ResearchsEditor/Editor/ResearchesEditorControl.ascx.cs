using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.ResearchsEditor.Editor
{
    public partial class ResearchesEditorControl : ListViewBasedUserControl
    {
        protected override string DetailsViewBasedName
        {
            get { return "ResearchesDetailsViewControl1"; }
        }

        protected override string FilterSessionName
        {
            get { return "ResearchesOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "ResearchesLinqDataSource"; }
        }

        protected override string ListViewName
        {
            get { return "ResearchesListView"; }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);

            var data = Prtl_ResearchUtility.GetResearchByID(int.Parse(GetCommandArgForListItem(listViewItem)));

            var title_Label = GetControl<Label>("title_Label", listViewItem);
            title_Label.Text = ResearchTitle(data.ID);
            var ResearcherName_Label = GetControl<Label>("ResearcherNameLbl", listViewItem);
            ResearcherName_Label.Text = ResearcherName(data.ID);
           
           
        }

        protected void ResearchesEditorControlInsertClicked(object sender, EventArgs e)
        {
            //ResearchesDetailsViewControl1.ShowInsert(FilterOwnerID, "0");
        }

        protected string ResearchTitle(object Res_ID)
        {
            var Research = Prtl_ResearchTransUtility.GetResearchTranslation(StaticUtilities.Currentlanguage(Page), Res_ID);
            return (Research == null) ? "Not_Translated" : Research.ResearchTitle;
        }

      

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data, string abbr = null)
        {
            return Prtl_ResearchTransUtility.LangsNotTranslated(CurrentTranslationID, data.ToString());
        }

        protected override int TranslationCount(object data, string abbr = null)
        {
            return Prtl_ResearchTransUtility.GetCountTranslations(data.ToString());
        }

        protected override bool Published(object data, string abbr = null)
        {
            return Prtl_ResearchUtility.GetPublishedState(data.ToString());
        }


        protected string ResearcherName(object Res_ID)
        {
            var Research = Prtl_ResearchTransUtility.GetResearchTranslation(StaticUtilities.Currentlanguage(Page), Res_ID);
            return (Research == null) ? "Not_Translated" : Research.MainResearcherName;
        }

       
    }
}