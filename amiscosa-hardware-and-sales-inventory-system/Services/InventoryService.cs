using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class InventoryService : IDisposable
    {
        private ProductRepository productRepository;
        private ManufacturerRepository manufacturerRepository;

        public InventoryService()
        {
            productRepository = new ProductRepository();
            manufacturerRepository = new ManufacturerRepository();
            Model = new InventoryModel();
            Model = GetAllProductList();
        }

        public InventoryModel Model { get; set; }

        public InventoryModel GetAllProductList()
        {
            Model.ProductList = productRepository.GetAllProducts();
            return Model;
        }

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        public void EditProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        public void RemoveProduct(Product product)
        {
            productRepository.DeleteProduct(product);
        }


        public void Dispose()
        {
            productRepository.Dispose();
        }

    }
}
