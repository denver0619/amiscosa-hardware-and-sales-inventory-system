using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class TransactionService
    {
        private CustomerRepository customerRepository;
        private ProductRepository productRepository;

        public TransactionService()
        {
            customerRepository = new CustomerRepository();
            productRepository = new ProductRepository();    
            Model = new TransactionModel();
            Model = GetAllCustomerList();
            Model = GetAllProductList();
        }

        public TransactionModel Model { get; set; }
        public TransactionModel GetAllCustomerList()
        {
            Model.CustomerList = customerRepository.GetAllCustomers();
            return Model;
        }

        public TransactionModel GetAllProductList()
        {
            Model.ProductList = productRepository.GetAllProducts();
            return Model;
        }
    }
}
