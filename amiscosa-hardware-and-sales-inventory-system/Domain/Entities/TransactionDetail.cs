using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents a transaction detail implementing the ITransactionDetail interface.
    /// </summary>
    public class TransactionDetail : ITransactionDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetail"/> class.
        /// </summary>
        public TransactionDetail() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetail"/> class with specified details.
        /// </summary>
        /// <param name="transactionDetailID">The unique identifier for the transaction detail.</param>
        /// <param name="transactionID">The identifier of the transaction associated with the detail.</param>
        /// <param name="productID">The identifier of the product associated with the detail.</param>
        /// <param name="quantity">The quantity of the product in the transaction detail.</param>
        public TransactionDetail(string transactionDetailID, string transactionID, string productID, int quantity)
        {
            TransactionDetailID = transactionDetailID;
            TransactionID = transactionID;
            ProductID = productID;
            Quantity = quantity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetail"/> class using another transaction detail's information.
        /// </summary>
        /// <param name="transactionDetail">An object implementing the ITransactionDetail interface from which to copy information.</param>
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