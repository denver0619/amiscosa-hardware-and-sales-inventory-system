using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    /// <summary>
    /// A service class responsible for managing customer-related operations.
    /// Implements the <see cref="IDisposable"/> interface to handle resource cleanup.
    /// </summary>
    public class CustomerService : IDisposable
    {
        
        private CustomerRepository customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// Creates a new instance of the <see cref="CustomerRepository"/> and initializes the customer model.
        /// </summary>
        public CustomerService()
        {
            customerRepository = new CustomerRepository();
            Model = new CustomerModel();
            Model = GetAllCustomerList();
        }

        /// <summary>
        /// Gets or sets the customer model associated with the service.
        /// </summary>
        public CustomerModel Model { get; set; }

        /// <summary>
        /// Retrieves a customer model containing a list of all customers.
        /// </summary>
        /// <returns>The customer model with the list of all customers.</returns>
        public CustomerModel GetAllCustomerList()
        {
            Model.CustomerList = customerRepository.GetAllCustomers();
            return Model;
        }

        /// <summary>
        /// Adds a new customer to the repository.
        /// </summary>
        /// <param name="customer">The customer to be added.</param>
        public void AddCustomer(Customer customer)
        {
            customerRepository.AddCustomer(customer);
        }

        /// <summary>
        /// Updates an existing customer in the repository.
        /// </summary>
        /// <param name="customer">The updated customer information.</param>
        public void UpdateCustomer(Customer customer)
        {
            customerRepository.UpdateCustomer(customer);
        }

        /// <summary>
        /// Disposes of the resources used by the customer service, including the associated repository.
        /// </summary>
        public void Dispose()
        {
            customerRepository.Dispose();
        }
    }
}
