using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class Manufacturer : IManufacturer
    {
        public Manufacturer(string manufacturerID, string name, string contact, string address)
        {
            ManufacturerID = manufacturerID;
            ManufacturerName = name;
            ManufacturerContact = contact;
            ManufacturerAddress = address;
        }

        public Manufacturer(IManufacturer manufacturer)
        {
            ManufacturerID = manufacturer.ManufacturerID;
            ManufacturerName = manufacturer.ManufacturerName;
            ManufacturerContact = manufacturer.ManufacturerContact;
            ManufacturerAddress = manufacturer.ManufacturerAddress;
        }

        [Required]
        public string? ManufacturerID { get; set; }
        [Required]
        public string? ManufacturerName { get; set; }
        [Required]
        public string? ManufacturerContact { get; set; }
        [Required]
        public string? ManufacturerAddress { get; set; }
    }
}
