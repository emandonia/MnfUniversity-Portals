using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class prtl_SecResUtillity
    {
        public static int  Insert_Stf_Research_Fields(int Stf_Id,string auther, string coresearch, string title, string jour, string vol,string num,string pagen,string year,string absa,string abse,string filename)
        {

            PortalDataContextDataContext d1 = new PortalDataContextDataContext();
            try
            {
                Prtl_SecntificResearch x = new Prtl_SecntificResearch()
                {
                    AuthorName =auther ,
                    Staff_ID  = Stf_Id,
                    Co_Authors  = coresearch ,
                    Title  = title ,
                    Journal = jour,
                    Volume  = vol ,
                    Number =num ,
                    pageNum =pagen ,
                    Year =year ,
                    abstract_ar =absa ,
                    abstract_en =abse ,
                    Files = filename
                };
                d1.Prtl_SecntificResearches .InsertOnSubmit(x);
                d1.SubmitChanges();
                return x.ID  ;
            }
            catch
            {
                return 0 ;
            }

        }

        public static void Update(int id,string auther, string coresearch, string title, string jour, string vol, string num, string pagen, string year ,string absa,string abse )
        {
            var dc = new PortalDataContextDataContext();
            {
                var user = (from x in dc.Prtl_SecntificResearches 
                            where x.ID  == id
                            select x).SingleOrDefault();
                if (user != null)
                {
                    user.AuthorName  = auther ;
                    user.Co_Authors  = coresearch ;
                    user.Title = title;
                    user.Journal = jour;
                    user.Volume = vol;
                    user.Number = num;
                    user.pageNum = pagen;
                    user.Year = year;
                    user.abstract_ar = absa;
                    user.abstract_en = abse;
                    //  user.Files = filename;
                }
                dc.SubmitChanges();

                //get all roles for this user
                
            }
        }
    }
}