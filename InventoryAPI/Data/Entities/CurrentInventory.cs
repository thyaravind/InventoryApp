#nullable disable

namespace InventoryAPI.Data.Entities
{
    public partial class CurrentInventory
    {
        public byte WarehouseId { get; set; }
        public string Sku { get; set; }
        public short? Stock { get; set; }

        public virtual Product SkuNavigation { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
