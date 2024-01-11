using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Models;
using amiscosa_hardware_and_sales_inventory_system.Domain.Repositories;

namespace amiscosa_hardware_and_sales_inventory_system.Services
{
    public class CustomerService : IDisposable
    {
        private CustomerRepository customerRepository;

        public CustomerService()
        {
            customerRepository = new CustomerRepository();
            Model = new CustomerModel();
        }

        public CustomerModel Model { get; set; }

        public CustomerModel GetAllCustomerList()
        {
            Model.CustomerList = customerRepository.GetAllCustomers();
            return Model;
        }

        public void AddCustomer(Customer customer)
        {
            customerRepository.AddCustomer(customer);
        }
        public void RemoveCustomer(Customer customer)
        {
            customerRepository.DeleteCustomer(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            customerRepository.UpdateCustomer(customer);
        }
        public void Dispose()
        {
            customerRepository.Dispose();
        }
    }
}
