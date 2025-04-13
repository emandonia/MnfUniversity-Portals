using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using MisBLL;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_UsersUtility
    {
        public static List<aspnet_User> GetAllAspUsers()
        {//Prtl_AspNetUtility.DisposeDC();
            return new PortalDataContextDataContext().aspnet_Users.ToList();
        }


        public static aspnet_User GetAspUser(string username)
        {
            new PortalDataContextDataContext().Refresh(RefreshMode.KeepChanges);
            return new PortalDataContextDataContext().aspnet_Users.SingleOrDefault(xx => xx.LoweredUserName == username.ToLower());
        }

        public static aspnet_User GetAspUser(Guid userid)
        {
            return new PortalDataContextDataContext().aspnet_Users.SingleOrDefault(xx => xx.UserId == userid);
        }

        public static aspnet_User GetAspUserByUserName(string username)
        {
            return new PortalDataContextDataContext().aspnet_Users.SingleOrDefault(xx => xx.UserName == username);
        }




        //public static void updateuser()
        //{
        //    MembershipUser user = Membership.GetUser("test1", false);
        //    user.ChangePassword(user.ResetPassword(), "FEE123");
        //}



        public static aspnet_Membership GetMemberShipuserByID(string userID)
        {
            return new PortalDataContextDataContext().aspnet_Memberships.SingleOrDefault(xx => xx.UserId == Guid.Parse(userID));
        }

        public static List<aspnet_Membership> GetMemberShipuserByID(Guid userID)
        {
            return (from x in new PortalDataContextDataContext().aspnet_Memberships where x.UserId == userID select x).ToList<aspnet_Membership>();
        }
        //public static void InsertNewStfMembersInOwnerAdminUsers(Guid ownerid,Guid userid)
        //{
        //    var dc = new PortalDataContextDataContext()
        //    {
        //        var u = new prtl_OwnersAdminUser { Owner_ID = ownerid, User_ID = userid };

        //        dc.prtl_OwnersAdminUsers.InsertOnSubmit(u);
        //        dc.SubmitChanges();
        //    }
            
        //}
        public static void InsertNewUserInRole(Guid roleid, Guid userid)
        {
            var dc = new PortalDataContextDataContext();
            {
                var u = new aspnet_UsersInRole { RoleId = roleid, UserId = userid };

                dc.aspnet_UsersInRoles.InsertOnSubmit(u);
                dc.SubmitChanges();
            }
        }

        public static void InsertUserInOwner(Guid ownerID, string username)
        {
            var newAdminUser = new prtl_OwnersAdminUser();

            var dc = new PortalDataContextDataContext();
            {
                newAdminUser.Owner_ID = ownerID;
                dc.prtl_OwnersAdminUsers.InsertOnSubmit(newAdminUser);
                dc.SubmitChanges();
                var singleOrDefault = GetAspUser(username);
                if (singleOrDefault != null)
                    newAdminUser.User_ID =
                        singleOrDefault.UserId;
                dc.SubmitChanges();
            }
        }

        public static void Update(string username, bool b)
        {
            var dcx = new PortalDataContextDataContext();
            {
                aspnet_User user =
                    (from x in dcx.aspnet_Users where x.UserName.ToLower() == username.ToLower() select x).
                        SingleOrDefault();
                if (user != null)
                {
                    user.LoginStatus = b;
                    dcx.SubmitChanges();
                }
            }
        }

        public static void UpdateUser(CheckBox ChkActive1, TextBox txtName, Guid gid, CheckBoxList ChekListRole)
        {
            var dc = new PortalDataContextDataContext();
            {
                var user = (from x in dc.aspnet_Users
                            where x.UserId == gid
                            select x).SingleOrDefault();
                if (user != null)
                {
                    user.UserName = txtName.Text;
                    user.LoweredUserName = txtName.Text.ToLower();
                }
                dc.SubmitChanges();

                //get all roles for this user
                var listRoles = ChekListRole.Items.Cast<ListItem>().Where(item => item.Selected).Select(
                    item => new Guid(item.Value)).ToList();

                //remove previous roles for this user
                List<aspnet_UsersInRole> removeRoles = (from x in dc.aspnet_UsersInRoles
                                                        where x.UserId == user.UserId
                                                        select x).ToList<aspnet_UsersInRole>();
                foreach (var x in removeRoles)
                {
                    dc.aspnet_UsersInRoles.DeleteOnSubmit(x);
                    dc.SubmitChanges();
                }

                //add new rols for this user
                foreach (var u in listRoles.Select(x => new aspnet_UsersInRole { RoleId = x }))
                {
                    if (user != null) u.UserId = user.UserId;
                    dc.aspnet_UsersInRoles.InsertOnSubmit(u);
                    dc.SubmitChanges();
                }

                //
                if (ChkActive1.Checked)
                {
                    //get membership for this user
                    aspnet_Membership member = (from x in dc.aspnet_Memberships
                                                where x.UserId == gid
                                                select x).SingleOrDefault();
                    if (member != null) member.IsLockedOut = false;
                    dc.SubmitChanges();
                }
                else
                {
                    //get membership for this user
                    aspnet_Membership member = (from x in dc.aspnet_Memberships
                                                where x.UserId == gid
                                                select x).SingleOrDefault();
                    if (member != null) member.IsLockedOut = true;
                    dc.SubmitChanges();
                }
            }
        }
    }
}