using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents customer information implementing the ICustomer interface.
    /// </summary>
    public class Customer : ICustomer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with specified details.
        /// </summary>
        /// <param name="customerID">The unique identifier for the customer.</param>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="middleName">The middle name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="address">The address of the customer.</param>
        /// <param name="contact">The contact information of the customer.</param>
        public Customer(string customerID, string firstName, string middleName, string lastName, string address, string contact)
        {
            CustomerID = customerID;
            CustomerFName = firstName;
            CustomerMName = middleName;
            CustomerLName = lastName;
            CustomerAddress = address;
            CustomerContact = contact;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class using another customer's information.
        /// </summary>
        /// <param name="customer">An object implementing the ICustomer interface from which to copy information.</param>
        public Customer(ICustomer customer)
        {
            CustomerID = customer.CustomerID;
            CustomerFName = customer.CustomerFName;
            CustomerMName = customer.CustomerMName;
            CustomerLName = customer.CustomerLName;
            CustomerAddress = customer.CustomerAddress;
            CustomerContact = customer.CustomerContact;
        }
        [Required]
        public string? CustomerID { get; set; }
        [Required]
        public string? CustomerFName { get; set; }
        [Required]
        public string? CustomerMName { get; set; }
        [Required]
        public string? CustomerLName { get; set; }
        [Required]
        public string? CustomerAddress { get; set; }
        [Required]
        public string? CustomerContact { get; set; }
    }
}
