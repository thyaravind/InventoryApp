using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace InventoryAPI.DataAccess.DataAccess
{
    public class DeliveryTime
    {

        public static IEnumerable<int> GetFastestDeliveryTime(int zip)


        {
            int id = zip;


            try
            {
                // Build connection string
                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    var zips = connection.Query<int>("exec inventory.spGetWarehouseByRegion @regionID", new { regionID = id });
                    return zips;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;

        }
        
        
    }
}