using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class Manufacturer : IManufacturer
    {
        public Manufacturer(string manufacturerID, string name, string contact, string address)
        {
            ManufacturerID = manufacturerID;
            Name = name;
            Contact = contact;
            Address = address;
        }

        [Required]
        public string? ManufacturerID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Contact { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
