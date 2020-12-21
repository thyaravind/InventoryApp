using System;
using System.Collections.Generic;
using DashboardApp.Models;

namespace DashboardApp.Models
{
    public class Collection
    {
        public Collection()
        {
            Products = new HashSet<Product>();
        }

        public short CollectionId { get; set; }
        public string Name { get; set; }
        public string CollectionDesc { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
