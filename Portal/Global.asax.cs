using System;
using Mis_DAL;
using Portal_DAL;

namespace MnfUniversity_Portals
{
    
    public partial class Global : System.Web.HttpApplication
    {
        public static MisDataContext M_dc;
        //public static PortalDataContextDataContext P_dc;

        //protected void Application_Start(object sender, EventArgs e)
        //{
        //    P_dc = new PortalDataContextDataContext()
        //    M_dc = new MisDataContext();
        //}

        //protected void Application_End(object sender, EventArgs e)
        //{
        //    P_dc.Dispose();
        //    M_dc.Dispose();
        //}
    }
}