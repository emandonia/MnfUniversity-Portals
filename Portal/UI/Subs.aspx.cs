using System;
using App_Code;
using BLL;
using Common;

namespace MnfUniversity_Portals.UI
{
    public partial class Subs : PageBase
    {
        protected string HomeURL(object abbr)
        {
            return URLBuilder.SubHomeURL(abbr.ToString(), Page);
        }

        protected string LogoPath(object abbr)
        {
            return URLBuilder.GetURLIfExists(this, SiteFolders.Owners_Logos, abbr.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var subownersTranslations =
                Prtl_OwnersUtility.GetAllSubOwnerNamesAndAbbrs(StaticUtilities.Currentlanguage(Page),
                                                               URLBuilder.OwnerAbbr(RouteData));
            ListView1.DataSource = subownersTranslations;
            ListView1.DataBind();
        }
    }
}