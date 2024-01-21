using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    /// <summary>
    /// A service class responsible for managing inventory-related operations.
    /// Implements the <see cref="IDisposable"/> interface to handle resource cleanup.
    /// </summary>
    public class InventoryService : IDisposable
    {
        private ProductRepository productRepository;
        private ManufacturerRepository manufacturerRepository;

        /// <summary>
        /// Gets or sets the inventory model associated with the service.
        /// </summary>
        public InventoryModel Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// Creates instances of <see cref="ProductRepository"/>, <see cref="ManufacturerRepository"/>, and initializes the inventory model.
        /// </summary>
        public InventoryService()
        {
            productRepository = new ProductRepository();
            manufacturerRepository = new ManufacturerRepository();
            Model = new InventoryModel();
            Model = GetAllProductList();
        }

        /// <summary>
        /// Retrieves an inventory model containing a list of all products with additional manufacturer information.
        /// </summary>
        /// <returns>The inventory model with the list of products and associated manufacturer details.</returns>
        public InventoryModel GetAllProductList()
        {
            List<Product> products = productRepository.GetAllProducts();

            List<ProductDataTransferObject> productData = new List<ProductDataTransferObject>();

            foreach (Product product in products)
            {
                ProductDataTransferObject productDataTransferObject = new ProductDataTransferObject(product);
                productDataTransferObject.Manufacturer = manufacturerRepository.GetManufacturerByID(product.ManufacturerID!);
                productData.Add(productDataTransferObject);
            }
            Model.ProductList = productData;
            return Model;
        }

        /// <summary>
        /// Adds a new product to the inventory.
        /// </summary>
        /// <param name="product">The product to be added.</param>
        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        /// <summary>
        /// Edits an existing product in the inventory.
        /// </summary>
        /// <param name="product">The updated product information.</param>
        public void EditProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        /// <summary>
        /// Removes a product from the inventory.
        /// </summary>
        /// <param name="product">The product to be removed.</param>
        public void RemoveProduct(Product product)
        {
            productRepository.DeleteProduct(product);
        }

        /// <summary>
        /// Disposes of the resources used by the inventory service, including associated repositories.
        /// </summary>
        public void Dispose()
        {
            productRepository.Dispose();
            manufacturerRepository.Dispose();
        }

    }
}
