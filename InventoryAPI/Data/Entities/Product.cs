#nullable disable

namespace InventoryAPI.Data.Entities
{
    public partial class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public int CollectionId { get; set; }
        public string Gtin { get; set; }
        public int Price { get; set; }

        public virtual Collection Collection { get; set; }
    }
}
