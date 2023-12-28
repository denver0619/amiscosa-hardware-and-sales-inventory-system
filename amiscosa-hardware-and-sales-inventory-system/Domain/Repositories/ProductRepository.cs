
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseHelper databaseHelper;
        private readonly string tableName = "Products";
        private readonly List<string> tableFields = ["product_id", "product_name", "product_description", "unit_price", "quantity", "manufacturer_id", "measurement", "is_available", "unit_cost"];
        private readonly string tableAddFields = "(product_name, product_description, unit_price, quantity, manufacturer_id, measurement, is_available, unit_cost)";

        public ProductRepository()
        {
            databaseHelper = new DatabaseHelper();
        }

        public void AddProduct(IProduct product)
        {
            string productValues = "(" + product.ProductName + "," + product.ProductDescription + "," + product.UnitPrice + "," + product.Quantity + "," + product.ManufacturerID + "," + product.Measurement + "," + product.IsAvailable + "," + product.UnitCost +")";
            List<string> values = [productValues];
            databaseHelper.InsertRecord(tableName, tableAddFields, values);
        }

        public void DeleteProduct(IProduct product)
        {
            Product productData = new Product(product)
            {
                IsAvailable = false
            };
            List<string> values = [product.ProductName!,product.ProductDescription!,product.UnitPrice.ToString(),product.Quantity.ToString(), product.ManufacturerID!,product.Measurement!,(product.IsAvailable?1:0).ToString(), product.UnitCost.ToString()];
            string constraints = "product_id = " + productData.ProductID;
            databaseHelper.UpdateRecord(this.tableName, databaseHelper.ConvertUpdateValuesToString(tableFields, values), constraints);
        }

        public void UpdateProduct(IProduct product)
        {
            Product productData = new Product(product);
            List<string> values = [product.ProductName!, product.ProductDescription!, product.UnitPrice.ToString(), product.Quantity.ToString(), product.ManufacturerID!, product.Measurement!, (product.IsAvailable ? 1 : 0).ToString(), product.UnitCost.ToString()];
            string constraints = "product_id = " + productData.ProductID;
            databaseHelper.UpdateRecord(this.tableName, databaseHelper.ConvertUpdateValuesToString(tableFields, values), constraints);
        }

        public Product GetProductByID(string id)
        {
            string constraints = "product_id = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Product(row["product_id"].ToString()!, row["product_name"].ToString()!, row["product_description"].ToString()!, Int32.Parse(row["unit_price"].ToString()!), Int32.Parse(row["quantity"].ToString()!), row["manufacturer_id"].ToString()!, row["measurement"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_available"].ToString()!)), Int32.Parse(row["unit_cost"].ToString()!));
        }

        public Product GetProductByName(string name)
        {
            string constraints = "product_name = " + name;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Product(row["product_id"].ToString()!, row["product_name"].ToString()!, row["product_description"].ToString()!, Int32.Parse(row["unit_price"].ToString()!), Int32.Parse(row["quantity"].ToString()!), row["manufacturer_id"].ToString()!, row["measurement"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_available"].ToString()!)), Int32.Parse(row["unit_cost"].ToString()!));
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
