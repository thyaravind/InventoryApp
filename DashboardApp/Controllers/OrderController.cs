using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DashboardApp.DataAccess;
using InventoryApp.Models;

namespace DashboardApp.Controllers
{
    [RoutePrefix("Order")]
    public class OrderController : Controller







    {
        public ActionResult Index()
        {

            return View ();
        }
        
        [Route("~/orders2/{warehouseID}")]
        public ActionResult Orders2(int warehouseID)
        {
            OrdersList ordersListRetrieved = GetOrders.GetOrdersList3(warehouseID);

            var output = ordersListRetrieved.Orders;

            return View ("~/Views/Order/Orders.cshtml");
        }

        [Route("OrdersByWarehouse/{id}")]
        public ActionResult OrdersByWarehouse(int id)
        {
            OrdersList ordersListRetrieved = GetOrders.GetOrdersList3(id);

            var output = ordersListRetrieved.Orders;

            return View ("Orders",model:output);
        }


        [HttpPost]
        public ActionResult RederDetail(string OrderId)
        {
            Order CurrentOrder = GetOrders.GetCurrentOrder(int.Parse(OrderId));

            return PartialView("_DetailChamber", CurrentOrder);
        }
        
    }
}
