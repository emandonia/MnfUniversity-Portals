using App_Code;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class SUHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (BannerViewer == "ar")
            //{
            //    return "margin-right:12px";
            //}
            //else if (StaticUtilities.Currentlanguage(Page) == "en")
            //{
            //    return "margin-left:12px";
            //}
            //return "";

        }
        public string getImage()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "NTRC")
            {
                return "/Styles/University_Master/images/speciaUnits2_";
            }
            else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "INTMED")
            {
                return "/Styles/University_Master/images/INTMED_";
            }
            else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData).ToLower()  == "sif")
            {
                return "/Styles/University_Master/images/SIF_";
            }
            else
            {
                return "/Styles/University_Master/images/speciaUnits_";
            }
                
            
            
        }
        protected void Button555_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/News/" + StaticUtilities.Currentlanguage(Page));
        }

    }
}