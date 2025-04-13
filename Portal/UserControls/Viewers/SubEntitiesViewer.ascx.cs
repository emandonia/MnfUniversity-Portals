using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;
using Resources;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class SubEntitiesViewer : ViewersBase
    {
        public string Label
        {
            get
            {
                switch (StaticUtilities.GetOwnerType(URLBuilder.OwnerAbbr(Page.RouteData)))
                {
                    case OwnerTypes.University:
                        return GlobalStrings.Faculties;
                    case OwnerTypes.Faculty:
                        return GlobalStrings.Departments;
                    case OwnerTypes.Department:
                        break;
                    case OwnerTypes.Subjects:
                        break;
                    case OwnerTypes.Staff:
                        break;

                    case OwnerTypes.Sectors:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["__ASYNCPOST"] != "true")
            {

                FillSubOwners();
            }
        }
        protected string HomeURL(object abbr)
        {
            return URLBuilder.SubHomeURL(abbr.ToString(), Page);
        }
        protected string LogoPath(object abbr)
        {
            return URLBuilder.GetURLIfExists(Page, SiteFolders.Owners_Logos, abbr.ToString());
        }
        public bool IsVisible
        {
            get { return SubownersShow.Panels.Count != 0; }

        }
        public string ParentDisplayStyle
        {
            get { return IsVisible ? "inline" : "none"; }
        }
        private void FillSubOwners()
        {
            IEnumerable<prtl_Translation> subownersTranslations =
            Prtl_OwnersUtility.GetAllSubOwnerNamesAndAbbrs2(StaticUtilities.Currentlanguage(Page),
            URLBuilder.OwnerAbbr(Page.RouteData));
            //rptList.DataSource = subownersTranslations;
            //rptList.DataBind();
            StaticUtilities.FillShow(subownersTranslations, SubownersShow,
            c =>
            {
                var image = new Image
                {
                    ImageAlign = ImageAlign.Middle,
                    ImageUrl = LogoPath(c.prtl_Owner.Abbr)
                };
                var hyperlink = new HyperLink { NavigateUrl = HomeURL(c.prtl_Owner.Abbr) };
                hyperlink.Controls.Add(image);
                return hyperlink;
            },
            z => new HtmlGenericControl("br"),
            y => new HyperLink { Text = y.Translation_Data, NavigateUrl = HomeURL(y.prtl_Owner.Abbr) }
            );
           
        }

    }
}