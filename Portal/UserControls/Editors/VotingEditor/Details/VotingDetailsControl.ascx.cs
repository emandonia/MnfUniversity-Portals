using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.VotingEditor.Details
{
    public partial class VotingDetailsControl : DetailsViewBasedUserControl
    {
        protected override string DefaultValueForFiltering
        {
            get { return "0"; }
        }

        protected override string FilterValueName
        {
            get { return "VotingTranslation_ID"; }
        }

        public override string EditorClientID
        {
            get { return ""; }
        }


        private string FilteredProperty
        {
            get { return "VotingID"; }
        }

        protected override void DataBound(object sender, EventArgs e)
        {
        }

        protected override IEnumerable<prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_VotingTransUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata);

            // ReSharper restore PossibleInvalidOperationException
        }

        protected override void ItemInserting(DetailsView detailsview, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {
                if (e.Cancel) { EditorModalPopupExtender.Show(); return; }
                var newVoting = new prtl_Voting { Owner_ID = CurrentOwnerID };
                Prtl_VotingUtility.InsertNewVote(newVoting);
                e.Values[FilteredProperty] = newVoting.VotingID;
                var c = GetControl<CheckBox>("CheckBox1", detailsview);
                if (c.Checked && CurrentOwnerID.HasValue)
                {
                    Prtl_OwnersUtility.UpdateOwnerWithVotingID(CurrentOwnerID.Value,
                                                               newVoting.VotingID);
                }
            }
            else
            {
                e.Values[FilteredProperty] = FilterValue;
            }
            var langddl = GetControl<DropDownList>("LangDropDownList", detailsview);
            e.Values["Lang_id"] = langddl.SelectedValue;
        }

        protected override void ItemUpdating(DetailsView detailsview, DetailsViewUpdateEventArgs e)
        {
            var VotingID = GetControl<HiddenField>("VotingID", detailsview);

            var c = GetControl<CheckBox>("DefaultCheck", detailsview);
            if (c.Checked)
            {
                if (CurrentOwnerID != null)
                    Prtl_OwnersUtility.UpdateOwnerWithVotingID(CurrentOwnerID.Value, Convert.ToInt32(VotingID.Value));
            }
        }

        protected override int TranslationsCount
        {
            get { return Prtl_VotingTransUtility.Count(FilterValue); }
        }
    }
}