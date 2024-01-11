using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private DatabaseHelper<Customer> databaseHelper;
        private readonly string tableName = "customers";
        public CustomerRepository()
        {
            databaseHelper = new DatabaseHelper<Customer>();
        }
        public void AddCustomer(ICustomer customer)
        {
            databaseHelper.InsertRecord(tableName, new Customer(customer));
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<Customer> customers = new List<Customer>();
            foreach (DataRow row in dataTable.Rows)
            {
                Customer customer = new Customer(
                row["CustomerID"].ToString()!,
                row["CustomerFName"].ToString()!,
                row["CustomerMName"].ToString()!,
                row["CustomerLName"].ToString()!,
                row["CustomerAddress"].ToString()!,
                row["CustomerContact"].ToString()!
                );
                customers.Add( customer );
            }
            return customers;
        }

        public Customer GetCustomerByID(string id)
        {
            string constraints = "CustomerID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Customer(
                row["CustomerID"].ToString()!,
                row["CustomerFName"].ToString()!,
                row["CustomerMName"].ToString()!,
                row["CustomerLName"].ToString()!,
                row["CustomerAddress"].ToString()!,
                row["CustomerContact"].ToString()!
                );
        }

        public void UpdateCustomer(ICustomer customer)
        {
            databaseHelper.UpdateRecord(tableName, new Customer(customer));
        }
    }
}
