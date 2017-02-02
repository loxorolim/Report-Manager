using System.Web.Configuration;

namespace ReportManager.Commons
{
    public static class Constants
    {
        public static readonly string ReportConnectionString = WebConfigurationManager.AppSettings["ReportDatabase"];
        
    }
}
