using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;
using Resources;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class MenuViewer : ViewersBase
    {
        //protected void VerticalMenu_MenuItemClick(object sender, MenuEventArgs e)
        //{

        //    var menuitem = Prtl_MenuUtility.GetMenuByID(Int32.Parse(e.Item.Value));
        //    switch (CurrentMenuMode)
        //    {
        //        case MenuMode.Normal:
        //        case MenuMode.Edit:
        //            QuickEditMenuDetailsViewControl.Position = Position;
        //            QuickEditMenuDetailsViewControl.Show(StaticUtilities.OwnerID(Page), menuitem.Translation_ID.ToString());
        //            MenuUpdatePanel.Update();
        //            break;

        //        case MenuMode.Delete:
        //            Prtl_MenuUtility.DeleteMenuItemAndSubItems(menuitem, true);
        //            CurrentMenu.DataBindings[0].NavigateUrlField = "";
        //            UpdateMenuAndXML();
        //            break;
        //    }

        //}

        public string Position { get; set; }
        public string StaticMenuItemStyle { get { return CurrentMenu.StaticMenuItemStyle.CssClass; } set { CurrentMenu.StaticMenuItemStyle.CssClass = value; } }
        public string StaticHoverStyle { get { return CurrentMenu.StaticHoverStyle.CssClass; } set { CurrentMenu.StaticHoverStyle.CssClass = value; } }
        public string DynamicMenuItemStyle { get { return CurrentMenu.DynamicMenuItemStyle.CssClass; } set { CurrentMenu.DynamicMenuItemStyle.CssClass = value; } }
        public string DynamicHoverStyle { get { return CurrentMenu.DynamicHoverStyle.CssClass; } set { CurrentMenu.DynamicHoverStyle.CssClass = value; } }


        public Orientation MenuOrientation { get { return CurrentMenu.Orientation; } set { CurrentMenu.Orientation = value; } }
        protected void VerticalMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {

            var menu = (Menu)sender;
            if (String.IsNullOrEmpty(e.Item.Text))
            {
                menu.RemoveMenuItem(e.Item);
                return;
            }
            var element = (XmlElement)e.Item.DataItem;
            var attrib = element.Attributes["Roles"];
            if (attrib != null && attrib.Value != "All")
            {
                var userroles = Roles.GetRolesForUser(Page.User.Identity.Name);
                if (!userroles.Any(ur => attrib.Value.Contains(ur)))
                    menu.RemoveMenuItem(e.Item);
                return;
            }
            var autherized = StaticUtilities.MenuUserAutherized(Page);
            var highlightItem = autherized && String.IsNullOrEmpty(e.Item.NavigateUrl);
            if (!(String.IsNullOrEmpty(e.Item.NavigateUrl) ||
                StaticUtilities.AbsoulteURLprefixes.Any(p => e.Item.NavigateUrl.StartsWith(p))))
                e.Item.NavigateUrl += CurrentPage.CurrentLanguage;
            // highlight menu items that don't have a hyperlink
            e.Item.Text = String.Format("{0}{1}{2}", highlightItem ? @"<span style=""color: red"">" : "",
                                    e.Item.Text, highlightItem ? "</span>" : "");
            e.Item.Selectable = !String.IsNullOrEmpty(e.Item.NavigateUrl) || autherized;


        }

        private MenuMode CurrentMenuMode
        {
            get { return ViewState["MenuMode"] == null ? MenuMode.Normal : (MenuMode)ViewState["MenuMode"]; }
            set { ViewState["MenuMode"] = value; }
        }
        //protected void NormalModeImageButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    MenuDiv.Attributes.Remove("onclick");
        //    CurrentModeLabel.Text = "";
        //    PrepareFor_Delete_Edit(CurrentMenuMode = MenuMode.Normal);
        //}
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //    StaticUtilities.SetPanelVisibility(InsertMenuItemPanel, StaticUtilities.MenueditorRoles, this, false);
        //}

      

      
        //protected void DeleteModeImageButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    MenuDiv.Attributes.Add("onclick", "return confirm('" + GlobalStrings.DeleteItemMessage + "');");
        //    CurrentModeLabel.Text = (string)GetLocalResourceObject("SiteMaster_DeleteModeImageButton_Click_");
        //    CurrentMenuMode = MenuMode.Delete;
        //    PrepareFor_Delete_Edit();
        //}

            //*//*//
        protected void Page_Load(object sender, EventArgs e)
        {
            //MenuDiv.Attributes.Add("dir", StaticUtilities.Dir);
            //if (CurrentMenuMode != MenuMode.Delete)
            //    MenuDiv.Attributes.Remove("onclick");

            if (!IsPostBack)
            {
                int type = URLBuilder.CurrentOwner(Page.RouteData).Type;
                Session["ownertype"] = type;
                string datamember = Position + "MenuItem";
                MenuXmlDataSource.DataFile = URLBuilder.Path(Page, PathType.WebServer, SiteFolders.Menu);
                MenuXmlDataSource.XPath = "/Menu/" + datamember;
                var menuxmlfilepath = URLBuilder.Path(Page, PathType.Local, SiteFolders.Menu);
                if (!Prtl_OwnersUtility.IsOwnerMenuUpdated(Page) || !File.Exists(menuxmlfilepath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(menuxmlfilepath));
                    Prtl_OwnersUtility.SetMenuUpdated(CurrentPage.CurrentOwner.Owner_ID, true);
                    UpdateMenuAndXML();
                }
                if (!StaticUtilities.IsRTL)
                    CurrentMenu.DynamicPopOutImageUrl = "~/styles/CommonImages/arrow_down_v_r.gif";
                //InsertMenuItemPanel.Style["float"] = StaticUtilities.FloatRight;

                if (!Page.IsPostBack)
                {
                    CurrentMenu.DataBindings[0].DataMember = datamember;
                   if(StaticUtilities.Currentlanguage(Page) == "fr")
                    {
                        CurrentMenu.DataBindings[0].TextField = "TitleFr";

                    }
                    else if (StaticUtilities.Currentlanguage(Page).ToLower() == "ja")
                    {
                        CurrentMenu.DataBindings[0].TextField = "TitleJa";

                    }
                    else if (StaticUtilities.Currentlanguage(Page).ToLower() == "de")
                    {
                        CurrentMenu.DataBindings[0].TextField = "TitleDe";

                    }
                    if (StaticUtilities.Currentlanguage(Page) == "fa")
                    {
                        CurrentMenu.DataBindings[0].TextField = "TitleFa";

                    }
                    else if (StaticUtilities.Currentlanguage(Page).ToLower() == "tr")
                    {
                        CurrentMenu.DataBindings[0].TextField = "TitleTr";

                    }
                    else if (StaticUtilities.Currentlanguage(Page).ToLower() == "ru")
                    {
                        CurrentMenu.DataBindings[0].TextField = "TitleRu";

                    }
                    else if (StaticUtilities.Currentlanguage(Page).ToLower() == "zh")
                    {
                        CurrentMenu.DataBindings[0].TextField = "TitleZh";

                    }
                    else
                    CurrentMenu.DataBindings[0].TextField = StaticUtilities.IsRTL ? "TitleAr" : "TitleEn";
                    //CurrentMenu.DataBindings[0].NavigateUrlField = StaticUtilities.IsRTL ? "UrlAr" : "UrlEn";
                }
            }
             
        }
        public string ParentDisplayStyle
        {
            get { return IsVisible ? "inline" : "none"; }
        }

        protected bool IsVisible
        {
            get { return CurrentMenu.Items.Count != 0; }
        }

        public PageBase CurrentPage
        {
            get { return (PageBase)Page; }
        }
        protected void EditorDetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            UpdateMenuAndXML();
        }
        public void EditorDetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            UpdateMenuAndXML();
        }
        //protected void MenuEditorControlInsertClicked(object sender, EventArgs e)
        //{
        //    QuickEditMenuDetailsViewControl.Position = Position;
        //    QuickEditMenuDetailsViewControl.ShowInsert(StaticUtilities.OwnerID(Page));
        //}

        private void UpdateMenuAndXML()
        {
            StaticUtilities.BuildXML(Page);
            //CurrentMenu.DataBind();
            MenuUpdatePanel.Update();
        }

        //protected void EditModeImageButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    MenuDiv.Attributes.Remove("onclick");
        //    CurrentModeLabel.Text = (string)GetLocalResourceObject("SiteMaster_EditModeImageButton_Click_Current_Mode_is_Edit");
        //    CurrentMenuMode = MenuMode.Edit;
        //    PrepareFor_Delete_Edit();
        //}
        //private void PrepareFor_Delete_Edit(MenuMode mode = MenuMode.Edit)
        //{
        //    CurrentMenu.DataBindings[0].NavigateUrlField = ((mode == MenuMode.Normal) ? "Url" : "");
        //    CurrentMenu.DataBind();
        //    MenuUpdatePanel.Update();
        //}
    }
}