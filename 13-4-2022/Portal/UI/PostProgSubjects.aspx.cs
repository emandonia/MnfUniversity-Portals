using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.BLL.MIS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class PostProgSubjects : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string parent = URLBuilder.CurrentFacAbbr(Page.RouteData);
            string DepAbbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (DepAbbr != null)
            {
                if (parent.ToLower() == "ART".ToLower()  || parent.ToLower() == "ENG".ToLower() || parent.ToLower() == "SCI".ToLower())
                {




                    ListView1.DataSource = PostSubject_Utility.GetSubjectsByDepID2(Prtl_OwnersUtility.getDepIDByAbbr(parent, DepAbbr));
                    ListView1.DataBind();

                }
                else
                {
                    ListView1.DataSource = PostSubject_Utility.GetSubjectsByDepID(Prtl_OwnersUtility.getDepIDByAbbr(parent, DepAbbr));
                    ListView1.DataBind();
                }
            }
        }

        protected string getSubjectUrl(object eval)
        {
            string uniabbr = "http://" + Request.Url.Authority;
            var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
            var lang = CurrentLanguage;

            string url = uniabbr + "/" + FacAbbr + "/PostSUB_" + eval + "/PostSubHome/" + lang;
            return url;
        }
    }
}