using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DashboardApp.DataAccess;
using DashboardApp.Models;

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

        [Route("OrdersByWarehouse/{id}/{OrderId}")]
        [Route("OrdersByWarehouse/{id}")]
        public ActionResult OrdersByWarehouse(int id,string OrderId)
            
        {
            Tuple<List<Order>, Order> tuple;
            List <Order> OrdersList = GetOrders.GetOrdersList3(id).Orders;



            var CurrentOrderIndex = 0;
            try
            {
                CurrentOrderIndex = OrdersList.FindIndex(a => a.OrderId == OrderId);
            }

            catch
            {
                CurrentOrderIndex = 0;
            }
            
            if(CurrentOrderIndex == -1)
            {
                CurrentOrderIndex = 0;
            }
            
            tuple = new Tuple<List<Order>, Order>(OrdersList, OrdersList[CurrentOrderIndex]);
            
            return View ("Orders",model:tuple);
        }


        [Route("RenderDetail/{OrderId}")]
        [HttpGet]
        public ActionResult RederDetail(string OrderId)
        {
            Order CurrentOrder = GetOrders.GetCurrentOrder2(int.Parse(OrderId));

            return PartialView("_DetailChamber", CurrentOrder);
        }
        
    }
}
