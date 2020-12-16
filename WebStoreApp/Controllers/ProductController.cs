using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers

{   [RoutePrefix("product")]
    //[Route({"action=index"})]
    public partial class ProductController : Controller
    {


        
        public ActionResult Index()
        {
            
            var product = new Product {ProductName = "test test",Price = 50};
            ViewBag.Product = product;
            return View();
        }


        [Route("collection/{collectionID}")]
        public ActionResult GetCollection(int collectionID)
        {
            Collection collection = null;
            using (var cnx = new WebStoreDbContext())
            {
                //collection = cnx.Collections.FirstOrDefault(c => c.CollectionID == collectionID)
                ViewBag.CollectionID = collectionID;

            }

            return View("collection");
        }



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
