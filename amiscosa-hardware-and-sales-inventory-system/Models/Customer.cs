using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Models
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
