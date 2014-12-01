using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace V1.TestAutomation.Common
{
    public sealed class RouteCache
    {
        public static readonly Dictionary<string, string> Routes;
        public static string ApplicationRoot;

        static RouteCache()
        {
            ApplicationRoot = ConfigurationManager.AppSettings["applicationRoot"];
            var json = File.ReadAllText(@"routes.json");
            Routes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static bool TryGetUrl(string key, out string url)
        {
            if (Routes.TryGetValue(key, out url))
            {
                url = ApplicationRoot + url;
                
            }
            else
            {
                url = key;
            }

            return true;
        }

    }
}
