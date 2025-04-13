using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MisBLL;
using Portal_DAL;
using Resources;
using Image = System.Drawing.Image;

namespace MnfUniversity_Portals.UI.Admin
{
    public partial class AdminPreferences : PageBase
    {
        protected string Translation_Id
        {
            get { return Session["Translation_Id"].ToString(); }
            set { Session["Translation_Id"] = value; }
        }

        private DetailsViewMode mode
        {
            get { return StaticUtilities.GetSessionValueOrDefault(this, "EditorMode", DetailsViewMode.ReadOnly); }
            set { Session["EditorMode"] = value; }
        }

        private string OwnerAbbr
        {
            get { return Prtl_OwnersUtility.GetOwnerByOwnerID(FilterControl.GetFilteredOwner_ID).Abbr; }
        }

        private object SetFilteredOwnerId
        {
            set { Session["EditorParentOwner_ID"] = value; }
        }

        protected void BannerFileUploader_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            var filepath = URLBuilder.GetLocalpath(this, SiteFolders.Owners_Banners, OwnerAbbr,
                                                      BannerLangDropDownList.SelectedValue);
            SaveImage(sender, e, filepath);
            BannerImageZoom.SmallImageURL = BannerImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Banners, OwnerAbbr + "_" + BannerLangDropDownList.SelectedValue);
        }

        protected void BannerLangDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BannerImageZoom.SmallImageURL = BannerImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Banners, OwnerAbbr + "_" + BannerLangDropDownList.SelectedValue);
        }

        protected void ChangeAbbr(object sender, EventArgs e)
        {
            if (Prtl_OwnersUtility.AbbrExists(txtAbbr.Text))
            {
                lblError.Text = (string)GetLocalResourceObject("AdminPreferences_ChangeAbbr_Abbrivation_Already_Exists");
            }
            else
            {
                Prtl_OwnersUtility.updateStaffAbbr(URLBuilder.OwnerAbbr(Page.RouteData), txtAbbr.Text);
                lblError.Text = (string)GetLocalResourceObject("AdminPreferences_ChangeAbbr_Abbrivation_Changed_Successfuly");
            }
        }

        protected string CurrentTheme(object Translation_ID)
        {
            return Prtl_OwnersUtility.GetOwnerByOwnerID(Guid.Parse(Translation_ID.ToString())).Theme;
        }

        protected string Done(object data)
        {
            var Done = Prtl_LanguagesUtility.Getlanguages((Guid)data)
                .Select(prtlLanguage => StaticUtilities.LanguageName(prtlLanguage.LCID)).ToArray();
            return String.Join(" , ", Done);
        }

        protected void Editor_DetailsView_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Delete Operation On Row:" + e.Keys[Editor_DetailsView.DataKeyNames[0]], TranslationsLinqDataSource.TableName);

            DetermineModeAndShowInsertButton2(Editor_DetailsView);
            Editor_ModalPopupExtender.Show();
            OwnersListView.DataBind();
        }

        protected void Editor_DetailsView_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Delete Trail On Row:" + e.Keys[Editor_DetailsView.DataKeyNames[0]], TranslationsLinqDataSource.TableName);
        }

        protected void Editor_DetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Insertion Operation", TranslationsLinqDataSource.TableName);
        }

        protected void Editor_DetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            using (var dc = new PortalDataContextDataContext())
            {
                e.Values["Translation_Id"] = Translation_Id;
                var langddl1 = (DropDownList)Editor_DetailsView.FindControl("LangDropDownList");
                var langs = dc.prtl_Languages;
                var lang = langs.SingleOrDefault(l => l.LCID == langddl1.SelectedValue);
                if (lang != null)
                    e.Values["Lang_id"] = lang.Lang_Id;
                else
                {
                    var newlang = new prtl_Language { LCID = langddl1.SelectedValue };
                    dc.prtl_Languages.InsertOnSubmit(newlang);
                    dc.SubmitChanges();
                    e.Values["Lang_id"] = newlang.Lang_Id;
                }
            }

            OwnersListView.DataBind();
        }

        protected void Editor_DetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "DetailsView Update Operation On Row:" + e.Keys[Editor_DetailsView.DataKeyNames[0]], TranslationsLinqDataSource.TableName);
        }

        protected void Editor_DetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            OwnersListView.DataBind();
            if (mode == DetailsViewMode.Insert)
            {
                mode = DetailsViewMode.Insert;
                return;
            }
            DetermineModeAndShowInsertButton2(Editor_DetailsView);
            Editor_ModalPopupExtender.Show();
        }

        protected void Editor_DetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            Editor_ModalPopupExtender.Show();
        }

        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
            var imagebutton = (ImageButton)sender;
            Translation_Id = imagebutton.CommandArgument;

            Editor_DetailsView.ChangeMode(DetailsViewMode.ReadOnly);

            DetermineModeAndShowInsertButton2(Editor_DetailsView);
            Editor_ModalPopupExtender.Show();
        }

        protected void FilterControl_SearchClicked(object sender, EventArgs e)
        {
            SetFilter();
            BannerLangDropDownList.DataSource = Prtl_LanguagesUtility.Getlanguages(FilterControl.GetFilteredOwner_ID).Select(tr => new { Value = tr.LCID, Text = StaticUtilities.LanguageName(tr.LCID) });
            BannerLangDropDownList.DataBind();
            BannerLangDropDownList_SelectedIndexChanged(sender, e);
            LogoImageZoom.SmallImageURL = LogoImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Logos, OwnerAbbr);
            IconImageZoom.SmallImageURL = IconImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Icons, OwnerAbbr);
            IntroImageZoom.SmallImageURL = IntroImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Intros, OwnerAbbr);
        }
        protected static void ResizeLogoIconBanner(int width, int height, string toFullFileName)
        {
            int newWidth = width;
            int newHeight = height;
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(toFullFileName);
            System.Drawing.Image thumbNailImg = fullSizeImg.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
            byte[] byteArray = imageToByteArray(thumbNailImg);
            thumbNailImg.Dispose();
            fullSizeImg.Dispose();
            System.Drawing.Image result;
            ImageFormat format = ImageFormat.Png;
            using (var ms = new MemoryStream(byteArray))
            {
                result = System.Drawing.Image.FromStream(ms);
            }
            using (System.Drawing.Image imageToExport = result)
            {
                var fs = new FileStream(toFullFileName, FileMode.Create, FileAccess.ReadWrite);
                imageToExport.Save(fs, format);
            }
        }

        protected void DetailsView_ItemCreated(object sender, EventArgs e)
        {
            var detailsview = (DetailsView)sender;

            //Test FooterRow to make sure all rows have been created
            if (detailsview.FooterRow == null || detailsview.Rows.Count <= 0) return;

            // The command bar is the last element in the Rows collection
            int commandRowIndex = detailsview.Rows.Count - 1;
            DetailsViewRow commandRow = detailsview.Rows[commandRowIndex];
            ImageButton b = null;

            // Look for the DELETE button
            var cell = (DataControlFieldCell)commandRow.Controls[0];
            foreach (ImageButton button in cell.Controls.OfType<ImageButton>())
            {
                switch (button.CommandName)
                {
                    case "Delete":
                        button.ToolTip = GlobalStrings.DeleteToolTip;
                        button.OnClientClick = "if (!confirm('" + GlobalStrings.DeleteItemMessage + "')) return false;";
                        break;

                    case "Edit":
                        button.ToolTip = GlobalStrings.EditToolTip;
                        break;

                    case "New":
                        button.ToolTip = GlobalStrings.NewToolTip;
                        break;

                    case "Insert":
                        button.ToolTip = GlobalStrings.InsertToolTip;
                        button.ValidationGroup = "InsertGroup";
                        button.CausesValidation = true;
                        b = button;
                        break;

                    case "Update":
                        button.ToolTip = GlobalStrings.UpdateToolTip;
                        button.ValidationGroup = "UpdateGroup";
                        button.CausesValidation = true;
                        break;

                    case "Cancel":
                        button.ToolTip = GlobalStrings.CancelToolTip;
                        break;
                }
            }
            if (b != null)
                b.Parent.Controls.Add(new Label { Text = GlobalStrings.PageBase_DepDetailsView_ItemCreated_Insert_New_Item });
        }
        private static byte[] imageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
        protected void IconFileUploader_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            var filepath = URLBuilder.GetLocalpath(this, SiteFolders.Owners_Icons, OwnerAbbr);
            if (SaveImage(sender, e, filepath))
                ResizeLogoIconBanner(15, 16, filepath);
            IconImageZoom.SmallImageURL = IconImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Icons, OwnerAbbr);
        }

        protected void IntroFileUploader_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            var filepath = URLBuilder.GetLocalpath(this, SiteFolders.Owners_Intros, OwnerAbbr);
            SaveImage(sender, e, filepath);
            IntroImageZoom.SmallImageURL = IntroImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Intros, OwnerAbbr);
        }

        protected void LogoFileUploader_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            var filepath = URLBuilder.GetLocalpath(this, SiteFolders.Owners_Logos, OwnerAbbr);
            if (SaveImage(sender, e, filepath))
                ResizeLogoIconBanner(75, 75, filepath);
            LogoImageZoom.SmallImageURL = LogoImageZoom.BigImageURL = URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Logos, OwnerAbbr);
        }

        protected string OwnerName(object Translation_ID)
        {
            var translation =
                Prtl_OwnersUtility.GetOwnerByOwnerID(Guid.Parse(Translation_ID.ToString())).prtl_Translations.
                    SingleOrDefault(t => t.prtl_Language.LCID == CurrentLanguage);
            return translation == null ? "Not Translated" : translation.Translation_Data;
        }

        protected void OwnersLinqDataSource_Inserted(object sender, LinqDataSourceStatusEventArgs e)
        {
            if (e.Result == null) return;

            // Add translation to the menu item after insertion
            var insertedMenu = (prtl_Owner)e.Result;
            var CurrentTranslation = OwnersListView.InsertItem.GetControl<TextBox>("InsertOwnerTextBox");
            var langid = Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(Page)).Lang_Id;
            var translation = new prtl_Translation
            {
                Lang_Id = langid,
                Translation_ID = insertedMenu.Owner_ID,
                Translation_Data = CurrentTranslation.Text
            };

            Prtl_TranslationUtility.InsertTranslation(translation);
        }

        protected void OwnersListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "ListView Delete Operation On Row:" + e.Keys[OwnersListView.DataKeyNames[0]], OwnersLinqDataSource.TableName);

            Prtl_TranslationUtility.DeleteTranslations((Guid)e.Keys["Owner_ID"], URLBuilder.CurrentOwnerAbbr(Page.RouteData));
        }

        protected void OwnersListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            e.Values["Parent_Id"] = Prtl_OwnersUtility.GetOwnerByOwnerID(FilterControl.GetFilteredOwner_ID).ID;
            e.Values["Type"] = OwnerTypeDropDownList.SelectedValue;
        }

        protected void OwnersListViewControl_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "ListView Insertion Operation", OwnersLinqDataSource.TableName);
        }

        protected void OwnersListViewControl_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "ListView Update Operation On Row:" + e.Keys[OwnersListView.DataKeyNames[0]], OwnersLinqDataSource.TableName);
        }

        protected void OwnerTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Owner_Type"] = int.Parse(OwnerTypeDropDownList.SelectedValue);
            OwnersListView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StaffManagementTabPanel.Visible = OwnersManagement_TabPanel.Visible = User.Identity.Name.ToLower() == StaticUtilities.Superadmin;
            Label6.Visible = User.Identity.Name.ToLower() == StaticUtilities.Superadmin;
            OwnerTypeDropDownList.Visible = User.Identity.Name.ToLower() == StaticUtilities.Superadmin;
           
            if (User.IsInRole("StaffRole"))
            {
                StaffAbbrTab.Visible = User.IsInRole("StaffRole");
                MainTabContainer.ActiveTabIndex = 4;
            }
            else
            {
                MainTabContainer.ActiveTabIndex = OwnersManagement_TabPanel.Visible ? 0 : 1;
            }
            PrepareFileUpload();
            if (!IsPostBack)
            {
                FilterControl_SearchClicked(null, null);

                //OwnerTypeDropDownList.DataSource = Enum.GetValues(typeof(OwnerTypes)).Cast<OwnerTypes>()
                //    .Where(p => (int)p > Prtl_OwnersUtility.GetOwnerByOwnerID(FilterControl.GetFilteredOwner_ID, null).Type)
                //    .Select(t => new { Value = (int)t, Text = t.ToString() });
                OwnerTypeDropDownList.DataSource = Prtl_OwnerTypesUtility.getOwnersTypes();

                // Enum.GetValues(typeof(OwnerTypes)).Cast<OwnerTypes>().ToList() ;
                // .t(t => new { Value = (int)t, Text = t.ToString() });
                OwnerTypeDropDownList.DataValueField = "ID";
                OwnerTypeDropDownList.DataTextField = "OwnerType";
                OwnerTypeDropDownList.DataBind();
                Session["Owner_Type"] = int.Parse(OwnerTypeDropDownList.SelectedValue);
            }
        }

        private static void DetermineModeAndShowInsertButton2(DetailsView detailsView)
        {
            var commandField = detailsView.Fields[detailsView.Fields.Count - 1] as CommandField;
            if (commandField != null)
            {
                commandField.ShowInsertButton = true;
                commandField.ShowCancelButton = detailsView.CurrentMode != DetailsViewMode.Insert;
            }
        }

        private bool SaveImage(object sender, AsyncFileUploadEventArgs e, string filepath)
        {
            var uploader = (AsyncFileUpload)sender;
            if (e.State == AsyncFileUploadState.Success)
            {
                if (File.Exists(filepath))
                {
                    File.SetAttributes(filepath, FileAttributes.Normal);
                    File.Delete(filepath);
                }

                uploader.PostedFile.SaveAs(filepath);
                logoerrorlbl.Visible = true;
                logoerrorlbl.Text = (string)GetLocalResourceObject("AdminPreferences_SaveImage_Done");
                return true;
            }
            logoerrorlbl.Visible = true;
            logoerrorlbl.Text = (string)GetLocalResourceObject("AdminPreferences_SaveImage_Not_Done");
            return false;
        }

        private void SetFilter()
        {
            SetFilteredOwnerId = FilterControl.GetFilteredOwner_ID;

            //SetFilteredOwnerId = Convert.ToInt32(OwnerTypeDropDownList.SelectedValue);
        }


        protected void MISUsersImport_Button_Click(object sender, EventArgs e)
        {
            StaffUsers_Utility.ImportMISEmails();
            ImportResultLabel.Text = "Importing completed successfully.";
        }


        protected void SendPortal_PasswordsEmails_Click(object sender, EventArgs e)
        {
            Server.ScriptTimeout = 70000;
            
            var result = StaffUsers_Utility.SendStaffEmail(EmailSubjectTextBox.Text,txtActualContent1. Text,
                SendToStaffMembersNotPasswordInformedCheckBox.Checked);
            ErrorsLabel.Text = string.IsNullOrEmpty(result) ? "Emails have been sent to the non notified users." : result;
        }



        protected void SendPasswordToStaffMemberEmailsButton_OnClick(object sender, EventArgs e)
        {
            var result = StaffUsers_Utility.SendStaffPasswordViaEmail(NationalIDTextBox.Text,EmailSubjectTextBox.Text,txtActualContent1.Text);
            ResetResultLabel.Text = string.IsNullOrEmpty(result) ? "An Email has been sent to the user." : result;
        }

        protected void ChangeUserName(object sender, EventArgs e)
        {
            if (Prtl_OwnersUtility.UserExists(UserName2.Text))
            {
                lblError2.Text = (string) GetLocalResourceObject("AdminPreferences_ChangeUserName_User_Already_Exists");
            }
            else
            {
                Prtl_OwnersUtility.updateStaffUserName(Page.User.Identity.Name, UserName2.Text);
                lblError2.Text = (string) GetLocalResourceObject("AdminPreferences_ChangeUserName_UserName_Changed_Successfully");
            }
        }

        protected void InsertStandardPasswordInformButton_OnClick(object sender, EventArgs e)
        {
           txtActualContent1.Text=
                    "Dear Staff Member ;" +
                    "<br/>The team of Menofia Portal is glad to give you the details for your new experimental portal which are:" +
                    "<br/>User Name : {UserName}" +
                    "<br/>Password  : {NewPassword}"  +
                    "<br/>URL       : <a href=\"{StaffURL}\">{StaffURL}</a>" +
                    "<br/><strong>Please be informed that these details are subject to change because the portal is still in beta phase" +
                    " and if many emails come from us containing the mentioned above details but different please consider the latest email only and remove the others.</strong> " +
                    "<br/>If you have any troubles please contact us always on" +
                    " <a href=\"mailto:mnfportal@gmail.com?subject={UserName} 's Staff Portal has a problem to report\">this email</a>." +
                    "<br/>Thanks for your time and your patience." +
                    "<br/>To change your details shown in your CV please log in to http://193.227.24.15/staff then search for your name in arabic then insert your National ID." +
                    "<br/> PS: please keep this email somewhere safe to use it later for any problems.";
            EmailSubjectTextBox.Text = "Your Experimental Portal @ Menofia";
        }
    }
}