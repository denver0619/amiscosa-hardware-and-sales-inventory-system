using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class ProductService : IDisposable
    {
        private InventoryModel inventoryModel;
        private ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
            inventoryModel = new InventoryModel(GetProductList());
        }

        public InventoryModel GetModel()
        {
            return inventoryModel;
        }

        public List<Product> GetProductList()
        {
            return productRepository.GetAllProducts();
        }

        public void Dispose()
        {
            productRepository.Dispose();
        }

    }
}
