﻿using System;
using System.Collections.Generic;

#nullable disable

namespace modelscaffold.Model
{
    public partial class Collection
    {
        public Collection()
        {
            Products = new HashSet<Product>();
        }

        public short CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string CollectionDesc { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
