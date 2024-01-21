using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents a product implementing the IProduct interface.
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified details.
        /// </summary>
        /// <param name="productID">The unique identifier for the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="productDescription">The description of the product.</param>
        /// <param name="unitPrice">The unit price of the product.</param>
        /// <param name="quantity">The available quantity of the product.</param>
        /// <param name="manufacturerID">The identifier of the manufacturer of the product.</param>
        /// <param name="measurement">The measurement unit of the product.</param>
        /// <param name="isAvailable">A flag indicating the availability of the product.</param>
        /// <param name="unitCost">The unit cost of the product.</param>
        public Product(string productID, string productName, string productDescription, double unitPrice, int quantity, string manufacturerID, string measurement, bool isAvailable, double unitCost)
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
        /// Initializes a new instance of the <see cref="Product"/> class using another product's information.
        /// </summary>
        /// <param name="product">An object implementing the IProduct interface from which to copy information.</param>
        public Product(IProduct product)
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
    }
}
