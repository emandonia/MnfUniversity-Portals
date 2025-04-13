using System.Collections.Generic;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public class Prtl_RolesUtility
    {
        public static List<aspnet_Role> GetAllRoles()
        {
            //Prtl_AspNetUtility.DisposeDC();
            using (var dc = new PortalDataContextDataContext())
            {
                return (from x in dc.aspnet_Roles select x).ToList();
            }
        }


        public static aspnet_Role GetRole(string RoleName)
        {
            //Prtl_AspNetUtility.DisposeDC();
            using (var dc = new PortalDataContextDataContext())
            {
                return (from x in dc.aspnet_Roles where x.RoleName == RoleName select x).SingleOrDefault( );
            }
        }
    }
}