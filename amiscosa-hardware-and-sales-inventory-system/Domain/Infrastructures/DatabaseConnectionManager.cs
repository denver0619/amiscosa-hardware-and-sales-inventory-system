using MySql.Data.MySqlClient;
using amiscosa_hardware_and_sales_inventory_system.Configurations;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Infrastructures
{
    public class DatabaseConnectionManager : IDatabaseConnectionManager, IDisposable
    {
        internal string? _connectionString;
        internal MySqlConnection? _connection;

        public DatabaseConnectionManager(string connectionString)
        {
            ConnectionString = connectionString;
            Connection = new MySqlConnection(ConnectionString);
        }
        public string ConnectionString { get { return _connectionString!; } set { _connectionString = value; } }
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
