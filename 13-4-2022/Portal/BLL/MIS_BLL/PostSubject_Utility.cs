using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mis_DAL;
using Portal_DAL;
using System.Data.SqlClient;
using System.Data; 
namespace MnfUniversity_Portals.BLL.MIS_BLL
{
    public class PostSubject_Utility
    {
        public static PG_SUBJECT getsubjectbyid(decimal subid)
        {
            var dc = Global.M_dc;
            return (from x in dc.PG_SUBJECTs where x.PG_SUBJECT_ID == subid select x).SingleOrDefault();
        }
        public static string GetSubjectYear(decimal SubjectID)
        {
            var dc = Global.M_dc;
            var query = (from x in dc.PG_SUBJECTs where x.PG_SUBJECT_ID == SubjectID select x).SingleOrDefault();
            var query2 =
                (from y in dc.PG_PHASE_NODEs where y.PG_PHASE_NODE_ID == query.PG_PHASE_NODE_ID select y).
                    SingleOrDefault();

            var query3 =
               (from y in dc.PG_PHASE_NODEs where y.PG_PHASE_NODE_ID == query2.NODE_PARENT_ID select y).
                   SingleOrDefault();
            return query3.NODE_DESCR_AR + "\\" + query2.NODE_DESCR_AR;
        }


        public static object GetDipPostPrograms(string facabbr,string currentLang)
        {
            var dc2 = new PortalDataContextDataContext();;

            var query2 = dc2.prtl_Owners.SingleOrDefault(xx => xx.Abbr == facabbr).InitAbbr;

var dc = Global.M_dc;
string s = "";
if (query2.EndsWith("EDU"))
{
    s = query2.Substring(0, 3);
}
else
{
    s = query2.Substring(0, 2);
}
            if(currentLang=="ar"){
            var query=(from x in dc.PG_NODE_GRANTABLE_DEGREEs where 
                           x.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW==1 
                           && x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_FACULTY_INFO.AS_FACULTY_INFO_ID.ToString()==s 
                          &&x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_CODE_DEGREE_ID==1
                      select new
                                  {
                                      
                                      name = x.DEGREE_DESCR_AR,
                                      ID = x.PG_NODE_GRANTABLE_DEGREE_ID
                                      
                                  });
                return query;
            }else {
                var query = (from x in dc.PG_NODE_GRANTABLE_DEGREEs
                             where x.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW == 1 && x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_FACULTY_INFO.AS_FACULTY_INFO_ID.ToString() == s &&
                          x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_CODE_DEGREE_ID==1
                      select new
                                  {

                                      name = x.DEGREE_DESCR_EN,
                                      ID = x.PG_NODE_GRANTABLE_DEGREE_ID
                                      
                                  });
                return query;
            }
        }

            public static object GetMasterPostPrograms(string facabbr,string currentLang)
        {
            var dc2 = new PortalDataContextDataContext();

           var query2 = dc2.prtl_Owners.SingleOrDefault(xx => xx.Abbr == facabbr).InitAbbr;

var dc = Global.M_dc;
string s = "";
if (query2.EndsWith("EDU"))
{
    s = query2.Substring(0, 3);
}
else
{
    s = query2.Substring(0, 2);
}
            if(currentLang=="ar"){
                var query = (from x in dc.PG_NODE_GRANTABLE_DEGREEs
                             where x.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW == 1 && x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_FACULTY_INFO.AS_FACULTY_INFO_ID.ToString() == s &&
                          x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_CODE_DEGREE_ID==4
                      select new
                                  {

                                      name = x.DEGREE_DESCR_AR,
                                      ID = x.PG_NODE_GRANTABLE_DEGREE_ID
                                      
                                  });
                return query;
            }else {
                var query = (from x in dc.PG_NODE_GRANTABLE_DEGREEs
                             where x.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW == 1 && x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_FACULTY_INFO.AS_FACULTY_INFO_ID.ToString() == s &&
                          x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_CODE_DEGREE_ID==4
                      select new
                                  {

                                      name = x.DEGREE_DESCR_EN,
                                      ID = x.PG_NODE_GRANTABLE_DEGREE_ID
                                      
                                  });
                return query;
            }


        }

        public static object GetphdPostPrograms(string facabbr,string currentLang)
        {
            var dc2 = new PortalDataContextDataContext();

            var query2 = dc2.prtl_Owners.SingleOrDefault(xx => xx.Abbr == facabbr).InitAbbr;

var dc = Global.M_dc;
string s = "";
if (query2.EndsWith("EDU"))
{
    s = query2.Substring(0, 3);
}
else
{
    s = query2.Substring(0, 2);
}
            if(currentLang=="ar"){
                var query = (from x in dc.PG_NODE_GRANTABLE_DEGREEs
                             where x.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW == 1 && x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_FACULTY_INFO.AS_FACULTY_INFO_ID.ToString() == s &&
                          x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_CODE_DEGREE_ID==5
                      select new
                                  {

                                      name = x.DEGREE_DESCR_AR,
                                      ID = x.PG_NODE_GRANTABLE_DEGREE_ID
                                      
                                  });
                return query;
            }else {
                var query = (from x in dc.PG_NODE_GRANTABLE_DEGREEs
                             where x.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW == 1 && x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_FACULTY_INFO.AS_FACULTY_INFO_ID.ToString() == s &&
                          x.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_CODE_DEGREE_ID==5
                      select new
                                  {

                                      name = x.DEGREE_DESCR_EN,
                                      ID = x.PG_NODE_GRANTABLE_DEGREE_ID
                                      
                                  });
                return query;
            }
        }





        public static string WebConfigConnectionString
        {
            get
            {
                var webconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                return webconfig.ConnectionStrings.ConnectionStrings["MisConnectionString"].ConnectionString;
            }
        }

        public static DataTable GetSubjectsByDepID(decimal DepId)
        {
            //var dc = Global.M_dc;


            SqlConnection connect = new SqlConnection(WebConfigConnectionString);
            connect.Close();
            string query = @"select * from PG_SUBJECT inner join PG_PHASE_NODE on PG_PHASE_NODE.PG_PHASE_NODE_ID=PG_SUBJECT.PG_PHASE_NODE_ID
inner join PG_BYLAW_DEGREE on PG_PHASE_NODE.PG_BYLAW_DEGREE_ID=PG_BYLAW_DEGREE.PG_BYLAW_DEGREE_ID
inner join PG_NODE_GRANTABLE_DEGREE on PG_NODE_GRANTABLE_DEGREE.PG_BYLAW_DEGREE_ID=PG_BYLAW_DEGREE.PG_BYLAW_DEGREE_ID
inner join PG_BYLAW on PG_BYLAW.PG_BYLAW_ID=PG_BYLAW_DEGREE.PG_BYLAW_ID
inner join AS_NODE on PG_NODE_GRANTABLE_DEGREE.AS_NODE_ID=AS_NODE.AS_NODE_ID
inner join AS_FACULTY_INFO on PG_SUBJECT.AS_FACULTY_INFO_ID=AS_FACULTY_INFO.AS_FACULTY_INFO_ID
where  PG_BYLAW.IS_CUR_BYLAW=1 and PG_NODE_GRANTABLE_DEGREE.PG_NODE_GRANTABLE_DEGREE_ID=" + DepId.ToString();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;

            connect.Open();



            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds, "test");

            return ds.Tables["test"];
            



        }
        public static DataTable GetSubjectsByDepID2(decimal DepId)
        {
            var dc = Global.M_dc;

             var dc2 = new PortalDataContextDataContext();
            SqlConnection connect = new SqlConnection(WebConfigConnectionString);
            connect.Close();
            var qq=(from xx in dc.PG_NODE_GRANTABLE_DEGREEs where xx.PG_NODE_GRANTABLE_DEGREE_ID==DepId select xx). SingleOrDefault();
            if (qq.PG_BYLAW_DEGREE.AS_GRANTABLE_DEGREE.AS_CODE_DEGREE.AS_CODE_DEGREE_ID == 1)
            {

                string query = @"select * from PG_SUBJECT inner join PG_PHASE_NODE on PG_PHASE_NODE.PG_PHASE_NODE_ID=PG_SUBJECT.PG_PHASE_NODE_ID
inner join PG_BYLAW_DEGREE on PG_PHASE_NODE.PG_BYLAW_DEGREE_ID=PG_BYLAW_DEGREE.PG_BYLAW_DEGREE_ID
inner join PG_NODE_GRANTABLE_DEGREE on PG_NODE_GRANTABLE_DEGREE.PG_BYLAW_DEGREE_ID=PG_BYLAW_DEGREE.PG_BYLAW_DEGREE_ID
inner join PG_BYLAW on PG_BYLAW.PG_BYLAW_ID=PG_BYLAW_DEGREE.PG_BYLAW_ID
inner join AS_NODE on PG_NODE_GRANTABLE_DEGREE.AS_NODE_ID=AS_NODE.AS_NODE_ID
inner join AS_FACULTY_INFO on PG_SUBJECT.AS_FACULTY_INFO_ID=AS_FACULTY_INFO.AS_FACULTY_INFO_ID
where  PG_BYLAW.IS_CUR_BYLAW=1 and PG_NODE_GRANTABLE_DEGREE.PG_NODE_GRANTABLE_DEGREE_ID=" + DepId.ToString();
                SqlCommand command = connect.CreateCommand();
                command.CommandText = query;

                connect.Open();



                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "test");

                return ds.Tables["test"];

            }
            else
            {

                var q = (from x in dc2.Prtl_PostProgsMappings where x.Prog_ID == DepId select x.PreProg_ID).SingleOrDefault();
                if (q != 0)
                {
                    string query = @"select * from PG_SUBJECT inner join PG_PHASE_NODE on PG_PHASE_NODE.PG_PHASE_NODE_ID=PG_SUBJECT.PG_PHASE_NODE_ID
inner join PG_BYLAW_DEGREE on PG_PHASE_NODE.PG_BYLAW_DEGREE_ID=PG_BYLAW_DEGREE.PG_BYLAW_DEGREE_ID
inner join PG_NODE_GRANTABLE_DEGREE on PG_NODE_GRANTABLE_DEGREE.PG_BYLAW_DEGREE_ID=PG_BYLAW_DEGREE.PG_BYLAW_DEGREE_ID
inner join PG_BYLAW on PG_BYLAW.PG_BYLAW_ID=PG_BYLAW_DEGREE.PG_BYLAW_ID
inner join AS_NODE on PG_NODE_GRANTABLE_DEGREE.AS_NODE_ID=AS_NODE.AS_NODE_ID
inner join AS_FACULTY_INFO on PG_SUBJECT.AS_FACULTY_INFO_ID=AS_FACULTY_INFO.AS_FACULTY_INFO_ID
where  PG_BYLAW.IS_CUR_BYLAW=1 and PG_NODE_GRANTABLE_DEGREE.PG_NODE_GRANTABLE_DEGREE_ID=" + q.ToString();
                    SqlCommand command = connect.CreateCommand();
                    command.CommandText = query;

                    connect.Open();



                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "test");

                    return ds.Tables["test"];
                }

                else
                {
                    return null;
                }
            }



        }
        public static void changeprogmenu()
        {

            var dc2 = new PortalDataContextDataContext();
            var q1=(from x in dc2.prtl_Owners where x.Type==16 select x).ToList();
            foreach (var v in q1)
            {

                var q2 = (from xx in dc2.prtl_Menus where xx.Owner_ID == v.Owner_ID select xx).ToList();

                foreach (var vv in q2)
                {

                    for(int i=1;i<=4;i++){
                    //    IEnumerable<prtl_Menu> q31 = (from d in dc2.prtl_Menus where d.Order == i && d.Owner_ID == vv.Owner_ID select d).Take(1);   
                    //q31.FirstOrDefault().Published=true;
                    //dc2.SubmitChanges();
                    IEnumerable<prtl_Menu> q32 = (from d in dc2.prtl_Menus where d.Order == i && d.Owner_ID == vv.Owner_ID select d).Skip(1);
                    dc2.prtl_Menus.DeleteAllOnSubmit(q32);
                    dc2.SubmitChanges();
                    //    q32.FirstOrDefault().Published = false;
                    //dc2.SubmitChanges();
                    //IEnumerable<prtl_Menu> q33 = (from d in dc2.prtl_Menus where d.Order == i && d.Owner_ID == vv.Owner_ID select d).Skip(2);
                    //dc2.prtl_Menus.DeleteOnSubmit(q33.FirstOrDefault());
                    //dc2.SubmitChanges();
                    ////q33.FirstOrDefault().Published = false;
                    ////dc2.SubmitChanges();
                    //IEnumerable<prtl_Menu> q34 = (from d in dc2.prtl_Menus where d.Order == i && d.Owner_ID == vv.Owner_ID select d).Skip(3);
                    //dc2.prtl_Menus.DeleteOnSubmit(q34.FirstOrDefault());
                    //dc2.SubmitChanges();
                    //q34.FirstOrDefault().Published = false;
                    //dc2.SubmitChanges();
                    }

                }











            }







        }
        public static void insertsubjects()
        {
            var dc = Global.M_dc;
            var dc2 = new PortalDataContextDataContext();

            var query2 = dc2.prtl_Owners.SingleOrDefault(vv => vv.Type == 1 && vv.Abbr == "SCI");
            var q1 = (from x in dc.PG_SUBJECTs where x.AS_FACULTY_INFO_ID == 26 && x.PG_PHASE_NODE.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW == 1 select x).ToList();
            foreach (var v in q1)
            {
                //var s=dc2.prtl_Owners.Any(xx=>xx.Type==15 && xx.Abbr.StartsWith("Postsub_"+v.PG_SUBJECT_ID.ToString()));
                //if(!s){
                
                prtl_Owner owner = new prtl_Owner(){
                    Abbr = "Postsub_" + v.PG_SUBJECT_ID.ToString(),
                    Theme = "Default",
                    CurrentVotingID = 0,
                    InitAbbr = "Postsub_" + v.PG_SUBJECT_ID.ToString(),
                    Type = 15,
                    Parent_Id = query2.ID

                };
                dc2.prtl_Owners.InsertOnSubmit(owner);
                dc2.SubmitChanges();
                //var q2 = (from xx in dc2.prtl_Owners where xx.Type == 15 && xx.Parent_Id == 24 select xx).ToList();
                //foreach (var f in q2)
                //{
                    var tg=dc2.prtl_Translations.Any(xx=>xx.prtl_Owner.Owner_ID==owner.Owner_ID);
                    if (v.SUBJECT_DESCR_AR != null &&  !tg)
                    {

                        prtl_Translation tt = new prtl_Translation()
                        {
                            Lang_Id = 1,
                            Translation_Data = Convert.ToString(v.SUBJECT_DESCR_AR),
                            Translation_ID = owner.Owner_ID

                        };
                        dc2.prtl_Translations.InsertOnSubmit(tt);
                        dc2.SubmitChanges();
                    }

                    if (v.SUBJECT_DESCR_EN != null && !tg)
                    {

                        prtl_Translation t = new prtl_Translation()
                        {
                            Lang_Id = 2,
                            Translation_Data = Convert.ToString(v.SUBJECT_DESCR_EN),
                            Translation_ID = owner.Owner_ID

                        };
                        dc2.prtl_Translations.InsertOnSubmit(t);
                        dc2.SubmitChanges();

                    }
                }
            //}
               // }
            

        }
        public static void updatesubjectowner()
        {
            var dc2 = new PortalDataContextDataContext();
            var query = (from x in dc2.prtl_Owners where x.Type == 16 select x).ToList();
            foreach (var d in query)
            {

                var q2=dc2.prtl_Owners.SingleOrDefault(xx=>xx.ID.ToString()==d.Parent_Id.ToString());
                var q3=dc2.prtl_Owners.SingleOrDefault(xxx=>xxx.ID.ToString()==q2.Parent_Id.ToString());



                d.Parent_Id = q3.ID;
                dc2.SubmitChanges();
            }
        }
        public static void CreateSubjectsOwners()
        {
            var dc = Global.M_dc;
            var dc2 = new PortalDataContextDataContext();
            //var query=(from yy in dc2.prtl_Owners where yy.Type==14 select yy).ToList();
            //foreach(var d in query){
            //    if (d != null)
            //{
            //    d.InitAbbr ="post_"+d.InitAbbr ;
            //    dc2.SubmitChanges();
            //}

            //}
            var allPostprogram = (from x in dc.PG_NODE_GRANTABLE_DEGREEs
                                  where  x.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW== 1
                                  && x.PG_BYLAW_DEGREE.PG_BYLAW.AS_FACULTY_INFO.AS_FACULTY_INFO_ID == 136
                                  
                                  select new
                                  {
                                      facID = x.PG_BYLAW_DEGREE.PG_BYLAW.AS_FACULTY_INFO.AS_FACULTY_INFO_ID,
                                      ID=x.PG_NODE_GRANTABLE_DEGREE_ID,
                                      nameAr = x.DEGREE_DESCR_AR,
                                      nameEn = x.DEGREE_DESCR_EN
                                      
                                  }).ToList();



            foreach (var v in allPostprogram)
            {
                int search = 0;
                var xj = v.facID;
                var query2 = dc2.prtl_Owners.SingleOrDefault(vv => vv.Type == 1 && vv.Abbr=="EDU");
                
                //if (dc2.prtl_Owners.SingleOrDefault(vv => vv.InitAbbr.Substring(0, vv.InitAbbr.Length-1)==xj.ToString() && vv.Type == 14) != null)
                //{
                    //var depid =
                    //    dc2.prtl_Owners.SingleOrDefault(vvv => vvv.InitAbbr.EndsWith(xj.ToString()) && vvv.Type == 14)
                    //        .InitAbbr;
                    //var prtlOwner = dc2.prtl_Owners.SingleOrDefault(xy => xy.InitAbbr == "post_"+xj);
                    //if (prtlOwner != null)
                    //    search = prtlOwner.ID;


                    prtl_Owner owner = new prtl_Owner()
                                   {
                                       Abbr = "PostPrg_" + v.ID.ToString(),
                                       Theme = "Default",
                                       CurrentVotingID = 0,
                                       InitAbbr = "PostPrg_" + v.ID.ToString(),
                                       Type = 16,
                                       Parent_Id = query2. ID

                                   };
                    dc2.prtl_Owners.InsertOnSubmit(owner);
                    dc2.SubmitChanges();
                    if (v.nameAr != null)
                    {

                        prtl_Translation tt = new prtl_Translation()
                                                 {
                                                     Lang_Id = 1,
                                                     Translation_Data = Convert.ToString(v.nameAr),
                                                     Translation_ID = owner.Owner_ID

                                                 };
                        dc2.prtl_Translations.InsertOnSubmit(tt);
                        dc2.SubmitChanges();
                    }

                    if (v.nameEn != null)
                    {

                        prtl_Translation t = new prtl_Translation()
                        {
                            Lang_Id = 2,
                            Translation_Data = Convert.ToString(v.nameEn),
                            Translation_ID = owner.Owner_ID

                        };
                        dc2.prtl_Translations.InsertOnSubmit(t);
                        dc2.SubmitChanges();

                    }
                //}
            }
        }





















        public static void CreatePostProgramOwners()
        {
            var dc = Global.M_dc;
             var dc2 = new PortalDataContextDataContext();
            var allPostprogram = (from x in dc.PG_SUBJECTs
                                            where x.AS_NODE.AS_CODE_NODE_NATURE_ID == 13 && x.PG_PHASE_NODE.PG_BYLAW_DEGREE.PG_BYLAW.IS_CUR_BYLAW==1
                                             orderby x.AS_FACULTY_INFO.AS_FACULTY_INFO_ID ascending
                                            select new 
                                            {
                                              ID=  x.AS_NODE.AS_NODE_ID,
                                              nameAr = x.AS_NODE.NODE_DESCR_AR,
                                              nameEn = x.AS_NODE.NODE_DESCR_EN,
                                              facID = x.AS_FACULTY_INFO.AS_FACULTY_INFO_ID 
                                            }).Distinct().ToList();



            foreach (var v in allPostprogram)
            {
                int search = 0;
                var xj =v.facID; 
                if (dc2.prtl_Owners.SingleOrDefault(xx => xx.InitAbbr == "PostPrg_" + v.ID).Abbr != null)
                            {
                        if (dc2.prtl_Owners.SingleOrDefault(vv => vv.InitAbbr.StartsWith(xj.ToString()) && vv.Type == 1) !=null)
                        {
                           
                                var facid =
                                    dc2.prtl_Owners.SingleOrDefault(
                                            vvv => vvv.InitAbbr.StartsWith(xj.ToString()) && vvv.Type == 1)
                                        .InitAbbr;
                                var prtlOwner = dc2.prtl_Owners.SingleOrDefault(xy => xy.InitAbbr == facid);
                                if (prtlOwner != null)
                                    search = prtlOwner.ID;
                                prtl_Owner owner = new prtl_Owner()
                                {
                                    Abbr = "PostPrg_" + v.ID,
                                    Theme = "Default",
                                    CurrentVotingID = 0,
                                    InitAbbr = "PostPrg_"+v.ID,
                                    Type = 16,
                                    Parent_Id = search

                                };
                                dc2.prtl_Owners.InsertOnSubmit(owner);
                                dc2.SubmitChanges();


                                prtl_Translation tt = new prtl_Translation()
                                {
                                    Lang_Id = 1,
                                    Translation_Data =
                                        v.nameAr,
                                    Translation_ID = owner.Owner_ID

                                };
                                dc2.prtl_Translations.InsertOnSubmit(tt);
                                dc2.SubmitChanges();


                                if (v.nameEn != null)
                                {

                                    prtl_Translation t = new prtl_Translation()
                                    {
                                        Lang_Id = 2,
                                        Translation_Data = v.nameEn,
                                        Translation_ID = owner.Owner_ID

                                    };
                                    dc2.prtl_Translations.InsertOnSubmit(t);
                                    dc2.SubmitChanges();

                                }
                            }
                        }
            }

                        
                        
                        




        
            
        }
    }
}