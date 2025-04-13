using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGoHome_Click(object sender, EventArgs e)
        {
            // Redirect to the homepage or any page you want
            Response.Redirect("~/");
        }

    }
}