using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductByID(string id);
        List<Product> GetAllProductByName(string name);
        List<Product> GetAllProducts();
        List<Product> GetAllActiveProducts();
        List<Product> GetAllInactiveProducts();
    }
}
