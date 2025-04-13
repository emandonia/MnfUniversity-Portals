using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using AjaxControlToolkit;
using App_Code;


using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Web.Security;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class gradeUtility
    {
        public static void insertGrade(string sa,string se,string tel,string mobile,string grade,
            string mail,string currentjob, string course,string add,string year,string workplace,string skills,
            int uni,int faciD,int depID)
        {
            var dc = new PortalDataContextDataContext();;

            prtl_Student s = new prtl_Student();
            s.StuNameA =sa;
            s.StuNameE = se;
            s.Tel = tel;
            s.mobile = mobile ;
            s.Grade = grade ;
            s.Email = mail ;
            s.currentJob = currentjob ;
            s.course = course ;
            s.Adress = add;
            s.Year =year ;
            s.WorkPlace =workplace ;
            s.Skills = skills ;
            s.University = uni ;
            s.FacID = faciD ;
            s.DepID =depID ;
            dc.prtl_Students.InsertOnSubmit(s);
            dc.SubmitChanges();
        }


        public static void updateGrade(int id,string sa, string se, string tel, string mobile, string grade,
          string mail, string currentjob, string course, string add, string year, string workplace, string skills,
          int uni, int? faciD =null, int? depID=null)
        {
            var dc = new PortalDataContextDataContext();

            prtl_Student s = (from c in dc.prtl_Students where c.Id == id select c).SingleOrDefault();
           
            s.StuNameA = sa;
            s.StuNameE = se;
            s.Tel = tel;
            s.mobile = mobile;
            s.Grade = grade;
            s.Email = mail;
            s.currentJob = currentjob;
            s.course = course;
            s.Adress = add;
            s.Year = year;
            s.WorkPlace = workplace;
            s.Skills = skills;
            s.University = uni;
            s.FacID = faciD;
            s.DepID = depID;

            dc.SubmitChanges();
        }



        public static string gettrans(int ID,string lang)
        { var dc = new PortalDataContextDataContext();
        prtl_Owner x = (from c in dc.prtl_Owners where c.ID == ID select c).SingleOrDefault();
        
            prtl_Translation d = (from cc in dc.prtl_Translations where cc.Translation_ID == x.Owner_ID && cc.prtl_Language.LCID == lang select cc).SingleOrDefault();
            return d.Translation_Data;
        
        }


        public static List <prtl_Student > getsBfdn(int fac,int dep,string name)
        {

            var dc = new PortalDataContextDataContext();
            List<prtl_Student> x = new List<prtl_Student>();
            x = (from c in dc.prtl_Students where c.FacID == fac && c.DepID == dep && c.StuNameA.Contains(name) select c).ToList();
            return x;

        }

        public static List<prtl_Student> getsBu( )
        {

            var dc = new PortalDataContextDataContext();
            List<prtl_Student> x = new List<prtl_Student>();
            x = (from c in dc.prtl_Students   select c).ToList();
            return x;

        }


        public static  prtl_Student getsBID(int ID )
        {

            var dc = new PortalDataContextDataContext();
          //  List<prtl_Student> x = new List<prtl_Student>();
            prtl_Student x = (from c in dc.prtl_Students where c.Id  == ID    select c).SingleOrDefault ();
            return x;

        }

        public static List<prtl_Student> getsBfn(int fac,  string name)
        {

            var dc = new PortalDataContextDataContext();
            List<prtl_Student> x = new List<prtl_Student>();
            x = (from c in dc.prtl_Students where c.FacID == fac  && c.StuNameA.Contains(name) select c).ToList();
            return x;

        }
      public static List<prtl_Student> getsBn(   string name)
        {

            var dc = new PortalDataContextDataContext();
            List<prtl_Student> x = new List<prtl_Student>();
            x = (from c in dc.prtl_Students where  c.StuNameA.Contains(name) select c).ToList();
            return x;

        }
      public static List<prtl_Student> getsBf(int fac)
      {

          var dc = new PortalDataContextDataContext();
          List<prtl_Student> x = new List<prtl_Student>();
          x = (from c in dc.prtl_Students where c.FacID ==fac  select c).ToList();
          return x;

      }
      public static List<prtl_Student> getsBfd(int fac,int dep)
      {

          var dc = new PortalDataContextDataContext();
          List<prtl_Student> x = new List<prtl_Student>();
          x = (from c in dc.prtl_Students where c.FacID == fac && c.DepID==dep  select c).ToList();
          return x;

      }
    }
}