using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public  class Prtl_ResearchesUtility
    {

        public static IQueryable<Prtl_Researches_MainData> GetResearchByPaperId(int Paperid)
        {

            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = from x in dc.Prtl_Researches_MainDatas where x.PaperId == Paperid select x;

            return query;


        }

        public static int GetResearchsCount(int facid)
        {

            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = from x in dc.ResearchPlan_MainDatas where x.Faculty == facid select x;

            return query.Count();


        }

        //public static void insertResearch(string StudentName, string StudentNameEng, DateTime UniverstyDate, int Faculty, int Department, int StudyTypee,
        //   string ArabicAddress, string EngAddress, string Summary, string SummaryEng)

        public static void insertResearch(string StudentName, string StudentNameEng, int Faculty, int Department, int StudyTypee,
            string ArabicAddress, string EngAddress, string Summary, string SummaryEng)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();

            FacultyTable x = (from z in dc.FacultyTables where z.Prtl_FacId == Faculty select z).SingleOrDefault();
            Department d = (from s in dc.Departments where s.NewDepID == Department select s).SingleOrDefault();
            var obj = new ResearchPlan_MainData()
            {
             StudentName = StudentName,
                StudentNameEng = StudentNameEng,
                Faculty = x.FacultyID ,
                StudyTypee = StudyTypee,
                Department = d.DeptID ,
             //  UniverstyDate = UniverstyDate,
                ArabicAddress = ArabicAddress,
                EngAddress = EngAddress,
                Summary = Summary,
                SummaryEng = SummaryEng
            };
            dc.ResearchPlan_MainDatas.InsertOnSubmit(obj);
            dc.SubmitChanges();
             
        }

    }
}