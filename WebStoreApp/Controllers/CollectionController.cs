using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class CollectionController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}