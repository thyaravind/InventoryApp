using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using DashboardApp.Controllers;
using DashboardApp.Models;

namespace DashboardApp.DataAccess
{
    public static class ProductAccess
    {



        public static string CreateProduct(Product product)
        {
            var status = "";
            try
            {

                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    connection.Query("exec inventory.spCreateProduct @Sku, @Name, @CollectionId, @Gtin, @Price, @Description, @Highlights, @stock ", new {Sku = product.Sku,Name = product.Name,CollectionId = product.CollectionId,Gtin = product.Gtin, Price = product.Price, Description = product.Description, Highlights = product.Highlights, stock = product.CurrentStock  });

                    status = "Product created successfully";


                }
            }
            catch (SqlException e)
            {
                status = e.ToString();
            }

            

            return status;


        }



        public static List<Product> GetAllProducts()
        {

            List<Product> products = new List<Product>();
            try
            {
 
                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    var productsRetrieved = connection.Query<Product>("exec inventory.spGetAllProducts");
                    products = (List<Product>)productsRetrieved;
                }
            }
            catch (SqlException e)
            {
                _ = e.ToString();
            }

            
            
            return (products);

        }

    }
}
