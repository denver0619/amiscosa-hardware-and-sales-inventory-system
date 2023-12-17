namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public class Transaction : ITransaction
    {
        public string TransactionID { get; set; } = null!;
        public string TransactionDate { get; set; } = null!;
        public string StaffID { get; set; } = null!;
        public string CustomerID { get; set; } = null!;
        public bool IsInvalid { get; set; }
    }
}
