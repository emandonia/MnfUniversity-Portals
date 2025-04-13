using System;
using App_Code;
using MisBLL;

namespace MnfUniversity_Portals.UI
{
    public partial class StaffHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //decimal id= Staff_Utility. getStaffIDByUserName(Page.User.Identity.Name);
                //  LinqDataSource1.Where = "SA_STF_MEMBER_ID == " + id;
                //  ListView1.DataBind();
            }
        }
    }
}