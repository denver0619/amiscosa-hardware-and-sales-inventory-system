﻿using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Models
{
    public class TransactionModel
    {
        public List<Customer>? CustomerList { get; set; }
        public List<Product>? ProductList { get; set; }
    }
}