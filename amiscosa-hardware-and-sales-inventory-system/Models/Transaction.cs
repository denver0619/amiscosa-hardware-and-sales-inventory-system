using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    public class Transaction : ITransaction
    {
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
