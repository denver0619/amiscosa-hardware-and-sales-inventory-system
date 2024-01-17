using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class TransactionDetail : ITransactionDetail
    {
        public TransactionDetail() { }  
        public TransactionDetail(string transactionDetailID, string transactionID, string productID, int quantity)
        {
            TransactionDetailID = transactionDetailID;
            TransactionID = transactionID;
            ProductID = productID;
            Quantity = quantity;
        }
        public TransactionDetail (ITransactionDetail transactionDetail)
        {
            TransactionID = transactionDetail.TransactionID;
            TransactionDetailID = transactionDetail.TransactionID;
            ProductID = transactionDetail.ProductID;
            Quantity = transactionDetail.Quantity;
        } 

        public string? TransactionDetailID { get; set; }

        public string? TransactionID { get; set; }
        [Required]
        public string? ProductID { get; set; }
        public int Quantity { get; set; }
    }
}