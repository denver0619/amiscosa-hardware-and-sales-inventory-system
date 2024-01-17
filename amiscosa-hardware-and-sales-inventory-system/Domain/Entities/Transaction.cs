using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{

    public class Transaction : ITransaction
    {
        public Transaction() {
            TransactionDate = DateTime.Now;
        }
        public Transaction(string transactionID, DateTime transactionDate, string staffID, string customerID, bool isInvalid)
        {
            TransactionID = transactionID;
            TransactionDate = transactionDate;
            StaffID = staffID;
            CustomerID = customerID;
            IsInvalid = isInvalid;
        }
        public Transaction(ITransaction transaction)
        {
            TransactionID = transaction.TransactionID;
            TransactionDate = transaction.TransactionDate;
            StaffID = transaction.StaffID;
            CustomerID = transaction.CustomerID;
            IsInvalid = transaction.IsInvalid;
        }

        public string? TransactionID { get; set; }

        public DateTime? TransactionDate { get; set; } = DateTime.Now;
        [Required]
        public string? StaffID { get; set; }
        [Required]
        public string? CustomerID { get; set; }
        [Required]
        public bool IsInvalid { get; set; }
    }

    internal class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
