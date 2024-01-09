using Microsoft.VisualBasic;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public interface ITransaction
    {
        public string? TransactionID { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? StaffID { get; set; }
        public string? CustomerID { get; set; }
        public bool IsInvalid { get; set; }
    }
}
