
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseHelper<Product> databaseHelper;
        private readonly string tableName = "Products";

        public ProductRepository()
        {
            databaseHelper = new DatabaseHelper<Product>();
        }

        public void AddProduct(IProduct product)
        {
            Product productData = new Product(product);
            string productValues = "(" + productData.ProductName + "," + productData.ProductDescription + "," + productData.UnitPrice + "," + productData.Quantity + "," + productData.ManufacturerID + "," + productData.Measurement + "," + productData.IsAvailable + "," + productData.UnitCost +")";
            List<string> values = [productValues];
            databaseHelper.InsertRecord(tableName, databaseHelper.GetFieldsForInsert(productData), values);
        }

        public void DeleteProduct(IProduct product)
        {
            Product productData = new Product(product)
            {
                IsAvailable = false
            };
            string constraints = "product_id = " + productData.ProductID;
            databaseHelper.UpdateRecord(this.tableName, databaseHelper.ConvertUpdateValuesToString(productData), constraints);
        }

        public void UpdateProduct(IProduct product)
        {
            Product productData = new Product(product);
            string constraints = "product_id = " + productData.ProductID;
            databaseHelper.UpdateRecord(this.tableName, databaseHelper.ConvertUpdateValuesToString(productData), constraints);
        }

        public Product GetProductByID(string id)
        {
            string constraints = "product_id = " + id;
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
            string constraints = "product_name = " + name;
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
