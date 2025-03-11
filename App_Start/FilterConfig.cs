using System.Web;
using System.Web.Mvc;

namespace sscgi_emsigner_webhook
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
