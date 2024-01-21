using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    /// <summary>
    /// Represents a model containing a list of product data transfer objects for inventory.
    /// </summary>
    public class InventoryModel
    {
        /// <summary>
        /// Gets or sets the list of product data transfer objects.
        /// </summary>
        public List<ProductDataTransferObject>? ProductList { get; set; }
    }
}
