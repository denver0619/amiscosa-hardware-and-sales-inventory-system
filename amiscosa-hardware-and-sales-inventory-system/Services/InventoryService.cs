using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class InventoryService : IDisposable
    {
        private ProductRepository productRepository;

        public InventoryService()
        {
            productRepository = new ProductRepository();
            Model = new InventoryModel();
            Model = GetAllProductList();
        }

        public InventoryModel Model { get; set; }

        public InventoryModel GetAllProductList()
        {
            Model.ProductList = productRepository.GetAllProducts();
            return Model;
        }


        public void Dispose()
        {
            productRepository.Dispose();
        }

    }
}
