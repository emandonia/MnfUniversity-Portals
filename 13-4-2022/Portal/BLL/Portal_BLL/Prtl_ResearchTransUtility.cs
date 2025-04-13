using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BLL;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class Prtl_ResearchTransUtility
    {
        public static Prtl_ResearchTranslation GetResearchTranslation(string currentlanguage, object Res_Id)
        {
            return new PortalDataContextDataContext().Prtl_ResearchTranslations.SingleOrDefault(a => a.prtl_Language.LCID == currentlanguage && a.ResID.ToString() == Res_Id.ToString());

        }

        public static IEnumerable<prtl_Language> LangsNotTranslated(Guid CurrentTranslationID, string ResID)
        {
            var dc = new PortalDataContextDataContext();
            return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.Prtl_ResearchTranslations.Where(tr => tr.ResID.ToString() == ResID).Select(tr => tr.prtl_Language)).ToList();
        }

        public static int GetCountTranslations(string id)
        {
            return new PortalDataContextDataContext().Prtl_ResearchTranslations.Count(tr => tr.ResID.ToString() == id.ToString());
        }
       

        public static object getstaffbyfacid(Guid facownerid,Page page)
        {
            var dc = new PortalDataContextDataContext();
            var query1 = dc.prtl_Owners.SingleOrDefault(x => x.Owner_ID == facownerid).ID;
            var query2 = (from c in dc.prtl_Owners
                          where c.StaffFac_ID == query1 && c.Type == 3
                          select new {Name = getstaffnames(c.Owner_ID, page), OWNERID = c.Owner_ID});
            return query2;

        }

        private static string getstaffnames(Guid owner_Id, Page page)
        {
            var dc = new PortalDataContextDataContext();
            var r = dc.prtl_Translations.SingleOrDefault(x => x.Translation_ID == owner_Id && x.Lang_Id == Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(page)).Lang_Id);
            if (r != null)
            {
                var query =
                    r.Translation_Data;
                return query;
            }else
            {
                return "not translated";
            }
        }
        public static string getstaffnameByResID(int resid,Page page)
        {
            var dc = new PortalDataContextDataContext();
            var r = dc.prtl_Translations.SingleOrDefault(x => x.Translation_ID == dc.Prtl_Researches.SingleOrDefault(xx=>xx.ID==resid).SatffOwner_ID && x.Lang_Id == Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(page)).Lang_Id);
            if (r != null)
            {
                var query =
                    r.Translation_Data;
                return query;
            }
            else
            {
                return "not translated";
            }
        }
        public static void UpdateResearcherName(int filterValue, int langid, string staffname)
        {
            var dc = new PortalDataContextDataContext();
            var newResTranslation =
                dc.Prtl_ResearchTranslations.SingleOrDefault(
                    x =>
                    x.ResID == filterValue &&
                    x.LangID == langid);
            newResTranslation.MainResearcherName = staffname;                      
                                           

                                      

            
            dc.SubmitChanges();
        }
    }
    
}