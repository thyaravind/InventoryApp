using System.Collections.Generic;

namespace InventoryAPI.Data.Entities
{
    public class OrdersList
    {

        public List<Order> Orders { get; set; }
        public string status { get; set; }
        
    }
}