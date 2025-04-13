using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using App_Code;
using BLL;
using Common;
namespace MnfUniversity_Portals.UI
{
    public partial class AllUni_Rss : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RssService CallWebService = new RssService();

                HyperLink HyperLink1 = (HyperLink)FormView2.FindControl("HyperLink1");
                HyperLink HyperLink2 = (HyperLink)FormView2.FindControl("HyperLink2");
                HyperLink HyperLink3 = (HyperLink)FormView2.FindControl("HyperLink3");
                HyperLink HyperLink4 = (HyperLink)FormView2.FindControl("HyperLink4");
                HyperLink HyperLink5 = (HyperLink)FormView2.FindControl("HyperLink5");
                HyperLink HyperLink6 = (HyperLink)FormView2.FindControl("HyperLink6");
                HyperLink HyperLink7 = (HyperLink)FormView2.FindControl("HyperLink7");
                HyperLink HyperLink8 = (HyperLink)FormView2.FindControl("HyperLink8");
                HyperLink HyperLink9 = (HyperLink)FormView2.FindControl("HyperLink9");
                HyperLink HyperLink10 = (HyperLink)FormView2.FindControl("HyperLink10");
                HyperLink HyperLink11 = (HyperLink)FormView2.FindControl("HyperLink11");
                HyperLink HyperLink12 = (HyperLink)FormView2.FindControl("HyperLink12");
                HyperLink HyperLink13 = (HyperLink)FormView2.FindControl("HyperLink13");
                HyperLink HyperLink14 = (HyperLink)FormView2.FindControl("HyperLink14");
                HyperLink HyperLink15 = (HyperLink)FormView2.FindControl("HyperLink15");
                HyperLink HyperLink16 = (HyperLink)FormView2.FindControl("HyperLink16");
                HyperLink HyperLink17 = (HyperLink)FormView2.FindControl("HyperLink17");
                HyperLink HyperLink18 = (HyperLink)FormView2.FindControl("HyperLink18");
                HyperLink HyperLink19 = (HyperLink)FormView2.FindControl("HyperLink19");
                HyperLink HyperLink20 = (HyperLink)FormView2.FindControl("HyperLink20");
                HyperLink HyperLink21 = (HyperLink)FormView2.FindControl("HyperLink21");
                HyperLink HyperLink22 = (HyperLink)FormView2.FindControl("HyperLink22");

                HyperLink1.NavigateUrl = CallWebService.getRssNews(1, StaticUtilities.Currentlanguage(Page .RouteData ));
                HyperLink2.NavigateUrl = CallWebService.getRssNews(2, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink3.NavigateUrl = CallWebService.getRssNews(3, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink4.NavigateUrl = CallWebService.getRssNews(4, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink5.NavigateUrl = CallWebService.getRssNews(5, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink6.NavigateUrl = CallWebService.getRssNews(6, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink7.NavigateUrl = CallWebService.getRssNews(7, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink8.NavigateUrl = CallWebService.getRssNews(8, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink9.NavigateUrl = CallWebService.getRssNews(9, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink10.NavigateUrl = CallWebService.getRssNews(10, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink11.NavigateUrl = CallWebService.getRssNews(11, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink12.NavigateUrl = CallWebService.getRssNews(12, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink13.NavigateUrl = CallWebService.getRssNews(13, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink14.NavigateUrl = CallWebService.getRssNews(14, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink15.NavigateUrl = CallWebService.getRssNews(15, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink16.NavigateUrl = CallWebService.getRssNews(16, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink17.NavigateUrl = CallWebService.getRssNews(17, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink18.NavigateUrl = CallWebService.getRssNews(18, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink19.NavigateUrl = CallWebService.getRssNews(19, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink20.NavigateUrl = CallWebService.getRssNews(20, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink21.NavigateUrl = CallWebService.getRssNews(21, StaticUtilities.Currentlanguage(Page.RouteData));
                HyperLink22.NavigateUrl = CallWebService.getRssNews(22, StaticUtilities.Currentlanguage(Page.RouteData));
            
            }

        }



        
    }
}