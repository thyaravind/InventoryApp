using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DashboardApp.DataAccess;
using InventoryApp.Models;

namespace DashboardApp.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Details(int id)
        {
            return View ();
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
        
        public ActionResult Edit(int id)
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

        public ActionResult Delete(int id)
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


        [Route("~/orde/{warehouseID}")]
        public async Task<ActionResult> Order3Async(int warehouseID)
        {
            OrdersList ordersListRetrieved = await GetOrders.GetOrdersList(warehouseID);

            var output = ordersListRetrieved.Orders;

            return View(output);
        }

    }
}