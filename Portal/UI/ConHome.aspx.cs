using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class ConHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button555_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/News/" + StaticUtilities.Currentlanguage(Page));
        }
    }
}