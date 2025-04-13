using System;
using System.Collections.Generic;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_VotingTransUtility
    {
        public static int Count(string VotingID)
        {
            return new PortalDataContextDataContext().prtl_VotingTranslations.Count(r => r.VotingID.ToString() == VotingID);
        }

        public static IEnumerable<prtl_Language> GetTranslatedLanguages(string VotingID, PortalDataContextDataContext dataContext)
        {
            return dataContext.prtl_VotingTranslations.Where(r => r.VotingID.ToString() == VotingID).Select(v => v.prtl_Language);
        }

        public static prtl_VotingTranslation GetVotTranByVIDAndLCID(int VoteID, String Lcid)
        {
            return new PortalDataContextDataContext().prtl_VotingTranslations.SingleOrDefault(x => x.VotingID == VoteID && x.prtl_Language.LCID == Lcid);
        }

        public static IEnumerable<prtl_Language> LangsNotTranslated(Guid CurrentTranslationID, string TransID)
        {
            var dc = new PortalDataContextDataContext();
            return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(GetTranslatedLanguages(TransID, dc)).ToList();
        }
    }
}