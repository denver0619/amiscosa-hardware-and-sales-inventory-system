
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    /// <summary>
    /// Represents a repository for managing product data in a database.
    /// Implements the <see cref="IProductRepository"/> interface.
    /// </summary>
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseHelper<Product> databaseHelper;
        private readonly string tableName = "products";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        public ProductRepository()
        {
            databaseHelper = new DatabaseHelper<Product>();
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">The product object to be added.</param>
        public void AddProduct(Product product)
        {
            databaseHelper.InsertRecord(tableName, product);
        }

        /// <summary>
        /// Deletes a product from the database by marking it as not available.
        /// </summary>
        /// <param name="product">The product object to be marked as not available.</param>
        public void DeleteProduct(Product product)
        {
            Product productData = new Product(product)
            {
                IsAvailable = false
            };
            databaseHelper.UpdateRecord(this.tableName, productData);
        }

        /// <summary>
        /// Updates the information of an existing product in the database.
        /// </summary>
        /// <param name="product">The updated product object.</param>
        public void UpdateProduct(Product product)
        {
            databaseHelper.UpdateRecord(this.tableName, product);
        }

        /// <summary>
        /// Retrieves a product from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product object with the specified ID.</returns>
        public Product GetProductByID(string id)
        {
            string constraints = "ProductID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Product(
                    row["ProductID"].ToString()!,
                    row["ProductName"].ToString()!,
                    row["ProductDescription"].ToString()!,
                    Double.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Double.Parse(row["UnitCost"].ToString()!));
        }

        /// <summary>
        /// Retrieves products from the database based on the provided name.
        /// </summary>
        /// <param name="name">The name or part of the name to search for.</param>
        /// <returns>A list of product objects matching the provided name.</returns>
        public List<Product> GetAllProductByName(string name)
        {
            string constraints = "ProductName LIKE %" + name + "%";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product(
                    row["ProductID"].ToString()!,
                    row["ProductName"].ToString()!,
                    row["ProductDescription"].ToString()!,
                    Double.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Double.Parse(row["UnitCost"].ToString()!));
                products.Add(product);
            }
            return products;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of product objects.</returns>
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
                    Double.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Double.Parse(row["UnitCost"].ToString()!));
                products.Add(product);
            }
            return products;
        }

        /// <summary>
        /// Retrieves all active products from the database.
        /// </summary>
        /// <returns>A list of active product objects.</returns>
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
                    Double.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Double.Parse(row["UnitCost"].ToString()!));
                products.Add(product);
            }
            return products;
        }

        /// <summary>
        /// Retrieves all inactive products from the database.
        /// </summary>
        /// <returns>A list of inactive product objects.</returns>
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
                    Double.Parse(row["UnitPrice"].ToString()!),
                    Int32.Parse(row["Quantity"].ToString()!),
                    row["ManufacturerID"].ToString()!,
                    row["Measurement"].ToString()!,
                    bool.Parse(row["IsAvailable"].ToString()!),
                    Double.Parse(row["UnitCost"].ToString()!));
                products.Add(product);
            }
            return products;
        }

        /// <summary>
        /// Disposes of the resources used by the repository.
        /// </summary>
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
