using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    public class InventoryModel
    {
        public List<ProductDataTransferObject>? ProductList { get; set; }
    }
}
