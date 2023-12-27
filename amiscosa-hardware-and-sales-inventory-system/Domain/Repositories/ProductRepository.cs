﻿
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseHelper databaseHelper;
        private readonly string tableName = "Products";
        private readonly string tableFields = "(product_id, product_name, product_description, unit_price, quantity, manufacturer_id, measurement, is_available, unit_cost)";
        private readonly string tableAddFields = "(product_name, product_description, unit_price, quantity, manufacturer_id, measurement, is_available, unit_cost)";

        public ProductRepository()
        {
            databaseHelper = new DatabaseHelper();
        }

        public void AddProduct(Product product)
        {
            string productValues = "(" + product.ProductName + "," + product.ProductDescription + "," + product.UnitPrice + "," + product.Quantity + "," + product.ManufacturerID + "," + product.Measurement + "," + product.IsAvailable + "," + product.UnitCost +")";
            List<string> values = [productValues];
            databaseHelper.InsertRecord(tableName, tableAddFields, values);
        }

        public void DeleteProduct(Product product)
        {
            Product userData = new Product(product)
            {
                IsAvailable = false
            };
            string values = "(" + product.ProductName + "," + product.ProductDescription + "," + product.UnitPrice + "," + product.Quantity + "," + product.ManufacturerID + "," + product.Measurement + "," + product.IsAvailable + "," + product.UnitCost + ")";
            string constraints = "user_id = " + userData.UserID;
            databaseHelper.UpdateRecord(this.tableName, values, constraints);
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(string id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product(row["product_id"].ToString()!, row["product_name"].ToString()!, row["product_description"].ToString()!, Int32.Parse(row["unit_price"].ToString()!), Int32.Parse(row["quantity"].ToString()!), row["manufacturer_id"].ToString()!, row["measurement"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_available"].ToString()!)), Int32.Parse(row["unit_cost"].ToString()!));
                products.Add(product);
            }
            return products;
        }

        public List<Product> GetAllActiveProducts()
        {
            string constraints = "is_available = 1";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product(row["product_id"].ToString()!, row["product_name"].ToString()!, row["product_description"].ToString()!, Int32.Parse(row["unit_price"].ToString()!), Int32.Parse(row["quantity"].ToString()!), row["manufacturer_id"].ToString()!, row["measurement"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_available"].ToString()!)), Int32.Parse(row["unit_cost"].ToString()!));
                products.Add(product);
            }
            return products;
        }

        public List<Product> GetAllInactiveProducts()
        {
            string constraints = "is_available = 0";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product(row["product_id"].ToString()!, row["product_name"].ToString()!, row["product_description"].ToString()!, Int32.Parse(row["unit_price"].ToString()!), Int32.Parse(row["quantity"].ToString()!), row["manufacturer_id"].ToString()!, row["measurement"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_available"].ToString()!)), Int32.Parse(row["unit_cost"].ToString()!));
                products.Add(product);
            }
            return products;
        }
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
