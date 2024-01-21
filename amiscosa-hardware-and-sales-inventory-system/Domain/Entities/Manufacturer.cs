using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents manufacturer information implementing the IManufacturer interface.
    /// </summary>
    public class Manufacturer : IManufacturer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer"/> class.
        /// </summary>
        public Manufacturer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer"/> class with specified details.
        /// </summary>
        /// <param name="manufacturerID">The unique identifier for the manufacturer.</param>
        /// <param name="name">The name of the manufacturer.</param>
        /// <param name="contact">The contact information of the manufacturer.</param>
        /// <param name="address">The address of the manufacturer.</param>
        public Manufacturer(string manufacturerID, string name, string contact, string address)
        {
            ManufacturerID = manufacturerID;
            ManufacturerName = name;
            ManufacturerContact = contact;
            ManufacturerAddress = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer"/> class using another manufacturer's information.
        /// </summary>
        /// <param name="manufacturer">An object implementing the IManufacturer interface from which to copy information.</param>
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
