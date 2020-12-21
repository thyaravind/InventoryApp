using System.Web.Mvc;

namespace DashboardApp.Filters
{
    public class CrawlBlocker : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Browser.Crawler)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}