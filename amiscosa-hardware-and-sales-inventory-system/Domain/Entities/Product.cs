﻿using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    public class Product : IProduct
    {
        public Product(string productID, string productName, string productDescription, int unitPrice, int quantity, string manufacturerID, string measurement, bool isAvailable, int unitCost)
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
    }
}