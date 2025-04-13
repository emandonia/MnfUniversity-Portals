using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Common;
using MySql.Data.MySqlClient;
using Portal_DAL;

namespace BLL
{
    public static class prtl_ThesisUtility
    {



        public static void delete_thesis_translation(string thesisId)
        {

            var dc = new PortalDataContextDataContext();
            var items = (from x in dc.Prtl_Thesis_Translations where x.Thesis_ID.ToString() == thesisId select x).ToList();
            foreach (var item in items)
            {
                dc.Prtl_Thesis_Translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }

        }
        public static void delete_thesis_map_super(string thesisId)
        {

            var dc = new PortalDataContextDataContext();
            var items = (from x in dc.Prtl_ThesisMapSupers where x.ThesisId.ToString()==thesisId select x).ToList();
            foreach (var item in items)
            {
                 dc.Prtl_ThesisMapSupers.DeleteOnSubmit(item);
            dc.SubmitChanges();
            }
           

        }

        public static void delete_thesis_map_supervisor(string thesisId)
        {

            var dc = new PortalDataContextDataContext();
            var items = (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId.ToString() == thesisId select x).ToList();
            foreach (var item in items)
            {
                dc.Prtl_ThesisMapSupervisors.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }

        }

        public static DataTable GetFaculties()
        {

            DataTable r = Query("select * from publications.jos_jresearch_research_area where name !='Uncategorized';");

            return r;

        }

        public static string GetConnectionString()
        {
            string connStr = "Server=localhost;Port=3307;Database=publications;Uid=root;Pwd=root;Convert Zero Datetime=True;Pooling=True;maximum pool size=50000;Connection LifeTime=3000;Max Pool Size=1000;";

            return connStr;
        }

        public static string StaticQuery1(string query)
        {
            using (MySqlConnection connect = new MySqlConnection(GetConnectionString()))
            {
                 connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.CommandText = query;
                MySqlDataReader x = command.ExecuteReader();
                string s = "";
                while (x.Read())
                {
                    s += x["name"];
                }
               
               return s;
            } 
        }
        public static string StaticQuery2(string query)
        {
            using (MySqlConnection connect = new MySqlConnection(GetConnectionString()))
            {
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.CommandText = query;
                MySqlDataReader x = command.ExecuteReader();
                string s = "";
                while (x.Read())
                {
                    s += x["author_name"].ToString() + "</br>";
                }
                return s;
            }
        }

        public static DataTable Query(string query)
        {
            using (MySqlConnection connect = new MySqlConnection(GetConnectionString()))
            {
                connect.Open();
                
                MySqlCommand command = connect.CreateCommand();
                command.CommandText = query;

                



                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "test");
           return ds.Tables["test"];  }
           
        }
        public static int CountRaws(string query)
        {
            using (MySqlConnection connect = new MySqlConnection(GetConnectionString()))
            {connect.Open();
                
                MySqlCommand command = connect.CreateCommand();
                command.CommandText = query;
 return Convert.ToInt32(command.ExecuteScalar());
                
            }
           
        }
        public static string GetThesisFile(int id)
        {
            var dc = new PortalDataContextDataContext();
            var prtlThesisTranslation = dc.Prtl_Thesis_Translations.SingleOrDefault(x => x.ID == id);
            if (prtlThesisTranslation.Prtl_Thesi.FileName != null)
            {
                var query = prtlThesisTranslation.Prtl_Thesi.FileName;
                return query;
            }
            else
            {
                return "";
            }
        }

        public static Prtl_Thesi GetThesisByID(int ID)
        {
            return new PortalDataContextDataContext().Prtl_Thesis.SingleOrDefault(x => x.ID == ID);
        }

        public static int insertSuperVisor(string name)
        {
            var dc = new PortalDataContextDataContext();
            {
                var supervisor = new Prtl_ThesisSUPERVISOR();
                supervisor.SuperName = name;
                dc.Prtl_ThesisSUPERVISORs.InsertOnSubmit(supervisor);
                dc.SubmitChanges();
                return supervisor.SuperId;
            }
        }
        public static void insertMapSuperVisor(int thesis, int supervisor)
        {
            var dc = new PortalDataContextDataContext();
            {
                var super = new Prtl_ThesisMapSupervisor();
                super.ThesisId = thesis;
                super.SuperId = supervisor;
                dc.Prtl_ThesisMapSupervisors.InsertOnSubmit(super);
                dc.SubmitChanges();
            }
        }

        public static int insertSuper(string name)
        {
            var dc = new PortalDataContextDataContext();
            {
                var super = new Prtl_ThesisSuper();
                super.SuperName = name;
                dc.Prtl_ThesisSupers.InsertOnSubmit(super);
                dc.SubmitChanges();
                return super.ID;
            }
        }

        public static void insertMapSuper(int thesis, int supervisor)
        {
            var dc = new PortalDataContextDataContext();
            {
                var super = new Prtl_ThesisMapSuper()
                {
                    ThesisId = thesis,
                    SuperId = supervisor
                };
                dc.Prtl_ThesisMapSupers.InsertOnSubmit(super);
                dc.SubmitChanges();
            }
        }

        //public static int insertThesis(Guid owner, bool studyType, DateTime RegistrationDate, bool ResearchType, DateTime DisscusionDate,
        //                                 string  lang,string studentName ,string Address,string Summary,string Specialisim,string  ResearchPlan)
        //{
        //    var dc = new PortalDataContextDataContext();
        //    {
        //        var thesis = new Prtl_Thesi();
        //        thesis.Owner_ID = owner;
        //        thesis.StudyTypee = studyType;
        //        thesis.RegistrationDate = RegistrationDate;
        //        thesis.ResearchType = ResearchType;
        //        thesis.DisscusionDate = DisscusionDate;
        //        dc.Prtl_Thesis.InsertOnSubmit(thesis);
        //        dc.SubmitChanges();

        //       int l=Convert .ToInt32 ((from x in dc.prtl_Languages where x.LCID ==lang select x).SingleOrDefault ().Lang_Id  );
        //        var thesisTrans = new Prtl_Thesis_Translation();

        //        if( lang=="ar"){

        //        thesisTrans.Lang_Id = l ;
        //        }
        //        else
        //        {
        //            thesisTrans.Lang_Id = 2; 
        //        }


        //        thesisTrans.StudentName = studentName;
        //        thesisTrans.Address = Address;
        //        thesisTrans.Summary = Summary;
        //        thesisTrans.Specialisim = Specialisim;
        //        thesisTrans.ResearchPlan = ResearchPlan;
        //        thesisTrans.Thesis_ID = thesis.ID;
        //        //dc.Prtl_Thesis_Translations.InsertOnSubmit(thesisTrans);
        //        //dc.SubmitChanges();


        //        return thesis.ID;
        //    }
        //}



        public static void insertThesisTrans(int thesisID, int lang, string studentName, string Address, string Summary, string Specialisim, string ResearchPlan)
        {

            var dc = new PortalDataContextDataContext();
            {


                var thesisTrans = new Prtl_Thesis_Translation();

                thesisTrans.StudentName = studentName;
                thesisTrans.Address = Address;
                thesisTrans.Summary = Summary;
                thesisTrans.Specialisim = Specialisim;
                thesisTrans.ResearchPlan = ResearchPlan;
                thesisTrans.Thesis_ID = thesisID;
                dc.Prtl_Thesis_Translations.InsertOnSubmit(thesisTrans);
                dc.SubmitChanges();
            }
        }
        public static int insertThesis(DetailsViewInsertEventArgs e, string filteredproperty, Guid owner, bool studyType, DateTime RegistrationDate, bool ResearchType, DateTime DisscusionDate,
                                        string lang, string studentName, string Address, string Summary, string Specialisim, string ResearchPlan
            , string FileName)
        {
            var dc = new PortalDataContextDataContext();
            {
                var thesis = new Prtl_Thesi();
                thesis.Owner_ID = owner;
                thesis.StudyTypee = studyType;
                thesis.RegistrationDate = RegistrationDate;
                thesis.ResearchType = ResearchType;
                thesis.DisscusionDate = DisscusionDate;
                thesis.FileName = FileName;
                dc.Prtl_Thesis.InsertOnSubmit(thesis);
                dc.SubmitChanges();

                //int l = Convert.ToInt32((from x in dc.prtl_Languages where x.LCID == lang select x).SingleOrDefault().Lang_Id);
                //var thesisTrans = new Prtl_Thesis_Translation();

                //if (lang == "ar")
                //{

                //    thesisTrans.Lang_Id = l;
                //}
                //else
                //{
                //    thesisTrans.Lang_Id = 2;
                //}


                //thesisTrans.StudentName = studentName;
                //thesisTrans.Address = Address;
                // thesisTrans.Summary = Summary;
                // thesisTrans.Specialisim = Specialisim;
                // thesisTrans.ResearchPlan = ResearchPlan;
                //thesisTrans.Thesis_ID = thesis.ID;
                //dc.Prtl_Thesis_Translations.InsertOnSubmit(thesisTrans);
                //dc.SubmitChanges();
                e.Values[filteredproperty] = thesis.ID;

                return thesis.ID;
            }
        }

        public static int GetCountTranslations(string id)
        {
            return new PortalDataContextDataContext().Prtl_Thesis_Translations.Count(tr => tr.Thesis_ID.ToString() == id.ToString());
        }
        public static void UpdateSupervisor(int thesisID, string s, string s1, string s2, string s3, string s4)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSupervisor> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId == thesisID select x).ToList();

                List<Prtl_ThesisSUPERVISOR> thesisSupervisors = new List<Prtl_ThesisSUPERVISOR>();
                foreach (Prtl_ThesisMapSupervisor c in mapSupers)
                {
                    thesisSupervisors.Add(
                        (from c1 in dc.Prtl_ThesisSUPERVISORs where c1.SuperId == c.SuperId select c1).SingleOrDefault());
                }
                thesisSupervisors[0].SuperName = s;
                thesisSupervisors[1].SuperName = s1;
                thesisSupervisors[2].SuperName = s2;
                thesisSupervisors[3].SuperName = s3;
                thesisSupervisors[4].SuperName = s4;

                dc.SubmitChanges();


            }
        }

        public static void UpdateSuper(int thesisID, string s, string s1, string s2, string s3, string s4)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSuper> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupers where x.ThesisId == thesisID select x).ToList();

                List<Prtl_ThesisSuper> thesisSupers = new List<Prtl_ThesisSuper>();
                foreach (Prtl_ThesisMapSuper c in mapSupers)
                {
                    thesisSupers.Add(
                        (from c1 in dc.Prtl_ThesisSupers where c1.ID == c.SuperId select c1).SingleOrDefault());
                }


                thesisSupers[0].SuperName = s;
                thesisSupers[1].SuperName = s1;
                thesisSupers[2].SuperName = s2;
                thesisSupers[3].SuperName = s3;
                thesisSupers[4].SuperName = s4;

                dc.SubmitChanges();

            }
        }

        public static void UpdateStudy(int thesisID, bool b)
        {
            var dc = new PortalDataContextDataContext();
            {
                Prtl_Thesi t = (from x in dc.Prtl_Thesis where x.ID == thesisID select x).SingleOrDefault();
                t.StudyTypee = b;
                dc.SubmitChanges();
            }
        }


        public static void UpdateRes(int thesisID, bool b, string FileName)
        {
            var dc = new PortalDataContextDataContext();
            {
                Prtl_Thesi t = (from x in dc.Prtl_Thesis where x.ID == thesisID select x).SingleOrDefault();
                t.ResearchType = b;
                if (FileName != null)
                {

                    string s = URLBuilder.ImageURLBase + "/uni/Portal/Thesis/" + t.FileName;//URLBuilder.GetURLIfExists3(Page, SiteFolders.Thesis ,t.FileName,  null);

                    // File .Exists( )
                    if (File.Exists(s))
                    {
                        File.Delete(s);
                        //string[] ss = Directory.GetFiles(s);
                        //if (ss.Length != 0)
                        //{
                        //    string file = Path.GetFileName(ss[0]);
                        //    string filepath = s + "\\" + file;
                        //    if (File.Exists(filepath))
                        //    {
                        //        File.Delete(filepath);
                        //    }
                        //}
                    }
                    t.FileName = FileName;
                }
                dc.SubmitChanges();
            }
        }




        //public static prtl_Article GetArticlebyMenuItemID(int ID)
        //{
        //    return new PortalDataContextDataContext();.prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID);
        //}

        //public static string GetArticleTitle(string abbr, string lcid, string noarticle)
        //{
        //    var prtlArticlesTranslation = new PortalDataContextDataContext();.prtl_Articles_Translations.SingleOrDefault(f => f.prtl_Article.Abbr == abbr && f.prtl_Language.LCID == lcid);
        //    return prtlArticlesTranslation != null ? prtlArticlesTranslation.Title : noarticle;
        //}

        //public static void InsertNewArticle(DetailsViewInsertEventArgs e, Guid? ownerid, string filteredproperty,bool published)
        //{

        //    var dc = new PortalDataContextDataContext();
        //          var newArticle = new prtl_Article {Owner_ID = ownerid};
        //    dc.prtl_Articles.InsertOnSubmit(newArticle);
        //    dc.SubmitChanges();
        //    e.Values[filteredproperty] = newArticle.ID;
        //    // ReSharper disable SpecifyACultureInStringConversionExplicitly
        //    newArticle.Abbr = newArticle.ID.ToString();
        //    // ReSharper restore SpecifyACultureInStringConversionExplicitly
        //    newArticle.MenuItemId = null;
        //    newArticle.Published = published;
        //    dc.SubmitChanges();
        //}


        //public static void UpdateArticleWithMenuID(int ArticleID, int MenuID)
        //{
        //    var dc = new PortalDataContextDataContext();
        //    {
        //        var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
        //        article.MenuItemId = MenuID;
        //        dc.SubmitChanges();
        //    }
        //}
        //public static void UpdateArticleWithPublish(int ArticleID, bool Published)
        //{
        //    var dc = new PortalDataContextDataContext();
        //    {
        //        var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
        //        article.Published = Published;
        //        dc.SubmitChanges();
        //    }
        //}
        //public static void UpdateArticleWithMenuTranslationID(int ArticleID, Guid MenuTranslationID)
        //{
        //    var dc = new PortalDataContextDataContext();
        //    {
        //        var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
        //        var menuId = dc.prtl_Menus.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
        //        article.MenuItemId = menuId;
        //        dc.SubmitChanges();
        //    }
        //}


    }
}