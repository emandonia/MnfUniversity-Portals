using System.Collections.Generic;
using System.Linq;
using Portal_DAL;
using MnfUniversity_Portals.BLL.Portal_BLL;

namespace BLL
{
    public static class Prtl_OwnerTypesUtility
    {
        public static List<prtl_OwnerType> getOwnersTypes()
        {
            var dc = new PortalDataContextDataContext();
            {
                return dc.prtl_OwnerTypes.Select(x => x).ToList();
            }
        }
    }
}