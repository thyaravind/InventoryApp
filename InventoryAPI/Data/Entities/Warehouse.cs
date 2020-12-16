#nullable disable

namespace InventoryAPI.Data.Entities
{
    public partial class Warehouse
    {
        public byte WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public byte? RegionId { get; set; }
        public string Street { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
