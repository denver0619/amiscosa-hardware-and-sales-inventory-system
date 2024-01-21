using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects
{
    /// <summary>
    /// Data transfer object for product information.
    /// Implements the <see cref="amiscosa_hardware_and_sales_inventory_system.Domain.Entities.IProduct" /> interface.
    /// </summary>
    public class ProductDataTransferObject : amiscosa_hardware_and_sales_inventory_system.Domain.Entities.IProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDataTransferObject"/> class.
        /// </summary>
        public ProductDataTransferObject() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDataTransferObject"/> class with specified parameters.
        /// </summary>
        /// <param name="productID">The product ID.</param>
        /// <param name="productName">The product name.</param>
        /// <param name="productDescription">The product description.</param>
        /// <param name="unitPrice">The unit price of the product.</param>
        /// <param name="quantity">The quantity of the product.</param>
        /// <param name="manufacturerID">The manufacturer ID associated with the product.</param>
        /// <param name="measurement">The measurement unit of the product.</param>
        /// <param name="isAvailable">A flag indicating product availability.</param>
        /// <param name="unitCost">The unit cost of the product.</param>
        public ProductDataTransferObject(string productID, string productName, string productDescription, double unitPrice, int quantity, string manufacturerID, string measurement, bool isAvailable, double unitCost)
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDataTransferObject"/> class based on an existing product.
        /// </summary>
        /// <param name="product">The product from which to create the data transfer object.</param>
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
        public Manufacturer? Manufacturer { get; set; }
    }
}
