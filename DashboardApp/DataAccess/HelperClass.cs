using System.Data.SqlClient;

namespace DashboardApp.DataAccess
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
                Password = "kingMAKER0116@",
                InitialCatalog = "Inrika"
            };
 
        }


    }
    
}
