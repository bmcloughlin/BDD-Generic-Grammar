using System.Collections.Generic;

namespace V1.TestAutomation.Common
{
    public sealed class RouteCache
    {
        public static readonly Dictionary<string, string> Routes;

        static RouteCache()
        {
            Routes = new Dictionary<string, string>
            {
                {"Register User", "http://localhost:52442/Account/Register"}
            };
        }

        public static bool TryGetUrl(string key, out string url)
        {
            return Routes.TryGetValue(key, out url);
        }

    }
}
