using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents a transaction implementing the ITransaction interface.
    /// </summary>
    public class Transaction : ITransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        public Transaction() {
            TransactionDate = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class with specified details.
        /// </summary>
        /// <param name="transactionID">The unique identifier for the transaction.</param>
        /// <param name="transactionDate">The date and time of the transaction.</param>
        /// <param name="staffID">The identifier of the staff member associated with the transaction.</param>
        /// <param name="customerID">The identifier of the customer associated with the transaction.</param>
        /// <param name="isInvalid">A flag indicating whether the transaction is invalid.</param>
        public Transaction(string transactionID, DateTime transactionDate, string staffID, string customerID, bool isInvalid)
        {
            TransactionID = transactionID;
            TransactionDate = transactionDate;
            StaffID = staffID;
            CustomerID = customerID;
            IsInvalid = isInvalid;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class using another transaction's information.
        /// </summary>
        /// <param name="transaction">An object implementing the ITransaction interface from which to copy information.</param>
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
