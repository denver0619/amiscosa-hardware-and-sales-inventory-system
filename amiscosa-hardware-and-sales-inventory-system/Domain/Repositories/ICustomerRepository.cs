using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface ICustomerRepository
    {
        public void AddCustomer(ICustomer customer);
        public void UpdateCustomer(ICustomer customer);
        public void DeleteCustomer(ICustomer customer);
        public Customer GetCustomerByID(string id);
        public Customer GetCustomerByName(string name);
        public List<Customer> GetAllCustomers();
    }
}
