using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.UserControls.Base;

using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.Base
{
    /// <summary>
    ///  An Abstract Class to Control the basic Structure of Listveiew based controls
    /// (the abstract class enforces the implementation of important methods and properties in the inherited controls)
    /// </summary>
    public abstract class ListViewBasedUserControl : UserControlBase
    {
        public Guid CurrentTranslationID
        {
            get
            {
                return FilterOwnerID.HasValue ? FilterOwnerID.Value : Guid.Empty;
            }
        }

        /// <summary>
        /// The LinqDataSource associated with the ListView Control
        /// </summary>
        public Guid? FilterOwnerID
        {
            get
            {
                return StaticUtilities.GetSessionValueOrDefault<Guid?>(Page, FilterSessionName, null);
            }
            set { Page.Session[FilterSessionName] = value; }
        }

        protected ListViewItem CurrentListViewItem
        {
            get { return ListViewControl.Items[CurrentEditorIndex]; }
        }

        /// <summary>
        /// The name of LinqDataSource associated with the ListView Control
        /// </summary>
        protected abstract string FilterSessionName
        { get; }

        /// <summary>
        /// The name of LinqDataSource associated with the ListView Control
        /// </summary>
        protected abstract string ListViewLinqDataSourceName { get; }

        /// <summary>
        /// The Index of the rown that the Editor is editing in details view
        /// </summary>
        private int CurrentEditorIndex
        {
            get
            {
                return GetViewStateValueOrDefault("CurrentEditorIndex", -1);
            }
            set
            {
                ViewState["CurrentEditorIndex"] = value;
            }
        }

        /// <summary>
        /// The LinqDataSource associated with the ListView Control
        /// </summary>
        private LinqDataSource ListViewLinqDataSource
        {
            get { return Control<LinqDataSource>(ListViewLinqDataSourceName); }
        }

        public virtual void UpdateListItem(ListViewItem listViewItem)
        {
            var Editor_LinkButton = GetControl<LinkButton>("Editor_LinkButton", listViewItem);
            var PrimaryKey = Editor_LinkButton.CommandArgument;
            var NotDoneLabel = GetControl<Label>("NotDoneLabel", listViewItem);
            NotDoneLabel.Text = NotDone(PrimaryKey);
            var StatusImage = GetControl<Image>("StatusImage", listViewItem);
            StatusImage.ImageUrl = Status(PrimaryKey);

            var PublishedImage = GetControl<Image>("PublishedImage", listViewItem);

            var MenuID = GetControl<HiddenField>("MenuID", listViewItem);
            if (MenuID != null)
            {
                if (PublishedImage != null)
                {
                    PublishedImage.ImageUrl = PublishedStatus(Published(PrimaryKey));
                }
            }
            else if (PublishedImage != null)
            {
                PublishedImage.ImageUrl = PublishedStatus(Published(PrimaryKey));
            }
        }

        protected T DetailsView<T>() where T : DetailsViewBasedUserControl
        {
            return (T)DetailsViewControl;
        }

        protected void DetailsViewControl_UpdateSource(object sender, EventArgs e)
        {
            DataBind();
        }

        protected void DetailsViewControl_UpdateSourceItem(object sender, EventArgs e)
        {
            UpdateListItem(CurrentListViewItem);
        }

        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
            var Linkbutton = (LinkButton)sender;
            CurrentEditorIndex = ((ListViewDataItem)Linkbutton.NamingContainer).DisplayIndex;
            foreach (
                var listdatarow in
                    ListViewControl.Items.Select(listitem => GetControl<HtmlTableRow>("ListViewDataRow", listitem)))
                listdatarow.Attributes["class"] = "ListViewItemTemplateRow";
            var linkbutton = (LinkButton)sender;
            var item = ((ListViewDataItem)linkbutton.NamingContainer);
            var datarow = GetControl<HtmlTableRow>("ListViewDataRow", item);
            datarow.Attributes["class"] = "ListViewItemTemplateRowSelected";
            DetailsViewControl.Show(FilterOwnerID, Linkbutton.CommandArgument);//, Linkbutton.CommandArgument
        }

        protected string GetCommandArgForListItem(ListViewItem listViewItem)
        {
            return GetControl<LinkButton>("Editor_LinkButton", listViewItem).CommandArgument;
        }

        /// <summary>
        /// Called when an Item is being deleted in the ListView Control The full implementation is done at the child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // ReSharper disable UnusedParameter.Global
        protected abstract void ItemDeleting(object sender, ListViewDeleteEventArgs e);

        // ReSharper restore UnusedParameter.Global

        protected void ListViewControl_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "ListView Delete Operation On Row:" + e.Keys[ListViewControl.DataKeyNames[0]], ListViewLinqDataSource.TableName);

            ItemDeleting(sender, e);
        }

        protected void ListViewControl_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "ListView Insertion Operation", ListViewLinqDataSource.TableName);
        }

        protected void ListViewControl_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "ListView Update Operation On Row:" + e.Keys[ListViewControl.DataKeyNames[0]], ListViewLinqDataSource.TableName);
        }

        protected string NotDone(object data,[Optional]string abbr)
        {
            if (data == null) return null;
            if (NotTranslatedLangs(data,abbr) != null)
            {
                var notDone =
                      NotTranslatedLangs(data, abbr).Select(prtlLanguage => StaticUtilities.LanguageName(prtlLanguage == null ? "" : prtlLanguage.LCID)).ToArray();
                return string.Join(" , ", notDone);
            }
            return null;
        }

        protected abstract IEnumerable<prtl_Language> NotTranslatedLangs(object data, [Optional]string abbr);

        protected string Status(object data,[Optional]string abbr)
        {
            return Status(data, OKImageURL, NotOKImageURL,abbr);
        }
        protected string PublishedStatus(object data)
        {
            return PublishedStatus(data, OKImageURL, NotOKImageURL);
        }

        public string PublishedStatus(object data, string OKimageURL, string NotOKimageURL)
        {
            return Convert.ToBoolean(data.ToString()) ? OKimageURL : NotOKimageURL;
        }

        protected abstract int TranslationCount(object data, [Optional]string abbr);

        protected abstract bool Published(object data, [Optional]string abbr);

        private string Status(object data, string OKimageURL, string NotOKimageURL,string abbr)
        {
            if (abbr == null)
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_univ_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility. OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;

            }
            else if (abbr.ToLower() == "fci")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_fci_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "fee")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_fee_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "eng")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_eng_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "nur")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_nur_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "edu")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_edu_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "sci")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_sci_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "edv")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_edv_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "agr")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_agr_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "hec")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_hec_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "law")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_law_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "fpe")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_fpe_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
                //****************
            else if (abbr.ToLower() == "vmed")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_VMed_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "pharm")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_Pharm_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
                //***********************
            else if (abbr.ToLower() == "fa")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_fas_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "art")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_art_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "ho")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_hos_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "med")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_med_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "liv")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_liv_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "com")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_com_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_ecedu_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else if (abbr.ToLower() == "media")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_media_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            //13-4-2022
            else if (abbr.ToLower() == "ai")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_ai_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }//fatma 6-6-2022
            else if (abbr.ToLower() == "dent")
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerName_dent_Translations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            else
            {
                if (data == null) return null;
                if (TranslationCount(data, abbr) == 0 &&
                    !Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Any())
                    return NotOKimageURL;
                if (TranslationCount(data, abbr) != -1)
                {
                    string imageUrl = (TranslationCount(data) < Prtl_TranslationUtility.OwnerNameTranslations(CurrentTranslationID).Count())
                                          ? NotOKimageURL
                                          : OKimageURL;
                    return imageUrl;
                }
                return null;
            }
            
        }

        // ReSharper disable MemberCanBePrivate.Global

        #region ImagesURL Properties

        /// <summary>
        /// Handles the click of EditorButton Click
        /// </summary>
        // ReSharper disable EventNeverSubscribedTo.Global
        public event EventHandler EditorButtonClick;

        [UrlProperty]
        public string CancelImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("CancelImageURL", GetCommonWebResource("cancel"));
            }
            set
            {
                ViewState["CancelImageURL"] = value;
            }
        }

        [UrlProperty]
        public string DeleteImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("DeleteImageURL", GetCommonWebResource("delete"));
            }
            set
            {
                ViewState["DeleteImageURL"] = value;
            }
        }

        /// <summary>
        /// DetailsViewBased Control that is embeded in the Server Control
        /// </summary>
        public DetailsViewBasedUserControl DetailsViewControl
        {
            get
            {
                var x = Control<DetailsViewBasedUserControl>(DetailsViewBasedName);
                return DetailsViewBasedName != null ? x : null;
            }
        }

        // ReSharper disable MemberCanBeProtected.Global
        [UrlProperty]
        public string EditImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("EditImageURL", GetCommonWebResource("edit"));
            }
            set
            {
                ViewState["EditImageURL"] = value;
            }
        }

        [UrlProperty]
        public string EditorImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("EditorImageURL", GetCommonWebResource("language"));
            }
            set
            {
                ViewState["EditorImageURL"] = value;
            }
        }

        [UrlProperty]
        public string InsertImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("InsertImageURL", GetCommonWebResource("insert"));
            }
            set
            {
                ViewState["InsertImageURL"] = value;
            }
        }

        /// <summary>
        /// The ListView Control contained in the server control
        /// </summary>
        public ListView ListViewControl
        {
            get
            {
                return Control<ListView>(ListViewName);
            }
        }

        [UrlProperty]
        public string NotOKImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("NotOKImageURL", GetCommonWebResource("NotOK"));
            }
            set
            {
                ViewState["NotOKImageURL"] = value;
            }
        }

        // ReSharper disable UnusedMember.Global
        [UrlProperty]
        public string OKImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("OKImageURL", GetCommonWebResource("OK"));
            }
            set
            {
                ViewState["OKImageURL"] = value;
            }
        }

        [UrlProperty]
        public string UpdateImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("UpdateImageURL", GetCommonWebResource("update"));
            }
            set
            {
                ViewState["UpdateImageURL"] = value;
            }
        }

        [UrlProperty]
        public string URLEditorImageURL
        {
            get
            {
                return GetViewStateValueOrDefault("URLEditorImageURL", GetCommonWebResource("link"));
            }
            set
            {
                ViewState["URLEditorImageURL"] = value;
            }
        }

        /// <summary>
        /// The Name of the DetailsViewBased Control that is embeded in the Server Control
        /// </summary>
        protected abstract string DetailsViewBasedName { get; }

        /// <summary>
        /// The Name of the ListView Control contained in the server control
        /// </summary>
        protected abstract string ListViewName { get; }

        // ReSharper restore EventNeverSubscribedTo.Global
        /// <summary>
        /// Calls the EditorButtonClick Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RaiseEditorButtonClick(object sender, EventArgs e)
        {
            if (EditorButtonClick != null)
            {
                EditorButtonClick(sender, e);
            }
        }

        #endregion ImagesURL Properties
    }
}