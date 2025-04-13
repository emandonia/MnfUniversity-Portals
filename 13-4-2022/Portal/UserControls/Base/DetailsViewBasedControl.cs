using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;

using Portal_DAL;
using Resources;

namespace MnfUniversity_Portals.UserControls.Base
{
    public abstract class DetailsViewBasedUserControl : UserControlBase
    {

        #region Methods

        public virtual void Show(Guid? currentOwnerID, string filterValue=null, DetailsViewMode EditMode = DetailsViewMode.ReadOnly)
        {
            CurrentOwnerID = currentOwnerID;
            FilterValue = filterValue;
            EditorDetailsView.PageIndex = 0;
            SetCFButtonsVisibility();
            EditorDetailsView.ChangeMode(EditMode);
            EditorModalPopupExtender.Show();
        }

        internal virtual void ShowInsert(Guid? currentOwnerID, string defaultempty = null)
        {
            CurrentOwnerID = currentOwnerID;
            EditorDetailsView.ChangeMode(DetailsViewMode.Insert);
            Mode = DetailsViewMode.Insert;
           
           
               FilterValue = string.IsNullOrEmpty(defaultempty) ? Guid.Empty.ToString() : defaultempty;
            if (CommandField != null)
            {
                CommandField.ShowInsertButton = true;
                CommandField.ShowCancelButton = false;
            }
            EditorModalPopupExtender.Show();
        }

        protected T GetDVControl<T>(string name) where T : Control
        {
            return GetControl<T>(name, EditorDetailsView);
        }

        protected virtual IEnumerable<prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            return null;
        }

        protected virtual int TranslationsCount
        {
            get { return 0; }
        }
        /// <summary>
        /// Determines whether the delete and insert and cancel buttons are shown depening on the translations count
        /// </summary>
        private void SetCFButtonsVisibility()
        {
            var detailsView = EditorDetailsView;
            Mode = DetailsViewMode.ReadOnly;
            EditorDetailsView.ChangeMode(Mode);
            EditorDetailsView.DefaultMode = detailsView.CurrentMode;

            if (CommandField != null)
            {
                CommandField.ShowDeleteButton = ShowDeleteButton;
                if (CurrentOwnerID != null)
                    CommandField.ShowInsertButton = ShowInsertButton;
                CommandField.ShowCancelButton = EditorDetailsView.CurrentMode != DetailsViewMode.Insert;
            }
        }

        public bool ShowInsertButton
        {
            get { return TranslationsCount < Prtl_TranslationUtility.OwnerNameTranslations(CurrentOwnerID.Value).Count(); }
        }

        public bool ShowDeleteButton
        {
            get { return TranslationsCount != 1; }
        }

        private void FillDropDownlistWithNonTranslatedLanguages(DetailsView detailsView, string filteringdata)
        {
            var ddl = (DropDownList)detailsView.FindControl("LangDropDownList");
            ddl.DataTextField = "Language";
            ddl.DataValueField = "Lang_Id";
            ddl.DataSource = GetLangDS(filteringdata);
            ddl.DataBind();
        }
        private DetailsBasedControlTemplate BaseTemplateControl
        {
            get { return Controls.OfType<DetailsBasedControlTemplate>().First(); }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Visible)
            {

                BaseTemplateControl.DVConfig += BaseTemplateControl_DvConfig;
                BaseTemplateControl.DVInsertBound += BaseTemplateControl_DVInsertBound;
                BaseTemplateControl.DVDataBound += BaseTemplateControl_DvDataBound;
                BaseTemplateControl.ItemInserting += BaseTemplateControl_ItemInserting;
                BaseTemplateControl.ItemInserted += BaseTemplateControl_ItemInserted;
                BaseTemplateControl.ItemUpdating += BaseTemplateControl_ItemUpdating;
                BaseTemplateControl.ItemUpdated += BaseTemplateControl_ItemUpdated;
                BaseTemplateControl.ItemDeleted += BaseTemplateControl_OnItemDeleted;
                BaseTemplateControl.ModeChanging += BaseTemplateControl_ModeChanging;
                BaseTemplateControl.Title = EditorTitle + "";

                base.OnLoad(e);
            }
        }

        void BaseTemplateControl_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            ModeChanging((DetailsView)sender, e);
        }

        void BaseTemplateControl_DvConfig(object sender, EventArgs e)
        {
            SetCFButtonsVisibility();

        }

        void BaseTemplateControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            ItemUpdating((DetailsView)sender, e);
        }

        void BaseTemplateControl_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            ItemInserting((DetailsView)sender, e);
        }

        void BaseTemplateControl_DVInsertBound(object sender, EventArgs e)
        {
            var detailsview = (DetailsView)sender;
            FillDropDownlistWithNonTranslatedLanguages(detailsview, FilterValue);
        }

        void BaseTemplateControl_DvDataBound(object sender, EventArgs e)
        {
            DataBound(sender, e);
        }

        void BaseTemplateControl_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            OnUpdateSourceItem(e);
            OnDetailsViewItemUpdated(e);
        }

        void BaseTemplateControl_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (Mode != DetailsViewMode.Insert)
            {
                OnUpdateSourceItem(e);
            }
            else
            {
                OnUpdateSource(e);
            }
            OnDetailsViewItemInserted(e);
        }

        void BaseTemplateControl_OnItemDeleted(object sender, EventArgs e)
        {
            OnUpdateSourceItem(e);
        }
        private object GetLangDS(string filteringdata)
        {
            if (CurrentOwnerID != null)
            {
                var langs = GetLanguagesNotTranslatedDatasource(filteringdata);
                if (langs != null)
                    return
                        langs.Select(l => new { l.Lang_Id, Language = StaticUtilities.LanguageName(l.LCID) });
            }

            return null;
        }
        protected string GetClientIDs(params string[] serverIDs)
        {
            var clientids = new List<string>();
            if (EditorDetailsView.CurrentMode != DetailsViewMode.ReadOnly)
            {
                clientids.AddRange(
                    // ReSharper disable ConvertClosureToMethodGroup
                    serverIDs.Select(serverID => GetDVControl<Control>(serverID))
                    // ReSharper restore ConvertClosureToMethodGroup
                             .Where(control => control != null)
                             .Select(control => control.ClientID));
                return string.Join("/", clientids);
            }
            return null;
        }
        #endregion Methods

        #region Events

        public event DetailsViewInsertedEventHandler DetailsView_ItemInserted;

        public event DetailsViewUpdatedEventHandler DetailsView_ItemUpdated;


        public event EventHandler UpdateSource;

        public event EventHandler UpdateSourceItem;

        private void OnDetailsViewItemInserted(DetailsViewInsertedEventArgs e)
        {
            if (DetailsView_ItemInserted != null) DetailsView_ItemInserted(this, e);
        }

        private void OnDetailsViewItemUpdated(DetailsViewUpdatedEventArgs e)
        {
            if (DetailsView_ItemUpdated != null) DetailsView_ItemUpdated(this, e);
        }


        private void OnUpdateSource(EventArgs e)
        {
            if (UpdateSource != null) UpdateSource(this, e);
        }

        private void OnUpdateSourceItem(EventArgs e)
        {
            if (UpdateSourceItem != null) UpdateSourceItem(this, e);
        }

        #endregion Events

        #region Event Handlers

        protected virtual object EditorTitle { get { return null; } }

        protected virtual void DataBound(object sender, EventArgs e)
        {
        }

        protected string GetPreViewHeaderText()
        {
            switch (EditorDetailsView.CurrentMode)
            {
                case DetailsViewMode.ReadOnly:
                    return GlobalStrings.Preview;
                case DetailsViewMode.Edit:
                case DetailsViewMode.Insert:
                    return GlobalStrings.Editor;
                default:
                    return "";
            }
        }

        // ReSharper disable UnusedParameter.Global
        protected virtual void ItemInserting(DetailsView detailsview, DetailsViewInsertEventArgs e)
        {
        }

        protected virtual void ItemUpdating(DetailsView detailsview, DetailsViewUpdateEventArgs e)
        {
        }

        protected virtual void ModeChanging(DetailsView detailsview, DetailsViewModeEventArgs e)
        {
        }



        #endregion Event Handlers

        #region Properties

        #region Controls

        protected DetailsView EditorDetailsView
        {
            get { return GetControl<DetailsView>("Editor_DetailsView", BaseTemplateControl); }
        }

        protected ModalPopupExtender EditorModalPopupExtender
        {
            get { return GetControl<ModalPopupExtender>("Editor_ModalPopupExtender", BaseTemplateControl); }
        }


        
        private CommandField CommandField
        {
            get { return EditorDetailsView.Fields[EditorDetailsView.Fields.Count - 1] as CommandField; }
        }

        #endregion Controls

        #region Abstract

        protected virtual string DefaultValueForFiltering { get { return ""; } }

        protected virtual string FilterValueName { get { return ""; } }

        #endregion Abstract

        #region Normal

        protected prtl_Owner CurrentOwner
        {
            get { return ((PageBase)Page).CurrentOwner; }
        }

        protected Guid? CurrentOwnerID
        {
            get { return GetViewStateValueOrDefault("CurrentOwnerID", Guid.Empty); }
            private set { ViewState["CurrentOwnerID"] = value; }
        }

        /// <summary>
        /// The value that is used to Filter the Data ( the Primary key of the details view to show its translations)
        /// </summary>
        protected string FilterValue
        {
            get
            {
                // using a session because we target a filtering where parameter in LinqDatasources 
                return StaticUtilities.GetSessionValueOrDefault(Page, FilterValueName, DefaultValueForFiltering);
            }
            set
            {
                Page.Session[FilterValueName] = value;
            }
        }

        public DetailsViewMode Mode
        {
            get { return GetViewStateValueOrDefault("EditorMode", DetailsViewMode.ReadOnly); }
            set { ViewState["EditorMode"] = value; }
        }

        public abstract string EditorClientID { get; }

        #endregion Normal

        #endregion Properties
    }
}