using System.Linq;
using System.Web.Mvc;
using InventoryApp.Filters;

namespace InventoryApp
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