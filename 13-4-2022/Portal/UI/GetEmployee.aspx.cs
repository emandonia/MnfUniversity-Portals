using App_Code;
using Portal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class GetEmployee : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dc = new PortalDataContextDataContext();
                List<Prtl_Employee> emp = (from x in dc.Prtl_Employees   select x).ToList();
                GridView1.DataSource = emp;
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var dc = new PortalDataContextDataContext();
            List<Prtl_Employee> emp = (from x in dc.Prtl_Employees where x.Name.Contains(TextBox1.Text) select x).ToList();
            GridView1.DataSource = emp;
            GridView1.DataBind();
        }
    }
}