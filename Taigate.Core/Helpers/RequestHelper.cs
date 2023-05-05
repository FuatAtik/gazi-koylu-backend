using System.Collections.Generic;

namespace Taigate.Core.Helpers
{
    public static class RequestHelper
    {
        public static string GetRequestPath(string path)
        {
            return path.Substring(1, path.Length - 1);
        }

        public static string[] GetDomains(string path)
        {
            if (path.Contains(",")) return path.Split(",");
            return new [] {path};
        }
    }
}