using System;
using System.Data.SqlClient;
using Dapper;
using InventoryAPI.Data.Entities;

namespace InventoryAPI.DataAccess.DataAccess
{
    public static class StockData
    {

        public static int GetStock(int id)


        {
            var stock = new Stock();    

            try
            {
                // Build connection string
                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    stock.stock =  connection.QueryFirst<int>("exec spGetStock @ProductID",new {ProductID = id});

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return stock.stock;


            /*
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection("Server = localhost; Database = Inventory; User Id = SA; Password = kingMAKER1015@;"))
            {
                return connection.QueryFirst<Stock>($"select CollectionID from products where id = {ID}");
            }
            */

        }
    }
}
