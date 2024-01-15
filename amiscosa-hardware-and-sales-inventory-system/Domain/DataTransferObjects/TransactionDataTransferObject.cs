using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects
{
    public class TransactionDataTransferObject : ITransaction
    {
        public TransactionDataTransferObject() { }
        public TransactionDataTransferObject(string transactionID, DateTime transactionDate, string staffID, string customerID, bool isInvalid)
        {
            TransactionID = transactionID;
            TransactionDate = transactionDate;
            StaffID = staffID;
            CustomerID = customerID;
            IsInvalid = isInvalid;
        }
        public TransactionDataTransferObject(ITransaction transaction)
        {
            TransactionID = transaction.TransactionID;
            TransactionDate = transaction.TransactionDate;
            StaffID = transaction.StaffID;
            CustomerID = transaction.CustomerID;
            IsInvalid = transaction.IsInvalid;
        }
        [Required]
        public string? TransactionID { get; set; }
        [Required]
        public DateTime? TransactionDate { get; set; }
        [Required]
        public string? StaffID { get; set; }
        [Required]
        public string? CustomerID { get; set; }
        [Required]
        public bool IsInvalid { get; set; }

        public Customer? Customer { get; set; }

        public User? User { get; set; }

        public List<TransactionDetail> TransactionDetails{ get; set; }
    }
}

