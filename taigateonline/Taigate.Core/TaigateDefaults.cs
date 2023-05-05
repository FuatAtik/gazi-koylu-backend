namespace Taigate.Core
{
    public static class TaigateDefaults
    {
        /// <summary>
        /// Gets a system name of 'administrators' customer role
        /// </summary>
        public static string SearchEngineCustomerName => "SearchEngine";
        /// <summary>
        /// Gets the cookie name prefix
        /// </summary>
        public static string Prefix => ".Taigate";

        /// <summary>
        /// Gets a cookie name of the customer
        /// </summary>
        public static string CustomerCookie => ".User";
        public static string XForwardedForHeader => "X-FORWARDED-FOR";
        public static string XWafForHeader => "X-WAF-FOR";
        public static string HttpClusterHttpsHeader => "HTTP_CLUSTER_HTTPS";
        public static string HttpXForwardedProtoHeader => "X-Forwarded-Proto";
        public static string IsPostBeingDoneRequestItem => "nop.IsPOSTBeingDone";
        public static string  UrlRecordCache => "Url-Record-{0}-{1}-{2}";
        public static string  SearchTermCache => "SearchTerm-{0}-{1}-{2}";
        
    }
    
    public enum CurrentSite
    {
        DoganlarMobilya = 6,
    }
}
