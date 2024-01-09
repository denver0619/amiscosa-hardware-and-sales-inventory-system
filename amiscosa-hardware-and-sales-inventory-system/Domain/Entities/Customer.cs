using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class Customer : ICustomer
    {
        public Customer(string customerID, string firstName, string middleName, string lastName, string address, string contact)
        {
            CustomerID = customerID;
            CustomerFirstName = firstName;
            CustomerMiddleName = middleName;
            CustomerLastName = lastName;
            CustomerAddress = address;
            CustomerContact = contact;
        }
        public Customer(ICustomer customer)
        {
            CustomerID = customer.CustomerID;
            CustomerFirstName = customer.CustomerFirstName;
            CustomerMiddleName = customer.CustomerMiddleName;
            CustomerLastName = customer.CustomerLastName;
            CustomerAddress = customer.CustomerAddress;
            CustomerContact = customer.CustomerContact;
        }
        [Required]
        public string? CustomerID { get; set; }
        [Required]
        public string? CustomerFirstName { get; set; }
        [Required]
        public string? CustomerMiddleName { get; set; }
        [Required]
        public string? CustomerLastName { get; set; }
        [Required]
        public string? CustomerAddress { get; set; }
        [Required]
        public string? CustomerContact { get; set; }
    }
}
