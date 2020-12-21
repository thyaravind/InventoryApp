using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DashboardApp.DataAccess;
using DashboardApp.Models;


namespace DashboardApp.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        public ActionResult Index(string status)
        {

            var ProductList = new List<Product>();
            Tuple<List<Product>, string> tuple;
            tuple = new Tuple<List<Product>, string>(ProductList, status);
            return View (tuple);
        }


        [Route("Products/{Sku}")]
        [Route("Products")]
        public ActionResult Products(string Sku)

        {
            Tuple<List<Product>, Product> tuple;
            List<Product> ProductsList = ProductAccess.GetAllProducts();

            var CurrentProductIndex = 0;
            try
            {
                CurrentProductIndex = ProductsList.FindIndex(a => a.Sku == Sku);
            }
            catch
            {
                CurrentProductIndex = 0;
            }

            if (CurrentProductIndex == -1)
            {
                CurrentProductIndex = 0;
            }
            tuple = new Tuple<List<Product>, Product>(ProductsList, ProductsList[CurrentProductIndex]);

            return View("~/Views/Product/Products.cshtml", model: tuple);
        }



        public ActionResult ProductsInitial()

        {
            Tuple<List<Product>, Product> tuple;
            List<Product> ProductsList = ProductAccess.GetAllProducts();

            var CurrentProductIndex = 0;

            tuple = new Tuple<List<Product>, Product>(ProductsList, ProductsList[CurrentProductIndex]);

            return View("~/Views/Product/Products2.cshtml", model: tuple);
        }


        public ActionResult Products2(string Sku)

        {
            Tuple<List<Product>, Product> tuple;
            List<Product> ProductsList = ProductAccess.GetAllProducts();

            var CurrentProductIndex = 0;
            try
            {
                CurrentProductIndex = ProductsList.FindIndex(a => a.Sku == Sku);
            }
            catch
            {
                CurrentProductIndex = 0;
            }

            tuple = new Tuple<List<Product>, Product>(ProductsList, ProductsList[CurrentProductIndex]);

            return View("~/Views/Product/Products.cshtml", model: tuple);
        }


        public ActionResult ProductForm()
        {
            
            List<Collection> CollectionList = CollectionAccess.GetAllCollections();
            var Product = new Product();
            ViewBag.Collections = CollectionList;

            return View(Product);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                string status = ProductAccess.CreateProduct(product);
                ViewBag.CreationStatus = status;

            }

            else
            {
                RedirectToAction("ProductForm");
            }

            return RedirectToAction("Status", "Product");
        }


        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Status(string status)
        {
            ViewBag.status = status;
            return View();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        [Route("Edit/{id}")]
        public ActionResult Edit(string Sku)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        [Route("Delete/{id}")]
        public ActionResult Delete(string Sku)
        {
            
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

    }

}
