using System;
using App_Code;
using BLL;
using Common;
using MisBLL;

namespace MnfUniversity_Portals.UI
{
    public partial class DepSubjects : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string parent = URLBuilder.CurrentFacAbbr(Page.RouteData);
            string DepAbbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (DepAbbr != null)
            {

                ListView1.DataSource = SubjectUtility.GetSubjectsByDepID(Prtl_OwnersUtility.getDepIDByAbbr(parent, DepAbbr), Prtl_OwnersUtility.getFacIDByAbbr(parent));
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