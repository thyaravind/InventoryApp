using System.Collections.Generic;
using DashboardApp.Models;

namespace DashboardApp.Models
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
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryType { get; set; }
        public string DeliveryPartner { get; set; }
    }
}