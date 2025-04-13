using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.MenuEditor
{
    public partial class MenuEditorUserControl : ListViewBasedUserControl
    {
        /// <summary>
        /// The Name of the DetailsViewBased Control that is embeded in the Server Control
        /// </summary>
        protected override string DetailsViewBasedName
        {
            get { return "MenuDetailsViewControl1"; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            //if (!IsPostBack)
            //{
                var x = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                if (x.Type == 1)
                {
                    if (x.Abbr.EndsWith("s"))
                    {
                        Menu_LinqDataSource.TableName = "prtl_menu_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) ;
                        Session["TbName1"] = "prtl_menu_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData);
                    }
                    else
                    {
                        Menu_LinqDataSource.TableName = "prtl_menu_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "s";
                        Session["TbName1"] = "prtl_menu_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "s";
                    }
                }
                else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
                {
                    Menu_LinqDataSource.TableName = "prtl_menu_univs";
                    Session["TbName1"] = "prtl_menu_univs";
                }
                else
                {
                    Menu_LinqDataSource.TableName = "prtl_Menus";
                    Session["TbName1"] = "prtl_Menus";
                }
            //}
            //else
            //{
            //    Menu_LinqDataSource.TableName = (string)Session["TbName1"];
            //}


        }
        protected override string FilterSessionName
        {
            get { return "MenuOwner_ID"; }
        }




        protected override string ListViewLinqDataSourceName
        {
            get { return "Menu_LinqDataSource"; }
        }

        protected override string ListViewName
        {
            get { return "Menu_ListView"; }
        }

        public  string DropSelIndex
        {
            get {

                //string selvaue = PositionDropDownList.SelectedItem.Value;
                return "selvaue";
            }

           


          
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {

            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (abbr == null)
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_univ_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id,abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);

            }
            else if (abbr.ToLower() == "fci")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_fci_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "fee")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_fee_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "eng")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_eng_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "nur")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_nur_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "edu")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_edu_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "sci")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_sci_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "edv")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_edv_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "agr")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_agr_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "hec")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_hec_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "law")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_law_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "fpe")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_fpe_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
                //***********************
            else if (abbr.ToLower() == "vmed")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_VMed_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "pharm")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_Pharm_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
                //*******************************
            else if (abbr.ToLower() == "fa")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_fa_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "art")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_art_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "ho")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_ho_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "med")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_med_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "liv")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_liv_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            //121212121212
            else if (abbr.ToLower() == "ecedu")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_ecedu_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "media")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_media_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "ai")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_ai_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            //16-6-2022
            else if (abbr.ToLower() == "dent")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_dent_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else if (abbr.ToLower() == "com")
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.Get_com_MenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id, abbr);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id, abbr);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                base.UpdateListItem(listViewItem);
                var data = Prtl_MenuUtility.GetMenuByTranslationID(GetCommandArgForListItem(listViewItem));
                var editImage = GetControl<Image>("EditImage", listViewItem);
                editImage.ImageUrl = EditImageURL;
                var deleteImage = GetControl<Image>("DeleteImage", listViewItem);
                deleteImage.ImageUrl = DeleteImageURL;
                var MenuItemLabel = GetControl<HyperLink>("MenuItemLabel", listViewItem);
                MenuItemLabel.Text = TranslationData(data.Menu_id);
                Session["MenuID"] = data.Menu_id;
                MenuItemLabel.NavigateUrl = URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,
                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = MenuItemLabel.Text,
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
                var Parent_id = GetControl<Label>("Parent_id", listViewItem);
                Parent_id.Text = TranslationData(data.Parent_id);
                var OrderLabel = GetControl<Label>("OrderLabel", listViewItem);
                OrderLabel.Text = data.Order.ToString(CultureInfo.InvariantCulture);

            }
            

            
        }

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (abbr == null)
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_univ_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_univ_MenuItemAndSubItems(menuitem, true);

            }
            else if (abbr.ToLower() == "fci")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_fci_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_fci_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "fee")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_fee_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_fee_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "eng")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_eng_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_eng_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "nur")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_nur_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_nur_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "edu")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_edu_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_edu_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "sci")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_sci_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_sci_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "edv")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_edv_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_edv_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "agr")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_agr_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_agr_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "hec")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_hec_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_hec_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "law")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_law_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_law_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "fpe")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_fpe_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_fpe_MenuItemAndSubItems(menuitem, true);
            }
                //*************************
            else if (abbr.ToLower() == "pharm")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_Pharm_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_Pharm_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "vmed")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_VMed_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_VMed_MenuItemAndSubItems(menuitem, true);
            }
                //121212121212
            else if (abbr.ToLower() == "ecedu")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_ecedu_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_ecedu_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "media")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_media_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_media_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "ai")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_ai_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_ai_MenuItemAndSubItems(menuitem, true);
            }//16-2022
            else if (abbr.ToLower() == "dent")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_dent_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_dent_MenuItemAndSubItems(menuitem, true);
            }

            //***************************
            else if (abbr.ToLower() == "fa")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_fas_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_fas_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "art")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_art_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_art_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "ho")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_ho_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_hos_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "med")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_med_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_med_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "liv")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_liv_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_liv_MenuItemAndSubItems(menuitem, true);
            }
            else if (abbr.ToLower() == "com")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.Get_com_MenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.Delete_com_MenuItemAndSubItems(menuitem, true);
            }
           
            else
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                var menuitem = Prtl_MenuUtility.GetMenuByID(int.Parse(e.Keys["Menu_id"].ToString()));
                Prtl_MenuUtility.DeleteMenuItemAndSubItems(menuitem, true);
            }
           
        }

        protected void MenuEditorControlInsertClicked(object sender, EventArgs e)
        {
            MenuDetailsViewControl1.Position = PositionDropDownList.SelectedValue;
            MenuDetailsViewControl1.ShowInsert(FilterOwnerID);
        }

        protected string MenuItemNavigateURL(object menu_id,string abbr)
        {
            if (abbr == null)
            {
                var data = Prtl_MenuUtility.Get_univ_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);

            }
            else if (abbr.ToLower() == "fci")
            {
                var data = Prtl_MenuUtility.Get_fci_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "fee")
            {
                var data = Prtl_MenuUtility.Get_fee_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "eng")
            {
                var data = Prtl_MenuUtility.Get_eng_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "nur")
            {
                var data = Prtl_MenuUtility.Get_nur_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "edu")
            {
                var data = Prtl_MenuUtility.Get_edu_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "sci")
            {
                var data = Prtl_MenuUtility.Get_sci_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "edv")
            {
                var data = Prtl_MenuUtility.Get_edv_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "agr")
            {
                var data = Prtl_MenuUtility.Get_agr_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "hec")
            {
                var data = Prtl_MenuUtility.Get_hec_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "law")
            {
                var data = Prtl_MenuUtility.Get_law_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "fpe")
            {
                var data = Prtl_MenuUtility.Get_fpe_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
                //********************
            else if (abbr.ToLower() == "pharm")
            {
                var data = Prtl_MenuUtility.Get_Pharm_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "vmed")
            {
                var data = Prtl_MenuUtility.Get_VMed_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
                //**************************
            else if (abbr.ToLower() == "fa")
            {
                var data = Prtl_MenuUtility.Get_fas_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "art")
            {
                var data = Prtl_MenuUtility.Get_art_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "ho")
            {
                var data = Prtl_MenuUtility.Get_ho_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "med")
            {
                var data = Prtl_MenuUtility.Get_med_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "liv")
            {
                var data = Prtl_MenuUtility.Get_liv_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            //121212121212
            else if (abbr.ToLower() == "ecedu")
            {
                var data = Prtl_MenuUtility.Get_ecedu_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
                //33333333333333

            else if (abbr.ToLower() == "media")
            {
                var data = Prtl_MenuUtility.Get_media_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
           // 13-4-2022
            else if (abbr.ToLower() == "ai")
            {
                var data = Prtl_MenuUtility.Get_ai_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            //16-6-2022
            else if (abbr.ToLower() == "dent")
            {
                var data = Prtl_MenuUtility.Get_dent_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else if (abbr.ToLower() == "com")
            {
                var data = Prtl_MenuUtility.Get_com_MenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            else
            {
                var data = Prtl_MenuUtility.GetMenuByID((int)menu_id);
                Session["menu_id"] = menu_id;
                return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                {
                    Id = data.Menu_id,

                    Parent_id = data.Parent_id,
                    Roles = data.Roles,
                    Translation_Data = TranslationData(data.Menu_id),
                    Url = data.Url,
                    Position = data.Position,
                    Url_target = data.Url_target
                }, Page);
            }
            
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data,[Optional] string abbr)
        {
            return Prtl_TranslationUtility.LangsNotTranslated(CurrentTranslationID, data.ToString(),URLBuilder.CurrentOwnerAbbr(Page.RouteData));
        }

        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);
            DetailsView<MenuDetailsViewUserControl>().Position = PositionDropDownList.SelectedValue;
        }

        protected override int TranslationCount(object data,[Optional] string abbr)
        {
            return Prtl_TranslationUtility.TranslationsCount(data.ToString(),abbr);
        }

        protected override bool Published(object data,[Optional] string abbr )
        {

            //HiddenField xx = (HiddenField)Menu_ListView.FindControl("Menu_id");
            //return Prtl_MenuUtility.GetPublishedState(xx.Value);

            //return Prtl_MenuUtility.GetPublishedState(Prtl_MenuUtility.GetMenuIDByTranslationID(data .ToString() ).ToString( ));
            return Prtl_MenuUtility.GetPublishedState(data.ToString(),URLBuilder.CurrentOwnerAbbr(Page.RouteData) );
        }

        protected string TranslationData(object data,[Optional] string abbr)
        {
            if (abbr == null)
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_univ_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;

            }
            else if (abbr.ToLower() == "fci")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_fci_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "fee")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_fee_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "eng")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_eng_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "nur")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_nur_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "edu")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_edu_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "sci")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_sci_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "edv")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_edv_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "agr")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_agr_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "hec")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_hec_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "law")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_law_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "fpe")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_fpe_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
                //***********
            else if (abbr.ToLower() == "pharm")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_Pharm_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "vmed")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_VMed_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
                ///*****************
            else if (abbr.ToLower() == "fa")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_fa_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "art")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_art_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "ho")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_ho_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "med")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_med_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "liv")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_liv_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "com")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_com_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            //121212121212
            else if (abbr.ToLower() == "ecedu")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_ecedu_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
                //33333333333
            else if (abbr.ToLower() == "media")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_media_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "ai")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_ai_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            //16-6-2022
            else if (abbr.ToLower() == "dent")
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.Get_dent_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else
            {
                if (data == null) return "(Root)";
                var x = Prtl_TranslationUtility.GetTransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            
        }
        
        protected void PositionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
      
        }
    }
}