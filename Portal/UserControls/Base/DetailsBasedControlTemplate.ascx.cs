using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

using Resources;

namespace MnfUniversity_Portals.UserControls.Base
{
    public partial class DetailsBasedControlTemplate : UserControlBase
    {
        #region Events

        public event EventHandler DVConfig;

        public event EventHandler DVDataBound;

        public event EventHandler DVInsertBound;

        public event EventHandler DVLoad;

        public event EventHandler ItemDeleted;

        public event DetailsViewInsertedEventHandler ItemInserted;

        public event DetailsViewInsertEventHandler ItemInserting;

        public event DetailsViewUpdatedEventHandler ItemUpdated;

        public event DetailsViewUpdateEventHandler ItemUpdating;

        public event DetailsViewModeEventHandler ModeChanging;

        #endregion

        [
         DefaultValue(null),
         Editor("System.Web.UI.Design.WebControls.DataFieldEditor,  System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)),
         TypeConverter(typeof(StringArrayConverter))
         ]
        public string[] DataKeys
        {
            get { return Editor_DetailsView.DataKeyNames; }
            set { Editor_DetailsView.DataKeyNames = value; }
        }

        [IDReferenceProperty(typeof(DataSourceControl))]
        public string DataSourceID
        {
            get { return Editor_DetailsView.DataSourceID; }
            set { Editor_DetailsView.DataSourceID = value; }
        }

        /// <devdoc>
        /// <para>Gets a collection of <see cref='System.Web.UI.WebControls.DataControlField'/> controls in the <see cref='System.Web.UI.WebControls.DetailsView'/>. This property is read-only.</para>
        /// </devdoc>
        [DefaultValue(null), Editor("System.Web.UI.Design.WebControls.DataControlFieldTypeEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)),
        MergableProperty(false),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public DataControlFieldCollection Fields
        {
            get { return Editor_DetailsView.Fields; }

        }

        public string Title { get { return EditorTitleLocalize.Text; } set { EditorTitleLocalize.Text = value; } }

        private DetailsViewBasedUserControl ContainingControl { get { return (DetailsViewBasedUserControl)Parent; } }

        protected void Editor_DetailsView_DataBound(object sender, EventArgs e)
        {
            var detailsview = (DetailsView)sender;
            OnDVDataBound(e);

            if (detailsview.CurrentMode != DetailsViewMode.Insert) return;
            OnDVInsertBound(e);
        }

        protected void Editor_DetailsView_ItemCreated(object sender, EventArgs eventArgs)
        {
            var detailsview = (DetailsView)sender;

            //Test FooterRow to make sure all rows have been created
            if (detailsview.FooterRow == null || detailsview.Rows.Count <= 0) return;
            var lastrow = detailsview.Rows[detailsview.Rows.Count - 1];
            switch (detailsview.CurrentMode)
            {
                case DetailsViewMode.ReadOnly:
                    var deletebutton = ModifyLinkButton(lastrow, "Delete", GlobalStrings.DeleteToolTip, GlobalStrings.DeleteName);
                    if (deletebutton != null)
                        deletebutton.OnClientClick = "return confirm('" + GlobalStrings.DeleteItemMessage + "');";
                    ModifyLinkButton(lastrow, "Edit", GlobalStrings.EditToolTip, GlobalStrings.EditName);
                    ModifyLinkButton(lastrow, "New", GlobalStrings.NewToolTip, GlobalStrings.NewName);
                    break;
                case DetailsViewMode.Edit:
                    ModifyLinkButton(lastrow, "Cancel", GlobalStrings.CancelToolTip, GlobalStrings.CancelName);
                    var updatebutton = ModifyLinkButton(lastrow, "Update", GlobalStrings.UpdateToolTip, GlobalStrings.UpdateName);
                    updatebutton.ValidationGroup = "UpdateGroup";
                    updatebutton.CausesValidation = true;
                    break;
                case DetailsViewMode.Insert:
                    var insertbutton = ModifyLinkButton(lastrow, "Insert", GlobalStrings.InsertToolTip, GlobalStrings.InsertName);
                    insertbutton.ValidationGroup = "InsertGroup";
                    insertbutton.CausesValidation = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }



        }

        protected void Editor_DetailsView_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            var detailsview = (DetailsView)sender;
            OnDVConfig(e);
            OnItemDeleted(e);
            Editor_ModalPopupExtender.Show();
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Delete Operation On Row:" + e.Keys[detailsview.DataKeyNames[0]], DVLinqDS(detailsview).TableName);
        }

        protected void Editor_DetailsView_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            var detailsview = (DetailsView)sender;
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Delete Trial On Row:" + e.Keys[detailsview.DataKeyNames[0]], DVLinqDS(detailsview).TableName);
        }

        protected void Editor_DetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
     {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Insertion Operation", DVLinqDS((DetailsView)sender).TableName);
            var detailsview = (DetailsView)sender;
            detailsview.DataBind();
            OnItemInserted(e);

        }

        protected void Editor_DetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            OnItemInserting(e);
        }

        protected void Editor_DetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            var detailsview = (DetailsView)sender;
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Update Operation On Row:" + e.Keys[detailsview.DataKeyNames[0]], DVLinqDS(detailsview).TableName);
            OnItemUpdated(e);
        }

        // ReSharper restore UnusedParameter.Global





        protected void Editor_DetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            var detailsview = (DetailsView)sender;
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Update Trial On Row:" + e.Keys[detailsview.DataKeyNames[0]], DVLinqDS(detailsview).TableName);
            OnItemUpdating(e);
        }

        protected void Editor_DetailsView_Load(object sender, EventArgs e)
        {
            if (ContainingControl.Mode != DetailsViewMode.Insert && Editor_DetailsView.CurrentMode == DetailsViewMode.Insert &&
                Page.Request["__EVENTTARGET"] != null &&
                Page.Request["__EVENTTARGET"].Contains("Editor_DetailsView$ctl0")
                && !Page.Request["__EVENTTARGET"].Contains("ArticleEditorControl"))
            {
                Editor_DetailsView.InsertItem(true);
            }

            // make the click on the modal background hide the popup

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "hideModalPopupViaClient", String.Format(
                @"function hideModalPopupViaClient() {{
                var modalPopupBehavior = $find('{0}');
                if (modalPopupBehavior) modalPopupBehavior.hide();
            }}", Editor_ModalPopupExtender.ClientID), true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "pageLoad", String.Format(
                @"function pageLoad() {{
                var backgroundElement = $get('{0}_backgroundElement');
                if (backgroundElement) $addHandler(backgroundElement, 'click', hideModalPopupViaClient);
            }}", Editor_ModalPopupExtender.ClientID), true);

            if (!(Editor_DetailsView.Fields[Editor_DetailsView.Fields.Count - 1] is CommandField))
            {
                Editor_DetailsView.Fields.Add(new CommandField { ButtonType = ButtonType.Link, ShowDeleteButton = true, ShowEditButton = true, ShowInsertButton = true });
            }
            OnDVLoad(e);
        }


        protected void Editor_DetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (ContainingControl.Mode == DetailsViewMode.Insert)
            {
                ContainingControl.Mode = DetailsViewMode.ReadOnly;
                return;
            }
            OnDVConfig(e);
            Editor_ModalPopupExtender.Show();
            OnModeChanging(e);
        }

        protected void EditorDetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            Editor_ModalPopupExtender.Show();
        }

        private LinqDataSource DVLinqDS(DetailsView detailsView)
        {
            return (LinqDataSource)detailsView.DataSourceObject;
        }

        private LinkButton ModifyLinkButton(DetailsViewRow footerRow, string commandName, string buttonToolTip, string buttonText)
        {
            var cell = (DataControlFieldCell)footerRow.Controls[0];
            var button = cell.Controls.OfType<LinkButton>().SingleOrDefault(c => c.CommandName == commandName);
            if (button != null)
            {
                var imageurl = "";
                switch (button.CommandName)
                {
                    case "Insert":
                    case "New":
                        imageurl = ieurl;
                        break;

                    case "Cancel":
                        imageurl = ciurl;
                        break;

                    case "Delete":
                        imageurl = diurl;
                        break;

                    case "Edit":
                        imageurl = eiurl;
                        break;

                    case "Update":
                        imageurl = uiurl;
                        break;
                }
                button.ToolTip = buttonToolTip;
                button.EnableViewState = false;
                button.Controls.Add(
                    new Image
                    {
                        CssClass = "NoMargin",
                        ToolTip = button.ToolTip,
                        ImageUrl = imageurl
                    });
                button.Controls.Add(new Label { Text = buttonText });
            }
            return button;
        }

        private void OnDVConfig(EventArgs e)
        {
            if (DVConfig != null) DVConfig(Editor_DetailsView, e);
        }

        private void OnDVDataBound(EventArgs e)
        {
            EventHandler handler = DVDataBound;
            if (handler != null) handler(Editor_DetailsView, e);
        }

        private void OnDVInsertBound(EventArgs e)
        {
            EventHandler handler = DVInsertBound;
            if (handler != null) handler(Editor_DetailsView, e);
        }

        private void OnDVLoad(EventArgs e)
        {
            if (DVLoad != null) DVLoad(Editor_DetailsView, e);
        }

        private void OnItemDeleted(EventArgs e)
        {
            EventHandler handler = ItemDeleted;
            if (handler != null) handler(Editor_DetailsView, e);
        }

        private void OnItemInserted(DetailsViewInsertedEventArgs e)
        {
            DetailsViewInsertedEventHandler handler = ItemInserted;
            if (handler != null) handler(Editor_DetailsView, e);
        }

        private void OnItemInserting(DetailsViewInsertEventArgs e)
        {
            if (ItemInserting != null) ItemInserting(Editor_DetailsView, e);
        }

        private void OnItemUpdated(DetailsViewUpdatedEventArgs e)
        {
            DetailsViewUpdatedEventHandler handler = ItemUpdated;
            if (handler != null) handler(Editor_DetailsView, e);
        }

        private void OnItemUpdating(DetailsViewUpdateEventArgs e)
        {
            if (ItemUpdating != null) ItemUpdating(Editor_DetailsView, e);
        }

        private void OnModeChanging(DetailsViewModeEventArgs e)
        {
            DetailsViewModeEventHandler handler = ModeChanging;
            if (handler != null) handler(Editor_DetailsView, e);
        }

        protected void Editor_DetailsView_PreRender(object sender, EventArgs e)
        {
            if (Editor_DetailsView.CurrentMode != DetailsViewMode.ReadOnly)
                StaticUtilities.SetSessionWithPaths(ContainingControl.EditorClientID, Page);
        }


    }
}