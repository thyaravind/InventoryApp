using System.Diagnostics;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DashboardApp.Filters
{
    public class CustomActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var log = new
            {
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = filterContext.ActionDescriptor.ActionName,
                IP = filterContext.HttpContext.Request.UserHostAddress,
                DateTime = filterContext.HttpContext.Timestamp


            };
            Debug.WriteLine(JsonConvert.SerializeObject(log));
            
        }
    }
}