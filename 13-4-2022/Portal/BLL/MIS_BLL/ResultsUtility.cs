using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MnfUniversity_Portals;

namespace MisBLL
{
    public  class ResultsUtility
    {


        public static Dictionary<string, decimal> GetFaculties()
        {
            var dc = Global.M_dc;
            var faculty = dc.Natega_FACULTY().ToDictionary(t=>t.FACULTY_DESCR_AR,t=>t.AS_FACULTY_INFO_ID);
            return faculty;
        }
        public static Dictionary<string, decimal> GetFaculties_2()
        {
            var dc = Global.M_dc;
            var faculty = dc.Natega_FACULTY_2().ToDictionary(t => t.FACULTY_DESCR_AR, t => t.AS_FACULTY_INFO_ID);
            return faculty;
        }
        public static Dictionary<string, decimal> GetYears(decimal facid)
        {
            var dc =  Global.M_dc;
            var year = dc.Natega_GRAD(facid).ToDictionary(t => t.GRAD_DES, t => t.GRAD_CODE);
            return year;
        }

        

        public static decimal Getis_mark_appear(decimal fac_id)
        {
            var dc = Global.M_dc;
            var faculty = dc.Natega_FACULTY().SingleOrDefault(t => t.AS_FACULTY_INFO_ID == fac_id);
            return faculty.IS_MARK_Appear;
        }
        public static decimal Getis_Mis_or_ext(decimal fac_id)
        {
            var dc = Global.M_dc;
            var faculty = dc.Natega_FACULTY().SingleOrDefault(t => t.AS_FACULTY_INFO_ID == fac_id);
            return faculty.RS_publish_MIS_OR_EXT;
        }
       
        public static object GetStd_info(decimal? seatno,string naid,decimal facid,int gradeid)
        {
            var dc = Global.M_dc;
            
            var faculty = dc.Natega_PUBLISH_STUD(seatno,naid,facid,gradeid).ToList();
            return faculty;
        }
        public static object GetResult_info(decimal? seatno, string naid, decimal facid, int gradeid)
        {
            var dc = Global.M_dc;
            var faculty = dc.Natega_PUBLISH(seatno, naid, facid, gradeid).ToList();
            return faculty;
        }
    }
}