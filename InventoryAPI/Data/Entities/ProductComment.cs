#nullable disable

namespace InventoryAPI.Data.Entities
{
    public partial class ProductComment
    {
        public string Sku { get; set; }
        public int? UserId { get; set; }
        public string ProductComment1 { get; set; }

        public virtual Product SkuNavigation { get; set; }
    }
}
