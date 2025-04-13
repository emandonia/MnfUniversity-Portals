using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using MnfUniversity_Portals.BLL.Portal_BLL;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class FileAbstractsViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* var  query = Prtl_StaffAbstractUtility.GetAbstractInfo(StaticUtilities.Currentlanguage(Page),
                                                                 OwnerID);
            AbstractsListView.DataSource = query;
            AbstractsListView.DataBind();*/

        }
        protected Guid? OwnerID
        {
            get { return StaticUtilities.OwnerID(Page); }
        }

        protected string FileAbstractUrl(object eval)
        {
           return  URLBuilder.GetURLIfExists(Page, SiteFolders.Abstracts, 
                                     eval+"");
        }
    }
}