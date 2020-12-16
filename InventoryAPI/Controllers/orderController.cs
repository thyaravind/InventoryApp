using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Data.Entities;
using InventoryAPI.DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using InventoryAPI.DataAccess;


namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    public class orderController : Controller
    {
        

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }
        


        [HttpGet("{id}")]
        public OrdersList Get(int id)
        {
            var ordersList = new OrdersList();    

            try
            {
                // Build connection string
                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    var orders = connection.Query<Order>("exec accounts.spGetOrders @WarehouseID", new {WarehouseID = id});
                    ordersList.Orders = (List<Order>) orders;
                }
            }
            catch (SqlException e)
            {
                ordersList.status = e.ToString();
            }

 
            
            ordersList.status = "Orders retrieved";
            return ordersList;
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
