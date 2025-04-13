using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class ControlUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DynamicDataManager1.RegisterControl(ListView1);
        }
    }
}