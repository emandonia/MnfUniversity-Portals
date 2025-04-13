using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;
//using BrandonHaynes.ModelAdapter;

namespace AnnualYouthWeekWebApplication
{
    public partial class CommitteControlPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (UsersUtility.getuser((string)Session["UserName"], (string)Session["Password"]).University_id == 3)
                {
                    HyperLink9.Visible = true;
                }
                else
                {
                    HyperLink9.Visible = false;
                }
            
        }

        
    }
}