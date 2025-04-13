using MnfUniversity_Portals.UserControls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class EventDetailsControl : ViewersBase
    {
        protected string BigImageURL(object imageName)
        {

            return URLBuilder.GetURLIfExists(Page, SiteFolders.Events, imageName + "");
        }

        protected string SmallImageURL(object imageName)
        {
            return URLBuilder.GetURLIfExists(Page, SiteFolders.Events, imageName + "");
        }
    

        
    }
}