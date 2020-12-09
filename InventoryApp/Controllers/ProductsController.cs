using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace InventoryApp.Controllers

{   [RoutePrefix("products2")]
    //[Route({"action=index"})]
    public class ProductsController : Controller
    {

        //route using route table
        
        public ActionResult Index()
        {
            return View();
        }

        //route using route attributes

        [Route("~/collections2")]
        public ActionResult Collections()
        {
            return View("Collections");
        }


        [Route("produce")]
        public ActionResult Produce()
        {
            return RedirectToAction("Produce","Home");
        }



    }
}
