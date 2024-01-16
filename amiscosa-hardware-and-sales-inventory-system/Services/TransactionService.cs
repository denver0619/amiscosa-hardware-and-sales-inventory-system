using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class TransactionService : IDisposable
    {
        private CustomerRepository customerRepository;
        private ProductRepository productRepository;
        private TransactionRepository transactionRepository;
        private TransactionDetailRepository transactionDetailRepository;

        public TransactionService()
        {
            customerRepository = new CustomerRepository();
            productRepository = new ProductRepository();    
            transactionRepository = new TransactionRepository();
            transactionDetailRepository = new TransactionDetailRepository();
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

        public void AddTransaction(TransactionModel model)
        {
            Model.Transaction = model.Transaction;
            Model.TransactionDetails = model.TransactionDetails;
            transactionRepository.AddTransaction(Model.Transaction!);
            foreach (TransactionDetail transactionDetail in Model.TransactionDetails!)
            {
                transactionDetailRepository.AddTransactionDetail(transactionDetail);
            }
        }

        public void Dispose()
        {
            customerRepository.Dispose();
            productRepository.Dispose();
            transactionRepository.Dispose();
            transactionDetailRepository.Dispose();
        }
    }
}
