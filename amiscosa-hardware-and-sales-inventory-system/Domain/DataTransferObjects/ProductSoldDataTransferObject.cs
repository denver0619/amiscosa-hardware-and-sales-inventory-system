using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects
{
    public class ProductSoldDataTransferObject: IProduct
    {
        public ProductSoldDataTransferObject() { }
        public ProductSoldDataTransferObject(string productID, string productName, string productDescription, double unitPrice, int quantity, string manufacturerID, string measurement, bool isAvailable, double unitCost)
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
        public ProductSoldDataTransferObject(IProduct product)
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
        public double UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? ManufacturerID { get; set; }
        public string? Measurement { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public double UnitCost { get; set; }

        public int ProductSold { get; set; }
        public double ProductSales { get; set; }

    }
}

