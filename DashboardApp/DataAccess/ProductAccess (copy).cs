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
                    string insertQuery = @"INSERT INTO [inventory].[products]([SKU], [Name], [CollectionID], [GTIN], [price]) VALUES (@Sku, @Name, @CollectionId, @Gtin, @Price)";

                    var result = connection.Execute(insertQuery, product);

                    string insertQuery2 = @"INSERT INTO [inventory].[productDescription]([SKU], [ProductDesc], [ProductHighlights]) VALUES (@Sku, @Description, @Highlights)";

                    var result2 = connection.Execute(insertQuery2, product);


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
