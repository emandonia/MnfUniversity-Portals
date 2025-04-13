using System;
using System.Linq;
using App_Code;
using Portal_DAL;

namespace MnfUniversity_Portals.UI.Admin
{
    public partial class LoggingViewer : PageBase
    {
        protected void handlesearch(object sender, EventArgs e)
        {
            using (var dc = new PortalDataContextDataContext())
            {
                var userIDs =
                    (from x in dc.prtl_OwnersAdminUsers
                     where x.Owner_ID == Drop1.GetFilteredOwner_ID
                     select x.User_ID).ToList();

                var users = userIDs.Select(x => (from c in dc.aspnet_Users where c.UserId == x select c).SingleOrDefault()).ToList();

                UsersDropDown.DataSource = users;
                UsersDropDown.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void viewlistview(object sender, EventArgs e)
        {
            if (UsersDropDown.SelectedValue != "")
            {
                LoggingViewer1.FilterOwnerID = Guid.Parse(UsersDropDown.SelectedValue);
                LoggingViewer1.ListViewControl.DataBind();
                LoggingViewer1.Visible = true;
            }
        }
    }
}