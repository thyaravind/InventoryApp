using System.Linq;
using System.Web.Mvc;
using DashboardApp.Filters;

namespace DashboardApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionHandler());
            filters.Add(new CustomActionFilter());
            filters.Add(new CrawlBlocker());
        }

    }
}