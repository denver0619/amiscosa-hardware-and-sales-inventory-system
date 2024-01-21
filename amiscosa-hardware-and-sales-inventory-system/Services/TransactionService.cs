using amiscosa_hardware_and_sales_inventory_system.Domain.DataTransferObjects;
using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    /// <summary>
    /// A service class responsible for managing transactions.
    /// Implements the <see cref="IDisposable"/> interface to handle resource cleanup.
    /// </summary>
    public class TransactionService : IDisposable
    {
        private CustomerRepository customerRepository;
        private ProductRepository productRepository;
        private TransactionRepository transactionRepository;
        private TransactionDetailRepository transactionDetailRepository;
        private ManufacturerRepository manufacturerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// Creates instances of repositories and initializes the transaction model.
        /// </summary>
        public TransactionService()
        {
            customerRepository = new CustomerRepository();
            productRepository = new ProductRepository();    
            transactionRepository = new TransactionRepository();
            transactionDetailRepository = new TransactionDetailRepository();
            manufacturerRepository = new ManufacturerRepository();
            Model = new TransactionModel();
            Model = GetAllCustomerList();
            Model = GetAllProductList();
        }

        /// <summary>
        /// Gets or sets the transaction model associated with the service.
        /// </summary>
        public TransactionModel Model { get; set; }

        /// <summary>
        /// Retrieves a transaction model containing all customers.
        /// </summary>
        /// <returns>The transaction model with customer information.</returns>
        public TransactionModel GetAllCustomerList()
        {
            Model.CustomerList = customerRepository.GetAllCustomers();
            return Model;
        }

        /// <summary>
        /// Retrieves a transaction model containing all products with additional information.
        /// </summary>
        /// <returns>The transaction model with product information.</returns>
        public TransactionModel GetAllProductList()
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
        /// Adds a transaction to the system, updating product quantities and related details.
        /// </summary>
        /// <param name="model">The transaction model containing transaction and details information.</param>
        public void AddTransaction(TransactionModel model)
        {
            Model.Transaction = model.Transaction;
            Model.TransactionDetails = model.TransactionDetails;
            transactionRepository.AddTransaction(Model.Transaction!);
            List<Transaction> transactions = transactionRepository.GetAllTransactions();
            Transaction transaction = transactions[transactions.Count - 1];
            foreach (TransactionDetail transactionDetail in Model.TransactionDetails!)
            {
                Product product = new Product(productRepository.GetProductByID(transactionDetail.ProductID!));
                TransactionDetail transactionDetailData = new TransactionDetail(transactionDetail);
                transactionDetailData.TransactionID = transaction.TransactionID;
                product.Quantity -= transactionDetail.Quantity;
                productRepository.UpdateProduct(product);
                transactionDetailRepository.AddTransactionDetail(transactionDetailData);
            }
        }

        /// <summary>
        /// Disposes of the resources used by the transaction service, including associated repositories.
        /// </summary>
        public void Dispose()
        {
            customerRepository.Dispose();
            productRepository.Dispose();
            transactionRepository.Dispose();
            transactionDetailRepository.Dispose();
            manufacturerRepository.Dispose();
        }
    }
}
