using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public static class Prtl_GalaryUtility
    {
      

        public static int TranslationsCount(string ID)
        {
            return new PortalDataContextDataContext().Prtl_GallaryTrans.Count(x => x.Translation_ID.ToString() == ID);
        }
        public static bool GetPublishedState(string ID)
        {
            var q = new PortalDataContextDataContext().prtl_Gallaries.SingleOrDefault(x => x.ID.ToString() == ID);
            if (q.Published)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static IEnumerable<prtl_Language> LangsNotTranslated(Guid CurrentTranslationID, string TransID)
        {
            var datc = new PortalDataContextDataContext();

            return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, datc).
                Except(datc.Prtl_GallaryTrans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
        }
    }
}