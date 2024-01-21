using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    /// <summary>
    /// Represents a model for managing transaction history.
    /// </summary>
    public class TransactionHistoryModel
    {
        /// <summary>
        /// Gets or sets the list of transactions.
        /// </summary>
        public List<Transaction>? TransactionList { get; set; }
    }
}
