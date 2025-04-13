using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Windows.Media.Animation;
using Mis_DAL;
using Portal_DAL;
namespace MnfUniversity_Portals.BLL.MIS_BLL
{
    public class ResearchUtility
    {

        public static List< SA_RESEARCH_TEAM> GetResearchByFacId(decimal? facid)
{
    var dc = Global.M_dc;
    var researches = 
            dc.SA_RESEARCH_TEAMs.Where(c => c.SA_STF_MEMBER_ID != null && c.AS_FACULTY_INFO_ID==facid).GroupBy(x=>x.SA_SC_RESEARCH_ID).Select(x=>x.First()).ToList();
    return researches;

}

        

        public static List<string> GetListofStaffMembers(string StaffText)
{

    var dc = Global.M_dc;
    var stafflist = (from x in dc.SA_STF_MEMBERs where x.STF_FULL_NAME_AR.StartsWith(StaffText) select x.STF_FULL_NAME_AR).ToList();
    return stafflist;

}

public static List<SA_RESEARCH_TEAM> GetAllResearches()
{

    var dc = Global.M_dc;
    var researches = dc.SA_RESEARCH_TEAMs.Where(c => c.SA_STF_MEMBER_ID !=null).GroupBy(x=>x.SA_SC_RESEARCH_ID).Select(x=>x.First()).ToList();
    return researches;

}
public static List<SA_RESEARCH_TEAM> GetResearchByTitle(string text)
        {
            var dc = Global.M_dc;
            var researches = dc.SA_RESEARCH_TEAMs.Where(x => x.SA_SC_RESEARCH.RESEARCH_TITLE.Contains(text) && x.SA_STF_MEMBER_ID != null).GroupBy(x => x.SA_SC_RESEARCH_ID).Select(x => x.First()).ToList();
               
            return researches;
        }
public static List<SA_RESEARCH_TEAM> GetResearchByAuthorfac(string text, decimal facid)
{
    var dc = Global.M_dc;
    var researches =
    dc.SA_RESEARCH_TEAMs.Where(x => x.SA_STF_MEMBER_ID != null && x.SA_STF_MEMBER.STF_FULL_NAME_AR.Contains(text) && x.AS_FACULTY_INFO_ID == facid).GroupBy(x => x.SA_SC_RESEARCH_ID).Select(x => x.First()).ToList();


    return researches;
}

public static List<SA_RESEARCH_TEAM> GetResearchByTitleAuthor(string text, string s)
{
    var dc = Global.M_dc;
    var researches =
    dc.SA_RESEARCH_TEAMs.Where(x => x.SA_STF_MEMBER_ID != null && x.SA_STF_MEMBER.STF_FULL_NAME_AR.Contains(s) && x.SA_SC_RESEARCH.RESEARCH_TITLE.Contains(text)).GroupBy(x => x.SA_SC_RESEARCH_ID).Select(x => x.First()).ToList();


    return researches;
}

public static List<SA_RESEARCH_TEAM> GetResearchByTitlefacAuthor(string text, decimal facid, string s)
{
    var dc = Global.M_dc;
    var researches =
    dc.SA_RESEARCH_TEAMs.Where(x => x.SA_STF_MEMBER_ID != null && x.SA_STF_MEMBER.STF_FULL_NAME_AR.Contains(s) && x.SA_SC_RESEARCH.RESEARCH_TITLE.Contains(text) && x.AS_FACULTY_INFO_ID==facid).GroupBy(x => x.SA_SC_RESEARCH_ID).Select(x => x.First()).ToList();


    return researches;
}
public static List<SA_RESEARCH_TEAM> GetResearchByTitlefac(string text, decimal facid)
        {
            var dc = Global.M_dc;
            var researches = 
            dc.SA_RESEARCH_TEAMs.Where(x => x.SA_STF_MEMBER_ID != null && x.SA_SC_RESEARCH.RESEARCH_TITLE.Contains(text) && x.AS_FACULTY_INFO_ID == facid).GroupBy(x => x.SA_SC_RESEARCH_ID).Select(x => x.First()).ToList();
    
    
    return researches;
        }

public static List<SA_RESEARCH_TEAM> GetResearchByAuthor(string text)
        {
            var dc = Global.M_dc;
            var stfid = dc.SA_STF_MEMBERs.SingleOrDefault(i => i.STF_FULL_NAME_AR == text);
            var researches = 
            
    dc.SA_RESEARCH_TEAMs.Where(x => stfid != null && x.SA_STF_MEMBER_ID != null && x.SA_STF_MEMBER_ID.ToString() == stfid.SA_STF_MEMBER_ID.ToString()).GroupBy(x => x.SA_SC_RESEARCH_ID).Select(x => x.First()).ToList();
    return researches;
            
        }
public static string GetFacName(string lang, decimal facid)
{
    var dc = Global.M_dc;
    if (lang == "ar")
    {
        var fac =
            dc.AS_FACULTY_INFOs.SingleOrDefault(x => x.AS_FACULTY_INFO_ID == facid).FACULTY_DESCR_AR;
        return fac;
    }
    else if (lang == "en")
    {
        var fac =
            dc.AS_FACULTY_INFOs.SingleOrDefault(x => x.AS_FACULTY_INFO_ID == facid)
                .FACULTY_DESCR_EN;
        return fac;
    }
    else
    {
        return " ";
    }
}

        public static object GetResearchByResId(int resID, int lang_Id)
        {
            var dc = Global.M_dc;
            var query = from x in dc.SA_SC_RESEARCHes where x.SA_SC_RESEARCH_ID == resID select x;

            return query;
        }

        public static string GetResSummery(decimal resID, string currentlanguage)
        {
            var dc = Global.M_dc;
            if (currentlanguage == "ar")
            {
                var saScResearch = ( from x in dc.SA_SC_RESEARCHes where x.SA_SC_RESEARCH_ID == resID select x).SingleOrDefault( );
                if (saScResearch != null)
                {
                string  query =
                        saScResearch.RESEARCH_SUMM_AR ;

                return query;
                }else
                {
                    return "";
                }
            }
            else
            {
                var saScResearch = (from x in dc.SA_SC_RESEARCHes where x.SA_SC_RESEARCH_ID == resID select x).SingleOrDefault();
                if (saScResearch != null)
                {
                    var query = saScResearch.RESEARCH_SUMM_EN;

                return query;
            }
                else
                {
                    return "";
                }
            }
        }
        public static  string GetResearcher(decimal  resID)
        {
            var dc = Global.M_dc;
            List<decimal  > memIDList  =
                (from x in dc.SA_RESEARCH_TEAMs where x.SA_SC_RESEARCH_ID == resID && x.SA_STF_MEMBER_ID !=null  select Convert.ToDecimal(x.SA_STF_MEMBER_ID)).ToList();
            string members = "";
            foreach (var xx in memIDList )

            {
                members +=
                    (from c in dc.SA_STF_MEMBERs where c.SA_STF_MEMBER_ID == xx select c).SingleOrDefault().STF_FULL_NAME_AR+"</br>";
            }
            return members;
        }

        
    }

}