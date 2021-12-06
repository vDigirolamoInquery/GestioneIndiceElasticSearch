using System.Configuration;

namespace FullTextElasticSearch.Utils.Classes
{
    public class AllConstants
    {
        public static string ElasticSearchDefaultServer;
        public static string ElasticSearchDefaultIndex;
        public static string ElasticSearchBasicAuthEnabled; //BDC-324
        public static string ElasticSearchBasicAuthUsername; //BDC-324
        public static string ElasticSearchBasicAuthPassword; //BDC-324
        public static string ElasticSearchDisableAutomaticProxyDetection; //BDC-338
        static AllConstants()
        {
            ElasticSearchDefaultServer = ConfigurationManager.AppSettings["ElasticSearch.DefaultServer"];
            ElasticSearchDefaultIndex = ConfigurationManager.AppSettings["ElasticSearch.DefaultIndex"];

            ElasticSearchBasicAuthEnabled = ConfigurationManager.AppSettings["ElasticSearch.BasicAuthEnabled"]; //BDC-324
            ElasticSearchBasicAuthUsername = ConfigurationManager.AppSettings["ElasticSearch.BasicAuthUsername"]; //BDC-324
            ElasticSearchBasicAuthPassword = ConfigurationManager.AppSettings["ElasticSearch.BasicAuthPassword"]; //BDC-324
            ElasticSearchDisableAutomaticProxyDetection = ConfigurationManager.AppSettings["ElasticSearch.DisableAutomaticProxyDetection"]; //BDC-338
        }
    }
}
