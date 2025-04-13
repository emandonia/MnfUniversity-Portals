using System;
using Common;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class AdminMenu : Base.ViewersBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Menu.Build(MenuMode.Normal);

            }
        }
    }
}