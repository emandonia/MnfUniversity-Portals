using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class Prtl_SCPapersUtility
    {

        public static IQueryable<Prtl_Thesis_Translation> GetSCPaperByPaperId(int Paperid,int lang)
        {

            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = from x in dc.Prtl_Thesis_Translations where x.Prtl_Thesi.ID == Paperid && x.Lang_Id==lang select x;

            return query;


        }

        //public static string GetStudyType(string id)
        //{
        //    var dc = new PortalDataContextDataContext()
        //    var query = dc.Prtl_Thesis.SingleOrDefault(x => x.ID.ToString() == id).Studytype.StudyType1;
            
        //    return query;
        //}
        public static string GetFacName(string ownerid,string currentlang)
        {
            var dc = new PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x => x.Owner_ID.ToString() == ownerid);
            var query2 =
                dc.prtl_Translations.SingleOrDefault(xx => xx.Translation_ID == query.Owner_ID
                    && xx.Lang_Id==dc.prtl_Languages.SingleOrDefault(xxx=>xxx.LCID==currentlang).Lang_Id).Translation_Data;
                 
            return query2;

        }
        public static IQueryable<Prtl_Thesis_Translation> GetSCPaperByPaperId2(int Paperid)
        {

            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = from x in dc.Prtl_Thesis_Translations where x.Prtl_Thesi.ID == Paperid select x;

            return query;


        }
        public static string GetSupervisors1(string paperid)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = from x in dc.Prtl_ThesisMapSupers where x.Prtl_Thesi.ID.ToString() == paperid select x;
            string result="";
            foreach (var paperSuper in query)
            {
                result += paperSuper.Prtl_ThesisSuper.SuperName  + "<br/>";
            }
            return result;
        }
        public static string GetSupervisors2(string paperid)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = from x in dc.Prtl_ThesisMapSupervisors where x.Prtl_Thesi.ID.ToString() == paperid select x;
            string result = "";
            foreach (var paperSuper in query)
            {
                result += paperSuper.Prtl_ThesisSUPERVISOR.SuperName + "<br/>";
            }
            return result;
        }
        public static int GetPapersCountByFacorDegOrSearchType(Guid? facid = null,bool? degree = null, bool? SearchType = null,int? langid=null)
        { 
            var dc = new Portal_DAL.PortalDataContextDataContext();
            IQueryable<object> query = null;
            // By Faculty ONLY
            if(facid !=null && degree==null && SearchType==null)
            {

                query = from x in dc.Prtl_Thesis_Translations where x.Prtl_Thesi.Owner_ID == facid && x.Lang_Id == langid select x;
            }else if (degree != null && facid==null && SearchType==null)
            {
                query = from x in dc.Prtl_Thesis_Translations where x.Prtl_Thesi.StudyTypee == degree && x.Lang_Id == langid select x;
            }
            // By Search Type ONLY
            else if (SearchType != null && facid==null && degree ==null)
            {

                query = from x in dc.Prtl_Thesis_Translations where x.Prtl_Thesi.ResearchType == SearchType && x.Lang_Id == langid select x;
               
               
            }

                // By fac & degree
            else if (facid != null && degree != null && SearchType==null)
            {

                query = from x in dc.Prtl_Thesis_Translations
                        where x.Prtl_Thesi.Owner_ID == facid && x.Prtl_Thesi.StudyTypee == degree && x.Lang_Id == langid
                            select x;
            }
                // By fac & search Type
            else if (facid != null && degree == null && SearchType != null)
            {

                query = from x in dc.Prtl_Thesis_Translations where x.Prtl_Thesi.Owner_ID == facid && x.Prtl_Thesi.ResearchType == SearchType && x.Lang_Id == langid select x;
               
               
            }
                // By search Type
            else if (facid == null && degree != null && SearchType != null)
            {


                query = from x in dc.Prtl_Thesis_Translations where x.Prtl_Thesi.ResearchType == SearchType && x.Prtl_Thesi.StudyTypee == degree && x.Lang_Id == langid select x;
                
            }

                // By fac & degree & search Type
            else if (facid != null && degree != null && SearchType != null)
            {
               
                
                    query = from x in dc.Prtl_Thesis_Translations where
                                x.Prtl_Thesi.StudyTypee == degree && x.Prtl_Thesi.Owner_ID == facid && x.Prtl_Thesi.ResearchType == SearchType && x.Lang_Id == langid
                            select x;
               
            }
            return query.Count();

        }
    }
}