#nullable disable

namespace InventoryAPI.Data.Entities
{
    public partial class ProductDescription
    {
        public string Sku { get; set; }
        public string ProductDesc { get; set; }
        public string ProductHighlights { get; set; }

        public virtual Product SkuNavigation { get; set; }
    }
}
