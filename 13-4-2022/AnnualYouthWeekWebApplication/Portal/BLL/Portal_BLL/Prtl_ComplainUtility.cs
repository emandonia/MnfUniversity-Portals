using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Web.UI.WebControls;
using Common;
using Portal_DAL;
using System.Data;
using System.Data.SqlClient;
namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class Prtl_ComplainUtility
    {
        
        public static int insert_Nt_Damage_Report(int facid, string EngName,string date, string Informer,
            string Damage, string fixing, string Notes)
        {
            try
            {
                var dc = new PortalDataContextDataContext();

                Prtl_Nt_Damage_Report ntDamageReport = new Prtl_Nt_Damage_Report
                {
                    Fac_Id = facid,
                    EngineerName = EngName,
                    Date = date,
                    Informer = Informer,
                    Damage = Damage,
                    Fixing = fixing,
                    Notes = Notes

                };
                dc.Prtl_Nt_Damage_Reports.InsertOnSubmit(ntDamageReport);
                dc.SubmitChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public static string getFac(int fac_id)
        {
            var dc = new PortalDataContextDataContext();
            var q =
                dc.prtl_Translations.SingleOrDefault(x => x.prtl_Owner.ID == fac_id && x.Lang_Id == 1).Translation_Data;
            return q;
        }


        public static object GetNtReportByID(int R_ID)
        {
            var dc = new PortalDataContextDataContext();
            var q = (from x in dc.Prtl_Nt_Damage_Reports
                where x.ID == R_ID
                select new
                {
                    ID = x.ID,
                    EngineerName = x.EngineerName,
                    Damage = x.Damage,
                    Date = x.Date,
                    Informer = x.Informer,
                    Fixing = x.Fixing,
                    Notes = x.Notes,
                    Fac = getFac(x.Fac_Id)

                });
            return q;

        }

        public static IEnumerable<object> GetNtReportsByFac(int Fac_ID)
        {
            var dc = new PortalDataContextDataContext();
            var q =  (from x in dc.Prtl_Nt_Damage_Reports
                where x.Fac_Id == Fac_ID
                select new 
                {
                    ID = x.ID,
                    EngineerName = x.EngineerName,
                    Damage = x.Damage,
                    Date = x.Date,
                    Informer = x.Informer,
                    Fixing = x.Fixing,
                    Notes = x.Notes,
                    Fac = getFac(x.Fac_Id)

                });
            return q;

        }
        public static Prtl_FacultiesEmail getfacemail(string ownerid)
        {

            var dc = new PortalDataContextDataContext();
            var q = dc.Prtl_FacultiesEmails.SingleOrDefault(x => x.Owner_Id.ToString() == ownerid);
            return q;

        }
       
        public static void Insert(string name, string mob, string mail, string comp, Guid currentOwner)
        {

            var dc = new PortalDataContextDataContext();
            var Complain = new Prtl_Complain
            {
                Text = comp,
                comp_date = DateTime.Now,
                Owner_ID = currentOwner
            };
            dc.Prtl_Complains.InsertOnSubmit(Complain);
            dc.SubmitChanges();
            var ComplainAns = new Prtl_Complain_An
            {
                Comps_Id = Complain.Comps_Id
            };
            dc.Prtl_Complain_Ans.InsertOnSubmit(ComplainAns);
            dc.SubmitChanges();
            
            var Complainant = new Prtl_Complainant
            {
                Email = mail,
                Mobile = mob,
                Name = name,
                owner_ID = currentOwner

            };

            dc.Prtl_Complainants.InsertOnSubmit(Complainant);
            dc.SubmitChanges();


            var Comp_Comp = new Prtl_Comp_Comp
            {
                Comp_Id = Complainant.com_ID,
                Comps_Id = Complain.Comps_Id

            };

            dc.Prtl_Comp_Comps.InsertOnSubmit(Comp_Comp);
            dc.SubmitChanges();


        }

        public static void InsertForEmp(string name, string mob, string mail, string comp, Guid currentOwner ,bool  a,int   type)
        {

            var dc = new PortalDataContextDataContext();
            var Complain = new Prtl_Complain
            {
                Text = comp,
                comp_date = DateTime.Now,
                Owner_ID = currentOwner,
                Area =a,
                type =type 
            };
            dc.Prtl_Complains.InsertOnSubmit(Complain);
            dc.SubmitChanges();
            var ComplainAns = new Prtl_Complain_An
            {
                Comps_Id = Complain.Comps_Id
            };
            dc.Prtl_Complain_Ans.InsertOnSubmit(ComplainAns);
            dc.SubmitChanges();

            var Complainant = new Prtl_Complainant
            {
                Email = mail,
                Mobile = mob,
                Name = name,
                owner_ID = currentOwner

            };

            dc.Prtl_Complainants.InsertOnSubmit(Complainant);
            dc.SubmitChanges();


            var Comp_Comp = new Prtl_Comp_Comp
            {
                Comp_Id = Complainant.com_ID,
                Comps_Id = Complain.Comps_Id

            };

            dc.Prtl_Comp_Comps.InsertOnSubmit(Comp_Comp);
            dc.SubmitChanges();


        }

        //public static string getComplainantByCompsID(int compsid, Guid owner)
        //{
        //    var dc = new PortalDataContextDataContext();
        //    var s = (from x in dc.Prtl_Comp_Comps where x.Comps_Id == compsid select x).SingleOrDefault().Comp_Id;
        //    var c = (from x in dc.Prtl_Complainants where x.com_ID == s && x.owner_ID == owner select x).SingleOrDefault().Email;

        //    return c;
        //}

        public static string getComplainantByCompsID(string compsid)
        {
            var dc = new PortalDataContextDataContext();
            var s = (from x in dc.Prtl_Comp_Comps where x.Comps_Id.ToString() == compsid select x).SingleOrDefault().Comp_Id;
            var c = (from x in dc.Prtl_Complainants where x.com_ID == s select x).SingleOrDefault().Email;

            return c;
        }

        public static string getTextComplain(int compsid)
        {
            var dc = new PortalDataContextDataContext();
            var s = (from x in dc.Prtl_Comp_Comps where x.Comps_Id == compsid select x).SingleOrDefault().Comp_Id;
            var c = (from x in dc.Prtl_Complains  where x.Comps_Id  == s select x).SingleOrDefault().Text ;

            return c;
        }


        public static void Insertreplay(string replay, string compsid)
        {

            var dc = new PortalDataContextDataContext();
            var ComplainAns = new Prtl_Complain_An
            {
                Replay = replay,
                Comps_Id = Convert.ToInt32(compsid),
                Replay_date = DateTime.Now

            };

            dc.Prtl_Complain_Ans.InsertOnSubmit(ComplainAns);
            dc.SubmitChanges();
        }


        public static void insert_SendToDrDate(string complainId){

            var dc = new PortalDataContextDataContext();

            var q = dc.Prtl_Complain_Ans.SingleOrDefault(x => x.Comps_Id.ToString() == complainId);
            q.SendToDrDate=DateTime.Now;
            
            dc.SubmitChanges();
        }
        public static void insert_SendToClientDate(string complainId)
        {

            var dc = new PortalDataContextDataContext();

            var q = dc.Prtl_Complain_Ans.SingleOrDefault(x => x.Comps_Id.ToString()== complainId);
            q.SendToClientDate = DateTime.Now;
            
            dc.SubmitChanges();
        }
         public static void insert_DrAnswerDate(string complainId){

            var dc = new PortalDataContextDataContext();

            var q = dc.Prtl_Complain_Ans.SingleOrDefault(x => x.Comps_Id.ToString() == complainId);
            q.DrAnswerDate=DateTime.Now;
            
            dc.SubmitChanges();
        }
        public static void insertReplay2(string replay, string drName, string complainId)
        {

            var dc = new PortalDataContextDataContext();
            var q=dc.Prtl_Complain_Ans.SingleOrDefault(x=>x.Comps_Id.ToString()==complainId);
            if(q==null){
            var ComplainAns = new Prtl_Complain_An
            {
                Replay = replay,
                Comps_Id = Convert.ToInt32(complainId),
                Replay_date = DateTime.Now,
                Dr_Name=drName

            };

            dc.Prtl_Complain_Ans.InsertOnSubmit(ComplainAns);
            dc.SubmitChanges();
            }else{
                q.Replay = replay;
                 q.Comps_Id = Convert.ToInt32(complainId);
                 q.Replay_date = DateTime.Now;
                 q.Dr_Name=drName;
                dc.SubmitChanges();

            }
        }





        public static Prtl_Complain GetComplainByID(string id)
        {
            var dc = new PortalDataContextDataContext();
            var q = dc.Prtl_Complains.SingleOrDefault(x=>x.Comps_Id.ToString()==id);
            return q;
        }
        public static Prtl_Complain_An GetComplainAnsByID(string id)
        {
            var dc = new PortalDataContextDataContext();
            var q = dc.Prtl_Complain_Ans.SingleOrDefault(x=>x.Comps_Id.ToString()==id);
            return q;
        }
        public static object GetCompByID(string id)
        {
            var dc = new PortalDataContextDataContext();
            var q = (from x in dc.Prtl_Complain_Ans
                     where x.Prtl_Complain.Comps_Id.ToString() == id
                     select new
                     {

                         Text = x.Prtl_Complain.Text,
                         Replay = x.Replay,
                         CompDate = x.Prtl_Complain.comp_date,
                         RepDate = x.Replay_date,
                         Name = x.Prtl_Complain.Prtl_Comp_Comps.SingleOrDefault(xx => xx.Prtl_Complainant.com_ID == xx.Comp_Id).Prtl_Complainant.Name,
                         Email = x.Prtl_Complain.Prtl_Comp_Comps.SingleOrDefault(xx => xx.Prtl_Complainant.com_ID == xx.Comp_Id).Prtl_Complainant.Email,
                         Mobile = x.Prtl_Complain.Prtl_Comp_Comps.SingleOrDefault(xx => xx.Prtl_Complainant.com_ID == xx.Comp_Id).Prtl_Complainant.Mobile
                        
                     });
            return q;
        }


        public static object GetCompByOwnerID(Guid ownerid)
        {
            var dc = new PortalDataContextDataContext();
            var q = (from x in dc.Prtl_Comp_Comps
                     where x.Prtl_Complain.Owner_ID == ownerid
                     select new
                     {

                         Text = x.Prtl_Complain.Text,
                         Replay = x.Prtl_Complain.Prtl_Complain_Ans.SingleOrDefault(xx => xx.Comps_Id==x.Comps_Id).Replay,
                         CompDate =StaticUtilities.FormatDate( x.Prtl_Complain.comp_date),
                         RepDate = StaticUtilities.FormatDate(x.Prtl_Complain.Prtl_Complain_Ans.SingleOrDefault(xx => xx.Comps_Id == x.Comps_Id).Replay_date),
                         Name = x.Prtl_Complain.Prtl_Comp_Comps.SingleOrDefault(xx => xx.Prtl_Complainant.com_ID == xx.Comp_Id).Prtl_Complainant.Name,
                         Email = x.Prtl_Complain.Prtl_Comp_Comps.SingleOrDefault(xx => xx.Prtl_Complainant.com_ID == xx.Comp_Id).Prtl_Complainant.Email,
                         Mobile = x.Prtl_Complain.Prtl_Comp_Comps.SingleOrDefault(xx => xx.Prtl_Complainant.com_ID == xx.Comp_Id).Prtl_Complainant.Mobile,
                         SendToDrDate = StaticUtilities.FormatDate(x.Prtl_Complain.Prtl_Complain_Ans.SingleOrDefault(xx => xx.Comps_Id == x.Comps_Id).SendToDrDate),
                         DrAnswerDate = StaticUtilities.FormatDate(x.Prtl_Complain.Prtl_Complain_Ans.SingleOrDefault(xx => xx.Comps_Id == x.Comps_Id).DrAnswerDate),
                         DrName = x.Prtl_Complain.Prtl_Complain_Ans.SingleOrDefault(xx => xx.Comps_Id == x.Comps_Id).Dr_Name,
                         SendToClientDate = StaticUtilities.FormatDate(x.Prtl_Complain.Prtl_Complain_Ans.SingleOrDefault(xx => xx.Comps_Id == x.Comps_Id).SendToClientDate),
                         Comps_Id = x.Comps_Id

                     });
            return q;
           
        }

        
    }
       
}