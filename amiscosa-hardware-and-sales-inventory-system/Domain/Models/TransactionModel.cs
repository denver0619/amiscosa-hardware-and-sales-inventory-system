using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    /// <summary>
    /// Represents a model for managing transactions.
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// Gets or sets the list of customers.
        /// </summary>
        public List<Customer>? CustomerList { get; set; }

        /// <summary>
        /// Gets or sets the list of products.
        /// </summary>
        public List<ProductDataTransferObject>? ProductList { get; set; }

        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        public Transaction? Transaction { get; set; }

        /// <summary>
        /// Gets or sets the list of transaction details.
        /// </summary>
        public List<TransactionDetail>? TransactionDetails { get; set; }
    }
}
