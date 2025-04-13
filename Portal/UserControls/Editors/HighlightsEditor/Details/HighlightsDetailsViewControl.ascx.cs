using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.HighlightsEditor.Details
{
    public partial class HighlightsDetailsViewControl : DetailsViewBasedUserControl
    {
        protected override string DefaultValueForFiltering
        {
            get { return "00000000-1000-0000-0000-000000000000"; }
        }

        protected override string FilterValueName
        {
            get { return "EventTranslation_ID"; }
        }

        public override string EditorClientID
        {
            get
            {
                return GetClientIDs("txtActualContent");
            }
        }


        protected override object EditorTitle{ get { return GetLocalResourceObject("Title"); } }

        private DataControlField EditorField
        {
            get { return EditorDetailsView.Fields[4]; }
        }

        private DataControlField EndDateField
        {
            get { return EditorDetailsView.Fields[2]; }
        }

        private string FilteredProperty
        {
            get { return "Translation_ID"; }
        }
     
        private DataControlField ImageField
        {
            get { return EditorDetailsView.Fields[3]; }
        }

        private DataControlField StartDateField
        {
            get { return EditorDetailsView.Fields[1]; }
        }

        protected override void DataBound(object sender, EventArgs e)
        {
            EndDateField.Visible =
                StartDateField.Visible =
                ImageField.Visible = EditorDetailsView.CurrentMode == DetailsViewMode.Edit || Mode == DetailsViewMode.Insert;
        }

        protected override IEnumerable<prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_TranslationUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata);

            // ReSharper restore PossibleInvalidOperationException
        }

        protected override void ItemInserting(DetailsView detailsView, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {
                var filename = StaticUtilities.UploadImage(detailsView, "AsyncFileUpload1", SiteFolders.Events, e);
                var InsertStartDateTextBox = detailsView.GetControl<TextBox>("InsertStartDateTextBox");
                var InsertEndDateTextBox = detailsView.GetControl<TextBox>("InsertEndDateTextBox");

                var startdate = StaticUtilities.ExtractDate(InsertStartDateTextBox.Text);
                var enddate = StaticUtilities.ExtractDate(InsertEndDateTextBox.Text);
                CheckStartEndDates(e, startdate, enddate);
                if (e.Cancel)
                {
                    EditorModalPopupExtender.Show(); return;
                }
                var x = detailsView.GetControl<CheckBox>("CheckBox1");
                Prtl_HighlightsUtility.Insert(e, filename,CurrentOwnerID, FilteredProperty,startdate, enddate,x.Checked);
                detailsView.CompleteTranslationData(e, e.Values[FilteredProperty].ToString());
            }
            else
            {
                detailsView.CompleteTranslationData(e, FilterValue);
            }
        }

        protected override void ItemUpdating(DetailsView detailsView, DetailsViewUpdateEventArgs e)
        {
            var filename = "";
            var Highlight_ID = detailsView.GetControl<HiddenField>("HighlightID");
            var EditStartDateTextBox = detailsView.GetControl<TextBox>("EditStartDateTextBox");
            var EditEndDateTextBox = detailsView.GetControl<TextBox>("EditEndDateTextBox");
            var AsyncFileUpload1 = detailsView.GetControl<AsyncFileUpload>("AsyncFileUpload1");
            var x = detailsView.GetControl<CheckBox>("CheckBox1");
            Prtl_HighlightsUtility.UpdateHighlightWithPublish(Convert.ToInt32(Highlight_ID.Value), x.Checked);
            if (AsyncFileUpload1.HasFile)
            {
                filename = StaticUtilities.UploadImage(detailsView, "AsyncFileUpload1",
                                                           SiteFolders.Events, e);
            }
            var startdate = StaticUtilities.ExtractDate(EditStartDateTextBox.Text);
            var enddate = StaticUtilities.ExtractDate(EditEndDateTextBox.Text);
            CheckStartEndDates(e, startdate, enddate);
            if (e.Cancel)
            {
                EditorModalPopupExtender.Show();
                return;
            }
            var oldname = Prtl_HighlightsUtility.UpdateItem(FilterValue, filename,
                startdate, enddate);
            if (oldname != filename)
            {
                StaticUtilities.DeleteImage(Page, oldname, SiteFolders.Events);
                StaticUtilities.DeleteImage(Page, oldname, SiteFolders.Events_Thumb);
            }
        }

      

        protected override int TranslationsCount
        {
            get { return Prtl_TranslationUtility.TranslationsCount(FilterValue); }
        }

        private void CheckStartEndDates(CancelEventArgs e, DateTime startdate, DateTime enddate)
        {
            if (startdate > enddate)
            {
                // DateErrorLabel.Visible = true;
                e.Cancel = true;

                //return;
            }

            //    DateErrorLabel.Visible = false;
        }

        protected void DetailsViewBasedControl1_PreRender(object sender, EventArgs e)
        {
                   EditorField.HeaderText = GetPreViewHeaderText();
        }
    }
}