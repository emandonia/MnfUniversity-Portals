using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;

namespace MnfUniversity_Portals.UI
{
    public partial class SMagHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            StaticUtilities.ChooseMaster(Page);
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


    }
}