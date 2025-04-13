using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.MenuEditor
{
    public partial class MenuDetailsViewUserControl : DetailsViewBasedUserControl
    {
        public object Position
        {
            private get { return Session[UniqueID + "Position"]; }
            set { Session[UniqueID + "Position"] = value; }
        }

        protected override string DefaultValueForFiltering
        {
            get { return "\"00000000-1000-0000-0000-000000000000\""; }
        }

        protected override string FilterValueName
        {
            get { return "MenuTranslation_ID"; }
        }

        public override string EditorClientID
        {
            get { return ""; }
        }


       

        private DropDownList ArticlesDropDownList
        {
            get { return GetDVControl<DropDownList>("ArticleTitlesDropDownList"); }
        }
        private DropDownList PositionDropDownList
        {
            get { return GetDVControl<DropDownList>("PositionDropDownList1"); }
        }
        private Label  lblposition
        {
            get { return GetDVControl<Label>("lblposition"); }
        }
        private ComboBox URLSelector
        {
            get { return GetDVControl<ComboBox>("URLSelector"); }
        }

        private DataControlField RolesField
        {
            get { return EditorDetailsView.Fields.OfType<DataControlField>().Single(f => f.HeaderText == "Roles"); }
        }

        public override void Show(Guid? currentOwnerID, string filterValue, DetailsViewMode EditMode = DetailsViewMode.ReadOnly)
        {
            base.Show(currentOwnerID, filterValue, EditMode);
            SetFieldsVisibility(EditorDetailsView.CurrentMode);
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            //if (!IsPostBack)
            //{
            var x = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
            if (x.Type == 1)
            {

                Menu_Translations_LinqDataSource.TableName = "prtl_menu_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";
                Session["TbName1"] = "prtl_menu_" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "_trans";

            }
            else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                Menu_Translations_LinqDataSource.TableName = "prtl_menu_univ_trans";
                Session["TbName1"] = "prtl_menu_univ_trans";
            }
            else
            {
                Menu_Translations_LinqDataSource.TableName = "prtl_Translations";
                Session["TbName1"] = "prtl_Translations";
            }
            //}
            //else
            //{
            //    Menu_Translations_LinqDataSource.TableName = (string)Session["TbName1"];
            //}



        }
        internal override void ShowInsert(Guid? currentOwnerID, string defaultempty = null)
        {
            base.ShowInsert(currentOwnerID, defaultempty);
            SetFieldsVisibility(EditorDetailsView.CurrentMode);
        }

        protected string ArticleData(Guid menu_id,string currentlanguage,string abbr)
        {
            var menuArticle = prtl_ArticlesUtility.GetArticlebyMenuItemID((Guid)menu_id,URLBuilder.CurrentOwnerid(Page.RouteData), currentlanguage, abbr);
            return menuArticle != null ? menuArticle.ID.ToString(CultureInfo.InvariantCulture) : null;
        }

        protected override void DataBound(object sender, EventArgs e)
        {
         
            if (EditorDetailsView.CurrentMode == DetailsViewMode.Edit || EditorDetailsView.CurrentMode == DetailsViewMode.Insert && Mode == DetailsViewMode.Insert)
            {   
                PositionDropDownList.SelectedValue = lblposition.Text;
                URLSelector.Visible = true;
                ArticlesDropDownList.Visible = URLSelector.SelectedValue.StartsWith("View");
                RolesField.Visible = Page.User.Identity.Name.ToLower() == "superadmin";
                
            }
            else if (EditorDetailsView.CurrentMode == DetailsViewMode.Insert && Mode == DetailsViewMode.ReadOnly)
            {
                ArticlesDropDownList.Visible = URLSelector.Visible = false;
            }
        }

        protected override void ModeChanging(DetailsView sender, DetailsViewModeEventArgs e)
        {
            SetFieldsVisibility(e.NewMode);
        }

        protected object GetArticlesTitles(Guid menuid,string abbr)
        {
            return Prtl_ArticlesTranslationUtility.GetUnMappedArticles(CurrentOwnerID,
                                                                       StaticUtilities.Currentlanguage(Page), menuid,abbr);
        }
        protected object GetArticlesTitles2(int menuid, string abbr)
        {
            return Prtl_ArticlesTranslationUtility.GetUnMappedArticles2(menuid,
                                                                       StaticUtilities.Currentlanguage(Page), CurrentOwnerID, abbr);
        }
        protected override IEnumerable<prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_TranslationUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata, URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            // ReSharper restore PossibleInvalidOperationException
        }

        protected object GetParents(Guid tid,string abbr)
        {
            return Prtl_MenuUtility.GetMenuIDs(tid, CurrentOwnerID, StaticUtilities.Currentlanguage(Page), Position.ToString(), abbr);
        }

        protected override void ItemInserting(DetailsView detailsview, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {
                string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
                if (abbr == null)
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_univ
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_univ_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);

                }
                else if (abbr.ToLower() == "fci")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_fci
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_fci_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "fee")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_fee
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_fee_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "eng")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_eng
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_eng_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "nur")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_nur
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_nur_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "edu")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_edu
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_edu_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "sci")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_sci
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_sci_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "edv")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_edv
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_edv_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "agr")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_agr
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_agr_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "hec")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_hec
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_hec_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "law")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_law
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_law_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "fpe")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_fpe
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_fpe_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                    //******************
                else if (abbr.ToLower() == "vmed")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_VMed
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),

                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_VMed_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "pharm")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_Pharm
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),

                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_Pharm_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                    ///**************************
                else if (abbr.ToLower() == "fa")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_fa
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_fas_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "art")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_art
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_art_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "ho")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_ho
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                        
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_hos_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "med")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_med
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_med_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "liv")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_liv
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_liv_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "com")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_com
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_com_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                    //121212
                else if (abbr.ToLower() == "ecedu")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_ECEDU
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),

                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_ecedu_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "media")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_media
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),

                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    
                    var insertedMenu = Prtl_MenuUtility.Insert_media_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                //13-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_AI
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                        Translation_ID = Guid.NewGuid(),
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;

                    var insertedMenu = Prtl_MenuUtility.Insert_ai_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else if (abbr.ToLower() == "dent")
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_menu_dent
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                        Translation_ID = Guid.NewGuid(),
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.Insert_dent_MenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
                else
                {
                    CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");

                    var menuitem = new prtl_Menu
                    {
                        Owner_ID = CurrentOwnerID,
                        Url = URLSelector.SelectedValue.ToNullIfEmpty(),
                         
                        Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty().ToString(),
                        Published = xx.Checked,
                    };
                    Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                    var parentid = GetDVControl<DropDownList>("ParentInsertDropDownList").SelectedValue;
                    menuitem.Parent_id = string.IsNullOrEmpty(parentid) ? (int?)null : int.Parse(parentid);
                    var order = GetDVControl<TextBox>("InsertOrderTextBox").Text;
                    menuitem.Order = int.Parse(order);
                    var ll = GetDVControl<CheckBoxList>("LDSRoles");
                    var listRoles =
                        (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                    var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                    menuitem.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                    var insertedMenu = Prtl_MenuUtility.InsertMenuItem(menuitem);
                    FilterValue = insertedMenu.Translation_ID.ToString();
                    if (ArticlesDropDownList.Visible)
                        prtl_ArticlesUtility.UpdateArticleWithMenuID(int.Parse(ArticlesDropDownList.SelectedValue),
                                                                     insertedMenu.Menu_id);
                }
               
            }
            EditorDetailsView.CompleteTranslationData(e, FilterValue);

        }

        protected override void ItemUpdating(DetailsView detailsview, DetailsViewUpdateEventArgs e)
        {
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (abbr == null)
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_univ_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()),URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "fci")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_fci_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "fee")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_fee_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "eng")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_eng_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "nur")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_nur_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "edu")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_edu_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "sci")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_sci_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "edv")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_edv_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "agr")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_agr_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "hec")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_hec_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "law")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_law_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "fpe")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_fpe_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
                //*************************
            else if (abbr.ToLower() == "vmed")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_VMed_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();

                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "pharm")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_Pharm_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();

                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
                //*************************************
            else if (abbr.ToLower() == "fa")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_fas_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "art")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_art_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "ho")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_hos_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "med")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_med_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "liv")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_liv_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "com")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_com_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "ecedu")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_ecedu_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();

                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "media")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_media_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();

                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            //13-4-2022
            else if (abbr.ToLower() == "ai")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_ai_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();

                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else if (abbr.ToLower() == "dent")
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.Update_dent_MenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();

                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            else
            {
                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);

                CheckBox xx = detailsview.GetControl<CheckBox>("CheckBox1");
                var Menu_ID = detailsview.GetControl<HiddenField>("MenuID");
                Prtl_MenuUtility.UpdateMenuWithPublish(Convert.ToInt32(Menu_ID.Value), xx.Checked, abbr);
                Prtl_MenuUtility.UpdateMenuItem((Guid)e.Keys["Translation_ID"],
                  m =>
                  {
                      m.Url = GetDVControl<ComboBox>("URLSelector").SelectedValue.ToNullIfEmpty();
                       
                      var ll = GetDVControl<CheckBoxList>("LDSRoles");
                      var listRoles =
                                         (ll.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value)).ToList();
                      var roles = listRoles.Aggregate("", (current, x) => current + (x + ";"));
                      m.Roles = string.IsNullOrEmpty(roles) ? "All" : roles;
                      m.Parent_id = string.IsNullOrEmpty(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue)
                                                                      ? (int?)null
                                                                      : int.Parse(GetDVControl<DropDownList>("ParentEditDropDownList").SelectedValue);
                      m.Order = int.Parse(GetDVControl<TextBox>("EditOrderTextBox").Text);
                      m.Position = GetDVControl<DropDownList>("PositionDropDownList1").SelectedValue.ToNullIfEmpty();
                      return m;
                  });
                var dropDownList = GetDVControl<DropDownList>("ArticleTitlesDropDownList").SelectedValue;
                if (!string.IsNullOrEmpty(dropDownList))
                    prtl_ArticlesUtility.UpdateArticleWithMenuTranslationID(int.Parse(dropDownList),
                                                                 Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                else
                    prtl_ArticlesUtility.ClearArticlesWithMenuItemTranslationID(Guid.Parse(e.Keys["Translation_ID"].ToString()), URLBuilder.CurrentOwnerAbbr(Page.RouteData));

            }
            
           
        }

        protected void MenuEditorDetailsView_Load(object sender, EventArgs e)
        {
            RolesField.Visible = Page.User.Identity.Name.ToLower() == "superadmin";
        }

        protected string MenuItemHyperLink(object id)
        {
            if (EditorDetailsView.CurrentMode == DetailsViewMode.ReadOnly)
            {
                string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
                if (abbr == null)
                {
                    var data = Prtl_TranslationUtility.Get_univ_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_univ_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);

                }
                else if (abbr.ToLower() == "fci")
                {
                    var data = Prtl_TranslationUtility.Get_fci_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_fci_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "fee")
                {
                    var data = Prtl_TranslationUtility.Get_fee_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_fee_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "eng")
                {
                    var data = Prtl_TranslationUtility.Get_eng_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_eng_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "nur")
                {
                    var data = Prtl_TranslationUtility.Get_nur_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_nur_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "edu")
                {
                    var data = Prtl_TranslationUtility.Get_edu_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_edu_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "sci")
                {
                    var data = Prtl_TranslationUtility.Get_sci_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_sci_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "edv")
                {
                    var data = Prtl_TranslationUtility.Get_edv_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_edv_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "agr")
                {
                    var data = Prtl_TranslationUtility.Get_agr_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_agr_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "hec")
                {
                    var data = Prtl_TranslationUtility.Get_hec_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_hec_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "law")
                {
                    var data = Prtl_TranslationUtility.Get_law_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_law_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var data = Prtl_TranslationUtility.Get_fpe_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_fpe_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                    //************************
                else if (abbr.ToLower() == "pharm")
                {
                    var data = Prtl_TranslationUtility.Get_Pharm_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_Pharm_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var data = Prtl_TranslationUtility.Get_VMed_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_VMed_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                    ///////////////////////
                else if (abbr.ToLower() == "fa")
                {
                    var data = Prtl_TranslationUtility.Get_fas_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_fa_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "art")
                {
                    var data = Prtl_TranslationUtility.Get_art_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_art_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "ho")
                {
                    var data = Prtl_TranslationUtility.Get_hos_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_ho_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "med")
                {
                    var data = Prtl_TranslationUtility.Get_med_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_med_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "liv")
                {
                    var data = Prtl_TranslationUtility.Get_liv_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_liv_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "com")
                {
                    var data = Prtl_TranslationUtility.Get_com_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_com_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "ecedu")
                {
                    var data = Prtl_TranslationUtility.Get_ecedu_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_ecedu_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else if (abbr.ToLower() == "media")
                {
                    var data = Prtl_TranslationUtility.Get_media_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_media_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                //13-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    var data = Prtl_TranslationUtility.Get_ai_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_ai_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                //16-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    var data = Prtl_TranslationUtility.Get_dent_TranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.Get_dent_MenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                else
                {
                    var data = Prtl_TranslationUtility.GetTranslationByID((int)id);
                    var prtl_menuitem = Prtl_MenuUtility.GetMenuByTranslationID(data.Translation_ID.ToString());
                    return URLBuilder.GetURL(new Prtl_MenuUtility.MenuItem
                    {
                        Id = prtl_menuitem.Menu_id,
                        Parent_id = prtl_menuitem.Parent_id,
                        Roles = prtl_menuitem.Roles,
                        Translation_Data = data.Translation_Data,
                        Url = prtl_menuitem.Url,
                        Position = prtl_menuitem.Position,
                        Url_target = prtl_menuitem.Url_target
                    }, Page);
                }
                
            }
            else
            {
                return "";
            }
        }



        protected void RolesCheckBoxList_DataBound(object sender, EventArgs e)
        {
            var checkboxlist = (CheckBoxList)sender;
            var roles = checkboxlist.ToolTip.Split(';');
            foreach (var role in checkboxlist.Items.Cast<ListItem>().Where(role => roles.Contains(role.Value)))
            {
                role.Selected = true;
            }
        }

        protected string TranslationData(Guid tid, string currentlanguage)
        {
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);

            if (abbr == null)
            {
                var data= new PortalDataContextDataContext().prtl_menu_univ_trans.SingleOrDefault(
                         xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                         .prtl_menu_univ.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_univ_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;

            }
            else if (abbr.ToLower() == "fci")
            {
                var data = new PortalDataContextDataContext().prtl_menu_fci_trans.SingleOrDefault(
                         xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                         .prtl_menu_fci.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_fci_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "ai")
            {
                var data = new PortalDataContextDataContext().prtl_menu_AI_trans.SingleOrDefault(
                         xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                         .prtl_menu_AI.Parent_id.ToString();
                if (data == null || data == "") return "(Root)";
                var x = Prtl_TranslationUtility.Get_ai_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "fee")
            {
                var data = new PortalDataContextDataContext().prtl_menu_fee_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_fee.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_fee_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "eng")
            {
                var data = new PortalDataContextDataContext().prtl_menu_eng_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_eng.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_eng_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "nur")
            {
                var data = new PortalDataContextDataContext().prtl_menu_nur_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_nur.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_nur_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "edu")
            {
                var data = new PortalDataContextDataContext().prtl_menu_edu_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_edu.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_edu_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "sci")
            {
                var data = new PortalDataContextDataContext().prtl_menu_sci_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_sci.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_sci_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "edv")
            {
                var data = new PortalDataContextDataContext().prtl_menu_edv_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_edv.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_edv_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "agr")
            {
                var data = new PortalDataContextDataContext().prtl_menu_agr_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_agr.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_agr_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "hec")
            {
                var data = new PortalDataContextDataContext().prtl_menu_hec_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_hec.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_hec_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "law")
            {
                var data = new PortalDataContextDataContext().prtl_menu_law_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_law.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_law_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "fpe")
            {
                var data = new PortalDataContextDataContext().prtl_menu_fpe_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_fpe.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_fpe_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
                //******************
            else if (abbr.ToLower() == "pharm")
            {
                var data = new PortalDataContextDataContext().prtl_menu_Pharm_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_Pharm.Parent_id.ToString();
                if (data == null || data == "") return "(Root)";
                var x = Prtl_TranslationUtility.Get_Pharm_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "vmed")
            {
                var data = new PortalDataContextDataContext().prtl_menu_VMed_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_VMed.Parent_id.ToString();
                if (data == null || data == "") return "(Root)";
                var x = Prtl_TranslationUtility.Get_VMed_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
                //***********************
            else if (abbr.ToLower() == "fa")
            {
                var data = new PortalDataContextDataContext().prtl_menu_fa_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_fa.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_fa_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
                //*************************
            //else if (abbr.ToLower() == "pharm")
            //{
            //    var data = new PortalDataContextDataContext().prtl_menu_Pharm_trans .SingleOrDefault(
            //                xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
            //                .prtl_menu_Pharm.Parent_id.ToString();
            //    if (data == null || data == "") return "(Root)";
            //    var x = Prtl_TranslationUtility.Get_pharm_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
            //    return (x == null) ? "none" : x.Translation_Data;
            //}


            //else if (abbr.ToLower() == "vmed")
            //{
            //    var data = new PortalDataContextDataContext().prtl_menu_VMed_trans.SingleOrDefault(
            //                xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
            //                .prtl_menu_VMed.Parent_id.ToString();
            //    if (data == null || data == "") return "(Root)";
            //    var x = Prtl_TranslationUtility.Get_VMed_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
            //    return (x == null) ? "none" : x.Translation_Data;
            //}
                //******************************
            else if (abbr.ToLower() == "art")
            {
                var data = new PortalDataContextDataContext().prtl_menu_art_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_art.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_art_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "ho")
            {
                var data = new PortalDataContextDataContext().prtl_menu_ho_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_ho.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_ho_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "med")
            {
                var data = new PortalDataContextDataContext().prtl_menu_med_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_med.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_med_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "liv")
            {
                var data = new PortalDataContextDataContext().prtl_menu_liv_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_liv.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_liv_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "com")
            {
                var data = new PortalDataContextDataContext().prtl_menu_com_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_com.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.Get_com_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "ecedu")
            {
                var data = new PortalDataContextDataContext().prtl_menu_ECEDU_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_ECEDU.Parent_id.ToString();
                if (data == null || data == "") return "(Root)";
                var x = Prtl_TranslationUtility.Get_ecedu_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else if (abbr.ToLower() == "media")
            {
                var data = new PortalDataContextDataContext().prtl_menu_media_trans.SingleOrDefault(
                         xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                         .prtl_menu_media.Parent_id.ToString();
                if (data == null || data == "") return "(Root)";
                var x = Prtl_TranslationUtility.Get_media_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            //16-6-2022
            else if (abbr.ToLower() == "dent")
            {
                var data = new PortalDataContextDataContext().prtl_menu_dent_trans.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_menu_dent.Parent_id.ToString();
                if (data == null || data == "") return "(Root)";
                var x = Prtl_TranslationUtility.Get_dent_TransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            else
            {
                var data = new PortalDataContextDataContext().prtl_Translations.SingleOrDefault(
                            xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage)
                            .prtl_Menu.Parent_id.ToString();
                if (data == null || data=="") return "(Root)";
                var x = Prtl_TranslationUtility.GetTransByMenuIDAndCurrentLang(Convert.ToInt32(data), StaticUtilities.Currentlanguage(Page));
                return (x == null) ? "none" : x.Translation_Data;
            }
            
        }

        protected override int TranslationsCount
        {
            get { return Prtl_TranslationUtility.TranslationsCount(FilterValue,URLBuilder.CurrentOwnerAbbr(Page.RouteData)); }
        }

        protected IEnumerable<ListItem> UrlSelectorDataSource()
        {
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (abbr == null)
            {
                var allaspxfiles = Directory.EnumerateFiles(
                Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_univ_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();

            }
            else if (abbr.ToLower() == "fci")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_fci_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "fee")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_fee_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "eng")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_eng_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "nur")
            {
                var allaspxfiles = Directory.EnumerateFiles(
                Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_nur_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "edu")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_edu_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "sci")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_sci_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "edv")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_edv_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "agr")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_agr_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "hec")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_hec_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "law")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_law_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "fpe")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_fpe_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
                //*************************
            else if (abbr.ToLower() == "pharm")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_Pharm_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "vmed")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_VMed_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
                //****************************
            else if (abbr.ToLower() == "fa")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_fa_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "art")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_art_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "ho")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_ho_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "med")
            {
                var allaspxfiles = Directory.EnumerateFiles(
                Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_med_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "liv")
            {
                var allaspxfiles = Directory.EnumerateFiles(
                Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_liv_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "ecedu")
            {
                var allaspxfiles = Directory.EnumerateFiles(
                Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_ecedu_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "media")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_media_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
           // 13-4-2022
            else if (abbr.ToLower() == "ai")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_ai_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            //16-6-2022
            else if (abbr.ToLower() == "dent")
            {
                var allaspxfiles = Directory.EnumerateFiles(
                Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_dent_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else if (abbr.ToLower() == "com")
            {
                var allaspxfiles = Directory.EnumerateFiles(
               Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.Get_com_DBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            else
            {
                var allaspxfiles = Directory.EnumerateFiles(
                 Page.Server.MapPath("~/UI/"), "*.aspx", SearchOption.AllDirectories);
                var excludedFilePaths = new List<string>();
                var excludedFiles = new[] { "ErrorPage", "NewsDetails", "Default" };
                if (Page.User.Identity.Name.ToLower() != "superadmin")
                {
                    excludedFilePaths.AddRange(Directory.EnumerateFiles(Page.Server.MapPath("~/UI/Admin/"), "*.aspx"));
                }
                var filesneeded = ConvertPathtToURL(allaspxfiles.Except(excludedFilePaths));
                var listitems = filesneeded.ToListItems();
                var items = new List<ListItem>
                            {
                                new ListItem(null,null),
                                new ListItem(URLSelector.Text, URLSelector.Text),
                                new ListItem("", ""),
                            };
                return listitems.Union(items.Distinct()).
                           Union(Prtl_MenuUtility.GetDBMenuItems(CurrentOwnerID).Select(m => new ListItem(m.Url, m.Url))).
                           Except(new List<ListItem> { new ListItem("/", "/") }).
                           Except(excludedFiles.ToListItems()).
                           Except(ConvertPathtToURL(excludedFilePaths).ToListItems()).
                           OrderByDescending(li => li.Value).
                           ToArray();
            }
            
        }

        protected void UrlSelectorSelectedIndexChanged(object sender, EventArgs e)
        {
            ArticlesDropDownList.Visible = URLSelector.SelectedValue.StartsWith("View");
            EditorModalPopupExtender.Show();
        }
        protected override object EditorTitle { get { return GetLocalResourceObject("Title"); } }

        private IEnumerable<string> ConvertPathtToURL(IEnumerable<string> input)
        {
            return input.Select(
                    s => s.Replace(Page.Server.MapPath("~/UI/"), "").Replace(".aspx", "").Replace("\\", "/").TrimStart('/'));
        }

        private void SetFieldsVisibility(DetailsViewMode mode)
        {
            var viewall = Mode != DetailsViewMode.Insert && mode == DetailsViewMode.Insert;
            var headers = new[] { "Parent", "Order", "URL", "Parameters", "Url Target", "Roles" };
            foreach (
                var field in
                    EditorDetailsView.Fields.Cast<DataControlField>().Where(field => headers.Contains(field.HeaderText)))
            {
                field.Visible = !viewall;
            }
        }

        protected void URLSelector_TextChanged(object sender, EventArgs e)
        {
            ArticlesDropDownList.Visible = false;
            EditorModalPopupExtender.Show();
        }




        protected  void Itemupdating2(DetailsView detailsview, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {



                MenuEditorUserControl fg = new MenuEditorUserControl();
                string kk = fg.DropSelIndex;
                DropDownList xx = TemplateDetailsViewBasedControl.GetControl<DropDownList>("PositionDropDownList1");

                xx.SelectedItem.Value = fg.DropSelIndex;


                Prtl_OwnersUtility.SetMenuUpdated(OwnerID, false);
                //DropDownList xx = (DropDownList)TemplateDetailsViewBasedControl.FindControl("PositionDropDownList1");



            }
        }


        protected string GetParentidValues(Guid tid, string abbr)
        {
            return Prtl_MenuUtility.GetParentidValues(tid, StaticUtilities.Currentlanguage(Page), abbr);
        }

        protected string GetOrder(Guid tid, string currentlanguage, string abbr)
        {
            return Prtl_MenuUtility.GetOrder(tid, StaticUtilities.Currentlanguage(Page), abbr);
        }

        protected string GetURL(Guid tid, string currentlanguage, string abbr)
        {
            return Prtl_MenuUtility.GetURL(tid, StaticUtilities.Currentlanguage(Page), abbr);
        }

        //protected string GetUrlTarget(Guid tid, string currentlanguage, string abbr)
        //{
        //    return Prtl_MenuUtility.GetURLTarget(tid, StaticUtilities.Currentlanguage(Page), abbr);
        //}

        protected string GetRoles(Guid tid, string currentlanguage, string abbr)
        {
            return Prtl_MenuUtility.GetRoles(tid, StaticUtilities.Currentlanguage(Page), abbr);
        }

        protected string GetPosition(Guid tid, string currentlanguage, string abbr)
        {
            return Prtl_MenuUtility.GetPosition(tid, StaticUtilities.Currentlanguage(Page), abbr);
        }

        protected bool GetPublished(Guid tid, string currentlanguage, string abbr)
        {
            return Prtl_MenuUtility.GetPublished(tid, StaticUtilities.Currentlanguage(Page), abbr);
        }

        protected string GetMenuId(Guid tid, string currentlanguage, string abbr)
        {
            return Prtl_MenuUtility.GetMenuId(tid, StaticUtilities.Currentlanguage(Page), abbr);
        }

        protected object GetParents2(int i, string abbr)
        {
            return Prtl_MenuUtility.GetMenuIDs2(i, CurrentOwnerID, StaticUtilities.Currentlanguage(Page), Position.ToString(), abbr);
        }
    }
}

internal static class Extender
{
    public static IEnumerable<ListItem> ToListItems(this IEnumerable<string> input)
    {
        return input.Select(s => new ListItem(s, s));
    }

    public static string ToNullIfEmpty(this string input)
    {
        return string.IsNullOrWhiteSpace(input) ? null : input;
    }
}