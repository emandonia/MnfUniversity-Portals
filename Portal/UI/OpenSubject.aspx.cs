using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using MisBLL;
namespace MnfUniversity_Portals.UI
{
    public partial class OpenSubject : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListView1.DataSource = SubjectUtility.getSubjectsforLawOpen();
                ListView1.DataBind();
            }
        }
        protected string getSubjectUrl(object eval)
        {
            string uniabbr = "http://" + Request.Url.Authority;
            var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
            var lang = CurrentLanguage;

            string url = uniabbr + "/" + FacAbbr + "/SUB_" + eval + "/SubjectHome/" + lang;
            return url;
        }
    }
}