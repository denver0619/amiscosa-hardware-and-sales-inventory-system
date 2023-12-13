using MySql.Data.MySqlClient;
using amiscosa_hardware_and_sales_inventory_system.Configurations;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Infrastructures
{
    public class DatabaseConnectionManager : IDatabaseConnectionManager, IDisposable
    {
        internal String? _connectionString;
        internal MySqlConnection? _connection;

        public DatabaseConnectionManager(String connectionString)
        {
            this.ConnectionString = connectionString;
            this.Connection = new MySqlConnection(ConnectionString);
        }
        public String ConnectionString { get { return _connectionString!; } set { _connectionString = value; } }
        public MySqlConnection Connection { get { return _connection!; } set { _connection = value; } }

        public void CloseConnection(IDatabaseConnectionManager dbManager)
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        
        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}
