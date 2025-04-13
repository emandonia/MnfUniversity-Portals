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
    public partial class CouncilHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if(s=="Publication")
            {
                Label1.Visible = true;
                Label1.Text=(string) GetLocalResourceObject("CouncilHome_Page_Load_tet");
            }else
            {
                Label1.Visible = false;
            }

        }
    }
}