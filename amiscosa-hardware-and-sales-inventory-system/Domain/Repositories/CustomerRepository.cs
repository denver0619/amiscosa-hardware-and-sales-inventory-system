using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    /// <summary>
    /// Represents a repository for managing customer data in a database.
    /// Implements the <see cref="ICustomerRepository"/> interface.
    /// </summary>
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private DatabaseHelper<Customer> databaseHelper;
        private readonly string tableName = "customers";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        public CustomerRepository()
        {
            databaseHelper = new DatabaseHelper<Customer>();
        }

        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        /// <param name="customer">The customer object to be added.</param>
        public void AddCustomer(ICustomer customer)
        {
            databaseHelper.InsertRecord(tableName, new Customer(customer));
        }

        /// <summary>
        /// Disposes of the resources used by the repository.
        /// </summary>
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        /// <summary>
        /// Retrieves all customers from the database.
        /// </summary>
        /// <returns>A list of customer objects.</returns>
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

        /// <summary>
        /// Retrieves a customer from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer object with the specified ID.</returns>
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

        /// <summary>
        /// Updates the information of an existing customer in the database.
        /// </summary>
        /// <param name="customer">The updated customer object.</param>
        public void UpdateCustomer(ICustomer customer)
        {
            databaseHelper.UpdateRecord(tableName, new Customer(customer));
        }
    }
}
