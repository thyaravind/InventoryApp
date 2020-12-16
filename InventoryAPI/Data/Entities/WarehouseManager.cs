#nullable disable

namespace InventoryAPI.Data.Entities
{
    public partial class WarehouseManager
    {
        public byte WarehouseId { get; set; }
        public string EmployeeId { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
