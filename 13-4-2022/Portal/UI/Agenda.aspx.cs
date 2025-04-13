using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class Calender : PageBase


    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //e.Cell.ToolTip = "jjjjjj";
            string url = e.SelectUrl;
            e.Cell.Controls.Clear();
            HyperLink link = new HyperLink();
            link.Text = e.Day.Date.Day.ToString();

            link.NavigateUrl = url;
            e.Cell.Controls.Add(link);
            DateTime x = new DateTime(2013, 12, 25);
            DateTime x1 = new DateTime(2013, 12, 10);
            if (x == e.Day.Date)
            {
                link.ToolTip = "test";
            }
            if (x1 == e.Day.Date)
            {
                link.ToolTip = "test2";
            }
        }
    }
}