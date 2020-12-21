using System.Web.Mvc;

namespace DashboardApp.Filters
{
    public class CustomExceptionHandler: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var path = filterContext.HttpContext.Server.MapPath("/Views/Shared/500.html");
            var bytes = System.IO.File.ReadAllBytes(path);
            filterContext.Result = new FileContentResult(bytes,"text/html");
            filterContext.ExceptionHandled = true;
        }
    }
}