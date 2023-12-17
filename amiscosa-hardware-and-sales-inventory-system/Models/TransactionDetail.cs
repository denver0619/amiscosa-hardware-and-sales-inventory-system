using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public class TransactionDetail : ITransactionDetail
    {
        public TransactionDetail(string transactionDetailID, string transactionID, string productID, int quantity)
        {
            TransactionDetailID = transactionDetailID;
            TransactionID = transactionID;
            ProductID = productID;
            Quantity = quantity;
        }
        [Required]
        public string? TransactionDetailID { get; set; }
        [Required]
        public string? TransactionID { get; set; }
        [Required]
        public string? ProductID { get; set; }
        public int Quantity { get; set; }
    }
}