namespace Mis_DAL
{
    public static class Info
    {
        public static string WebConfigConnectionString
        {
            get
            {
                var webconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                return webconfig.ConnectionStrings.ConnectionStrings["MisConnectionString"].ConnectionString;
            }
        }
    }

    public partial class MisDataContext
    {
        public MisDataContext() :
            this(Info.WebConfigConnectionString, mappingSource)
        {
        }
    }
}