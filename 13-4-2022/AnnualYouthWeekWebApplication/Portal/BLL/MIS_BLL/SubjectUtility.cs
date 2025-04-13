using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using App_Code;
using Common;
using Microsoft.Web.Administration;
using Mis_DAL;
using MnfUniversity_Portals;
using Portal_DAL;

namespace MisBLL

{
    public class SubjectUtility
    {

        public static ED_SUBJECT getsubjectbyid(decimal subid)
        {
            var dc = Global.M_dc;
            return (from x in dc.ED_SUBJECTs where x.ED_SUBJECT_ID == subid select x).SingleOrDefault();
        }
        public static Dictionary<string, decimal> GET_ScentificDeg(Decimal Fac_id)
        {
            var dc = Global.M_dc;

            List<ED_PHASE_NODE> quary =
                (from x in dc.ED_PHASE_NODEs
                 where x.NODE_PARENT_ID == x.ED_PHASE_NODE_ID && x.AS_FACULTY_INFO_ID == Fac_id
                 select x).ToList();

            List<ED_BYLAW_DEGREE> q2=new List<ED_BYLAW_DEGREE>( );
            foreach (var c in quary)
            {
                ED_BYLAW_DEGREE  x =
                    (from cc in quary
                     where cc.ED_BYLAW_DEGREE_ID == c.ED_BYLAW_DEGREE_ID
                     select cc.ED_BYLAW_DEGREE).SingleOrDefault( );

                q2.Add(x);
            }
            List<string> bylaw = new List<string>();
            foreach (var d in q2)
            {
                string s =
                    (from i in q2 where i.ED_BYLAW_DEGREE_ID == d.ED_BYLAW_DEGREE_ID select i.ED_BYLAW.BYLAW_DESCR_AR).
                        SingleOrDefault();
                bylaw.Add(s);
            }
            
            Dictionary<string, decimal> dec = new Dictionary<string, decimal>();
            for(int i=0;i<quary .Count;i++)
            {
               dec.Add(  quary[i].NODE_DESCR_AR +"-"+ bylaw[i],quary[i].ED_PHASE_NODE_ID  );

            }


            return dec;

        }

        public static string getCourseReportFileName(Page page)
        {

            string s = URLBuilder.GetURLIfExists3(page, SiteFolders.Course_Report,
                                                  null);
            if (Directory.Exists(s))
            {
                string[] ss = Directory.GetFiles(s);
                if (ss.Length != 0)
                {
                    string file = Path.GetFileName(ss[0]);


                    return file;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return "";
            }
        }

        public static SqlDataReader getSubjectsforLawEnglish()
        {
            SqlConnection con = new SqlConnection(Mis_DAL.Info.WebConfigConnectionString);
            con.Open();
            string query =
                           "SELECT ED_SUBJECT.SUBJECT_CODE,ED_SUBJECT.ED_SUBJECT_ID,ED_SUBJECT.SUBJECT_DESCR_AR, ED_SUBJECT.SUBJECT_DESCR_EN, ED_BYLAW.BYLAW_DESCR_AR, AS_NODE.NODE_DESCR_AR FROM   " +
                           "      ED_SUBJECT INNER JOIN ED_PHASE_NODE ON ED_SUBJECT.ED_PHASE_NODE_ID = ED_PHASE_NODE.ED_PHASE_NODE_ID" +
                           " INNER JOIN ED_BYLAW_DEGREE ON ED_BYLAW_DEGREE.ED_BYLAW_DEGREE_ID = ED_PHASE_NODE.ED_BYLAW_DEGREE_ID " +
                           "INNER JOIN ED_BYLAW ON ED_BYLAW.ED_BYLAW_ID = ED_BYLAW_DEGREE.ED_BYLAW_ID " +
                           "INNER JOIN AS_NODE ON ED_SUBJECT.AS_NODE_ID = AS_NODE.AS_NODE_ID WHERE AS_NODE.AS_NODE_ID=413";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();

            return da;
        }
        public static SqlDataReader getSubjectsforLawArabic()
        {
            SqlConnection con = new SqlConnection(Mis_DAL.Info.WebConfigConnectionString);
            con.Open();
            string query =
                           "SELECT ED_SUBJECT.SUBJECT_CODE,ED_SUBJECT.ED_SUBJECT_ID,ED_SUBJECT.SUBJECT_DESCR_AR, ED_SUBJECT.SUBJECT_DESCR_EN, ED_BYLAW.BYLAW_DESCR_AR, AS_NODE.NODE_DESCR_AR FROM   " +
                           "      ED_SUBJECT INNER JOIN ED_PHASE_NODE ON ED_SUBJECT.ED_PHASE_NODE_ID = ED_PHASE_NODE.ED_PHASE_NODE_ID" +
                           " INNER JOIN ED_BYLAW_DEGREE ON ED_BYLAW_DEGREE.ED_BYLAW_DEGREE_ID = ED_PHASE_NODE.ED_BYLAW_DEGREE_ID " +
                           "INNER JOIN ED_BYLAW ON ED_BYLAW.ED_BYLAW_ID = ED_BYLAW_DEGREE.ED_BYLAW_ID " +
                           "INNER JOIN AS_NODE ON ED_SUBJECT.AS_NODE_ID = AS_NODE.AS_NODE_ID WHERE AS_NODE.AS_NODE_ID=414";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();

            return da;
        }
        public static SqlDataReader getSubjectsforLawOpen()
        {
            SqlConnection con = new SqlConnection(Mis_DAL.Info.WebConfigConnectionString);
            con.Open();
            string query =
                           "SELECT ED_SUBJECT.SUBJECT_CODE,ED_SUBJECT.ED_SUBJECT_ID,ED_SUBJECT.SUBJECT_DESCR_AR, ED_SUBJECT.SUBJECT_DESCR_EN, ED_BYLAW.BYLAW_DESCR_AR, AS_NODE.NODE_DESCR_AR FROM   " +
                           "      ED_SUBJECT INNER JOIN ED_PHASE_NODE ON ED_SUBJECT.ED_PHASE_NODE_ID = ED_PHASE_NODE.ED_PHASE_NODE_ID" +
                           " INNER JOIN ED_BYLAW_DEGREE ON ED_BYLAW_DEGREE.ED_BYLAW_DEGREE_ID = ED_PHASE_NODE.ED_BYLAW_DEGREE_ID " +
                           "INNER JOIN ED_BYLAW ON ED_BYLAW.ED_BYLAW_ID = ED_BYLAW_DEGREE.ED_BYLAW_ID " +
                           "INNER JOIN AS_NODE ON ED_SUBJECT.AS_NODE_ID = AS_NODE.AS_NODE_ID WHERE AS_NODE.AS_NODE_ID=393";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();

            return da;
        }
        public static string getCourseSpecsFileName(Page page)
        {

            string s = URLBuilder.GetURLIfExists3(page, SiteFolders.Course_Specs,
                                                  null);
            if (Directory.Exists(s))
            {
                string[] ss = Directory.GetFiles(s);
                if (ss.Length != 0)
                {
                    string file = Path.GetFileName(ss[0]);


                    return file;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return "";
            }
        }
        public static void InsertSubjectMenu(Page page)
        {

            var dc = new PortalDataContextDataContext();
            var q1=(from x in dc.prtl_Owners where x.Type==5 && x.Parent_Id==41  select x).ToList();
            foreach (var prtlOwner in q1)
            {

                prtl_Menu menu = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 2,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu);
                dc.SubmitChanges();

                prtl_Translation menutranslation = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu.Translation_ID,
                    Translation_Data = "توصيف المقرر"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslation);
                dc.SubmitChanges();
                prtl_Translation menutranslation2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu.Translation_ID,
                    Translation_Data = "Course Specification"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslation2);
                dc.SubmitChanges();

                prtl_Menu menu2 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 3,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu2);
                dc.SubmitChanges();

                prtl_Translation menutranslationn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu2.Translation_ID,
                    Translation_Data = "تقرير المقرر"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationn);
                dc.SubmitChanges();
                prtl_Translation menutranslationn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu2.Translation_ID,
                    Translation_Data = "Course Report"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationn2);
                dc.SubmitChanges();

                prtl_Menu menu3 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 4,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu3);
                dc.SubmitChanges();

                prtl_Translation menutranslationnn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu3.Translation_ID,
                    Translation_Data = "امتحانات سابقة"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnn);
                dc.SubmitChanges();
                prtl_Translation menutranslationnn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu3.Translation_ID,
                    Translation_Data = "Previous Exams"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnn2);
                dc.SubmitChanges();

                prtl_Menu menu4 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 5,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu4);
                dc.SubmitChanges();

                prtl_Translation menutranslationnnn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu4.Translation_ID,
                    Translation_Data = "محاضرات"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnn);
                dc.SubmitChanges();
                prtl_Translation menutranslationnnn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu4.Translation_ID,
                    Translation_Data = "Lectures"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnn2);
                dc.SubmitChanges();

                prtl_Menu menu5 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 6,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu5);
                dc.SubmitChanges();

                prtl_Translation menutranslationnnnn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu5.Translation_ID,
                    Translation_Data = "تمارين"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnnn);
                dc.SubmitChanges();
                prtl_Translation menutranslationnnnn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu5.Translation_ID,
                    Translation_Data = "Exercises"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnnn2);
                dc.SubmitChanges();
            }
        }

        public static string GetSubjectYear(decimal SubjectID)
        {
            var dc = Global.M_dc;
            var query = (from x in dc.ED_SUBJECTs where x.ED_SUBJECT_ID == SubjectID select x).SingleOrDefault();
            var query2 =
                (from y in dc.ED_PHASE_NODEs where y.ED_PHASE_NODE_ID == query.ED_PHASE_NODE_ID select y).
                    SingleOrDefault();

            var query3 =
               (from y in dc.ED_PHASE_NODEs where y.ED_PHASE_NODE_ID == query2.NODE_PARENT_ID select y).
                   SingleOrDefault();
            return query3.NODE_DESCR_AR + "\\" + query2.NODE_DESCR_AR;
        }
        public static List<ED_PHASE_NODE>  GET_Year(Decimal DegID)
        {
            var dc = Global.M_dc;

            List<ED_PHASE_NODE> quary =
                (from x in dc.ED_PHASE_NODEs
                 where x.NODE_PARENT_ID ==DegID && x.NODE_PARENT_ID !=x.ED_PHASE_NODE_ID 
                 select x).ToList();


            return quary;

        }
        public static List<AS_NODE> GET_Dept(Decimal Fac_ID)
        {
            var dc = Global.M_dc;
            
           
         var X=   (from x in dc.AS_FACULTY_INFOs where x.AS_FACULTY_INFO_ID == Fac_ID select x ).SingleOrDefault() ;
            var n =
                (from c in dc.AS_NODEs where c.NODE_PARENT_ID == X.AS_NODE_ID && c.IS_NODE_VISIBLE == 1 select c).
                    ToList();
            var deps=(from s in n where s.AS_CODE_NODE_NATURE_ID == 8 select s).ToList();
            return deps;

        }
        public static List<ED_SUBJECT> GetSubjectsByDepID(decimal DepId, decimal facid)
        {
            var dc = Global.M_dc;
           
            var depsubjects =
                (from c in dc.ED_SUBJECTs
                 where c.AS_NODE_ID == DepId select c ).
                    ToList();
            var q1 = (from s in dc.ED_SUBJECTs where s.AS_FACULTY_INFO_ID == facid && s.IS_ACTIVE==1 select s);
            foreach (var edSubject in q1)
            {
                var q2 = (from x in dc.AS_NODEs where x.AS_NODE_ID == edSubject.AS_NODE_ID select x).SingleOrDefault();
                if(q2.NODE_PARENT_ID==292)
                {

                    depsubjects.Add(edSubject);
                }
            }
           
            return depsubjects;

            
        }
        public static List<ED_SUBJECT> GetSubjectsByFacID(decimal FacId)
        {
            var dc = Global.M_dc;

            var n =
                (from c in dc.ED_SUBJECTs
                 where c.AS_FACULTY_INFO_ID == FacId && c.IS_ACTIVE==1
                 select c).
                    ToList();
            return n;


        } 
        //public static string GetSubjectYear(decimal SubjectID)
        //{
        //    var dc = Global.M_dc;
        //    var query = (from x in dc.ED_SUBJECTs where x.ED_SUBJECT_ID == SubjectID select x).SingleOrDefault();
        //    var query2 =
        //        (from y in dc.ED_PHASE_NODEs where y.ED_PHASE_NODE_ID == query.ED_PHASE_NODE_ID select y).
        //            SingleOrDefault();

        //    var query3 =
        //       (from y in dc.ED_PHASE_NODEs where y.ED_PHASE_NODE_ID == query2.NODE_PARENT_ID select y).
        //           SingleOrDefault();
        //    return query3.NODE_DESCR_AR + "\\" + query2.NODE_DESCR_AR;
        //}
        public static List<ED_PHASE_NODE> GET_Sem(Decimal Dep_ID)
        {
            var dc = Global.M_dc;


            
            var n =
                (from c in dc.ED_PHASE_NODEs where c.NODE_PARENT_ID == Dep_ID && c.NODE_PARENT_ID != c.ED_PHASE_NODE_ID &&
                     c.ED_CODE_PHASE_NODE_NATURE_ID == 5 && c.IS_NODE_VISIBLE == 1 select c).
                    ToList();
            return n;

        }

        public static List<SubjectsResult> getSubjects(Decimal facID, Decimal SemId, Decimal? DepId = null, Decimal? IsMandatory = null)
        {
            var dc = Global.M_dc;
            List<SubjectsResult> xx = new List<SubjectsResult>();
            var x=(dc.Subjects(facID, SemId, DepId, IsMandatory));
            foreach (var subjectsResult in x)
            {
               xx.Add(subjectsResult);
            }
            return xx;
        }

         public static void CreateSubjectsOwners()
{
    var dc = Global.M_dc;
             List<ED_SUBJECT> AllActiveSubjects = (from x in dc.ED_SUBJECTs where x.IS_ACTIVE == 1 select x).ToList();
    var dc2 = new PortalDataContextDataContext();
             foreach (var allActiveSubject in AllActiveSubjects)
             {
                 if(!dc2.prtl_Owners.Any(x=>x.Abbr=="SUB_"+allActiveSubject.ED_SUBJECT_ID))
                 {
                     int search = 0;

                     var singleOrDefault =
                         dc.ED_SUBJECTs.SingleOrDefault(xx => xx.ED_SUBJECT_ID == allActiveSubject.ED_SUBJECT_ID);
                     if (singleOrDefault != null)
                     {
                         var x =
                             singleOrDefault.
                                 AS_FACULTY_INFO_ID;
                         if (dc2.prtl_Owners.SingleOrDefault(v => v.InitAbbr.StartsWith(x.ToString()) && v.Type == 1) !=
                             null)
                         {
                             var facid =
                                 dc2.prtl_Owners.SingleOrDefault(v => v.InitAbbr.StartsWith(x.ToString()) && v.Type == 1)
                                     .InitAbbr;
                             var prtlOwner = dc2.prtl_Owners.SingleOrDefault(xy => xy.InitAbbr == facid);
                             if (prtlOwner != null)
                                 search = prtlOwner.ID;

                             prtl_Owner owner = new prtl_Owner()
                                                    {
                                                        Abbr = "SUB_" + allActiveSubject.ED_SUBJECT_ID,
                                                        Theme = "Default",
                                                        CurrentVotingID = 0,
                                                        InitAbbr = "SUB_" + allActiveSubject.ED_SUBJECT_ID,
                                                        Type = 5,
                                                        Parent_Id = search

                                                    };
                             dc2.prtl_Owners.InsertOnSubmit(owner);
                             dc2.SubmitChanges();

                         }
                     }
                 }
             }
}

        public static void TranslateSubjectOwners()
        {
            var dc2 = new PortalDataContextDataContext();
            var dc = Global.M_dc;
            var SUBJECTOWNERs = (from x in dc2.prtl_Owners where x.Type == 5 select x).ToList();
            foreach (var subjectowneR in SUBJECTOWNERs)
            {
                if (!dc2.prtl_Owners.Any(x => x.Abbr == subjectowneR.Abbr))
                {
                    prtl_Translation t = new prtl_Translation()
                                             {
                                                 Lang_Id = 1,
                                                 Translation_Data =
                                                     dc.ED_SUBJECTs.SingleOrDefault(
                                                         x =>
                                                         x.ED_SUBJECT_ID.ToString() ==
                                                         subjectowneR.InitAbbr.Substring(4)).SUBJECT_DESCR_AR,
                                                 Translation_ID = subjectowneR.Owner_ID



                                             };
                    dc2.prtl_Translations.InsertOnSubmit(t);
                    dc2.SubmitChanges();
                }
            }

        }

        public static ED_SUBJECT getSubject(Decimal ID)
        {
            var dc = Global.M_dc;
             
            var x = (from c in dc.ED_SUBJECTs where c.ED_SUBJECT_ID==ID  select c).SingleOrDefault();
             
            return x;
        }
    }

   
}
 