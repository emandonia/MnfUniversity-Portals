using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using Common;
using MisBLL;

namespace MnfUniversity_Portals.UI
{
    public partial class LawEnglishSubjects : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListView1.DataSource = SubjectUtility.getSubjectsforLawEnglish();
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