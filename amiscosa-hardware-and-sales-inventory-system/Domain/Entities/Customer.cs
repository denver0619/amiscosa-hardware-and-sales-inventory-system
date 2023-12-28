using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class Customer : ICustomer
    {
        public Customer(string customerID, string firstName, string middleName, string lastName, string address, string contact)
        {
            CustomerID = customerID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Address = address;
            Contact = contact;
        }
        public Customer(ICustomer customer)
        {
            CustomerID = customer.CustomerID;
            FirstName = customer.FirstName;
            MiddleName = customer.MiddleName;
            LastName = customer.LastName;
            Address = customer.Address;
            Contact = customer.Contact;
        }
        [Required]
        public string? CustomerID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Contact { get; set; }
    }
}
