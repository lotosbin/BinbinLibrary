using System.Web;
using System.Web.Mvc;

namespace Samples.BinbinHttpModules.Log4Net.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}