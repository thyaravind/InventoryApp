using System.Data.SqlClient;

namespace InventoryAPI.DataAccess
{
    public class HelperClass
    {
        public SqlConnectionStringBuilder Builder { get; private set; }


        public HelperClass()
        {
            Builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                UserID = "sa",
                Password = "********",
                InitialCatalog = "Inventory"
            };
 
        }


    }
    
}
