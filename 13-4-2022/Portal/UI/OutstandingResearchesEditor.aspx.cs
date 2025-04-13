using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using Common;

namespace MnfUniversity_Portals.UI
{
    public partial class OutstandingResearchesEditor : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                //LinqDataSource1.Where = "Faculty == " + URLBuilder.CurrentFacID(Page.RouteData);
                //GridView1.DataBind();
           
        }

      

       

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
            GridView1.DataBind();
        }
    }
}