namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public interface ITransactionDetail
    {
        public string? TransactionDetailID { get; set; }
        public string? TransactionID { get; set; }
        public string? ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
