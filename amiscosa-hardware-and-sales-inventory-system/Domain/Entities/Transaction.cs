using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{

    public class Transaction : ITransaction
    {
        public Transaction(string transactionID, string transactionDate, string staffID, string customerID, bool isInvalid)
        {
            TransactionID = transactionID;
            TransactionDate = transactionDate;
            StaffID = staffID;
            CustomerID = customerID;
            IsInvalid = isInvalid;
        }
        [Required]
        public string? TransactionID { get; set; }
        [Required]
        public string? TransactionDate { get; set; }
        [Required]
        public string? StaffID { get; set; }
        [Required]
        public string? CustomerID { get; set; }
        [Required]
        public bool IsInvalid { get; set; }
    }
}
