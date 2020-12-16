using System.Collections.Generic;

namespace InventoryAPI.Data.Entities
{
    public class Order
    {
        public string OrderId { get; set; }
        public int NumberOfProducts { get; set; }
        public List<Product> Products { get; set; }
        public string Street { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}