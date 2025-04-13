using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using AjaxControlToolkit;
using App_Code;
using BLL;

using Common;
using MnfUniversity_Portals.UserControls.Viewers;
using OboutInc.Show;
using Portal_DAL;

using Image = System.Drawing.Image;
using Panel = System.Web.UI.WebControls.Panel;

public static class StaticUtilities
{
    #region Fields

    public const string Superadmin = "superadmin";
    public static readonly PageRoles[] AdminRoles = new[] { PageRoles.FacAdmin, PageRoles.DepAdmin, PageRoles.StaffRole, PageRoles.ThesisEditor  };
    public static readonly PageRoles[] HighlightseditorRoles = new[] { PageRoles.HighlightsEditor }.Union(AdminRoles).ToArray();
    public static readonly PageRoles[] MenueditorRoles = new[] { PageRoles.MenuEditor }.Union(AdminRoles).ToArray();
    public static readonly PageRoles[] NewseditorRoles = new[] { PageRoles.NewsEditor }.Union(AdminRoles).ToArray();
    public static readonly PageRoles[] ThesisditorRoles = new[] { PageRoles.ThesisEditor }.Union(AdminRoles).ToArray();
    public static readonly PageRoles[] PageeditorRoles = new[] { PageRoles.PageEditor }.Union(AdminRoles).ToArray();
    public static readonly string[] AbsoulteURLprefixes = new[] { "http", "www", "https" };

    #endregion Fields

    #region Properties

    /// <summary>
    /// Gets the format of the datetime that is used with Calendar Extenders of AjaxControlToolKit
    /// </summary>
    public static string DateTimeFormat
    {
        get { return "dd/MM/yyyy"; }
    }
    public static string LoginDivFloat
    {
        get { return (IsRTL) ? "margin-left:270px" : "margin-right:270px"; }
    }
    public static string socialulDivmargin
    {
        get { return (IsRTL) ? "margin-right:1300px" :  "margin-left:-270px";}
    }
    public static string Dir
    {
        get { return (IsRTL) ? "rtl" : "ltr"; }
    }

    public static string FloatLeft
    {
        get { return (IsRTL) ? "left" : "right"; }
    }

    public static string FloatRight
    {
        get { return (IsRTL) ? "right" : "left"; }
    }
    public static string Textright
    {
        get { return (IsRTL) ? "right" : "left"; }
    }

    public static Boolean IsRTL
    {
        get { return Thread.CurrentThread.CurrentCulture.Name.Contains("ar"); }
    }

    public static string Rdir
    {
        get { return (IsRTL) ? "ltr" : "rtl"; }
    }

    #endregion Properties

    #region Methods
    public static void FillShow<T>(IEnumerable<T> Gallery, Show show, params Func<T, Control>[] func)
    {
        show.Panels.Clear();
         foreach (var y in Gallery)
        {
            var p = new OboutInc.Show.Panel();
            var table = new Table { CssClass = "" };
            var rightcell = new TableCell { ID = "rightcell" };
            foreach (var func1 in func)
                rightcell.Controls.Add(func1(y));
            var row = new TableRow();
            row.Cells.Add(rightcell);
            table.Rows.Add(row);
            p.Controls.Add(table);
            show.AddPanel(p);
        }
        show.StyleFolder = URLBuilder.VirtualPath(show.Page) + "/Styles/University_Master/ShowStyle";
    }
    
    public static string DummyDataMethod()
    {
        return "test";
    }
    public static void SetSessionWithPaths(string clientids, Page page)
    {

        if (!string.IsNullOrEmpty(clientids))
        {
            var controlclientids = clientids.Split('/');
            foreach (var controlclientid in controlclientids)
            {
                page.Session[controlclientid + "_ImagesFolder"] = URLBuilder.ImageURLBase + "/" + URLBuilder.OwnerFilePath(page) + "/Portal/Images/";
                page.Session[controlclientid + "_FilesFolder"] = URLBuilder.ImageURLBase + "/" + URLBuilder.OwnerFilePath(page) + "/Portal/Files/";
                page.Session[controlclientid + "_SentficResearches"] = URLBuilder.ImageURLBase + "/" + URLBuilder.OwnerFilePath(page) + "/Portal/SentficResearches/";
            
            }
        }
    }
    public static string UploadFile(Control control, string controlName, SiteFolders folder)
    {
        var fileUpload = (AsyncFileUpload)control.FindControl(controlName);
        var newfn = UploadFiles(control.Page, fileUpload.PostedFile, folder);
        fileUpload.ClearFileFromPersistedStore();
        return newfn;
    }
    public static string UploadFile3(Control control, string controlName, SiteFolders folder)
    {
        var fileUpload = (AsyncFileUpload)control.FindControl(controlName);
        var newfn = UploadFiles(control.Page, fileUpload.PostedFile, folder);
     //   fileUpload.ClearFileFromPersistedStore();
        return newfn;
    }
    public static string UploadFile2(Control control, string controlName, SiteFolders folder)
    {
        var fileUpload = (FileUpload)control.FindControl(controlName);
        var newfn = UploadFiles(control.Page, fileUpload.PostedFile, folder);
        //fileUpload.ClearFileFromPersistedStore();
        return newfn;
    }
    public static string UploadFiles(Page control, HttpPostedFile fileUpload, SiteFolders folder)
    {
        if (fileUpload == null || fileUpload.FileName == "")
            return null;





        var FilePath = URLBuilder.Path(control.Page, PathType.Local, folder,
                                      Path.GetFileName(fileUpload.FileName));
      
        fileUpload.SaveAs(FilePath);
        var FileName = Path.GetFileName(FilePath);

        return FileName;

    }

    public static string UploadFileswithRename(Page control, HttpPostedFile fileUpload, SiteFolders folder,string newname)
    {
        if (fileUpload == null || fileUpload.FileName == "")
            return null;





        var FilePath = URLBuilder.Path(control.Page, PathType.Local, folder,
                                      newname );

        fileUpload.SaveAs(FilePath);
        var FileName = Path.GetFileName(FilePath);

        return FileName;

    }
    public static void RemoveMenuItem(this Menu menu, MenuItem item)
    {
        if (item.Parent != null) item.Parent.ChildItems.Remove(item);
        else
            menu.Items.Remove(item);
    }
    public static void AddSiteIcon(Page page)
    {
        
        var link = new HtmlLink();
        link.Attributes.Add("href", URLBuilder.GetURLIfExists(page, SiteFolders.Owners_Icons, null));
        link.Attributes.Add("rel", "shortcut icon");
        page.Header.Controls.Add(link);
    }
   
    //public static string EncryptIt(string encryptData)
    //{
    //    try
    //    {
    //        byte[] data = Encoding.ASCII.GetBytes(encryptData);
    //        byte[] rgbKey = Encoding.ASCII.GetBytes("12345678");
    //        byte[] rgbIV = Encoding.ASCII.GetBytes("87654321");
    //        //1024-bit encryption
    //        var memoryStream = new MemoryStream(1024);
    //        var desCryptoServiceProvider = new DESCryptoServiceProvider();
    //        var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
    //        cryptoStream.Write(data, 0, data.Length);
    //        cryptoStream.FlushFinalBlock();
    //        var result = new byte[(int)memoryStream.Position];
    //        memoryStream.Position = 0;
    //        memoryStream.Read(result, 0, result.Length);
    //        cryptoStream.Close();
    //        memoryStream.Dispose();
    //        return Convert.ToBase64String(result);
    //    }
    //    catch (Exception ex)
    //    {
    //        return null;
    //    }
    //}

    //public static string DecryptIt(string toDecrypt)
    //{
    //    string decrypted;
    //    try
    //    {
    //        byte[] data = Convert.FromBase64String(toDecrypt);
    //        byte[] rgbKey = Encoding.ASCII.GetBytes("12345678");
    //        byte[] rgbIV = Encoding.ASCII.GetBytes("87654321");
    //        //1024-bit decryption
    //        var memoryStream = new MemoryStream(data.Length);
    //        var desCryptoServiceProvider = new DESCryptoServiceProvider();
    //        var x = desCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV);
    //        var cryptoStream = new CryptoStream(memoryStream, x, CryptoStreamMode.Read);
    //        memoryStream.Write(data, 0, data.Length);
    //        memoryStream.Position = 0;
    //        decrypted = new StreamReader(cryptoStream).ReadToEnd();
    //        cryptoStream.Close();
    //        memoryStream.Dispose();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return decrypted;
    //}
    public static void Build(this Menu menu, MenuMode mode)
    {
        var position = menu.Orientation.ToString();
        menu.MaximumDynamicDisplayLevels = 5;
        menu.StaticDisplayLevels = 1;
        menu.Items.Clear();
        if (!String.IsNullOrEmpty(menu.ToolTip))
            position = menu.ToolTip;
        var currentPage = menu.Page;
        var lcid = StaticUtilities.Currentlanguage(currentPage);
        var userroles = Roles.GetRolesForUser(currentPage.User.Identity.Name);
        if (StaticUtilities.IsRTL)
            menu.StaticPopOutImageUrl =
                menu.DynamicPopOutImageUrl = "~/styles/CommonImages/Menu_Popout.gif";
        var query =GetMenuItems(lcid, position, StaticUtilities.OwnerID(currentPage));
        var menuItemsFilteredbyRole = query.Where(
            x =>

                x.Roles.Contains("All") || currentPage.User.Identity.Name.ToLower() == StaticUtilities.Superadmin ||
                userroles.Any(ur => x.Roles.Contains(ur))).ToList();
        var parentitems = menuItemsFilteredbyRole.Where(i => i.Parent_id == null);
        var nonparentitems = menuItemsFilteredbyRole.Where(i => i.Parent_id != null);
        foreach (var x in parentitems)
            menu.Items.Add(StaticUtilities.GetMenuItem(x, currentPage, mode));
        foreach (MenuItem x in menu.Items)
            StaticUtilities.AddChildren(x, nonparentitems.ToList(), currentPage, mode);
    }
    public static IEnumerable<Prtl_MenuUtility.MenuItem> GetMenuItems(string currentLanguage, string position, Guid? ownerID = null)
    {
        string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];int type;
        if (System.Web.HttpContext.Current.Session["ownertype"] != null)
        {
            type = (int)System.Web.HttpContext.Current.Session["ownertype"];
        }
        else { type = 0; }
        var dc = new PortalDataContextDataContext();
        if (abbr == null && type == 0)
        {
            return from mt in dc.prtl_menu_univ_trans
                   orderby mt.prtl_menu_univ.Parent_id, mt.prtl_menu_univ.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_univ.Published && mt.prtl_menu_univ.Position == position
                   && (mt.prtl_menu_univ.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_univ.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_univ.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_univ.Url,
                       Id = mt.prtl_menu_univ.Menu_id,

                       Url_target = mt.prtl_menu_univ.Url_target,

                       Roles = mt.prtl_menu_univ.Roles
                   };

        }
        else if (abbr != null && (abbr.ToLower() == "fci" && type == 1))
        {
            return from mt in dc.prtl_menu_fci_trans
                   orderby mt.prtl_menu_fci.Parent_id, mt.prtl_menu_fci.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_fci.Published && mt.prtl_menu_fci.Position == position
                   && (mt.prtl_menu_fci.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_fci.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_fci.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_fci.Url,
                       Id = mt.prtl_menu_fci.Menu_id,

                       Url_target = mt.prtl_menu_fci.Url_target,

                       Roles = mt.prtl_menu_fci.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
        {
            return from mt in dc.prtl_menu_fee_trans
                   orderby mt.prtl_menu_fee.Parent_id, mt.prtl_menu_fee.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_fee.Published && mt.prtl_menu_fee.Position == position
                   && (mt.prtl_menu_fee.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_fee.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_fee.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_fee.Url,
                       Id = mt.prtl_menu_fee.Menu_id,

                       Url_target = mt.prtl_menu_fee.Url_target,

                       Roles = mt.prtl_menu_fee.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
        {
            return from mt in dc.prtl_menu_eng_trans
                   orderby mt.prtl_menu_eng.Parent_id, mt.prtl_menu_eng.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_eng.Published && mt.prtl_menu_eng.Position == position
                   && (mt.prtl_menu_eng.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_eng.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_eng.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_eng.Url,
                       Id = mt.prtl_menu_eng.Menu_id,

                       Url_target = mt.prtl_menu_eng.Url_target,

                       Roles = mt.prtl_menu_eng.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
        {
            return from mt in dc.prtl_menu_nur_trans
                   orderby mt.prtl_menu_nur.Parent_id, mt.prtl_menu_nur.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_nur.Published && mt.prtl_menu_nur.Position == position
                   && (mt.prtl_menu_nur.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_nur.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_nur.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_nur.Url,
                       Id = mt.prtl_menu_nur.Menu_id,

                       Url_target = mt.prtl_menu_nur.Url_target,

                       Roles = mt.prtl_menu_nur.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
        {
            return from mt in dc.prtl_menu_edu_trans
                   orderby mt.prtl_menu_edu.Parent_id, mt.prtl_menu_edu.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_edu.Published && mt.prtl_menu_edu.Position == position
                   && (mt.prtl_menu_edu.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_edu.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_edu.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_edu.Url,
                       Id = mt.prtl_menu_edu.Menu_id,

                       Url_target = mt.prtl_menu_edu.Url_target,

                       Roles = mt.prtl_menu_edu.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
        {
            return from mt in dc.prtl_menu_sci_trans
                   orderby mt.prtl_menu_sci.Parent_id, mt.prtl_menu_sci.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_sci.Published && mt.prtl_menu_sci.Position == position
                   && (mt.prtl_menu_sci.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_sci.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_sci.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_sci.Url,
                       Id = mt.prtl_menu_sci.Menu_id,

                       Url_target = mt.prtl_menu_sci.Url_target,

                       Roles = mt.prtl_menu_sci.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
        {
            return from mt in dc.prtl_menu_edv_trans
                   orderby mt.prtl_menu_edv.Parent_id, mt.prtl_menu_edv.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_edv.Published && mt.prtl_menu_edv.Position == position
                   && (mt.prtl_menu_edv.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_edv.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_edv.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_edv.Url,
                       Id = mt.prtl_menu_edv.Menu_id,

                       Url_target = mt.prtl_menu_edv.Url_target,

                       Roles = mt.prtl_menu_edv.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
        {
            return from mt in dc.prtl_menu_agr_trans
                   orderby mt.prtl_menu_agr.Parent_id, mt.prtl_menu_agr.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_agr.Published && mt.prtl_menu_agr.Position == position
                   && (mt.prtl_menu_agr.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_agr.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_agr.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_agr.Url,
                       Id = mt.prtl_menu_agr.Menu_id,

                       Url_target = mt.prtl_menu_agr.Url_target,

                       Roles = mt.prtl_menu_agr.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
        {
            return from mt in dc.prtl_menu_hec_trans
                   orderby mt.prtl_menu_hec.Parent_id, mt.prtl_menu_hec.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_hec.Published && mt.prtl_menu_hec.Position == position
                   && (mt.prtl_menu_hec.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_hec.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_hec.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_hec.Url,
                       Id = mt.prtl_menu_hec.Menu_id,

                       Url_target = mt.prtl_menu_hec.Url_target,

                       Roles = mt.prtl_menu_hec.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
        {
            return from mt in dc.prtl_menu_law_trans
                   orderby mt.prtl_menu_law.Parent_id, mt.prtl_menu_law.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_law.Published && mt.prtl_menu_law.Position == position
                   && (mt.prtl_menu_law.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_law.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_law.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_law.Url,
                       Id = mt.prtl_menu_law.Menu_id,

                       Url_target = mt.prtl_menu_law.Url_target,

                       Roles = mt.prtl_menu_law.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
        {
            return from mt in dc.prtl_menu_fpe_trans
                   orderby mt.prtl_menu_fpe.Parent_id, mt.prtl_menu_fpe.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_fpe.Published && mt.prtl_menu_fpe.Position == position
                   && (mt.prtl_menu_fpe.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_fpe.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_fpe.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_fpe.Url,
                       Id = mt.prtl_menu_fpe.Menu_id,

                       Url_target = mt.prtl_menu_fpe.Url_target,

                       Roles = mt.prtl_menu_fpe.Roles
                   };
        }
        //****************************
        else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
        {
            return from mt in dc.prtl_menu_VMed_trans
                   orderby mt.prtl_menu_VMed.Parent_id, mt.prtl_menu_VMed.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_VMed.Published && mt.prtl_menu_VMed.Position == position
                   && (mt.prtl_menu_VMed.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_VMed.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_VMed.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_VMed.Url,
                       Id = Convert.ToInt32(mt.prtl_menu_VMed.Menu_id),

                       Url_target = mt.prtl_menu_VMed.Url_target,

                       Roles = mt.prtl_menu_VMed.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
        {
            return from mt in dc.prtl_menu_Pharm_trans
                   orderby mt.prtl_menu_Pharm.Parent_id, mt.prtl_menu_Pharm.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_Pharm.Published && mt.prtl_menu_Pharm.Position == position
                   && (mt.prtl_menu_Pharm.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_Pharm.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_Pharm.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_Pharm.Url,
                       Id = Convert.ToInt32(mt.prtl_menu_Pharm.Menu_id),

                       Url_target = mt.prtl_menu_Pharm.Url_target,

                       Roles = mt.prtl_menu_Pharm.Roles
                   };
        }
        //******************
        else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
        {
            return from mt in dc.prtl_menu_fa_trans
                   orderby mt.prtl_menu_fa.Parent_id, mt.prtl_menu_fa.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_fa.Published && mt.prtl_menu_fa.Position == position
                   && (mt.prtl_menu_fa.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_fa.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_fa.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_fa.Url,
                       Id = mt.prtl_menu_fa.Menu_id,

                       Url_target = mt.prtl_menu_fa.Url_target,

                       Roles = mt.prtl_menu_fa.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
        {
            return from mt in dc.prtl_menu_art_trans
                   orderby mt.prtl_menu_art.Parent_id, mt.prtl_menu_art.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_art.Published && mt.prtl_menu_art.Position == position
                   && (mt.prtl_menu_art.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_art.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_art.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_art.Url,
                       Id = mt.prtl_menu_art.Menu_id,

                       Url_target = mt.prtl_menu_art.Url_target,

                       Roles = mt.prtl_menu_art.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
        {
            return from mt in dc.prtl_menu_ho_trans
                   orderby mt.prtl_menu_ho.Parent_id, mt.prtl_menu_ho.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_ho.Published && mt.prtl_menu_ho.Position == position
                   && (mt.prtl_menu_ho.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_ho.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_ho.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_ho.Url,
                       Id = mt.prtl_menu_ho.Menu_id,

                       Url_target = mt.prtl_menu_ho.Url_target,

                       Roles = mt.prtl_menu_ho.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
        {
            return from mt in dc.prtl_menu_med_trans
                   orderby mt.prtl_menu_med.Parent_id, mt.prtl_menu_med.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_med.Published && mt.prtl_menu_med.Position == position
                   && (mt.prtl_menu_med.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_med.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_med.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_med.Url,
                       Id = mt.prtl_menu_med.Menu_id,

                       Url_target = mt.prtl_menu_med.Url_target,

                       Roles = mt.prtl_menu_med.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
        {
            return from mt in dc.prtl_menu_liv_trans
                   orderby mt.prtl_menu_liv.Parent_id, mt.prtl_menu_liv.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_liv.Published && mt.prtl_menu_liv.Position == position
                   && (mt.prtl_menu_liv.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_liv.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_liv.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_liv.Url,
                       Id = mt.prtl_menu_liv.Menu_id,

                       Url_target = mt.prtl_menu_liv.Url_target,

                       Roles = mt.prtl_menu_liv.Roles
                   };
        }
        else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
        {
            return from mt in dc.prtl_menu_com_trans
                   orderby mt.prtl_menu_com.Parent_id, mt.prtl_menu_com.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_com.Published && mt.prtl_menu_com.Position == position
                   && (mt.prtl_menu_com.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_com.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_com.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_com.Url,
                       Id = mt.prtl_menu_com.Menu_id,

                       Url_target = mt.prtl_menu_com.Url_target,

                       Roles = mt.prtl_menu_com.Roles
                   };
        }
            //121212
        else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
        {
            return from mt in dc.prtl_menu_ECEDU_trans
                   orderby mt.prtl_menu_ECEDU.Parent_id, mt.prtl_menu_ECEDU.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_ECEDU.Published && mt.prtl_menu_ECEDU.Position == position
                   && (mt.prtl_menu_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_menu_ECEDU.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_menu_ECEDU.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_menu_ECEDU.Url,
                       Id = mt.prtl_menu_ECEDU.Menu_id,

                       Url_target = mt.prtl_menu_ECEDU.Url_target,

                       Roles = mt.prtl_menu_ECEDU.Roles
                   };
        }
        //else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
        //{
        //    return from mt in dc.prtl_menu_com_trans
        //           orderby mt.prtl_menu_com.Parent_id, mt.prtl_menu_com.Order
        //           where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_com.Published && mt.prtl_menu_com.Position == position
        //           && (mt.prtl_menu_com.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
        //           || mt.prtl_menu_com.Owner_ID == null)
        //           select new Prtl_MenuUtility.MenuItem
        //           {
        //               Parent_id = mt.prtl_menu_com.Parent_id,
        //               Translation_Data = mt.Translation_Data,
        //               Url = mt.prtl_menu_com.Url,
        //               Id = mt.prtl_menu_com.Menu_id,

        //               Url_target = mt.prtl_menu_com.Url_target,

        //               Roles = mt.prtl_menu_com.Roles
        //           };
        //}
        //else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
        //{
        //    return from mt in dc.prtl_menu_com_trans
        //           orderby mt.prtl_menu_com.Parent_id, mt.prtl_menu_com.Order
        //           where mt.prtl_Language.LCID == currentLanguage && mt.prtl_menu_com.Published && mt.prtl_menu_com.Position == position
        //           && (mt.prtl_menu_com.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
        //           || mt.prtl_menu_com.Owner_ID == null)
        //           select new Prtl_MenuUtility.MenuItem
        //           {
        //               Parent_id = mt.prtl_menu_com.Parent_id,
        //               Translation_Data = mt.Translation_Data,
        //               Url = mt.prtl_menu_com.Url,
        //               Id = mt.prtl_menu_com.Menu_id,

        //               Url_target = mt.prtl_menu_com.Url_target,

        //               Roles = mt.prtl_menu_com.Roles
        //           };
        //}
        else
        {
            return from mt in dc.prtl_Translations
                   orderby mt.prtl_Menu.Parent_id, mt.prtl_Menu.Order
                   where mt.prtl_Language.LCID == currentLanguage && mt.prtl_Menu.Published && mt.prtl_Menu.Position == position
                   && (mt.prtl_Menu.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                   || mt.prtl_Menu.Owner_ID == null)
                   select new Prtl_MenuUtility.MenuItem
                   {
                       Parent_id = mt.prtl_Menu.Parent_id,
                       Translation_Data = mt.Translation_Data,
                       Url = mt.prtl_Menu.Url,
                       Id = mt.prtl_Menu.Menu_id,

                       Url_target = mt.prtl_Menu.Url_target,

                       Roles = mt.prtl_Menu.Roles
                   };
        }

    }
    public static void BuildXML(Page currentPage)
    {

        var ownerId = OwnerID(currentPage);
        var menuxml = new XDocument(new XElement("Menu"));
        var root = menuxml.Element("Menu");
        var positions = Prtl_MenuUtility.GetUniquePositions(ownerId);
        foreach (var position in positions)
        {
            var query = Prtl_MenuUtility.GetXMLMenuItems(position, ownerId).ToList();
            var parentitems = query.Where(i => i.Parent_id == null);
            var nonparentitems = query.Where(i => i.Parent_id != null).ToList();
            foreach (var x in parentitems)
                // ReSharper disable PossibleNullReferenceException
                root.Add(GetMenuXElement(x, currentPage, position));
            foreach (var x in root.Elements())
                AddXMLChildren(x, nonparentitems, currentPage, position);
        }
        // ReSharper restore PossibleNullReferenceException
        menuxml.Save(URLBuilder.Path(currentPage, PathType.Local, SiteFolders.Menu));
    }
    static XElement GetMenuXElement(Prtl_MenuUtility.XMLMenuItem item, Page currentPage, string position)
    {
        var element = new XElement(position + "MenuItem");
        element.SetAttributeValue("TitleAr", item.TitleAr + "");
        element.SetAttributeValue("TitleEn", item.TitleEn + "");
        element.SetAttributeValue("Id", item.Id);
        element.SetAttributeValue("Roles", item.Roles);
        element.SetAttributeValue("Url", URLBuilder.GetURL(item, currentPage, "") + "");
        //    element.SetAttributeValue("UrlEn", URLBuilder.GetURL(item, currentPage, "en") + "");
        element.SetAttributeValue("Url_target", item.Url_target + "");
        element.ReplaceAttributes(element.Attributes().OrderBy(e => e.Name.ToString()));
        return element;
    }
    private static void AddXMLChildren(XElement parentItem, List<Prtl_MenuUtility.XMLMenuItem> children, Page currentPage, string position)
    {
        var childitems = children.Where(i => i.Parent_id != null && i.Parent_id.Value.ToString() == parentItem.Attribute("Id").Value).ToList();
        foreach (var item in childitems.Select(i => GetMenuXElement(i, currentPage, position)))
        {
            parentItem.Add(item);
            AddXMLChildren(item, children, currentPage, position);
        }
    }







    
    public static string GetArticleItemURL(Page page, object id)
    {
        string x;
        if (URLBuilder.OwnerAbbr(page.RouteData) != null)
        {
            x = "/" + URLBuilder.OwnerAbbr(page.RouteData).Replace('.','/') + "/view/" + id + "/" + Currentlanguage(page);
        }
        else
        {
            x = "/view/" + id + "/" + Currentlanguage(page);
        }
        return x;
    }
    public static void ChooseMaster(Page page)
    { 
        var pagebase = (PageBase)page;
        if (pagebase.CurrentOwner.Type == 3)
        {
            page.MasterPageFile = "~/Masterpages/StaffMaster.master";
        }
        else if (pagebase.CurrentOwner.Type == 1 || pagebase.CurrentOwner.Type == 2 || pagebase.CurrentOwner.Type == 14 || pagebase.CurrentOwner.Type == 10)
        {
            page.MasterPageFile = "~/Masterpages/FacultyMaster.master";
        }


        else if (pagebase.CurrentOwner.Type == 5)
        {
            page.MasterPageFile = "~/Masterpages/SubjectsMaster.master";
        }
        else if (pagebase.CurrentOwner.Type == 6)
        {
            page.MasterPageFile = "~/Masterpages/CouncilMaster.master";
        }
        else if (pagebase.CurrentOwner.Type == 4)
        {
            page.MasterPageFile = "~/Masterpages/SectorsMaster.master";
        }
        else if (pagebase.CurrentOwner.Type == 7)
        {
            page.MasterPageFile = "~/Masterpages/QualityMaster.master";
        }
        else if (pagebase.CurrentOwner.Type == 8)
        {
            page.MasterPageFile = "~/Masterpages/StrategyMaster.master";
        }
        else if (pagebase.CurrentOwner.Type == 9)
        {
            page.MasterPageFile = "~/Masterpages/ItUnitsMaster.master";
        }
       
        else if (pagebase.CurrentOwner.Type == 11)
        {
            page.MasterPageFile = "~/Masterpages/LibraryMaster.master";
        }
        else if (pagebase.CurrentOwner.Type == 12 || pagebase.CurrentOwner.Type == 20)
        {
            page.MasterPageFile = "~/Masterpages/SpecialUnitsMaster.Master";
        }
        else if (pagebase.CurrentOwner.Type == 13)
        {
            page.MasterPageFile = "~/Masterpages/LibraryMaster.Master";
        }
        
        else if (pagebase.CurrentOwner.Type == 15)
        {
            page.MasterPageFile = "~/Masterpages/SubjectsMaster.Master";
        }
        else if (pagebase.CurrentOwner.Type == 17)
        {
            page.MasterPageFile = "~/Masterpages/LibraryMaster.Master";
        }
        else if (pagebase.CurrentOwner.Type == 18 || pagebase.CurrentOwner.Type == 19)
        {
            page.MasterPageFile = "~/Masterpages/LibraryMaster.Master";
        }
        else if (pagebase.CurrentOwner.Type == 21  )
        {
            page.MasterPageFile = "~/Masterpages/CONMaster.Master";
        }
        else if (pagebase.CurrentOwner.Type == 22)
        {
            page.MasterPageFile = "~/Masterpages/Festival.Master";
        }
        else
        {
            page.MasterPageFile = "~/Masterpages/UniversityMaster.Master";
        }

    }
    private static void AddChildren(MenuItem parentItem, List<Prtl_MenuUtility.MenuItem> children, Page currentPage, MenuMode mode)
    {
        var childitems = children.Where(i => i.Parent_id != null && i.Parent_id.Value.ToString() == parentItem.Value).ToList();
        if (!childitems.Any())
            return;
        foreach (var childItem in childitems)
            parentItem.ChildItems.Add(GetMenuItem(childItem, currentPage, mode));
        foreach (MenuItem childItem in parentItem.ChildItems)
            AddChildren(childItem, children, currentPage, mode);
    }
    private static MenuItem GetMenuItem(Prtl_MenuUtility.MenuItem menuItem, Page currentPage, MenuMode mode)
    {
        var item = new MenuItem
        {
            Value = menuItem.Id.ToString(),
            Target = menuItem.Url_target,
            NavigateUrl = (mode == MenuMode.Normal) ? URLBuilder.GetURL(menuItem, currentPage) : "",
        };
        var autherized = MenuUserAutherized(currentPage);
        var highlightItem = autherized && string.IsNullOrEmpty(item.NavigateUrl);

        // highlight menu items that don't have a hyperlink
        item.Text = string.Format("{0}{1}{2}", highlightItem ? @"<div style=""color: red"">" : "",
                                  menuItem.Translation_Data, highlightItem ? "</div>" : "");
        item.Selectable = !string.IsNullOrEmpty(item.NavigateUrl) || autherized;

        return item;
    }

    public static bool CheckuserVaild(string userName, Page page)
    {
        if (Membership.GetUser(userName) == null || (page.Session["UserName"] == null && page.User.Identity.IsAuthenticated))
            return false;
        if (userName.ToLower() == Superadmin) return true;

        return Prtl_OwnerAdminUsersUtility.GetUserOwnerIDs(userName).Contains(((PageBase)page).CurrentOwner.Owner_ID);
    }


    public static void CompleteTranslationData(this DetailsView detailsView, DetailsViewInsertEventArgs e,
        string translationId)
    {
        e.Values["Translation_ID"] = translationId;
        var langddl = (DropDownList)detailsView.FindControl("LangDropDownList");
        e.Values["Lang_Id"] = langddl.SelectedValue;
    }

    public static string Currentlanguage(RouteData routeData)
    {
        return
            !routeData.Values.ContainsKey("lang") ? GetBrowserSelectedLang() : routeData.Values["lang"].ToString();
    }

    public static string Currentlanguage(Page page)
    {
        return Currentlanguage(page.RouteData);
    }

    public static void DeleteImage(Page page, string imageName, SiteFolders folder)
    {
        var path = URLBuilder.Path(page, PathType.Local, folder, imageName);

        if (File.Exists(path)) File.Delete(path);
    }

    public static DateTime ExtractDate(object date)
    {
        if (date != null)
        {

            return DateTime.ParseExact(date + "", DateTimeFormat, CultureInfo.InvariantCulture);
        }
        else
        {

            return Convert.ToDateTime(null);
        }
    }

    public static string FormatDate(object date)
    {
        if (date != null)
        {
            return
                DateTime.Parse(date.ToString()).ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Find a control by the user of its ID in the Controls found inside <param name="control"></param>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="control"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static T GetControl<T>(this Control control, string id)
        where T : Control
    {
        return (T)control.FindControl(id);
    }

    public static OwnerTypes GetOwnerType(string abbr)
    {
        return (OwnerTypes)Prtl_OwnersUtility.GetOwnerType(abbr);
    }
    public static OwnerTypes GetOwnerType2(string abbr)
    {
        return (OwnerTypes)Prtl_OwnersUtility.GetOwnerType2(abbr);
    }
    public static T GetSessionValueOrDefault<T>(Page page, string name, T defaultvalue)
    {
        return GetSessionValueOrDefault(page.Session, name, defaultvalue);
    }

    public static T GetSessionValueOrDefault<T>(HttpSessionState session, string name, T defaultvalue)
    {
        return session[name] == null ? defaultvalue : (T)session[name];
    }

    public static string LanguageName(object lcid)
    {
        return lcid == null ? "" : CultureInfo.CreateSpecificCulture(lcid.ToString()).Parent.NativeName;
    }

    /*
    private const string VIRTAPPSTRING = "VIRTAPPSTRING";
    */

    public static Guid? OwnerID(Page page)
    {
        return GetSessionValueOrDefault<Guid?>(page, URLBuilder.OwnerPath(page.RouteData, "_") + "OwnerID", null);
    }

    public static IEnumerable<prtl_Language> OwnerLanguages()
    {
        
            return OwnerNameTranslations().Select(tr => tr.prtl_Language);
        
        
    }

    public static IEnumerable<prtl_Translation> OwnerNameTranslations(Page page)
    {
        return OwnerNameTranslations(page.RouteData);
    }

    public static void PrepareFileUpload(Control control)
    {
        control.Page.Form.Enctype = "multipart/form-data";
        control.Page.Form.Attributes.Add("enctype", "multipart/form-data");
    }

    public static void SetOwnerID(Page page, Guid? ownerID)
    {
        page.Session[URLBuilder.OwnerPath(page.RouteData, "_") + "OwnerID"] = ownerID;
    }

    public static void SetPanelVisibility(Panel panel, IEnumerable<PageRoles> autherizedRoles, Control control, bool isfloat = true)
    {
        panel.Visible = control.Page.User.Identity.Name.ToLower() == Superadmin ||
                        autherizedRoles.Any(r => control.Page.User.IsInRole(r.ToString()));
        if (!panel.Visible) return;
        if (isfloat) panel.Style["float"] = FloatRight;
        panel.Direction = IsRTL
                              ? ContentDirection.RightToLeft
                              : ContentDirection.LeftToRight;
    }

    public static void ShowErrorMessage(MasterPage masterPage, string title, string message)
    {
        if (masterPage.GetControl<ErrorMessageViewer>("ErrorMessageViewer") != null)
        {
            var errorviewer = masterPage.GetControl<ErrorMessageViewer>("ErrorMessageViewer");
            var titleLocalize = errorviewer.GetControl<Localize>("TitleLocalize");
            titleLocalize.Text = title;
            var messageLabel = errorviewer.GetControl<Label>("MessageLabel");
            messageLabel.Text = message;
            var modal = errorviewer.GetControl<ModalPopupExtender>("ErrorMessage_ModalPopupExtender");
            modal.Show();
        }
    }

    public static string UploadImage(Control control, string controlName, SiteFolders folder, CancelEventArgs e)
    {
        var fileUpload = (AsyncFileUpload)control.FindControl(controlName);
        var newfn = UploadImage(control.Page, fileUpload.PostedFile, folder, e);
        fileUpload.ClearFileFromPersistedStore();
        return newfn;
    }
    public static string UploadImage00(Control control, string controlName, SiteFolders folder )
    {
        var fileUpload = (AsyncFileUpload)control.FindControl(controlName);
        var newfn = UploadImage22(control.Page, fileUpload.PostedFile, folder);
        fileUpload.ClearFileFromPersistedStore();
        return newfn;
    }
    //public static string UploadFile(Control control, string controlName, SiteFolders folder, CancelEventArgs e)
    //{
    //    var fileUpload = (AsyncFileUpload)control.FindControl(controlName);
    //    var newfn = UploadFiles(control.Page, fileUpload.PostedFile, folder, e);
    //    fileUpload.ClearFileFromPersistedStore();
    //    return newfn;
    //}
    // to get the file path of images.
    public static int VoteID(Page currentpage)
    {
        var ownervid = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.OwnerAbbr(currentpage.RouteData)).CurrentVotingID;
        return ownervid;
    }

    // ReSharper restore ParameterTypeCanBeEnumerable.Local
    // ReSharper disable ParameterTypeCanBeEnumerable.Local

    private static string GetBrowserSelectedLang()
    {
        string[] languages = HttpContext.Current.Request.UserLanguages;

        if (languages == null || languages.Length == 0)

            return "ar";
        try
        {
            var lang = languages[0].ToLowerInvariant().Trim();
            return lang.Remove(lang.IndexOf("-", StringComparison.Ordinal));
        }

        catch (ArgumentException)
        {
            return "ar";
        }
    }


    private static SiteFolders GetThumbfolder(SiteFolders folder)
    {
        var thumbfolder = SiteFolders.None;
        switch (folder)
        {
            case SiteFolders.Events:
                thumbfolder = SiteFolders.Events_Thumb;
                break;

            case SiteFolders.News:
                thumbfolder = SiteFolders.News_Thumb;
                break;

            case SiteFolders.Articles:
                thumbfolder = SiteFolders.Articles_Thumb;
                break;
        }
        return thumbfolder;
    }

    private static IEnumerable<prtl_Translation> OwnerNameTranslations(RouteData routeData)
    {
        return Prtl_TranslationUtility.OwnerNameTranslations(URLBuilder.CurrentOwnerid(routeData));
    }

    private static IEnumerable<prtl_Translation> OwnerNameTranslations()
    {
        return OwnerNameTranslations(HttpContext.Current.Request.RequestContext.RouteData);
    }

    private static void ResizeImage(float width, string fromFullFileName, string toFullFileName)
    {
        var image = Image.FromFile(fromFullFileName);
        var newWidth = (int)width;
        var newHeight = (int)(image.Height * (width / image.Width));
        var thumbnailBitmap = new Bitmap(newWidth, newHeight);
        var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
        thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
        thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
        thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
        thumbnailGraph.DrawImage(image, imageRectangle);
        thumbnailBitmap.Save(toFullFileName, image.RawFormat);
        thumbnailGraph.Dispose();
        thumbnailBitmap.Dispose();
        image.Dispose();
    }

    private static string UploadImage(Page control, HttpPostedFile fileUpload, SiteFolders folder, CancelEventArgs e)
    {
        if (fileUpload == null || fileUpload.FileName == "")
            return null;
        if (!fileUpload.ContentType.Contains("image") && e is ListViewInsertEventArgs) e.Cancel = true;

        //Events, News, Articles
        var thumbfolder = GetThumbfolder(folder);
        var renameImage = Guid.NewGuid().ToString();
        var imgeFilePath = URLBuilder.Path(control.Page, PathType.Local, folder,
                                     (renameImage == "")
                                         ? Path.GetFileName(fileUpload.FileName)
                                         : renameImage + ".png");
        var imageFileName = Path.GetFileName(imgeFilePath);

        fileUpload.SaveAs(imgeFilePath);
        if (thumbfolder != SiteFolders.None)
        {
            const int imageWidth = 100;
            var thumbsavePath = URLBuilder.Path(control.Page, PathType.Local, thumbfolder, imageFileName);
            var directory = Path.GetDirectoryName(thumbsavePath);
            if (directory != null && thumbsavePath != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            ResizeImage(imageWidth, imgeFilePath, thumbsavePath);
        }
        return imageFileName;
    }

    private static string UploadImage22(Page control, HttpPostedFile fileUpload, SiteFolders folder )
    {
        if (fileUpload == null || fileUpload.FileName == "")
            return null;
        //if (!fileUpload.ContentType.Contains("image") && e is ListViewInsertEventArgs) e.Cancel = true;

        //Events, News, Articles
        var thumbfolder = GetThumbfolder(folder);
        var renameImage = Guid.NewGuid().ToString();
        var imgeFilePath = URLBuilder.Path(control.Page, PathType.Local, folder,
                                     (renameImage == "")
                                         ? Path.GetFileName(fileUpload.FileName)
                                         : renameImage + ".png");
        var imageFileName = Path.GetFileName(imgeFilePath);

        fileUpload.SaveAs(imgeFilePath);
        if (thumbfolder != SiteFolders.None)
        {
            const int imageWidth = 100;
            var thumbsavePath = URLBuilder.Path(control.Page, PathType.Local, thumbfolder, imageFileName);
            var directory = Path.GetDirectoryName(thumbsavePath);
            if (directory != null && thumbsavePath != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            ResizeImage(imageWidth, imgeFilePath, thumbsavePath);
        }
        return imageFileName;
    }

    //private static string UploadFiles(Page control, HttpPostedFile fileUpload, SiteFolders folder, CancelEventArgs e)
    //{
    //    if (fileUpload == null || fileUpload.FileName == "")
    //        return null;





    //    var FilePath = URLBuilder.Path(control.Page, PathType.Local, folder,
    //                                  Path.GetFileName(fileUpload.FileName));
    //    var FileName = Path.GetFileName(FilePath);

    //    fileUpload.SaveAs(FilePath);

    //    return FileName;

    //}
    public static void FloatControls(Control parent, string floatdirection, params string[] controlsServerIds)
    {
        foreach (var xx in controlsServerIds.Select(parent.FindControl))
        {
            if (xx is WebControl)
            {
                ((WebControl)xx).Style.Add("float", floatdirection);

            }
            else if (xx is HtmlGenericControl)
            {
                ((HtmlGenericControl)xx).Style.Add("float", floatdirection);

            }
        }
    }

    public static bool MenuUserAutherized(Page currentPage)
    {
        return currentPage.User.Identity.Name.ToLower() == Superadmin ||
               MenueditorRoles.Any(r => currentPage.User.IsInRole(r.ToString()));
    }

    #endregion Methods
}