using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using InventoryApp.Models;

namespace InventoryApp.Controllers

{   [RoutePrefix("product2")]
    //[Route({"action=index"})]
    public class Product2Controller : Controller
    {

        //route using route table
        
        public ActionResult Index()
        {
            var product = new Product {ProductName = "test test",Price = 50};
            ViewBag.Product = product;
            return View();
        }

        //route using route attributes

        [Route("~/Collections")]
        public ActionResult Collections()
        {
            return View("Collections");
        }


        [Route("home")]
        public ActionResult Home()
        {
            return RedirectToAction("Index","Home");
        }

        [Route("product")]
        public ActionResult Product(Product product)
        {
            return View(product);
        }


    }
}
