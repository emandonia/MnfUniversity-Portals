using System;
using App_Code;
using Common;

namespace MnfUniversity_Portals
{
    public partial class _Default : PageBase
    {


        protected string HomeURL(string lcid)
        {
            var homepage = "Home";
            switch ((OwnerTypes)CurrentOwner.Type)
            {
                case OwnerTypes.University:
                case OwnerTypes.Faculty:
                case OwnerTypes.SMagazines:
                case OwnerTypes.Department:
                case OwnerTypes.PostPrograms:
                case OwnerTypes.PostDep:
                    break;
                case OwnerTypes.Staff:
                    homepage = "StaffDetails/1";
                    break;
                case OwnerTypes.Subjects:
                    homepage = "SubjectHome";
                    break;
                case OwnerTypes.PostSubjects:
                    homepage = "PostSubHome";
                    break;
                case OwnerTypes.Council:
                    homepage = "CouncilHome";
                    break;
                case OwnerTypes.Sectors:
                    homepage = "SectorsHome";
                    break;
                case OwnerTypes.QualityUnits:
                    homepage = "QualityHome";
                    break;
                case OwnerTypes.Stratigies:
                    homepage = "StratHome";
                    break;
                case OwnerTypes.ItUnits:
                    homepage = "ItUnitHome";
                    break;
                
                case OwnerTypes.Library :
                    homepage = "LibraryHome";
                    break;
                case OwnerTypes.SPecial_Unit:
                    homepage = "SUHome";
                    break;
                case OwnerTypes.infor :
                    homepage = "infoHome";
                    break;
                case OwnerTypes.Css :
                    homepage = "CssHome";
                    break;
                case OwnerTypes.caamu:
                    homepage = "CaamuHome";
                    break;
                case OwnerTypes.cedo:
                    homepage = "CedoHome";
                    break;
                case OwnerTypes.ResProg:
                    homepage = "ResProgHome";
                    break;
                case OwnerTypes.Fourm :
                    homepage = "ConHome";
                    break;
                case OwnerTypes.Festival :
                    homepage = "FestalHome";
                    break;
            }

            return URLBuilder.URLFormat(URLBuilder.OwnerPath(Page), homepage, lcid);
        }
        protected override void OnPreInit(EventArgs e)
        {
            int type = URLBuilder.CurrentOwner(Page.RouteData).Type;
            Session["ownertype"] = type;
            Response.Redirect("~/" + HomeURL("ar"),true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}