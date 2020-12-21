using System;
using System.Collections.Generic;

namespace InventoryAPI.Data.DataObjects
{
    public class DeliveryOptionsRequestObj
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Product
        {
            public string productSKU { get; set; }
            public string quantity { get; set; }
        }

        public class FastestDeliveryRequest
        {
            public string zipCode { get; set; }
            public List<Product> products { get; set; }
        }


    }
}
