using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(IProduct product);
        void DeleteProduct(IProduct product);
        void UpdateProduct(IProduct product);
        Product GetProductByID(string id);
        Product GetProductByName(string name);
        List<Product> GetAllProducts();
        List<Product> GetAllActiveProducts();
        List<Product> GetAllInactiveProducts();
    }
}
