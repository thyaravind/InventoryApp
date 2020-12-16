using System.Collections;

namespace InventoryApp.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string Collection { get; set; }
        
        public int Price { get; set; }

        public Product()
        {
            this.ProductName = "test product";
            this.ProductDesc = "test product desc";
            this.Collection = "test collection";
        }

    }
}