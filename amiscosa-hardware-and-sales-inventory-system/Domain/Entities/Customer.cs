using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class Customer : ICustomer
    {
        public Customer() { }
        public Customer(string customerID, string firstName, string middleName, string lastName, string address, string contact)
        {
            CustomerID = customerID;
            CustomerFName = firstName;
            CustomerMName = middleName;
            CustomerLName = lastName;
            CustomerAddress = address;
            CustomerContact = contact;
        }
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
