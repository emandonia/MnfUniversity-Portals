using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using BLL;
using MnfUniversity_Portals;
using MnfUniversity_Portals.BLL.Portal_BLL;
using Portal_DAL;


//using Microsoft.Web.Administration;

namespace Common
{

    public static class URLBuilder
    {
        #region Images Code

        public const string DefaultImageName = "Default.jpg";

        public static string FilesFolderBase
        {
            get
            {
                return
                  "/" + ConfigurationManager.AppSettings["FilesBase"];
            }
        }

        private static string FilesFSBase
        {
            get
            {
                return PhysicalPath("");
            }
        }

        public static string PhysicalPath(string currentOwnerRelativeFolderBase)
        {
            currentOwnerRelativeFolderBase = currentOwnerRelativeFolderBase.Replace(ImageURLBase, "");
            var parts = new[] { "localhost\\", FilesFolderBase, currentOwnerRelativeFolderBase };
            return CombinePath(PathType.Local, parts);
        }
        public static string CombinePath(PathType type, params string[] parts)
        {
            var separator = (type == PathType.Local) ? "\\" : "/";

            return ((type == PathType.Local) ? "\\\\" : (parts[0].Contains("http://") ? "" : "/")) + string.Join(separator,
                parts.Select(s => (type == PathType.Local) ? s.Replace("/", "\\").Trim('\\') : s.Replace("\\", "/").Trim('/')))
                    + separator;
        }
        public static string FilesHomeServer
        {
            get
            {
                return
                  ConfigurationManager.AppSettings["FilesHomeServer"];
            }
        }

        public static string ImageURLBase
        {
            get
            {
                return FilesHomeServer + FilesFolderBase;
            }
        }

        public static string StaffImageUrl(Page page, string filename)
        {
            return GetURLIfExists(page, SiteFolders.Staff, filename);
        }
        public static string BannerURL(Page page)
        {
            if (Prtl_OwnersUtility.GetOwnerType(URLBuilder.CurrentFacAbbr(page.RouteData)) == 3)
            {
                return GetURLIfExists(page, SiteFolders.StaffBanners, null, StaticUtilities.Currentlanguage(page));
            }
            else if (Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentFacAbbr(page.RouteData)).Type == 5)
            {
                return GetURLIfExists(page, SiteFolders.Subjects, null, StaticUtilities.Currentlanguage(page));
            }

            else
            {
                return GetURLIfExists(page, SiteFolders.Owners_Banners, null, StaticUtilities.Currentlanguage(page));
            }
        }

        public static string GetLocalpath(Page page, SiteFolders folder, string filename, string language = "")
        {
            if (filename != null && string.IsNullOrEmpty(System.IO.Path.GetExtension(filename)))
                filename += "." + Extension(folder);
            return Path(page, PathType.Local, folder, filename, language);
        }

        
        public static string GetURLIfExists(Page page, SiteFolders folder, string filename, string language = null)
        {
            var localpath = GetLocalpath(page, folder, ref filename, language);
            var path = Path(page, PathType.WebServer, folder, filename, language);
            var directory = System.IO.Path.GetDirectoryName(localpath);

            if (directory != null && localpath != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return File.Exists(localpath) ? path : Path(page, PathType.WebServer, folder, language: language, getDefault: true);
        }
        public static string GetURLIfExistsforNewsImage(Page page, SiteFolders folder, string filename,int id,string abbr, string language = null)
        {

            Guid ownerId=Guid.NewGuid();
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var guid = Prtl_NewsUtility.Get_univ_NewsByID(id).Owner_ID;
                    if (guid != null)
                        ownerId = (Guid) guid;
                }
                else if (abbr.ToLower() == "fci")
                {
                    ownerId = (Guid) Prtl_NewsUtility.Get_fci_NewsByID(id).Owner_ID;
                }
               else if (abbr.ToLower() == "fee")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_fee_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "eng")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_eng_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "nur")
                {
                    ownerId = (Guid) Prtl_NewsUtility.Get_nur_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "edu")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_edu_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "sci")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_sci_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "edv")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_edv_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "agr")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_agr_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "hec")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_hec_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "law")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_law_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "fpe")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_fpe_NewsByID(id).Owner_ID;
                }

                         //***************************
                else if (abbr.ToLower() == "pharm")
                {
                    ownerId = (Guid)Prtl_NewsUtility.Get_Pharm_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "vmed")
                {
                    ownerId = (Guid)Prtl_NewsUtility.Get_VMed_NewsByID(id).Owner_ID;
                }
                //*********************   
                
                else if (abbr.ToLower() == "fa")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_fas_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "art")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_art_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "ho")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_hos_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "med")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_med_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "liv")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_liv_NewsByID(id).Owner_ID;
                }
                else if (abbr.ToLower() == "com")
                {
                     ownerId = (Guid) Prtl_NewsUtility.Get_com_NewsByID(id).Owner_ID;
                }
                    //1212121212
                else if (abbr.ToLower() == "ecedu")
                {
                    ownerId = (Guid)Prtl_NewsUtility.Get_ecedu_NewsByID(id).Owner_ID;
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    ownerId = (Guid)Prtl_NewsUtility.Get_com_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    ownerId = (Guid)Prtl_NewsUtility.Get_com_NewsByID(id).Owner_ID;
                //}
                    
                else
                {
                    ownerId = (Guid) Prtl_NewsUtility.GeNewsByID(id).Owner_ID;
                }
            }
           

            if ( ownerId == new Guid("b9c7a805-ed88-425c-8763-db283c4cc92b"))
            {
                var localpath = GetLocalpath(page, folder, ref filename, language);
                var path = Path(page, PathType.WebServer, folder, filename, language);
                var directory = System.IO.Path.GetDirectoryName(localpath);

                if (directory != null && localpath != null && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                return File.Exists(localpath)
                    ? path
                    : Path(page, PathType.WebServer, folder, language: language, getDefault: true);
            }
            else
            {
                var localpath = GetLocalpath(page, folder, ref filename, language);
                var path = Path(page, PathType.WebServer, folder, filename, language);
                var directory = System.IO.Path.GetDirectoryName(localpath);

                if (directory != null && localpath != null && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                return File.Exists(localpath)
                    ? path
                    : Path(page, PathType.WebServer, folder, language: language, getDefault: true);
            }
        }
        public static string GetURLIfExists2(Page page, SiteFolders folder, string filename, string language = null)
        {

            var localpath = GetLocalpath(page, folder, ref filename, language);
            var path = Path(page, PathType.WebServer, folder, filename, language);
            var directory = System.IO.Path.GetDirectoryName(localpath);

            if (directory != null && localpath != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            if (folder == SiteFolders.StaffImage)
            {
                return directory;
            }
            return File.Exists(localpath) ? path : "";
        }
        public static string GetURLIfExists3(Page page, SiteFolders folder, string filename, string language = null)
        {

            var localpath = GetLocalpath2(page, folder, ref filename, language);
            var path = Path(page, PathType.WebServer, folder, filename, language);
            var directory = System.IO.Path.GetDirectoryName(localpath);

            if (directory != null && localpath != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return Directory.Exists(localpath) ? localpath : "";
        }
        /// <summary>
        ///  Forms Image path to be used all over the project either the path is used to view an image or to store it locally on server.
        /// </summary>
        /// <param name="routeData"></param>
        /// <param name="type"> The type of path needed either to be stored locally ( type local ) or displayed ( type webserver).</param>
        /// <param name="folder">The folder the image is stored in. </param>
        /// <param name="filename"></param>
        /// <param name="language">The Language in which the page is displayed (used with Logos)</param>
        /// <param name="getDefault"></param>
        /// <returns></returns>
        public static string Path( RouteData routeData, PathType type, SiteFolders folder, object filename = null,
                                       string language = "", bool getDefault = false)
        {
            // for default only ( or university)
            var defaultroutedata = new RouteData();
            var defaultOwnerAbbr = "uni";
            if (getDefault)
            {
                var ownerabbr = OwnerAbbr(routeData);
                // the default is the parent if the subowner doesn't have data
                if (ownerabbr != null && ownerabbr.Contains("."))
                {
                    var tempcurrentOwnerAbbr = ownerabbr.Split('.')[0];
                    var temproutedata = new RouteData();
                    temproutedata.Values.Add("currentowner", tempcurrentOwnerAbbr);
                    if (File.Exists(Path(temproutedata, PathType.Local, folder, language: language)))
                    {
                        defaultOwnerAbbr = tempcurrentOwnerAbbr;
                        defaultroutedata = temproutedata;
                    }
                }
                if (!IsSiteInfo(folder))
                    filename = DefaultImageName;
            }
            //end for default only
            string foldername;

            if (folder == SiteFolders.Staff)
            {
                foldername = ImageURLBase + "/uni/Portal/SiteInfo";
                var newfilename = "Users.xml";
                return CombinePath(type, (type == PathType.Local)
                                                 ? MapPath(foldername)
                                                 : foldername) + newfilename;
            }
            else if (folder == SiteFolders.Abstracts)
            {
                foldername = ImageURLBase + "/uni/Portal/Images";
                //var newfilename = "Users.xml";
                return CombinePath(type, (type == PathType.Local)
                                                 ? MapPath(foldername)
                                                 : foldername) + filename;
            }
           
            else if (folder == SiteFolders.Course_Specs)
            {
                foldername = ImageURLBase + "/" + OwnerFilePath(getDefault ? defaultroutedata : routeData) + "/Portal/Files/Specs/";
                if (filename != null)
                {
                    var newfilename = filename ??
                                      (SiteInfoFileName(
                                          CurrentOwnerAbbr(routeData) != null && !getDefault
                                              ? CurrentOwnerAbbr(routeData)
                                              : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                    return CombinePath(type, (type == PathType.Local)
                                                  ? MapPath(foldername)
                                                  : foldername) + newfilename;
                }
                else
                {
                    return CombinePath(type,
                                       MapPath(foldername));

                }

            }
             if (folder == SiteFolders.Sectors)
            {
                foldername = ImageURLBase + "/" + OwnerFilePath(getDefault ? defaultroutedata : routeData) + "/Portal/Files/Specs/";
                if (filename != null)
                {
                    var newfilename = filename ??
                                      (SiteInfoFileName(
                                          CurrentOwnerAbbr(routeData) != null && !getDefault
                                              ? CurrentOwnerAbbr(routeData)
                                              : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                    return CombinePath(type, (type == PathType.Local)
                                                  ? MapPath(foldername)
                                                  : foldername) + newfilename;
                }
                else
                {
                    return CombinePath(type,
                                       MapPath(foldername));

                }

            }
            if (folder == SiteFolders.Course_Report)
            {
                foldername = ImageURLBase + "/" + OwnerFilePath(getDefault ? defaultroutedata : routeData) + "/Portal/Files/Report/";
                if (filename != null)
                {
                    var newfilename = filename ??
                                      (SiteInfoFileName(
                                          CurrentOwnerAbbr(routeData) != null && !getDefault
                                              ? CurrentOwnerAbbr(routeData)
                                              : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                    return CombinePath(type, (type == PathType.Local)
                                                  ? MapPath(foldername)
                                                  : foldername) + newfilename;
                }
                else
                {
                    return CombinePath(type,
                                       MapPath(foldername));

                }

            }
            if (folder == SiteFolders.Thesis )
            {
                foldername = ImageURLBase+ "/uni/Portal/Thesis/";
                if (filename != null)
                {
                    var newfilename = filename ??
                                      (SiteInfoFileName(
                                          CurrentOwnerAbbr(routeData) != null && !getDefault
                                              ? CurrentOwnerAbbr(routeData)
                                              : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                    return CombinePath(type, (type == PathType.Local)
                                                  ? MapPath(foldername)
                                                  : foldername) + newfilename;
                }
                else
                {
                    return CombinePath(type,
                                       MapPath(foldername));

                }

            }
            if (folder == SiteFolders.CV)
            {
                var  ownerabbr = OwnerAbbr(routeData);
                foldername = ImageURLBase + "/uni/Portal/CVs/"+ownerabbr ;
                if (filename != null)
                {
                    var newfilename = filename ??
                                      (SiteInfoFileName(
                                          CurrentOwnerAbbr(routeData) != null && !getDefault
                                              ? CurrentOwnerAbbr(routeData)
                                              : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                    return CombinePath(type, (type == PathType.Local)
                                                  ? MapPath(foldername)
                                                  : foldername) + newfilename;
                }
                else
                {
                    return CombinePath(type,
                                       MapPath(foldername));

                }

            }

            if (folder == SiteFolders.SentficResearches )
            {
                var ownerabbr = OwnerAbbr(routeData);
                foldername = ImageURLBase + "/uni/Portal/SentficResearches/" + ownerabbr;
                if (filename != null)
                {
                    var newfilename = filename ??
                                      (SiteInfoFileName(
                                          CurrentOwnerAbbr(routeData) != null && !getDefault
                                              ? CurrentOwnerAbbr(routeData)
                                              : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                    return CombinePath(type, (type == PathType.Local)
                                                  ? MapPath(foldername)
                                                  : foldername) + newfilename;
                }
                else
                {
                    return CombinePath(type,
                                       MapPath(foldername));

                }

            }
                if (folder == SiteFolders.SentficResearches )
            {
                var  ownerabbr = OwnerAbbr(routeData);
                foldername = ImageURLBase + "/uni/Portal/SentficResearches/" + ownerabbr;

                
                  
                //    if (!Directory.Exists(foldername))
                //{
                //    Directory.CreateDirectory(foldername);
                //}

                if (filename != null)
                {
                    var newfilename = filename ??
                                      (SiteInfoFileName(
                                          CurrentOwnerAbbr(routeData) != null && !getDefault
                                              ? CurrentOwnerAbbr(routeData)
                                              : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                    return CombinePath(type, (type == PathType.Local)
                                                  ? MapPath(foldername)
                                                  : foldername) + newfilename;
                }
                else
                {
                    return CombinePath(type,
                                       MapPath(foldername));

                }
             }
            else
            {
                foldername = ImageURLBase + "/" + OwnerFilePath(getDefault ? defaultroutedata : routeData) + "/Portal/" +
                         (IsSiteInfo(folder)
                              ? "SiteInfo"
                              : (folder.ToString().Contains("Thumb") ? "Images/Thumbs" : "Images"));
                var newfilename = filename ??
                                  (SiteInfoFileName(
                                      CurrentOwnerAbbr(routeData) != null && !getDefault
                                          ? CurrentOwnerAbbr(routeData)
                                          : defaultOwnerAbbr, folder, language) + "." + Extension(folder));
                return CombinePath(type, (type == PathType.Local)
                                             ? MapPath(foldername)
                                             : foldername) + newfilename;

            }
        }

        public static string Path(Page page, PathType type, SiteFolders folder, object filename = null,string language = "", bool getDefault = false)
        {
            return Path(page.RouteData, type, folder, filename, language, getDefault);
        }
        public static string fixedpath(PathType type, SiteFolders folder, object filename = null, bool getDefault = true)
        {
            var defaultroutedata = new RouteData();
            var defaultOwnerAbbr = "uni";
            var foldername = ImageURLBase + "/" + OwnerFilePath(defaultroutedata) + "/Portal/" + (IsSiteInfo(folder) ? "SiteInfo" : "Images");
            var newfilename = filename ??
                              (SiteInfoFileName(defaultOwnerAbbr, folder) + "." + Extension(folder));
            return CombinePath(type, (type == PathType.Local)
                     ? MapPath(foldername) : foldername) + newfilename;
        }
        public static bool IsSiteInfo(SiteFolders folder)
        {
            switch (folder)
            {
                case SiteFolders.Owners_Icons:

                case SiteFolders.Owners_Banners:
                case SiteFolders.StaffBanners:
                case SiteFolders.Subjects:
                case SiteFolders.Owners_Logos:
                case SiteFolders.Menu:
                case SiteFolders.RightLeftLinks:

                case SiteFolders.Staff:
                case SiteFolders.StaffImage:
                case SiteFolders.Owners_Intros:
                    return true;
                default:
                    return false;
            }

        }

        public static string SiteInfoFileName(string currentOwnerAbbr, SiteFolders folder, string language = "")
        {
            switch (folder)
            {
                case SiteFolders.Owners_Icons:
                case SiteFolders.Owners_Intros:
                    return currentOwnerAbbr;
                case SiteFolders.Owners_Banners:
                    return currentOwnerAbbr + "_" + language;
                case SiteFolders.Owners_Logos:
                    return currentOwnerAbbr + "_logo";
                case SiteFolders.Menu:
                    return "menu";
                case SiteFolders.RightLeftLinks:
                    return "Links";
                case SiteFolders.Staff:
                    return "Users";
                case SiteFolders.StaffImage:
                    return "Image";
                case SiteFolders.StaffBanners:
                    return "staff_" + language;
                case SiteFolders.Subjects:
                    return "courses_" + language;
                default:
                    return "";
            }

        }

        private static string Extension(SiteFolders folder)
        {
            switch (folder)
            {
                case SiteFolders.Owners_Icons:
                    return "ico";
                case SiteFolders.Owners_Banners:
                case SiteFolders.Owners_Logos:
                case SiteFolders.Owners_Intros:
                    return "png";
                case SiteFolders.Staff:
                    return "xml";

                case SiteFolders.Menu:
                    return "xml";
                case SiteFolders.RightLeftLinks:
                    return "xml";
                case SiteFolders.Abstracts:
                    return "pdf";
                case SiteFolders.StaffBanners:
                    return "png";
                case SiteFolders.Subjects:
                    return "png";
                case SiteFolders.StaffImage:
                    return "png";
                case SiteFolders.Course_Specs:
                    return "doc";
                case SiteFolders.Course_Report:
                    return "doc";
                default:
                    return "jpg";
            }
        }

        private static string GetLocalpath(Page page, SiteFolders folder, ref string filename, string language = "")
        {
            if (filename != null && string.IsNullOrEmpty(System.IO.Path.GetExtension(filename)))
            {
                filename += "." + Extension(folder);
            }
            return Path(page, PathType.Local, folder, filename, language);
        }
        private static string GetLocalpath2(Page page, SiteFolders folder, ref string filename, string language = "")
        {
            if (filename != null && string.IsNullOrEmpty(System.IO.Path.GetExtension(filename)))
            {
                filename += "." + Extension(folder);
            }
            else if (filename == null)
            {
                filename = null;
            }


            return Path(page, PathType.Local, folder, filename, language);

        }
        private static string MapPath(string url)
        {
            return FilesFSBase + url.Replace(ImageURLBase, "").TrimStart('/').Replace('/', '\\');
        }

        #endregion Images Code

        #region Owners

        private static IEnumerable<string> OwnerPaths
        {
            get
            {
                return new[]
                             {
                                 ""// means university
                                 ,"{currentowner}"// Faculty or Staff or Sector
                                 ,"{parentowner1}/{currentowner}" // faculty / department or faculty / subject
                             };
            }
        }

        public static Guid CurrentOwnerid(RouteData routeData)
        {
            return Prtl_OwnersUtility.GetOwnerIDByAbbr(OwnerAbbr(routeData));
        }

         
        public static prtl_Owner CurrentOwner(RouteData routeData)
        {
            return Prtl_OwnersUtility.GetOwnerByAbbr2(OwnerAbbr(routeData));
        }

        public static string OwnerAbbr(RouteData routeData)
        {

            if (routeData.Values.ContainsKey("currentowner"))
                if (routeData.Values.ContainsKey("parentowner1"))
                    return 
                          routeData.GetRequiredString("currentowner");
                else return routeData.GetRequiredString("currentowner");
            return null;
        }
        public static string CurrentOwnerAbbr(RouteData routeData)
        {
            var ownerAbbr = OwnerAbbr(routeData);
            if (ownerAbbr != null && ownerAbbr.Contains("."))
                return ownerAbbr.Split('.')[1];
            return ownerAbbr;

        }
        
        public static string CurrentDepAbbr(RouteData routeData)
        {
            var ownerAbbr = OwnerAbbr(routeData);
            if (ownerAbbr != null && ownerAbbr.Contains("."))
            {
                return ownerAbbr.Split('.')[1];
            }
            else
            {
                return null;
            }
        }
        public static string CurrentFacAbbr(RouteData routeData)
        {
            if (routeData.Values.ContainsKey("currentowner"))
                if (routeData.Values.ContainsKey("parentowner1"))
                    return routeData.GetRequiredString("parentowner1");

                else return routeData.GetRequiredString("currentowner");
            return null;
        }

        public static int CurrentFacID(RouteData routeData)
        {
            if (routeData.Values.ContainsKey("currentowner")){
                
                    var dc = new Portal_DAL.PortalDataContextDataContext();
                    var q =
                        dc.prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == routeData.GetRequiredString("currentowner")).ID;
                    return q;
                }
                    

                else return 32;
            return 32;
        }
        public static string OwnerPath(Page page)
        {
            return OwnerPath(page.RouteData);
        }

        public static string OwnerPath(RouteData routeData, string separator = "/")
        {

            if (string.IsNullOrEmpty(OwnerAbbr(routeData)) && separator != "/")
                return "uni";
            return string.IsNullOrEmpty(OwnerAbbr(routeData)) ? "" : string.Join(separator,
                RouteWithNoLang(routeData).Select(v => v.Value.ToString()).ToArray());
        }

        public static string OwnerFilePath(Page page, string separator = "/")
        {
            return OwnerFilePath(page.RouteData, separator);
        }

        public static string OwnerFilePath(RouteData routeData, string separator = "/")
        {

            if (string.IsNullOrEmpty(OwnerAbbr(routeData)))
                return "uni";
            //if (string.IsNullOrEmpty(OwnerAbbr(routeData)) || Prtl_OwnersUtility.GetOwnerType(URLBuilder.CurrentFacAbbr(routeData)) == 3)
            //    return "uni";

            var ownersArray = RouteWithNoLang(routeData).Select(v => v.Value.ToString()).ToArray();
            var ownerFilePathArray = new List<string>();
            var type = "";
            foreach (var owner in ownersArray)
            {
                type =  owner;
                //type = owner;
                var ownerType = StaticUtilities.GetOwnerType(type);
                switch (ownerType)
                {
                    case OwnerTypes.Faculty:
                        ownerFilePathArray.Add("Faculties");
                        break;
                    case OwnerTypes.Department:
                        ownerFilePathArray.Add("Departments");
                        break;
                    case OwnerTypes.PostDep:
                        ownerFilePathArray.Add("PostDep");
                        break;
                    case OwnerTypes.PostPrograms:
                        ownerFilePathArray.Add("PostPrograms");
                        break;
                    case OwnerTypes.Staff:
                        ownerFilePathArray.Add("Staff");
                        break;
                    case OwnerTypes.Sectors:
                        ownerFilePathArray.Add("Sectors");
                        break;
                    case OwnerTypes.Subjects:
                        ownerFilePathArray.Add("Subjects");
                        break;
                    case OwnerTypes.PostSubjects:
                        ownerFilePathArray.Add("PostSubjects");
                        break;
                    case OwnerTypes.Council:
                        ownerFilePathArray.Add("Council");
                        break;
                    case OwnerTypes.QualityUnits:
                        ownerFilePathArray.Add("QualityUnits");
                        break;
                    case OwnerTypes.Stratigies:
                        ownerFilePathArray.Add("Stratigies");
                        break;
                    case OwnerTypes.ItUnits:
                        ownerFilePathArray.Add("ItUnits");
                        break;
                    case OwnerTypes.SMagazines:
                        ownerFilePathArray.Add("SMagazines");
                        break;
                    case OwnerTypes.Library:
                        ownerFilePathArray.Add("Library");
                        break;
                    case OwnerTypes.SPecial_Unit :
                        ownerFilePathArray.Add("SUHome");
                        break;
                    case OwnerTypes.infor :
                        ownerFilePathArray.Add("infoHome");
                        break;
                    case OwnerTypes.Css :
                        ownerFilePathArray.Add("CssHome");
                        break;
                    case OwnerTypes.caamu:
                        ownerFilePathArray.Add("CaamuHome");
                        break;
                    case OwnerTypes.cedo:
                        ownerFilePathArray.Add("CedoHome");
                        break;
                    case OwnerTypes.ResProg:
                        ownerFilePathArray.Add("ResProgHome");
                        break;
                    case OwnerTypes.Fourm :
                        ownerFilePathArray.Add("ConHome");
                        break;
                    case OwnerTypes.Festival :
                        ownerFilePathArray.Add("FestalHome");
                        break;


                    default:
                        throw new ArgumentOutOfRangeException();
                }
                ownerFilePathArray.Add(
                    ownerType == OwnerTypes.Staff ?
                    Prtl_OwnersUtility.GetOwnerByAbbr2(owner).InitAbbr : owner);
            }
            return string.Join(separator, ownerFilePathArray);
        }
        public static string OwnersNamesString(RouteData routeData, string currentlanguage)
        {
            var route = RouteWithNoLang(routeData);
            if (route == null)
                return Prtl_TranslationUtility.GetTransDataByTranIDandLCID(
                    Prtl_OwnersUtility.GetOwnerIDByAbbr(null), currentlanguage);
            var names = new List<string>();
            foreach (var result in route.Select(p => p.Value.ToString()))
                names.Add(names.LastOrDefault() + (names.Any() ? "." + result : result));
            var ownerNames = names
                .Select(result =>
                    Prtl_TranslationUtility.GetTransDataByTranIDandLCID(
                    Prtl_OwnersUtility.GetOwnerIDByAbbr(result), currentlanguage)).ToList();
            return string.Join(" - ", Enumerable.Reverse(ownerNames));
        }

        private static string OwnerPathName(string ownerpath, string listitem)
        {
            return "RouteTo" + GetkeysfromPlaceholders(ownerpath) + listitem;
        }

        private static IEnumerable<KeyValuePair<string, object>> RouteWithNoLang(RouteData routeData)
        {
            if (!routeData.Values.ContainsKey("currentowner"))
            {
                return null;
            }
            var route = routeData.Values.TakeWhile(k => k.Key != "currentowner")
               .ToList();
            route.Add(routeData.Values.SingleOrDefault(s => s.Key == "currentowner"));
            return route;
        }

        #endregion Owners

        #region URLs

        public static object EventsHandlerURL(Page page)
        {
            return URL("~", page, "EventsRSS");
        }

        public static string FormURL(object lcid, Page page)
        {

            // ReSharper disable PossibleNullReferenceException
            var urlparts = page.Request.AppRelativeCurrentExecutionFilePath.Split('/');
            // ReSharper restore PossibleNullReferenceException

            urlparts[urlparts.Length - 1] = lcid.ToString();
            return String.Join("/", urlparts);
        }

        public static string GetURL(Prtl_MenuUtility.MenuItem menuItem, Page currentPage)
        {
            string url; if (menuItem.Url == null) return null;
            if (menuItem.Url.StartsWith("View"))
            {

                var xx = prtl_ArticlesUtility.GetArticlebyMenuItemID2(menuItem.Id, URLBuilder.CurrentOwnerid(currentPage.RouteData));
                url = URL(VirtualPath(currentPage), currentPage, "View" + (xx == null ? "" : "/" + xx.Abbr));
            }
            else if (StaticUtilities.AbsoulteURLprefixes.Any(p => menuItem.Url.ToLower().StartsWith(p))) url = menuItem.Url;
            else
                url = currentPage.ResolveUrl(URL(VirtualPath(currentPage), currentPage, menuItem.Url.TrimStart('/')));
            return url;
        }
        public static string GetURL(Prtl_MenuUtility.XMLMenuItem menuItem, Page currentPage, string lang)
        {
            string url; if (menuItem.Url == null) return null;
            if (menuItem.Url.StartsWith("View"))
            {
                var xx = prtl_ArticlesUtility.GetArticlebyMenuItemID2(menuItem.Id,URLBuilder.CurrentOwnerid(currentPage.RouteData));
                url = URL(VirtualPath(currentPage), currentPage, "View" + (xx == null ? "" : "/" + xx.Abbr), lang);
            }
            else if (StaticUtilities.AbsoulteURLprefixes.Any(p => menuItem.Url.ToLower().StartsWith(p))) url = menuItem.Url;
            else
                url = currentPage.ResolveUrl(URL(VirtualPath(currentPage), currentPage, menuItem.Url.TrimStart('/'), lang));
            return url;
        }
        public static object HomeURL(Page page)
        {
            var homepage = "Home";
            switch ((OwnerTypes)StaticUtilities.GetOwnerType2(CurrentOwnerAbbr(page.RouteData)))
            {
                case OwnerTypes.University:
                case OwnerTypes.Faculty:
                case OwnerTypes.SMagazines:
                case OwnerTypes.Department:
                case OwnerTypes.PostPrograms:
                case OwnerTypes.PostDep:
                    break;
                case OwnerTypes.Staff:
                    homepage = "StaffDetails/1";
                    break;
                case OwnerTypes.Subjects:
                    homepage = "SubjectHome";
                    break;
                case OwnerTypes.PostSubjects:
                    homepage = "PostSubHome";
                    break;
                case OwnerTypes.Council:
                    homepage = "CouncilHome";
                    break;
                case OwnerTypes.Sectors:
                    homepage = "SectorsHome";
                    break;
                case OwnerTypes.QualityUnits:
                    homepage = "QualityHome";
                    break;
                case OwnerTypes.Stratigies:
                    homepage = "StratHome";
                    break;
                case OwnerTypes.ItUnits:
                    homepage = "ItUnitHome";
                    break;
                case OwnerTypes.infor:
                    homepage = "infoHome";
                    break;
                case OwnerTypes.Library :
                    homepage = "LibraryHome";
                    break;
                case OwnerTypes.SPecial_Unit :
                    homepage = "SUHome";
                    break;
                case OwnerTypes.Css:
                    homepage = "CssHome";
                    break;
                case OwnerTypes.caamu:
                    homepage = "CaamuHome";
                    break;
                case OwnerTypes.cedo:
                    homepage = "CedoHome";
                    break;
                case OwnerTypes.ResProg:
                    homepage = "ResProgHome";
                    break;
                case OwnerTypes.Fourm :
                    homepage = "ConHome";
                    break;
                case OwnerTypes.Festival:
                    homepage = "FestalHome";
                    break;
            }
            return URL(VirtualPath(page), page, homepage);

        }

        public static string HomeURL(Page page, RouteData routeData)
        {
            var homepage = "Home";
            switch ((OwnerTypes)StaticUtilities.GetOwnerType2(CurrentOwnerAbbr(page.RouteData)))
            {
                case OwnerTypes.University:
                case OwnerTypes.Faculty:
                case OwnerTypes.SMagazines:
                case OwnerTypes.Department:
                case OwnerTypes.PostPrograms:
                case OwnerTypes.PostDep:
                    break;
                case OwnerTypes.Staff:
                    homepage = "StaffDetails/1";
                    break;
                case OwnerTypes.Subjects:
                    homepage = "SubjectHome";
                    break;
                case OwnerTypes.PostSubjects:
                    homepage = "PostSubHome";
                    break;
                case OwnerTypes.Council:
                    homepage = "CouncilHome";
                    break;
                case OwnerTypes.Sectors:
                    homepage = "SectorsHome";
                    break;
                case OwnerTypes.QualityUnits:
                    homepage = "QualityHome";
                    break;
                case OwnerTypes.infor:
                    homepage = "infoHome";
                    break;
                case OwnerTypes.Stratigies:
                    homepage = "StratHome";
                    break;
                case OwnerTypes.ItUnits:
                    homepage = "ItUnitHome";
                    break;
                
                case OwnerTypes.Library :
                    homepage = "LibraryHome";
                    break;
                case OwnerTypes.SPecial_Unit :
                    homepage = "SUHome";
                    break;
                case OwnerTypes.ResProg:
                    homepage = "ResProgHome";
                    break;
                case OwnerTypes.Css:
                    homepage = "CssHome";
                    break;
                case OwnerTypes.caamu:
                    homepage = "CaamuHome";
                    break;
                case OwnerTypes.cedo:
                    homepage = "CedoHome";
                    break;
                case OwnerTypes.Fourm :
                    homepage = "ConHome";
                    break;
                     case OwnerTypes.Festival  :
                    homepage = "FestalHome";
                    break;
                    
            }
            return URL(VirtualPath(page), routeData, homepage);

        }
        public static string LoginURL(Page page, RouteData routeData)
        {

            return URL(VirtualPath(page), routeData, "Login");

        }
        public static string UniNewItemUrl(RouteData routeData, int id,string abbr,string ViewerId)
        {
            Guid ownerId = Guid.NewGuid();
            //var dc = new PortalDataContextDataContext();
            

                //if (abbr == null)
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_univ_NewsByID(id).Owner_ID;

                //}
                //else if (abbr.ToLower() == "fci")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_fci_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "fee")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_fee_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "eng")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_eng_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "nur")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_nur_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "edu")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_edu_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "sci")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_sci_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "edv")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_edv_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "agr")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_agr_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "hec")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_hec_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "law")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_law_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "fpe")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_fpe_NewsByID(id).Owner_ID;
                //}
                //////////////////////******
                //else if (abbr.ToLower() == "pharm")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_Pharm_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "vmed")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_VMed_NewsByID(id).Owner_ID;
                //}
                ////************************

                //else if (abbr.ToLower() == "fa")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_fas_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "art")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_art_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "ho")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_hos_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "med")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_med_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "liv")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_liv_NewsByID(id).Owner_ID;
                //}
                //else if (abbr.ToLower() == "com")
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.Get_com_NewsByID(id).Owner_ID;
                //}
                //else
                //{
                //    if (Prtl_NewsUtility.Get_univ_NewsByID(id) != null)
                //        ownerId = (Guid) Prtl_NewsUtility.GeNewsByID(id).Owner_ID;
                //}



            if (ViewerId == "NewsViewerControl2")
            {


                return URL2("~", routeData,
                    Prtl_NewsUtility.GetOwnerByNewsID(id).Abbr + "/NewsDetails/" + id);
            }
            else if (ViewerId == "NewsViewerControl1")
            {
                return URL2("~", routeData,
                   CurrentOwnerAbbr(routeData) + "/NewsDetails/" + id);
            }
            else
            {
                return URL("~", routeData, "NewsDetails/" + id);
            }

        }

        public static string NewItemUrl(RouteData routeData, int id,string abbr)
        {
            Guid ownerId = Guid.NewGuid();
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var guid = Prtl_NewsUtility.Get_univ_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "fci")
                {
                    var guid = Prtl_NewsUtility.Get_fci_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "fee")
                {
                    var guid = Prtl_NewsUtility.Get_fee_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "eng")
                {
                    var guid = Prtl_NewsUtility.Get_eng_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "nur")
                {
                    var guid = Prtl_NewsUtility.Get_nur_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "edu")
                {
                    var guid = Prtl_NewsUtility.Get_edu_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "sci")
                {
                    var guid = Prtl_NewsUtility.Get_sci_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "edv")
                {
                    var guid = Prtl_NewsUtility.Get_edv_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "agr")
                {
                    var guid = Prtl_NewsUtility.Get_agr_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "hec")
                {
                    var guid = Prtl_NewsUtility.Get_hec_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "law")
                {
                    var guid = Prtl_NewsUtility.Get_law_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var guid = Prtl_NewsUtility.Get_fpe_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                    /////**********
                else if (abbr.ToLower() == "vmed")
                {
                    var guid = Prtl_NewsUtility.Get_VMed_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var guid = Prtl_NewsUtility.Get_Pharm_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                    //**************
                else if (abbr.ToLower() == "fa")
                {
                    var guid = Prtl_NewsUtility.Get_fas_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "art")
                {
                    var guid = Prtl_NewsUtility.Get_art_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "ho")
                {
                    var guid = Prtl_NewsUtility.Get_hos_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "med")
                {
                    var guid = Prtl_NewsUtility.Get_med_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "liv")
                {
                    var guid = Prtl_NewsUtility.Get_liv_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                else if (abbr.ToLower() == "com")
                {
                    var guid = Prtl_NewsUtility.Get_com_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                    //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var guid = Prtl_NewsUtility.Get_ecedu_NewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var guid = Prtl_NewsUtility.Get_com_NewsByID(id);
                //    if (guid != null)
                //        ownerId = (Guid)guid.Owner_ID;
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var guid = Prtl_NewsUtility.Get_com_NewsByID(id);
                //    if (guid != null)
                //        ownerId = (Guid)guid.Owner_ID;
                //}
                else
                {
                    var guid = Prtl_NewsUtility.GeNewsByID(id);
                    if (guid != null)
                        ownerId = (Guid)guid.Owner_ID;
                }
            }




            if (ownerId == new Guid("2ae9b66d-0977-4e1b-a4d5-a65d145e331d"))
            {


                return URL("~", routeData, Prtl_OwnersUtility.GetOwnerByOwnerID(ownerId).Abbr + "/NewsDetails/" + id);
            }
            else
            {
                return URL("~", routeData, "NewsDetails/" + id);
            }



          //  return URL("~", routeData, "NewsDetails/" + id);
        }

        public static string ComplainReplayItemUrl(RouteData routeData, int id)
        {
           
           

                return URL("~", routeData , "/ReplayToClient/" + id);
            



            //  return URL("~", routeData, "NewsDetails/" + id);
        } 
        public static string ComplainItemUrl(RouteData routeData, int id)
        {
           
           

                return URL("~", routeData , "/PrintComplain/" + id);
            



            //  return URL("~", routeData, "NewsDetails/" + id);
        }
        public static string ReportItemUrl(RouteData routeData, int id)
        {



            return URL("~", routeData, "/NtFinalReport/" + id);




            //  return URL("~", routeData, "NewsDetails/" + id);
        }
        public static string ComplainAnswerItemUrl(RouteData routeData, int id)
        {



            return URL("~", routeData, "/Answer/" + id);




            //  return URL("~", routeData, "NewsDetails/" + id);
        }
        public static string EventItemUrl(RouteData routeData, int id)
        {
            return URL("~", routeData, "EventDetails/" + id);
        }
        public static string StaffDetailUrl(RouteData routeData, string itemId)
        {
            return URL("~", routeData, "StaffDetails/" + itemId);
        }
       
        public static object NewsHandlerURL(Page page)
        {
            return URL("~", page, "NewsRSS");
        }

        public static string SubHomeURL(string abbr, Page page)
        {
            return URLFormat("~/" + OwnerPath(page) + "/" + abbr, "", null);
        }
        public static string PassRecoveryURL(string abbr, Page page)
        {
            return URLFormat("~/" + OwnerPath(page) + "/" + abbr, "Admin/PasswordRecovery", StaticUtilities.Currentlanguage(page));
        }
        public static string URL(string root, RouteData routeData, string item, string currentlanguage = null)
        {
            if (currentlanguage == null)
            {
                currentlanguage = StaticUtilities.Currentlanguage(routeData);
            }
            return root + "/" +
                   URLFormat(
                   OwnerPath(routeData),
                   item,
                  currentlanguage
                   );
        }

        public static string URL2(string root, RouteData routeData, string abbr, string currentlanguage = null)
        {
            if (currentlanguage == null)
            {
                currentlanguage = StaticUtilities.Currentlanguage(routeData);
            }
            return root + "/" +
                   URLFormat2(
                  abbr,
                   
                  currentlanguage
                   );
        }


        public static string URLFormat2(string ownerpath, string lang)
        {
            return (ownerpath + "/") + lang;
        }

        public static string URLFormat(string ownerpath, string itemname, string lang = "{lang}")
        {
            return (string.IsNullOrEmpty(ownerpath) ? "" : ownerpath + "/") + itemname + "/" + lang;
        }

        public static string VirtualPath(Page page)
        {
            Debug.Assert(page.Request.ApplicationPath != null, "page.Request.ApplicationPath != null");
            return page.Request.ApplicationPath.TrimEnd('/');
        }

        private static string URL(string root, Page page, string item, string currentlanguage = null)
        {
            return URL(root, page.RouteData, item, currentlanguage);
        }

        #endregion URLs

        public static void BuildRoutes<TNewsRssHandler, TEventsRssHandler>(RouteCollection routes, HttpServerUtility server)
            where TNewsRssHandler : RSSGenerator, new()
            where TEventsRssHandler : RSSGenerator, new()
        {
            foreach (var ownerPath in OwnerPaths)
            {

                #region RSSGenerators

                routes.Add(OwnerPathName(ownerPath, "NewsRSSHandler"), new Route(URLFormat(ownerPath, "NewsRSS"), new MyHandlerRouteHandler<TNewsRssHandler>()));
                routes.Add(OwnerPathName(ownerPath, "EventsRSSHandler"), new Route(URLFormat(ownerPath, "EventsRSS"), new MyHandlerRouteHandler<TEventsRssHandler>()));

                #endregion RSSGenerators
                #region Pages
                routes.MapPageRoute(OwnerPathName(ownerPath, "EventDetails"), URLFormat(ownerPath, "EventDetails/{id}"), "~/UI/EventDetails.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "NewsDetails"), URLFormat(ownerPath, "NewsDetails/{id}"), "~/UI/NewsDetails.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "StaffDetails"), URLFormat(ownerPath, "StaffDetails/{id}"), "~/UI/StaffDetails.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "PrintComplain"), URLFormat(ownerPath, "PrintComplain/{id}"), "~/UI/PrintComplain.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "FacNetReport"), URLFormat(ownerPath, "FacNetReport/{id}"), "~/UI/FacNetReport.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "Answer"), URLFormat(ownerPath, "Answer/{id}"), "~/UI/Answer.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "ReplayToClient"), URLFormat(ownerPath, "ReplayToClient/{id}"), "~/UI/ReplayToClient.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "Viewer"), URLFormat(ownerPath, "View/{ArticleAbbr}"), "~/UI/View.aspx");
                routes.MapPageRoute(OwnerPathName(ownerPath, "CourseRegister"), URLFormat(ownerPath, "CourseRegister/{id}"), "~/UI/CourseRegister.aspx");

                var differentroutes = new List<string> { "NewsDetails", "StaffDetails", "EventDetails", "PrintComplain", "Answer", "ReplayToClient", "FacNetReport", "CourseRegister" };


                var differentroutes2 = new List<string> { "HomeFestival" };
            
                
                var allpages = Directory.GetFiles(
                    server.MapPath("~/UI"), "*.aspx", SearchOption.AllDirectories);
                var pages = allpages.Where(s => !(s.Contains("browser") || differentroutes.Any(s.Contains))).Select(s => GetVirtualPath(server.MapPath("~/UI"), s));

                foreach (var listItem in pages)
                    routes.MapPageRoute(OwnerPathName(ownerPath, listItem), URLFormat(ownerPath, listItem),
                                        "~/UI/" + listItem + ".aspx", true);

                #endregion

                if (string.IsNullOrEmpty(ownerPath))
                    continue;
                routes.MapPageRoute(OwnerPathName(ownerPath, "Default"), ownerPath, "~/Default.aspx", true,
                                    null, GetConstraints(ownerPath));
            }
        }
        static string GetVirtualPath(string rootpath, string filename)
        {

            return filename.Replace(rootpath, "").Replace("\\", "/").Replace(".aspx", "").TrimStart('/');
        }
        public static string FooterURL(Page page)
        {
            return VirtualPath(page) + "/App_Themes/" + page.Theme + "/images/" + "uni_" + StaticUtilities.Currentlanguage(page) + ".png";
        }

        private static RouteValueDictionary GetConstraints(string ownerPath)
        {
            var constraints = new RouteValueDictionary();
            var keys = GetkeysfromPlaceholders(ownerPath).Split('_');
            foreach (var key in keys)
                constraints.Add(key, "^[^\\.]*$");
            return constraints;
        }

        private static string GetkeysfromPlaceholders(string ownerpath)
        {
            return ownerpath.Replace("}", "").Replace("{", "").Replace("/", "_");
        }
    }
    public static class RouteUtils
    {
        public static RouteData GetRouteDataByUrl(string url)
        {
            return RouteTable.Routes.GetRouteData(new RewritedHttpContextBase(url));
        }

        private class RewritedHttpContextBase : HttpContextBase
        {
            private readonly HttpRequestBase _mockHttpRequestBase;

            public RewritedHttpContextBase(string appRelativeUrl)
            {
                _mockHttpRequestBase = new MockHttpRequestBase(appRelativeUrl);
            }

            public override HttpRequestBase Request
            {
                get
                {
                    return _mockHttpRequestBase;
                }
            }

            private class MockHttpRequestBase : HttpRequestBase
            {
                private readonly string _appRelativeUrl;

                public MockHttpRequestBase(string appRelativeUrl)
                {
                    _appRelativeUrl = appRelativeUrl;
                }

                public override string AppRelativeCurrentExecutionFilePath
                {
                    get { return _appRelativeUrl; }
                }

                public override string PathInfo
                {
                    get { return ""; }
                }
            }
        }
    }
}