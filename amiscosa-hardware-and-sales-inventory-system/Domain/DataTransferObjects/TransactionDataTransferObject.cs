using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects
{
    public class TransactionDataTransferObject
    {
        public TransactionDataTransferObject() { }
        public Transaction? TransactionData { get; set; }
        public List<TransactionDetail>? TransactionDetails { get; set; }
    }
}

