
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseHelper<Product> databaseHelper;
        private readonly string tableName = "products";

        public ProductRepository()
        {
            databaseHelper = new DatabaseHelper<Product>();
        }

        public void AddProduct(Product product)
        {
            databaseHelper.InsertRecord(tableName, product);
        }

        public void DeleteProduct(Product product)
        {
            Product productData = new Product(product)
            {
                IsAvailable = false
            };
            databaseHelper.UpdateRecord(this.tableName, productData);
        }

        public void UpdateProduct(Product product)
        {
            databaseHelper.UpdateRecord(this.tableName, product);
        }

        public Product GetProductByID(string id)
        {
            string constraints = "ProductID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Product(
                    row["ProductID"].ToString()!,
                    row["ProductName"].ToString()!,
                    row["ProductDescription"].ToString()!,
                    Int32.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Convert.ToInt32(decimal.Parse(row["UnitCost"].ToString()!)));
        }

        public Product GetProductByName(string name)
        {
            string constraints = "ProductName = " + name;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return  new Product(
                    row["ProductID"].ToString()!,
                    row["ProductName"].ToString()!,
                    row["ProductDescription"].ToString()!,
                    Int32.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Convert.ToInt32(decimal.Parse(row["UnitCost"].ToString()!)));
        }

        public List<Product> GetAllProducts()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product(
                    row["ProductID"].ToString()!, 
                    row["ProductName"].ToString()!, 
                    row["ProductDescription"].ToString()!, 
                    Int32.Parse(row["UnitPrice"].ToString()!), 
                    Int32.Parse(row["Quantity"].ToString()!), 
                    row["ManufacturerID"].ToString()!, 
                    row["Measurement"].ToString()!, 
                    bool.Parse(row["IsAvailable"].ToString()!), 
                    Convert.ToInt32(decimal.Parse(row["UnitCost"].ToString()!)));
                products.Add(product);
            }
            return products;
        }

        public List<Product> GetAllActiveProducts()
        {
            string constraints = "IsAvailable = 1";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product(
                    row["ProductID"].ToString()!,
                    row["ProductName"].ToString()!,
                    row["ProductDescription"].ToString()!,
                    Int32.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Convert.ToInt32(decimal.Parse(row["UnitCost"].ToString()!)));
                products.Add(product);
            }
            return products;
        }

        public List<Product> GetAllInactiveProducts()
        {
            string constraints = "IsAvailable = 0";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product(
                    row["ProductID"].ToString()!,
                    row["ProductName"].ToString()!,
                    row["ProductDescription"].ToString()!,
                    Int32.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Convert.ToInt32(decimal.Parse(row["UnitCost"].ToString()!))); 
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
