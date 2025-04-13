using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.UI;
using System.Xml.Linq;
using Common;
using Portal_DAL;

namespace BLL
{

    public static class Prtl_OwnersUtility
    {
        private static readonly PortalDataContextDataContext datc = new PortalDataContextDataContext();

        public static bool AbbrExists(string NewAbbr)
        {
            return new PortalDataContextDataContext().prtl_Owners.Any(x => x.Abbr == NewAbbr);

        }

        //public static void insertstafffacid()
        //{
        //    var dc1 = new Mis_DAL.MisDataContext();
        //    var query1 = (from x in dc1.SA_STF_MEMBERs where x.AS_FACULTY_INFO_ID == 136 select x).ToList();
        //    foreach (var saStfMember in query1)
        //    {
        //        var dc = new PortalDataContextDataContext()
        //        var query2 = dc.prtl_Owners.SingleOrDefault(xx => xx.Initabbr.ToLower() == saStfMember.SA_STF_MEMBER_ID.ToString() && xx.Type==3);
        //        query2.StaffFac_ID = 30;
        //        dc.SubmitChanges();
        //    }
        //}

        public static void updatestaffpassword(prtl_Owner owner,string password)
        {

            var dc = new PortalDataContextDataContext();
            var q =dc.prtl_Owners.SingleOrDefault(x=>x.Owner_ID==owner.Owner_ID);
            q.Password = password;
            dc.SubmitChanges();


        }
        public static object GetOwnersFaculties(string currentLang)
        {

            var dc = new PortalDataContextDataContext();
           
                var query =
                    (from x in dc.prtl_Owners where x.Type==1
                     select new { OwnerAbbr = x.Owner_ID, Faculty_Name =
                         x.prtl_Translations.Single(xx=>xx.Translation_ID==x.Owner_ID && xx.prtl_Language.LCID==currentLang).Translation_Data });
                

                return query;
          
        }

        public static object GetFacultiesandIDs(string currentLang)
        {

            var dc = new PortalDataContextDataContext();

            var query =
                (from x in dc.prtl_Owners
                 where x.Type == 1
                 select new
                 {
                     ID = x.ID ,
                     Faculty_Name =
                         x.prtl_Translations.SingleOrDefault(xx => xx.Translation_ID == x.Owner_ID && xx.prtl_Language.LCID == currentLang).Translation_Data
                 });


            return query;

        }


        public static object GetDepartmentsandIDs(string currentLang,int facID)
        {

            var dc = new PortalDataContextDataContext();

            var query =
                (from x in dc.prtl_Owners
                 where x.Type == 2  && x.Parent_Id ==facID 
                 select new
                 {
                     ID = x.ID,
                     Department_Name =
                         x.prtl_Translations.Single(xx => xx.Translation_ID == x.Owner_ID && xx.prtl_Language.LCID == currentLang).Translation_Data
                 });


            return query;

        }
        public static int getStaffIDbyAbbr(string abbr)
        {
            return new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == abbr && x.Type ==3).ID ;
        }
        public static string getOwnerInitAbbr(string abbr)
        {
            return new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == abbr).InitAbbr;
        }
        public static List<prtl_Owner> getAllStaffMembers()
        {
            var dc = new PortalDataContextDataContext();
            var query = (from x in dc.prtl_Owners where x.Type == 3 select x).ToList();
            return query;
        }
        public static bool checkOwnerVoting(string abbr)
        {
            return new PortalDataContextDataContext().prtl_Owners.Any(x => x.CurrentVotingID == 0 && x.Abbr.ToLower() == abbr);

        }
        public static object GetAllSubOwnerNamesAndAbbrs(string currentLanguage, string abbr)
        {
            var parentID = GetOwnerByAbbr2(abbr).ID;
            string s = GetOwnerByAbbr2(abbr).InitAbbr;

            return GetSubOwnersOnParentID(currentLanguage, parentID).Select(
                       t => new { t.prtl_Owner.Abbr, t.Translation_Data });
        }
        public static string getStaffAbbrFromId(string stfid)
        {

            var dc = new PortalDataContextDataContext();
            var q = dc.prtl_Owners.SingleOrDefault(x => x.InitAbbr.ToLower() == stfid).Abbr;
            return q;


        }
        public static IEnumerable<prtl_Translation> GetAllSubOwnerNamesAndAbbrs2(string currentLanguage, string abbr)
        {
            var parent = GetOwnerByAbbr2(abbr);
            return GetSubOwnersOnParentID(currentLanguage, parent.ID, parent.Type + 1);
        }

        public static object GetAllSubOwnerNamesAndIDs(string currentLanguage, string parentOwnerID, int type = 1)
        {
            int? parentID = null;
            if (!string.IsNullOrEmpty(parentOwnerID)) parentID = GetOwnerByOwnerID(Guid.Parse(parentOwnerID)).ID;
            return GetSubOwnersOnParentID(currentLanguage, parentID, type).Select(
                       t => new { Value = t.Translation_ID, Text = t.Translation_Data });
        }
        public static prtl_Owner GetOwnerByAbbr2(string abbr)
        {
            if (abbr != null && abbr.Contains("."))
            {
                return
                    new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(
                        f => String.Equals(f.Abbr, abbr.Split('.')[1]));
            }
            else
            {
                return
                    new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(
                        f => String.Equals(f.Abbr, abbr));
            }
        }
      

        public static bool GetAdressPublished(string abbr)
        {
            return new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == abbr).Adress_Publish;
        }
        public static bool GetTelPublished(string abbr)
        {
            var dc = new PortalDataContextDataContext();
            var xx = dc.prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == abbr).Tel_Publish;

            return xx;
        }
        public static bool GetEmailPublished(string abbr)
        {
            return new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == abbr).Email_Publish;
        }
        public static prtl_Owner GetOwnerByOwnerID(Guid OwnerID, PortalDataContextDataContext context = null)
        {
            var dc = context ?? datc;
            return dc.prtl_Owners.SingleOrDefault(f => f.Owner_ID == OwnerID);
        }

        public static Guid GetOwnerIDByAbbr(string abbr)
        {
            var prtlOwner = GetOwnerByAbbr2(abbr);

            return prtlOwner != null ? prtlOwner.Owner_ID : Guid.Empty;
        }
        public static void BuildRightLeftLinksXML(Page currentPage)
        {


            var menuxml = new XDocument(new XElement("Links"));
            var root = menuxml.Element("Links");





            menuxml.Save(URLBuilder.Path(currentPage, PathType.Local, SiteFolders.RightLeftLinks));
        }
        static XElement GetMenuXElement2(string itemtype, string url, Guid? ownerid)
        {
            var element = new XElement("MenuItem");
            element.SetAttributeValue("MenuItemType", itemtype);
            element.SetAttributeValue("Url", url);
            element.SetAttributeValue("OwnerId", ownerid);
            element.ReplaceAttributes(element.Attributes().OrderBy(e => e.Name.ToString()));
            return element;
        }
        public static void AddXMLChildren2(Page page, string itemtype, string url, Guid? ownerid)
        {

            string doc = URLBuilder.fixedpath(PathType.Local, SiteFolders.RightLeftLinks);
            var doc1 = XDocument.Load(doc);
            var root = doc1.Element("Links");
            root.Add(GetMenuXElement2(itemtype, url, ownerid));
            doc1.Save(URLBuilder.Path(page, PathType.Local, SiteFolders.RightLeftLinks));
        }
        public static int GetOwnerType(string abbr)
        {
            if (GetOwnerByAbbr2(abbr) != null)
            {
                return GetOwnerByAbbr2(abbr).Type;
            }
            else
            {
                return 0;
            }
        }
        public static int GetOwnerType2(string abbr)
        {
            return GetOwnerByAbbr2(abbr).Type;
        }
        public static string GetParentOwnerID(string OwnerID)
        {
            return
                    GetOwnerByOwnerID(Guid.Parse(OwnerID)).prtl_Owner1.Owner_ID.ToString();
        }

        public static IEnumerable<prtl_Owner> GetSubOwnersByOwnerID(Guid ParentOwnerID)
        {
            var owner = new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(o => o.Owner_ID == ParentOwnerID);
            return owner == null ? null : GetSubOwnersByParentID(owner.ID);
        }



        public static bool OwnerExists(string ownerabbr)
        {
            return ownerabbr == null || new PortalDataContextDataContext().prtl_Owners.Any(o => o.Abbr == ownerabbr);
        }

        public static void UpdateOwnerWithVotingID(Guid ownerID, int votingID)
        {
            var dc = new PortalDataContextDataContext();
            {
                var owner = GetOwnerByOwnerID(ownerID, dc);
                owner.CurrentVotingID = votingID;
                dc.SubmitChanges();
            }
        }

        public static void updateStaffAbbr(string oldAbbr, string NewAbbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                var abbr = dc.prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == oldAbbr);
                if (abbr != null)
                {
                    abbr.Abbr = NewAbbr;
                    dc.SubmitChanges();
                }
            }
        }

        private static IEnumerable<prtl_Owner> GetSubOwnersByParentID(int ParentID)
        {
            return new PortalDataContextDataContext().prtl_Owners.Where(sub => sub.Parent_Id == ParentID);
        }

        private static IEnumerable<prtl_Translation> GetSubOwnersOnParentID(string currentLanguage, int? parentID, int type = 1)
        {
            var dc = new PortalDataContextDataContext();
            return dc.prtl_Owners.Where(o => Nullable.Equals(o.Parent_Id, parentID) && o.Type == type)
                 .Join(dc.prtl_Translations, o => o.Owner_ID, t => t.Translation_ID, (o, t) => t)
                 .Where(t => t.prtl_Language.LCID == currentLanguage);
        }
        public static string GetStaffAbstractFromPortal(decimal staffid)
        {
            var dc = new PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x => x.InitAbbr.ToLower() == staffid.ToString()).AbstractFile;
            return query;
        }

        public static string GetStaffCVFromPortal(decimal staffid)
        {
            var dc = new PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x =>x.Type ==3 && x.InitAbbr.ToLower() == staffid.ToString()).CVFile;
            return query;
        }

        public static prtl_Owner InsertNewStfOwner(string Abbr, decimal stfid)
        {

            var dc = new PortalDataContextDataContext();
            var obj = new prtl_Owner
            {
                Abbr = Abbr,
                InitAbbr = stfid.ToString(),
                CurrentVotingID = 0,
                Parent_Id = 32,
                Type = 3,
                Theme = "Default"
            };
            dc.prtl_Owners.InsertOnSubmit(obj);
            dc.SubmitChanges();
            return obj;

        }

        public static bool UserExists(string newUserName)
        {
            return new PortalDataContextDataContext().aspnet_Users.Any(x => x.UserName.ToLower() == newUserName.ToLower());
        }

        public static void updateStaffUserName(string oldName, string NewName)
        {
            var dc = new PortalDataContextDataContext();
            {
                var UserName = dc.aspnet_Users.SingleOrDefault(x => x.UserName == oldName);
                if (UserName != null)
                {
                    UserName.UserName = NewName;
                    UserName.LoweredUserName = NewName.ToLower();
                    dc.SubmitChanges();
                }
            }
        }


        public static decimal getFacIDByAbbr(string abbr)
        {

            var singleOrDefault = new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(xy => xy.Abbr.ToLower() == abbr);
            if (singleOrDefault != null)
            {
                string x = singleOrDefault.InitAbbr;

                int xx;
                string xxx = "";
                foreach (var VARIABLE in x)
                {
                    bool isnum = int.TryParse(VARIABLE.ToString(), out xx);

                    if (isnum)
                    {
                        xxx += VARIABLE.ToString();
                    }

                }
                return Convert.ToInt32(xxx);
            }
            return 0;
        }

        public static string getSPapersFacIDByAbbr(string abbr)
        {

            var singleOrDefault = new PortalDataContextDataContext().prtl_Owners.SingleOrDefault(xy => xy.Abbr.ToLower() == abbr);
            if (singleOrDefault != null)
            {
                string x = singleOrDefault.Owner_ID.ToString();


                return x;
            }
            return null;
        }
        public static string getFacAbbrByID(int id)
        {
            var dc = new PortalDataContextDataContext();
            if (dc.prtl_Owners.SingleOrDefault(v => v.InitAbbr.StartsWith(id.ToString()) && v.Type == 1) != null)
            {
                var x =
                    dc.prtl_Owners.SingleOrDefault(v => v.InitAbbr.StartsWith(id.ToString()) && v.Type == 1).InitAbbr;
                int xx;
                string xxx = "";
                foreach (var VARIABLE in x)
                {
                    bool isnum = int.TryParse(VARIABLE.ToString(), out xx);

                    if (!isnum)
                    {
                        xxx += VARIABLE.ToString();
                    }

                }
                return xxx;
            }
            return null;
        }

        public static bool IsOwnerMenuUpdated(Page page)
        {
            return GetOwnerByAbbr2(URLBuilder.OwnerAbbr(page.RouteData)).MenuUpdated;
        }

        public static void SetMenuUpdated(Guid? ownerId, bool b)
        {
            if (ownerId == null) return;
            var dc = new PortalDataContextDataContext();
            var owner = GetOwnerByOwnerID(ownerId.Value, dc);
            owner.MenuUpdated = b;
            dc.SubmitChanges();
        }
        public static decimal getDepIDByAbbr(string parentAbbr, string DepAbbr)
        {
            var dc = new PortalDataContextDataContext();
            var prtlOwner = dc.prtl_Owners.SingleOrDefault(x => x.Abbr.ToLower() == parentAbbr);
            int parentId = 0;
            if (prtlOwner != null)
            {
                parentId = prtlOwner.ID;
            }
            var singleOrDefault =
                dc.prtl_Owners.SingleOrDefault(xy => xy.Abbr.ToLower() == DepAbbr && xy.Parent_Id == parentId);
            if (singleOrDefault != null)
            {
                string x = singleOrDefault.InitAbbr.Substring(singleOrDefault.InitAbbr.IndexOf('_') + 1);

                return Convert.ToInt32(x);
            }
            else
            {
                return 0;
            }
        }



        //public static List<prtl_Translation> getDepsOfFac(Guid?  translationID)
        //{
        //    var dc = new PortalDataContextDataContext()
        //    prtl_Owner id = (from c in dc.prtl_Owners where c.Owner_ID == translationID select c).SingleOrDefault();

        //    List<prtl_Translation> deps =
        //        (from cc in dc.prtl_Translations
        //         where (cc.prtl_Owner.Type == 2 && cc.prtl_Owner.Parent_Id == id.ID)
        //         select cc).ToList<prtl_Translation>();


        //    return deps;
        //}




        //public static List<prtl_Translation> getFac( )
        //{
        //    var dc = new PortalDataContextDataContext()
        //   // prtl_Owner id = (from c in dc.prtl_Owners where c.abbr.ToLower() == facabrr select c).SingleOrDefault();

        //    List<prtl_Translation> deps =
        //        (from cc in dc.prtl_Translations
        //         where (cc.prtl_Owner.Type == 1)
        //         select cc).ToList<prtl_Translation>();

        //    return deps;
        //}



        public static int getIDByTranslationID(Guid? translationid)
        {
            var dc = new PortalDataContextDataContext();
            prtl_Owner id = (from c in dc.prtl_Owners where c.Owner_ID == translationid select c).SingleOrDefault();


            return id.ID;
        }
        public static Dictionary<string,int > getDepsOfFac(int facId, string lang)
        {



            var dc = new PortalDataContextDataContext();
            int xxx = (from a in dc.prtl_Languages where a.LCID == lang select a).SingleOrDefault().Lang_Id;
            List<prtl_Owner> Odeps = (from c in dc.prtl_Owners where c.Type == 2 && c.Parent_Id == facId select c).ToList<prtl_Owner>();

            Dictionary<string, int> deps = new Dictionary<string, int>();
            foreach (prtl_Owner x in Odeps)
            {
                prtl_Translation a =
                    (from cc in dc.prtl_Translations where cc.Translation_ID == x.Owner_ID && cc.Lang_Id == xxx select cc).SingleOrDefault();


                var query =
                   (from cc in dc.prtl_Translations
                    where cc.Translation_ID   == x.Owner_ID  && cc.Lang_Id == xxx
                    select new { ID = cc.prtl_Owner .ID  , name = cc.Translation_Data});
              
                deps.Add(a.Translation_Data,a.prtl_Owner .ID  );

            }

            //    return query;
            //(from cc in dc.prtl_Translations
            //  where ( cc.Translation_ID ==id.Owner_ID)
            //  select cc).ToList<prtl_Translation>();


             return deps;
        }

        public static object  getFac(string lang)
        {
            var dc = new PortalDataContextDataContext();
            // prtl_Owner id = (from c in dc.prtl_Owners where c.abbr.ToLower() == facabrr select c).SingleOrDefault();
            int xxx = (from a in dc.prtl_Languages where a.LCID == lang select a).SingleOrDefault().Lang_Id;
            //List<prtl_Translation> deps =
            //    (from cc in dc.prtl_Translations
            //     where (cc.prtl_Owner.Type == 1 && cc.Lang_Id == xxx)
            //     select cc).ToList<prtl_Translation>();

            var query =
                    (from x in dc.prtl_Translations
                     where x.prtl_Owner .Type ==1 && x.Lang_Id ==xxx
                     select new { ID = x.prtl_Owner .ID , name = x.Translation_Data  });


            return query;
        }


        public static string getAbbrByID(int id)
        {
            var dc = new PortalDataContextDataContext();
            var x = (from cc in dc.prtl_Owners where cc.ID == id select cc).SingleOrDefault();
            return x.Abbr;
        }
    }
}