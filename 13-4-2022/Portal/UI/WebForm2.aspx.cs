using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class WebForm2 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reading DataKeyName
            int x = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value);

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int x = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value);

        }
    }
}