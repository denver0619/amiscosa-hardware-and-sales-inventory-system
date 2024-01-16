using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    public class TransactionModel
    {
        public List<Customer>? CustomerList { get; set; }
        public List<ProductDataTransferObject>? ProductList { get; set; }

        public Transaction? Transaction { get; set; }
        public List<TransactionDetail>? TransactionDetails { get; set; }
    }
}
