using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(ProductRepository product);
        void DeleteProduct(ProductRepository product);
        void EditProduct(ProductRepository product);
        ProductRepository GetProductByID(string id);
        ProductRepository GetProductByName(string name);
        List<ProductRepository> GetProducts();
    }
}
