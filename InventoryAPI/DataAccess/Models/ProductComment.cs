using System;
using System.Collections.Generic;

#nullable disable

namespace modelscaffold.Model
{
    public partial class ProductComment
    {
        public string Sku { get; set; }
        public int? UserId { get; set; }
        public string ProductComment1 { get; set; }

        public virtual Product SkuNavigation { get; set; }
    }
}
