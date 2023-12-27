
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseHelper databaseHelper;
        private readonly string tableName = "Products";
        private readonly string tableFields = "(product_id, product_name, product_description, unit_price, quantity, manufacturer_id, measurement, is_available, unit_cost)";
        private readonly string tableUpdateFields = "(product_name, product_description, unit_price, quantity, manufacturer_id, measurement, is_available, unit_cost)";

        public ProductRepository()
        {
            databaseHelper = new DatabaseHelper();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
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

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
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
