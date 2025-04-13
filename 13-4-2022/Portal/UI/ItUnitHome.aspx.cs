using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using MnfUniversity_Portals.Base_Code;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using App_Code;
using Common;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Portal_DAL;
 
namespace MnfUniversity_Portals.UI
{
    public partial class ItUnitHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
    public  string getImage()
        {

            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
        {
            return "/Styles/University_Master/images/itunits_"  ;
        }else
        {
            return "/Styles/University_Master/images/itunits2_"  ;
        }

        }
    
    }
}