namespace Portal_DAL
{
    public static class Info
    {
        public static string WebConfigConnectionString
        {
            get
            {
                var webconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                return webconfig.ConnectionStrings.ConnectionStrings["MnfUniversityConnectionString"].ConnectionString;
            }
        }
    }

    public partial class PortalDataContextDataContext
    {
        public PortalDataContextDataContext() :
            this(Info.WebConfigConnectionString, mappingSource)

        {

        }

    }
}