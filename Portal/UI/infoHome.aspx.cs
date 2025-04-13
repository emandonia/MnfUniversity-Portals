using App_Code;
using Common;
using MnfUniversity_Portals.Base_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class infoHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string getImage()
        {

            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "infor")
            {
                return "/Styles/University_Master/images/10721445_876929532317496_225504342_n.jpg";
            }
            else  // (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "uni_is")
            {
                return "/Styles/University_Master/images/InfoNtworks.jpg";
            }


        }

    }

}