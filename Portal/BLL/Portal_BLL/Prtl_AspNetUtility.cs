using System.Collections.Generic;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_AspNetUtility
    {
        public static List<Portal_DAL.aspnet_Role> GetAllRoles()
        {
            return new PortalDataContextDataContext().aspnet_Roles.Where(r => !r.LoweredRoleName.Contains("co")).ToList();
        }
    }
}