using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects
{
    /// <summary>
    /// Data transfer object for transaction information, including the main transaction and associated details.
    /// </summary>
    public class TransactionDataTransferObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDataTransferObject"/> class.
        /// </summary>
        public TransactionDataTransferObject() { }

        /// <summary>
        /// Gets or sets the main transaction information.
        /// </summary>
        public Transaction? TransactionData { get; set; }

        /// <summary>
        /// Gets or sets the list of transaction details associated with the main transaction.
        /// </summary>
        public List<TransactionDetail>? TransactionDetails { get; set; }
    }
}

