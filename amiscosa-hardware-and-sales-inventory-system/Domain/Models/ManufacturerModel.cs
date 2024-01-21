using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    /// <summary>
    /// Represents a model containing a list of manufacturers.
    /// </summary>
    public class ManufacturerModel
    {
        /// <summary>
        /// Gets or sets the list of manufacturers.
        /// </summary>
        public List<Manufacturer>? ManufacturerList { get; set; }
    }
}
