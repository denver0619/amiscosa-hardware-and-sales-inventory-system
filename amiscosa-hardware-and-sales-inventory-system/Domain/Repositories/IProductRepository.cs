using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void EditProduct(Product product);
        Product GetProductByID(string id);
        Product GetProductByName(string name);
        List<Product> GetProducts();
    }
}
