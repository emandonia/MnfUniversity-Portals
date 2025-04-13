using System;
using System.Collections.Generic;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_OwnerAdminUsersUtility
    {
        public static IQueryable<Guid> GetUserIDsInOwner(Guid OwnerID)
        {
            return new PortalDataContextDataContext().prtl_OwnersAdminUsers.Where(u => u.Owner_ID == OwnerID).Select(u => u.User_ID);
        }

        public static List<Guid?> GetUserOwnerIDs(string userName)
        {
            var ownersIDs = new List<Guid?>();
            if (string.IsNullOrEmpty(userName))
                return ownersIDs;
            var user = new PortalDataContextDataContext().aspnet_Users.SingleOrDefault(x => x.UserName == userName);

            var prtlOwnersAdminUser = new PortalDataContextDataContext().prtl_OwnersAdminUsers.SingleOrDefault(x => user != null && x.User_ID == user.UserId);
            if (prtlOwnersAdminUser != null)
            {
                ownersIDs.Add(prtlOwnersAdminUser.Owner_ID);
                ownersIDs.AddRange(prtlOwnersAdminUser.prtl_Owner.prtl_Owners.Select(prtlOwner => prtlOwner.Owner_ID).Select(dummy => (Guid?)dummy));
            }
            return ownersIDs;
        }
        public static Guid GetUserIdByOwnerId(Guid OwnerId)
        {
            var prtlOwnersAdminUser = new PortalDataContextDataContext().prtl_OwnersAdminUsers.SingleOrDefault(x => x.Owner_ID == OwnerId);

            return
                prtlOwnersAdminUser.
                    User_ID;

        }
    }

}