using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    /// <summary>
    /// Represents a model containing a list of customers.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Gets or sets the list of customers.
        /// </summary>
        public List<Customer>? CustomerList { get; set; }
    }
}
