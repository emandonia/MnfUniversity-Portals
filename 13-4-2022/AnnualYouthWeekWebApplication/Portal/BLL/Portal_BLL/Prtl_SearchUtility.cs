using System;
using System.Collections;
using System.Collections.Generic;

using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using App_Code;
using MnfUniversity_Portals.UI;

using Portal_DAL;
namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class Prtl_SearchUtility
    {

        
        public object SearchArticles(string SearchString,string lang,Guid OwnerId)
        {


            var dc = new PortalDataContextDataContext();
            var langg = dc.prtl_Languages.Single(xx => xx.LCID == lang).Lang_Id;     
            var x = (from c in dc.prtl_Articles_Translations
                     where c.Lang_Id == langg && c.prtl_Article.Owner_ID == OwnerId
                     select new {ID=c.Article_ID,
                                 Body = dc.HighLightSearch(c.Actual_Content, SearchString,
                                           "font-weight:bold; background-color:green", 500),Title=dc.HighLightSearch(c.Title, SearchString,
                                           "font-weight:bold; background-color:green", 100)});
            return x;
        }

        public object SearchNews(string SearchString, string lang, Guid OwnerId)
        {
            //var dc = new PortalDataContextDataContext()
            //var langg = dc.prtl_Languages.Single(xx => xx.LCID == lang).Lang_Id;
            //var x = (from c in dc.prtl_News_Translations
            //         where c.Lang_Id == langg && c.prtl_New.Owner_ID == OwnerId
            //         select new
            //         {
            //             ID = c.News_Id,
            //             Body = dc.HighLightSearch(c.News_Body, SearchString,
            //                 "font-weight:bold; background-color:green", 500),
            //             Title = dc.HighLightSearch(c.News_Head, SearchString,
            //                 "font-weight:bold; background-color:green", 100)
            //         });
            //return x;
            return null;
        }




    }
}