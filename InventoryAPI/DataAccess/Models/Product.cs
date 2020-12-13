using System;
using System.Collections.Generic;

#nullable disable

namespace modelscaffold.Model
{
    public partial class Product
    {
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public short? CollectionId { get; set; }
        public string Gtin { get; set; }
        public short? Price { get; set; }

        public virtual Collection Collection { get; set; }
    }
}
