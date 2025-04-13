using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.VotingEditor.Editor
{
    public partial class VotingEditorControl : ListViewBasedUserControl
    {
        protected override string DetailsViewBasedName
        {
            get { return "VotingDetailsControl1"; }
        }

        protected override string FilterSessionName
        {
            get { return "VotingOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "VotingLinqDataSource"; }
        }

        protected override string ListViewName
        {
            get { return "VotingListView"; }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);
            var data = Prtl_VotingUtility.GetVotingByID(int.Parse(GetCommandArgForListItem(listViewItem)));

            var Question_Label = GetControl<Label>("Question_Label", listViewItem);
            Question_Label.Text = GetQuestion(data.VotingID);
            var Ans1_Label = GetControl<Label>("Ans1_Label", listViewItem);
            Ans1_Label.Text = GetAnswers(data.VotingID).Ans1;
            var Ans2_Label = GetControl<Label>("Ans2_Label", listViewItem);
            Ans2_Label.Text = GetAnswers(data.VotingID).Ans2;
            var Ans3_Label = GetControl<Label>("Ans3_Label", listViewItem);
            Ans3_Label.Text = GetAnswers(data.VotingID).Ans3;
            var ActiveLbl = GetControl<Label>("ActiveLbl", listViewItem);
            ActiveLbl.Text = GetActive(data.VotingID);
        }

        protected string GetActive(object id)
        {
            var voting = Prtl_VotingUtility.GetcurrentVoting(FilterOwnerID);
            var ItemID = voting.CurrentVotingID;
            return ItemID.ToString() == id.ToString() ? "Active" : "";
        }

        protected prtl_VotingTranslation GetAnswers(object eval)
        {
            var ans = Prtl_VotingTransUtility.GetVotTranByVIDAndLCID(Convert.ToInt32(eval), StaticUtilities.Currentlanguage(Page));
            return ans;
        }

        protected string GetQuestion(object eval)
        {
            var question = Prtl_VotingTransUtility.GetVotTranByVIDAndLCID(Convert.ToInt32(eval), StaticUtilities.Currentlanguage(Page));
            return (question == null) ? "Not_Translated" : question.Question;
        }

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (FilterOwnerID != null) Prtl_OwnersUtility.UpdateOwnerWithVotingID(FilterOwnerID.Value, 0);
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data, string abbr = null)
        {
            return Prtl_VotingTransUtility.LangsNotTranslated(CurrentTranslationID, data.ToString());
        }

        protected override int TranslationCount(object data, string abbr = null)
        {
            return Prtl_VotingTransUtility.Count(data.ToString());
        }

        protected override bool Published(object data,[Optional]string abbr)
        {
            throw new NotImplementedException();
        }

        protected void VotingEditorControl_insertClicked(object sender, EventArgs e)
        {
            VotingDetailsControl1.ShowInsert(FilterOwnerID, "0");
        }
    }
}