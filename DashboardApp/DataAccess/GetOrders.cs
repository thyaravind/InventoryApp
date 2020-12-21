using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using DashboardApp.Controllers;
using DashboardApp.Models;

namespace DashboardApp.DataAccess
{
    public static class GetOrders
    {


        public static async Task<OrdersList> GetOrdersList(int id)
        {
            string url = "";
            var ordersList = new OrdersList();
            url = $"https://localhost:26797/api/order/{id}";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ordersList = await response.Content.ReadAsAsync<OrdersList>();
                    
                }

            }
            
            return ordersList;
        }
        
        public static  OrdersList GetOrdersList2(int id)
        {
            string url = "";
            var ordersList = new OrdersList();
            url = $"https://localhost:26797/api/order/{id}";
            using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).GetAwaiter().GetResult())
            {
                if (response.IsSuccessStatusCode)
                {
                    ordersList = response.Content.ReadAsAsync<OrdersList>().Result;
                    return ordersList;
                }

            }

            return null;

        }

        public static Order GetCurrentOrder(int orderID)
        {

            try
            {
                // Build connection string
                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    var CurrentOrder = connection.Query<Order>("exec accounts.spGetCurrentOrder @OrderID", new { OrderID = orderID });
                    return (Order)CurrentOrder;
                }
            }
            catch (SqlException e)
            {
                _ = e.ToString();
            }


            return null;

        }


        public static  OrdersList GetOrdersList3(int id)
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


        public static Order GetCurrentOrder2(int orderID)
        {
            var CurrentOrder = new Order();

            try
            {
                var helper = new HelperClass();
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    var order = connection.Query<Order>("exec accounts.spGetCurrentOrder @OrderID", new { OrderID = orderID });
                    CurrentOrder = (Order)order.ElementAt(0);

                }

            }

            catch (SqlException e)
            {
                _ = e.ToString();
            }


            return CurrentOrder;
        }
        
        
    }
}