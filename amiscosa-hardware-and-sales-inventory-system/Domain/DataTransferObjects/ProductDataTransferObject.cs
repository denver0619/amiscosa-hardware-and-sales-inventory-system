using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects
{
    public class ProductDataTransferObject : amiscosa_hardware_and_sales_inventory_system.Domain.Entities.IProduct
    {
        public ProductDataTransferObject() { }
        public ProductDataTransferObject(string productID, string productName, string productDescription, int unitPrice, int quantity, string manufacturerID, string measurement, bool isAvailable, int unitCost)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ManufacturerID = manufacturerID;
            Measurement = measurement;
            IsAvailable = isAvailable;
            UnitCost = unitCost;
        }
        public ProductDataTransferObject(IProduct product)
        {
            ProductID = product.ProductID;
            ProductName = product.ProductName;
            ProductDescription = product.ProductDescription;
            UnitPrice = product.UnitPrice;
            Quantity = product.Quantity;
            ManufacturerID = product.ManufacturerID;
            Measurement = product.Measurement;
            IsAvailable = product.IsAvailable;
            UnitCost = product.UnitCost;
        }

        [Required]
        public string? ProductID { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? ManufacturerID { get; set; }
        public string? Measurement { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public int UnitCost { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
