using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal_DAL;

namespace Al_Arabia.controls
{
    public partial class ConsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                var x = new PortalDataContextDataContext ();
                List<Con> xx = (from c in x.Advs    orderby c.ordered   descending  select c).Take (1).ToList();
                NewsListView.DataSource = xx;
                NewsListView.DataBind();
            //}
        }
        protected bool getVisible()
        {
           // string lang = (Convert.ToString(Session["lang"])).ToLower();
            if ((Session["lang"])==null || (Convert.ToString(Session["lang"])).ToLower() == "ar")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool getVisible2()
        {
            string lang = (Convert.ToString(Session["lang"])).ToLower();
            if (lang == "en")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}