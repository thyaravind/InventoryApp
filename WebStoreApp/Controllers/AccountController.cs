using System.Web.Mvc;
using InventoryApp.Filters;

namespace InventoryApp.Controllers
{
    public class AccountController : Controller
    {
        // GET
        [Authorize]
        [CrawlBlocker]
        [CustomActionFilter]
        public ActionResult Index()
        {
            return View();
        }
        
        
        [CustomExceptionHandler]
        public ActionResult CustomException()
        {

            throw new System.Exception();
            return View();
        }
    }
}