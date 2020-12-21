using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using InventoryAPI.Data.DataObjects;
using InventoryAPI.DataAccess;

namespace InventoryAPI.Data.DataAccess
{
    public static class DeliveryTime
    {

        public static List<ZipObj> GetNearestWarehouses(string zip)

        {
            var zips = new List<ZipObj>();

            try
            {
                // Build connection string
                var helper = new HelperClass();
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(helper.Builder.ConnectionString))
                {
                    connection.Open();
                    zips = (List<ZipObj>)connection.Query<ZipObj>("exec inventory.spGetNearestWarehouses @zip_code", new { zip_code = zip });
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

