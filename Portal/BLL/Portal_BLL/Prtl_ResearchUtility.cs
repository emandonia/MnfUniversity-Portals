using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class Prtl_ResearchUtility
    {
        public static Prtl_Research GetResearchByID(int ID)
        {
            return new PortalDataContextDataContext().Prtl_Researches.SingleOrDefault(x => x.ID == ID);
        }

        public static bool GetPublishedState(string ID)
        {
            var q = new PortalDataContextDataContext().Prtl_Researches.SingleOrDefault(x => x.ID.ToString() == ID);
            if (q.Published)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int InsertNewResearch(DetailsViewInsertEventArgs e, Guid ownerid,string staffownerid,DateTime resdate, string filteredproperty, bool published)
        {

            var dc = new PortalDataContextDataContext();
            var newResearch = new Prtl_Research() { FacOwner_ID = ownerid };
            dc.Prtl_Researches.InsertOnSubmit(newResearch);
            dc.SubmitChanges();
            e.Values[filteredproperty] = newResearch.ID;
            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            newResearch.SatffOwner_ID = new Guid(staffownerid);
            // ReSharper restore SpecifyACultureInStringConversionExplicitly
            newResearch.ResDate = resdate;
            newResearch.Published = published;
            dc.SubmitChanges();
            return newResearch.ID;
        }

        public static void UpdateResearch(int resid,DateTime resdate, bool @checked,string staffname,Guid staffownerid,Page page)
        {
            var dc = new PortalDataContextDataContext();
           
                var res = dc.Prtl_Researches.Single(a => a.ID == resid);
                res.Published = @checked;
                res.SatffOwner_ID= staffownerid;
                res.ResDate = resdate;
                dc.SubmitChanges();

            var res_tran =
                dc.Prtl_ResearchTranslations.SingleOrDefault(
                    x =>
                    x.ResID == resid &&
                    x.LangID == Prtl_LanguagesUtility.getLangByLCID(StaticUtilities.Currentlanguage(page)).Lang_Id);
            res_tran.MainResearcherName = staffname;
            dc.SubmitChanges();
        }

       
    }
}