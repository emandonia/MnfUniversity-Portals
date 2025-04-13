using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace MnfUniversity_Portals.UI
{
    public partial class LibraryHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            Session["owner_abbr"] = abbr; 
            int type = URLBuilder.CurrentOwner(Page.RouteData).Type;
            Session["ownertype"] = type;


        }


        protected void Button555_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/News/" + StaticUtilities.Currentlanguage(Page));
        }

        protected string Getmargin()
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
                return "margin-right:12px";
            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                return "margin-left:12px";
            }
            return "";
        }


        public string getImage()
        {

            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "INTMED")
            {
                return "";
            }
            else if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "PREL")
            {
                return "/Styles/University_Master/images/prel_" + StaticUtilities.Currentlanguage(Page.RouteData) + ".jpg";
            }
            else  // (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "uni_is")
            {
                return "/Styles/University_Master/images/library_" + StaticUtilities.Currentlanguage(Page.RouteData) + ".jpg";
            }


        }
    }
}