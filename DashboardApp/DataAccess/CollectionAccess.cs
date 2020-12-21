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
    public static class CollectionAccess
    {



        public static string CreateCollection(Collection collection)
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

                    var result = connection.Execute(insertQuery, collection);
                    status = "Product created successfully";

                }
            }
            catch (SqlException e)
            {
                status = e.ToString();
            }

            

            return status;


        }



        public static List<Collection> GetAllCollections()
        {

            List<Collection> collections = new List<Collection>();
            try
            {
 
                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    var collectionsRetrieved = connection.Query<Collection>("exec inventory.spGetAllCollections");
                   collections = (List<Collection>)collectionsRetrieved;
                }
            }
            catch (SqlException e)
            {
                _ = e.ToString();
            }

            
            
            return (collections);

        }

    }
}
