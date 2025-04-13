using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using BLL;
using Mis_DAL;
using MnfUniversity_Portals;
using Portal_DAL;

namespace MisBLL
{
    public class Staff_Utility
    {
        public static List<string> getAllFacDepResFields(int facid, int depid)
        {
            var dc = new PortalDataContextDataContext();
            var q = (from x in dc.prtl_Res_Fields where x.Fac_ID == facid && x.Dep_ID==depid select x.Res_Fields).ToList();
            return q;
        }

        public static List<string> getAllFacResFields(int facid)
        {
            var dc = new PortalDataContextDataContext();
            var q = (from x in dc.prtl_Res_Fields where x.Fac_ID==facid select x.Res_Fields).ToList();
            return q;
        }

        public static List<string> getAllResFields()
        {
            var dc = new PortalDataContextDataContext();
            var q = (from x in dc.prtl_Res_Fields select x.Res_Fields).ToList();
            return q;
        }
        public static string getResFieldsByStfAbbr(string abbr)
        {

            var dc = new PortalDataContextDataContext();
            var q = dc.prtl_Owners.SingleOrDefault(x => x.Abbr == abbr).InitAbbr;
            if(dc.prtl_Res_Fields.SingleOrDefault(xx => xx.Stf_ID.ToString() == q) !=null){
                var qq = dc.prtl_Res_Fields.SingleOrDefault(xx => xx.Stf_ID.ToString() == q).Res_Fields;
                return qq;
            }
            else
            {
                return "لا يوجد مجالات بحثية حتي الان";
            }
            
            




        }

        public static string getResFieldsByStfID(string memberid)
        {

            var dc = new PortalDataContextDataContext();
           // var q = dc.prtl_Owners.SingleOrDefault(x => x.Abbr == abbr).InitAbbr;
            if (dc.prtl_Res_Fields.SingleOrDefault(xx => xx.Stf_ID.ToString() == memberid) != null)
            {
                var qq = dc.prtl_Res_Fields.SingleOrDefault(xx => xx.Stf_ID.ToString() == memberid).Res_Fields;
                return qq;
            }
            else
            {
                return "لا يوجد مجالات بحثية حتي الان";
            }






        }

        public static string getMemberPassword(string abbr)
        {

            var dc = new PortalDataContextDataContext();
            var x1 = (from x in dc.prtl_Owners where x.Abbr == abbr select x).SingleOrDefault();
            var xx = x1.Password;  
          
            // var query = dc.prtl_Owners.SingleOrDefault(x=>x.Abbr==abbr).Password;
            if (xx != null)
            { return xx.ToString(); }
            else
            {
                x1.Password = "12345";
                dc.SubmitChanges ();
                return x1.Password; }
           


        }  
            public static SA_STF_MEMBER getMemberByID(decimal staffid)
        {
            return Global.M_dc.SA_STF_MEMBERs.SingleOrDefault(x => x.SA_STF_MEMBER_ID == staffid);
        }
        public static string GET_SEC_TYPE(object id)
        {
            var dc = Global.M_dc;
            var q = dc.SA_SECONDMENTs.SingleOrDefault(x => x.SA_STF_MEMBER_ID.ToString() == id.ToString());
            if (q != null)
            {
                decimal typee = q.SA_CODE_SECONDMENT_TYPE;
                return typee == 1 ? "إعارة داخلية" : "إعارة خارجية";
            }
            return "لا يوجد";
        }

        public static void getStfEmail(string nationalNumber,out string email,out string password)
        {
            var dc = Global.M_dc;
             Mis_DAL.SA_STF_MEMBER staffmember = Staff_Utility.getStfByNationalId(nationalNumber);
            var query=(from x in dc.GS_CONTACT_METHOD_Ds where x.GS_CONTACT_METHOD_H_ID== staffmember.GS_CONTACT_METHOD_H_ID && staffmember.STF_NATIONAL_ID_NUM==nationalNumber
                      && x.METHOD_DESCR.EndsWith("menofia.edu.eg") select x).SingleOrDefault();
            email = query.METHOD_DESCR;
            password = staffmember.EMAIL_PASSWORD;
            

        }

        public static object GetDepartments(decimal facid, string currentLang)
        {
           
            MisDataContext dc = Global.M_dc;
          
            if (currentLang == "ar")
            {
                var nodeid = dc.AS_FACULTY_INFOs.Single(x => x.AS_FACULTY_INFO_ID == facid);

               
                var id = nodeid.AS_NODE_ID;

                var nodes = (from s in dc.AS_NODEs
                             where s.NODE_PARENT_ID == id && s.IS_NODE_VISIBLE == 1
                             select s);
                var type8 = (from ss in nodes where ss.AS_CODE_NODE_NATURE_ID == 8 select ss);
                
                  var deps=(from sx in type8 select new { ID = sx.AS_NODE_ID, DepName = sx.NODE_DESCR_AR, Depname2 = sx.NODE_DESCR_AR });

                  var q2 = deps.Except(from c in deps where (c.DepName == null) select c).ToArray();

                return q2;

               
            }
            else
            {
                var nodeid = dc.AS_FACULTY_INFOs.Single(x => x.AS_FACULTY_INFO_ID == facid);

               
                var id = nodeid.AS_NODE_ID;

                var nodes = (from s in dc.AS_NODEs
                             where s.NODE_PARENT_ID == id && s.IS_NODE_VISIBLE == 1
                             select s);
                var type8 = (from ss in nodes where ss.AS_CODE_NODE_NATURE_ID == 8 select ss);

                var deps = (from sx in type8 select new { ID = sx.AS_NODE_ID, DepName = sx.NODE_DESCR_EN, Depname2 = sx.NODE_DESCR_EN });

                var q2 = deps.Except(from c in deps where (c.DepName == null) select c).ToArray();

                return q2;
            }
        }

        public static object GetFaculties(string currentLang)
        {
            MisDataContext dc = Global.M_dc;

            if (currentLang == "ar")
            {
                var query =
                    (from x in dc.AS_FACULTY_INFOs
                     select new { ID = x.AS_FACULTY_INFO_ID, Faculty_Name = x.FACULTY_DESCR_AR });
                var q2 = query.Except(from c in query where c.Faculty_Name == null select c).ToArray();

                return q2;
            }
            else
            {
                var query =
                    (from x in dc.AS_FACULTY_INFOs
                     select new { ID = x.AS_FACULTY_INFO_ID, Faculty_Name = x.FACULTY_DESCR_EN });
                var q2 = query.Except(from c in query where c.Faculty_Name == null select c).ToArray();

                return q2;
            }
        }

        public static string getMemberAbbr(decimal id,Page page)
        {
            PortalDataContextDataContext d1 = new PortalDataContextDataContext();

            var s2 = d1.prtl_Owners.SingleOrDefault(xx => xx.InitAbbr == id.ToString() && xx.Type==3);
            if(s2 !=null)
            {
                return s2.Abbr;
            }
            else
            {
               return StaffUsers_Utility.InsertNewStaffMember(id,page);
            }

           
        }
        public static bool checkMemberinResFields(decimal stfid)
        {

            PortalDataContextDataContext d1 = new PortalDataContextDataContext();
            return d1.prtl_Res_Fields.Any(x => x.Stf_ID == stfid);


        }
        public static prtl_Res_Field getMemberinResFields(decimal stfid)
        {

            PortalDataContextDataContext d1 = new PortalDataContextDataContext();
            return d1.prtl_Res_Fields.SingleOrDefault(x => x.Stf_ID == stfid);


        }
        public static bool Insert_Stf_Research_Fields(decimal Stf_Id, string ResearchFields,string InsertedBy,string facid,string depid)
        {

            PortalDataContextDataContext d1 = new PortalDataContextDataContext();
            try
            {
                prtl_Res_Field Res_Field = new prtl_Res_Field()
                {
                    Stf_ID = Stf_Id,
                    Res_Fields = ResearchFields,
                    Insert_By = InsertedBy,
                    Fac_ID = Convert.ToInt32(facid),
                    Dep_ID = Convert.ToInt32(depid)
                };
                d1.prtl_Res_Fields.InsertOnSubmit(Res_Field);
                d1.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool update_Stf_Research_Fields(decimal Stf_Id, string ResearchFields, string InsertedBy)
        {

            PortalDataContextDataContext d1 = new PortalDataContextDataContext();
            MisDataContext dc = Global.M_dc;
            if (d1.prtl_Res_Fields.SingleOrDefault(x => x.Stf_ID == Stf_Id) != null)
            {
                var q = d1.prtl_Res_Fields.SingleOrDefault(x => x.Stf_ID == Stf_Id);
                q.Res_Fields = ResearchFields;
                q.Insert_By = InsertedBy;
                d1.SubmitChanges();
                return true;
            }
            else
            { bool xy=Insert_Stf_Research_Fields(Stf_Id,ResearchFields ,InsertedBy, dc.SA_STF_MEMBERs.SingleOrDefault(x=>x.SA_STF_MEMBER_ID==Stf_Id).AS_FACULTY_INFO_ID.ToString(),
                dc.SA_STF_MEMBERs.SingleOrDefault(x=>x.SA_STF_MEMBER_ID==Stf_Id).AS_NODE_ID.ToString());
                return xy;
            }
            

        }
        public static bool update_Stf_Research_Fields2(decimal Stf_Id, string ResearchFields)
        {
            MisDataContext dc = Global.M_dc;
            PortalDataContextDataContext d1 = new PortalDataContextDataContext();
            if (d1.prtl_Res_Fields.SingleOrDefault(x => x.Stf_ID == Stf_Id) != null)
            {
                var q = d1.prtl_Res_Fields.SingleOrDefault(x => x.Stf_ID == Stf_Id);
                q.Res_Fields = ResearchFields;

                d1.SubmitChanges();
                return true;
            }
            else
            {
                bool xy = Insert_Stf_Research_Fields(Stf_Id, ResearchFields, dc.SA_STF_MEMBERs.SingleOrDefault(x => x.SA_STF_MEMBER_ID == Stf_Id).STF_FULL_NAME_AR, dc.SA_STF_MEMBERs.SingleOrDefault(x => x.SA_STF_MEMBER_ID == Stf_Id).AS_FACULTY_INFO_ID.ToString(),
                dc.SA_STF_MEMBERs.SingleOrDefault(x => x.SA_STF_MEMBER_ID == Stf_Id).AS_NODE_ID.ToString());
                return xy;
            }

        }
        public static bool Delete_Stf_Research_Fields(decimal Stf_Id)
        {

            PortalDataContextDataContext d1 = new PortalDataContextDataContext();
            if (d1.prtl_Res_Fields.SingleOrDefault(x => x.Stf_ID == Stf_Id) != null)
            {
                var q = d1.prtl_Res_Fields.SingleOrDefault(x => x.Stf_ID == Stf_Id);
                d1.prtl_Res_Fields.DeleteOnSubmit(q);
                d1.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }


        }
        public static object GetMemberByFacAndDegree(decimal degreeID, decimal FacID, string currentLang,Page page)
        {
            MisDataContext dc = Global.M_dc;
            if (currentLang == "ar")
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(100).ToList
                        <decimal>();
                var x = (dc.SA_STF_MEMBERs.Where(
                    s => s.AS_FACULTY_INFO_ID == FacID && MemberIDs.Contains(s.SA_STF_MEMBER_ID)).Select(
                        s => new { Name = s.STF_CL_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName=s.AS_NODE.NODE_DESCR_AR ,FacName=s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Image="" })).Take(100);

                // t = x.Count();

                return x;
            }
            else
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(100).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_FACULTY_INFO_ID == FacID && MemberIDs.Contains(s.SA_STF_MEMBER_ID)
                         select new { Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Image = "" }).Take(100);

                //   t = x.Count();
                return x;
            }
        }

        public static object GetMemberByFacAndDegreeAndName(decimal degreeID, decimal FacID, string currentLang, string Name,Page page)
        {
            MisDataContext dc = Global.M_dc;
            if (currentLang == "ar")
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(100).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_FACULTY_INFO_ID == FacID && MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_AR.Contains(Name)
                         select new { Name = s.STF_CL_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Image = "" }).Take(100);

                // t = x.Count();

                return x;
            }
            else
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(100).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_FACULTY_INFO_ID == FacID && MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_EN.Contains(Name)
                         select new { Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Image = "" }).Take(100);

                //   t = x.Count();
                return x;
            }
        }

        public static object GetMemberByNodeAndDegree(decimal degreeID, decimal NodeID, string currentLang,Page page)
        {
            MisDataContext dc = Global.M_dc;
            if (currentLang == "ar")
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(2000).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_NODE_ID == NodeID && MemberIDs.Contains(s.SA_STF_MEMBER_ID)
                         select new { Name = s.STF_CL_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Image = "" }).Take(2000);

                // t = x.Count();

                return x;
            }
            else
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(2000).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_NODE_ID == NodeID && MemberIDs.Contains(s.SA_STF_MEMBER_ID)
                         select new { Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Image = "" }).Take(2000);

                //   t = x.Count();
                return x;
            }
        }

        public static object GetMemberByNodeAndDegreeandName(decimal degreeID, decimal NodeID, string currentLang, String Name, Page page)
        {
            MisDataContext dc = Global.M_dc;
            if (currentLang == "ar")
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(2000).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_NODE_ID == NodeID && MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_AR.Contains(Name)
                         select new { Name = s.STF_CL_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Image = "" }).Take(2000);

                // t = x.Count();

                return x;
            }
            else
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(2000).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_NODE_ID == NodeID && MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_EN.Contains(Name)
                         select new { Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Image = "" }).Take(2000);

                //   t = x.Count();
                return x;
            }
        }

        public static object GetMemberByNodeAndDegreeAndName(decimal degreeID, decimal NodeID, string currentLang, string Name, Page page)
        {
            MisDataContext dc = Global.M_dc;
            if (currentLang == "ar")
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(2000).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_NODE_ID == NodeID && MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_AR.Contains(Name)
                         select new { Name = s.STF_CL_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Image = "" }).Take(2000);

                // t = x.Count();

                return x;
            }
            else
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(2000).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where s.AS_NODE_ID == NodeID && MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_EN.Contains(Name)
                         select new { Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Image = "" }).Take(2000);

                //   t = x.Count();
                return x;
            }
        }

        public static List<SA_SC_MEETING> getMemberConferences(decimal id)
        {
            var dc = Global.M_dc;
            var query = from x in dc.SA_SC_MEETING_ATTENDENCEs where x.SA_STF_MEMBER_ID == id select x.SA_SC_MEETING_ID;
            List<SA_SC_MEETING> meetings = new List<SA_SC_MEETING>();
            foreach (var qq in query)
            {
                var querry =
                    (from y in dc.SA_SC_MEETINGs
                     where y.SA_SC_MEETING_ID == qq && y.SA_CODE_SC_MEETING_TYPE_ID == 6
                     select y).SingleOrDefault();
                if (querry != null)
                {
                    meetings.Add(querry);
                }
            }
            return meetings;
        }



        public static object GetMembersByDegreeAndName(decimal degreeID, string currentLang, string Name, Page page)
        {
            MisDataContext dc = Global.M_dc;


            if (currentLang == "ar")
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(100).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_AR.Contains(Name)
                         select new { Name = s.STF_CL_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Image = "" }).Take(100);



                return x;
            }
            else
            {
                List<decimal> MemberIDs =
                    (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == degreeID select (s.SA_STF_MEMBER_ID)).Take(100).ToList
                        <decimal>();
                var x = (from s in dc.SA_STF_MEMBERs
                         where MemberIDs.Contains(s.SA_STF_MEMBER_ID) && s.STF_FULL_NAME_EN.Contains(Name)
                         select new { Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID,page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Image = "" }).Take(100);

          
                return x;
            }
        }

        public static object GetMembersByDep(decimal DeptNodeID, string currentLang, Page page)
        {
            MisDataContext dc = Global.M_dc;

            if (currentLang == "ar")
            {
                var x = (from s in dc.SA_STF_MEMBERs where s.AS_NODE_ID == Convert.ToDecimal(DeptNodeID) orderby s.STF_FULL_NAME_AR ascending select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_AR, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR });

                return x;
            }
            else
            {
                var x = (from s in dc.SA_STF_MEMBERs where s.AS_NODE_ID == Convert.ToDecimal(DeptNodeID) orderby s.STF_FULL_NAME_AR ascending select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_EN, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR_EN });

                return x;
            }
        }

        public static object GetMembersByDepAndName(decimal DeptNodeID, string currentLang, string Name, Page page)
        {
            MisDataContext dc = Global.M_dc;


            if (currentLang == "ar")
            {
                var x = (from s in dc.SA_STF_MEMBERs where s.AS_NODE_ID == Convert.ToDecimal(DeptNodeID) && s.STF_FULL_NAME_AR.Contains(Name) select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_AR, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR });

                return x;
            }
            else
            {
                var x = (from s in dc.SA_STF_MEMBERs where s.AS_NODE_ID == Convert.ToDecimal(DeptNodeID) && s.STF_FULL_NAME_EN.Contains(Name) select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_EN, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR_EN });

                return x;
            }
        }

        public static object GetMembersByFac(decimal FacID, string currentLang, Page page)
        {
            MisDataContext dc = Global.M_dc;

            if (currentLang == "ar")
            {

                var Degrees = (from s in dc.SA_STF_MEMBERs where s.AS_FACULTY_INFO_ID == FacID select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_AR, EnName = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_AR, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR });

                return Degrees;
            }
            else
            {
                var Degrees = (from s in dc.SA_STF_MEMBERs where s.AS_FACULTY_INFO_ID == FacID select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_EN, EnName = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_EN, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR_EN });

                return Degrees;
            }
        }
        public static object GetMembersByFac2(decimal FacID, Page page)
        {
            MisDataContext dc = Global.M_dc;
            var dc2 = new PortalDataContextDataContext();

           
            var Degrees = (from s in dc.SA_STF_MEMBERs where s.AS_FACULTY_INFO_ID == FacID orderby s.STF_FULL_NAME_AR select s );

                return Degrees;
           
        }
        public static object GetMembersByFacAndName(decimal FacID, string currentLang, string Name, Page page)
        {
            MisDataContext dc = Global.M_dc;

            // List<AS_FACULTY_INFO> query=new List<AS_FACULTY_INFO>();

            if (currentLang == "ar")
            {
                // decimal nodeid = dc.AS_FACULTY_INFOs.Single(x => x.AS_FACULTY_INFO_ID == Depid).AS_NODE_ID;
                var Degrees = (from s in dc.SA_STF_MEMBERs where s.AS_FACULTY_INFO_ID == FacID && s.STF_FULL_NAME_AR.Contains(Name) select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_AR, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR });

                return Degrees;
            }
            else
            {
                var Degrees = (from s in dc.SA_STF_MEMBERs where s.AS_FACULTY_INFO_ID == FacID && s.STF_FULL_NAME_EN.Contains(Name) select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_EN, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR_EN });

                return Degrees;
            }
        }

        public static object GetMembersByName(string currentLang, string Name, Page page)
        {
            MisDataContext dc = Global.M_dc;

            // List<AS_FACULTY_INFO> query=new List<AS_FACULTY_INFO>();

            if (currentLang == "ar")
            {
                var x = (from s in dc.SA_STF_MEMBERs where s.STF_FULL_NAME_AR.Contains(Name) select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_AR, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_AR, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_AR, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_AR, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR });

                return x;
            }
            else
            {
                var x = (from s in dc.SA_STF_MEMBERs where s.STF_FULL_NAME_EN.Contains(Name) select new { ID = s.SA_STF_MEMBER_ID, Name = s.STF_FULL_NAME_EN, Abbr = getMemberAbbr(s.SA_STF_MEMBER_ID, page), DepName = s.AS_NODE.NODE_DESCR_EN, FacName = s.AS_FACULTY_INFO.FACULTY_DESCR_EN, Job = s.SA_CODE_SC_DEG.SC_DEG_DESCR_EN, Job2 = s.SA_CODE_JOB_STATUS.JOB_STATUS_DESCR_EN });

                return x;
            }
        }

 
        //ندوات تعليمية
        public static List<SA_SC_MEETING> getMemberSeminars(decimal id)
        {
            var dc = Global.M_dc;
            var query = from x in dc.SA_SC_MEETING_ATTENDENCEs where x.SA_STF_MEMBER_ID == id select x.SA_SC_MEETING_ID;
            List<SA_SC_MEETING> meetings = new List<SA_SC_MEETING>();
            foreach (var qq in query)
            {
                var queryy =
                    (from y in dc.SA_SC_MEETINGs
                     where y.SA_SC_MEETING_ID == qq && y.SA_CODE_SC_MEETING_TYPE_ID == 1
                     select y).SingleOrDefault();
                if (queryy != null)
                {
                    meetings.Add(queryy);
                }
            }

            return meetings;
        }




        //دورات تدريبية
        public static List<SA_SC_MEETING> getMemberTrainings(decimal id)
        {
            var dc = Global.M_dc;
            var query = from x in dc.SA_SC_MEETING_ATTENDENCEs where x.SA_STF_MEMBER_ID == id select x.SA_SC_MEETING_ID;
            List<SA_SC_MEETING> meetings = new List<SA_SC_MEETING>();
            foreach (var qq in query)
            {
                var queryy =
                    (from y in dc.SA_SC_MEETINGs
                     where y.SA_SC_MEETING_ID == qq && y.SA_CODE_SC_MEETING_TYPE_ID == 7
                     select y).SingleOrDefault();
                if (queryy != null)
                {
                    meetings.Add(queryy);
                }
            }

            return meetings;
        }
        public static SqlDataReader getStfComEnv(decimal id)
        {
            //var dc = Global.M_dc;
            //var query = from x in dc.U2_SA_SERVICE_COMMUNITY_ENVIRONMENTs select x;
            //return query;

            SqlConnection con = new SqlConnection(Mis_DAL.Info.WebConfigConnectionString);
            con.Open();
            string query =
                           "select * from U2_SA_SERVICE_COMMUNITY_ENVIRONMENT inner join U2_GS_CODE_ACTIVITY_SERVICE_TYPE on U2_SA_SERVICE_COMMUNITY_ENVIRONMENT.GS_CODE_ACTIVITY_SERVICE_TYPE_ID=" +
                           "U2_GS_CODE_ACTIVITY_SERVICE_TYPE.GS_CODE_ACTIVITY_SERVICE_TYPE_ID where U2_SA_SERVICE_COMMUNITY_ENVIRONMENT.SA_STF_MEMBER_ID=" + id;

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();

            return da;
        }

        public static List<SA_SC_MEETING> getMemberWorkshops(decimal id)
        {
            var dc = Global.M_dc;
            var query = from x in dc.SA_SC_MEETING_ATTENDENCEs where x.SA_STF_MEMBER_ID == id select x.SA_SC_MEETING_ID;
            List<SA_SC_MEETING> meetings = new List<SA_SC_MEETING>();
            foreach (var qq in query)
            {
                var queryy =
                    (from y in dc.SA_SC_MEETINGs
                     where y.SA_SC_MEETING_ID == qq && y.SA_CODE_SC_MEETING_TYPE_ID == 2
                     select y).SingleOrDefault();
                if (queryy != null)
                {
                    meetings.Add(queryy);
                }
            }

            return meetings;
        }

        public static prtl_Owner getStfOwner(decimal id)
        {
            var dc = new PortalDataContextDataContext();
            var query = (from x in dc.prtl_Owners where x.InitAbbr == id.ToString() select x).SingleOrDefault();
            return query;
        }
        public static SA_STF_MEMBER getStf(decimal id)
        {
            var dc = Global.M_dc;
           
                return dc.SA_STF_MEMBERs.SingleOrDefault(i => i.SA_STF_MEMBER_ID == id);

           
        }
        public static prtl_OwnersAdminUser getUserByOwner(Guid owner)
        {
            var dc = new PortalDataContextDataContext();
            var query = (from x in dc.prtl_OwnersAdminUsers where x.Owner_ID == owner select x).SingleOrDefault();
            return query;
        }


        public static aspnet_User getStfUser(Guid ownerId)
        {
            var dc = new PortalDataContextDataContext();
            var query = (from x in dc.prtl_OwnersAdminUsers where x.Owner_ID == ownerId select x).SingleOrDefault();
            var query2 = (from xx in dc.aspnet_Users where xx.UserId == query.User_ID select xx).SingleOrDefault();
            return query2;
        }
        public static SA_STF_MEMBER getStfByNationalId(string NID)
        {
            var dc = Global.M_dc;
            var query = (from x in dc.SA_STF_MEMBERs where x.STF_NATIONAL_ID_NUM == NID.Trim()   select x).SingleOrDefault();
            if (query != null)
            {
                return query;
            }
            else
            {
                return null;
            }
        }
        public static List<U2_SCIENTIFIC_PAPER> getMemberSupervisePapers(decimal id)
        {
            var dc = Global.M_dc;
            List<U2_SCIENTIFIC_PAPER> query = (from x in dc.U2_SCIENTIFIC_PAPERs where x.IS_SUPERVISE == 1 && x.SA_STF_MEMBER_ID == id select x).ToList();

            return query;
        }

        public static List<U2_SCIENTIFIC_PAPER> getMemberDiscussPapers(decimal id)
        {
            var dc = Global.M_dc;
            List<U2_SCIENTIFIC_PAPER> query = (from x in dc.U2_SCIENTIFIC_PAPERs where x.IS_SUPERVISE == 0 && x.SA_STF_MEMBER_ID == id select x).ToList();

            return query;
        }

        public static SqlDataReader getMemberEstablish(decimal id)
        {

            SqlConnection con = new SqlConnection(Mis_DAL.Info.WebConfigConnectionString);
            con.Open();
            string query =
                           "select * from U2_SA_ESTABLISH inner join U2_GS_CODE_ESTABLISH_TYPE on U2_SA_ESTABLISH.GS_CODE_ESTABLISH_TYPE_ID=" +
                           "U2_GS_CODE_ESTABLISH_TYPE.GS_CODE_ESTABLISH_TYPE_ID where U2_SA_ESTABLISH.SA_STF_MEMBER_ID=" + id;

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();

            return da;

        }

        public static SqlDataReader getMemberMembership(decimal id)
        {

            SqlConnection con = new SqlConnection(Mis_DAL.Info.WebConfigConnectionString);
            con.Open();
            string query =
                           "SELECT *  FROM U2_SA_MEMBERSHIP inner join U2_GS_CODE_MEMBERSHIP_TYPE on U2_SA_MEMBERSHIP.GS_CODE_MEMBERSHIP_TYPE_ID=" +
                "U2_GS_CODE_MEMBERSHIP_TYPE.GS_CODE_MEMBERSHIP_TYPE_ID inner join U2_AS_SCIENTIFIC_AFFLITION on U2_SA_MEMBERSHIP.AS_SCIENTIFIC_AFFLITION_ID =U2_AS_SCIENTIFIC_AFFLITION.AS_SCIENTIFIC_AFFLITION_ID" +
                           "  WHERE U2_SA_MEMBERSHIP.SA_STF_MEMBER_ID=" + id;

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();

            return da;

        }

        public static SqlDataReader getMemberESubject(decimal id)
        {

            SqlConnection con = new SqlConnection(Mis_DAL.Info.WebConfigConnectionString);
            con.Open();
            string query =
                           "select E_SUBJECT_ID,SA_SUBJECT_NAME_AR as name, SA_SITE_NAME,CLASS_DESCR_AR as level,SA_SITE_NAME as site from U2_SA_E_SUBJECT left join AS_CODE_DEGREE_CLASS on U2_SA_E_SUBJECT.SA_CODE_DEGREE_CLASS=AS_CODE_DEGREE_CLASS.AS_CODE_DEGREE_CLASS_ID where SA_STF_MEMBER_ID=" + id;

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader da = cmd.ExecuteReader();

            return da;

        }




        public static decimal getMemeberIDByAbbr(RouteData data)
        {
            var dc = new PortalDataContextDataContext();
            {
                var q = dc.prtl_Owners.SingleOrDefault(x => x.Abbr == Common.URLBuilder.OwnerAbbr(data));
                if (q != null)
                {
                    return Convert.ToDecimal(q.InitAbbr);
                }
                else
                {
                    return Convert.ToDecimal("0");
                }
            }
        }

        public static ISingleResult<ResearchByStfIDResult> GetReasearchesBySTFID(decimal? staffid)
        {
            return new PortalDataContextDataContext().ResearchByStfID(staffid);
        }

        //public static object GetSections(decimal nodeid, string currentLang)
        //{
        //    MisDataContext dc = Global.M_dc;

        //    // List<AS_FACULTY_INFO> query=new List<AS_FACULTY_INFO>();

        //    if (currentLang == "ar")
        //    {
        //        // decimal nodeid = dc.AS_FACULTY_INFOs.Single(x => x.AS_FACULTY_INFO_ID == Depid).AS_NODE_ID;
        //        var nodes = (from s in dc.AS_NODEs where s.NODE_PARENT_ID == nodeid select new { ID = s.AS_NODE_ID, SecName = s.NODE_DESCR_AR });

        //        var q2 = nodes.Except(from c in nodes where (c.SecName == null) select c).ToArray();

        //        return q2;
        //    }
        //    else
        //    {
        //        var nodes = (from s in dc.AS_NODEs where s.NODE_PARENT_ID == nodeid select new { ID = s.AS_NODE_ID, SecName = s.NODE_DESCR_EN });

        //        var q2 = nodes.Except(from c in nodes where (c.SecName == null) select c).ToArray();

        //        return q2;
        //    }
        //}

        public static string GetSpecDetail(object SA_STF_MEMBER_ID, int Detailnumber)
        {
            MisDataContext dc = Global.M_dc;

            var qu1 =
                from x in dc.SA_STF_MEMBERs
                where x.SA_STF_MEMBER_ID == Convert.ToDecimal(SA_STF_MEMBER_ID)
                select x.GS_CONTACT_METHOD_H_ID;
            string qu2 = "";

            foreach (var item in qu1)
            {
                var dd =

                dc.GS_CONTACT_METHOD_Ds.FirstOrDefault(
                    c => c.GS_CONTACT_METHOD_H_ID == item && c.GS_CODE_CONTACT_METHOD_ID == Detailnumber);
                if (dd != null)
                {
                    qu2 = dd.METHOD_DESCR;
                }
            }

            //from c in dc.GS_CONTACT_METHOD_Ds where c.GS_CONTACT_METHOD_H_ID.ToString()==qu1.ToString() && c.GS_CODE_CONTACT_METHOD_ID==8 select c.GS_CODE_CONTACT_METHOD.METHOD_DESCR_AR ;

            return qu2;
        }

        //public static decimal getStaffIDByUserName(string username)
        //{
        //    SA_STF_MEMBER member =
        //        (from x in dc.SA_STF_MEMBERs where x.User_Name == username select x).SingleOrDefault();
        //    return member.SA_STF_MEMBER_ID;

        //}

        //public static object GetStaffDegrees(string currentLang)
        //{
        //    MisDataContext dc = Global.M_dc;

        //    // List<AS_FACULTY_INFO> query=new List<AS_FACULTY_INFO>();

        //    if (currentLang == "ar")
        //    {
        //        // decimal nodeid = dc.AS_FACULTY_INFOs.Single(x => x.AS_FACULTY_INFO_ID == Depid).AS_NODE_ID;
        //        var Degrees = (from s in dc.AS_CODE_DEGREEs where s.AS_CODE_DEGREE_CLASS_ID == 2 select new { ID = s.AS_CODE_DEGREE_ID, DegreeName = s.DEGREE_DESCR_AR });

        //        var q2 = Degrees.Except(from c in Degrees where (c.DegreeName == null) select c).ToArray();

        //        return q2;
        //    }
        //    else
        //    {
        //        var Degrees = (from s in dc.AS_CODE_DEGREEs where s.AS_CODE_DEGREE_CLASS_ID == 2 select new { ID = s.AS_CODE_DEGREE_ID, DegreeName = s.DEGREE_DESCR_EN });

        //        var q2 = Degrees.Except(from c in Degrees where (c.DegreeName == null) select c).ToArray();

        //        return q2;
        //    }
        //}

        //public static object GetMembersByAllFilters(decimal SectNodeID, decimal DegreeID, string currentLang)
        //{
        //    if (currentLang == "ar")
        //    {
        //        var MemberIDs = (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == DegreeID  select new { Name = s.SA_STF_MEMBER_ID });
        //        var members = new List<object>();

        //        foreach (var ID in MemberIDs)
        //        {
        //            var x = (from s in dc.SA_STF_MEMBERs where s.SA_STF_MEMBER_ID == Convert.ToDecimal(ID) && s.AS_NODE_ID==SectNodeID  select new { Name = s.STF_FULL_NAME_AR, ID = s.SA_STF_MEMBER_ID });
        //            members.Add(x);
        //        }

        //        return members;

        //    }
        //    else
        //    {
        //        var MemberIDs = (from s in dc.SA_SC_QUALs where s.AS_CODE_DEGREE_ID == DegreeID select new { Name = s.SA_STF_MEMBER_ID });
        //        var members = new List<object>();

        //        foreach (var ID in MemberIDs)
        //        {
        //            var x = (from s in dc.SA_STF_MEMBERs where s.SA_STF_MEMBER_ID == Convert.ToDecimal(ID) && s.AS_NODE_ID == SectNodeID select new { Name = s.STF_FULL_NAME_EN , ID = s.SA_STF_MEMBER_ID });
        //            members.Add(x);
        //        }

        //        return members;
        //    }

        //}

        public static prtl_Owner getStfOwner(object userID)
        {
            var dc = new PortalDataContextDataContext();
          return dc.prtl_OwnersAdminUsers.Single(u => u.User_ID.ToString() == userID.ToString()).prtl_Owner;
        }
        public static bool AdressCheck(decimal MemeberId)
        {
            var dc = new PortalDataContextDataContext();
            var t = dc.prtl_Owners.Single(x => x.InitAbbr == MemeberId.ToString()).Adress_Publish;

            return t;
        }
        public static void UpdateStaffInfo(string abbr, bool address, bool email, bool tel)
        {
            var dc = new PortalDataContextDataContext();
            prtl_Owner owner = dc.prtl_Owners.SingleOrDefault(x => x.Abbr == abbr);
            owner.Adress_Publish = address;
            owner.Email_Publish = email;
            owner.Tel_Publish = tel;
            dc.SubmitChanges();
        }
        public static bool TelCheck(decimal MemeberId)
        {
            var dc = new PortalDataContextDataContext();
            var t = dc.prtl_Owners.Single(x => x.InitAbbr == MemeberId.ToString()).Tel_Publish;

            return t;
        }

        public static bool EmailCheck(decimal MemeberId)
        {
            var dc = new PortalDataContextDataContext();
            var t = dc.prtl_Owners.Single(x => x.InitAbbr == MemeberId.ToString()).Email_Publish;

            return t;
        }

        public static string getIDFac(string id)
        {
            var dc = new PortalDataContextDataContext();
            var x = (from d in dc.prtl_Owners where d.InitAbbr.Substring (0,2)==id && d.Type ==1 select d).SingleOrDefault();

            return x.Abbr .ToString ();
        }
    }
}