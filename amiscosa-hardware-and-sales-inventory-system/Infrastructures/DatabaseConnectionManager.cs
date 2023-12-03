using MySql.Data;
using MySql.Data.MySqlClient;

namespace amiscosa_hardware_and_sales_inventory_system.Infrastructures
{
    public class DatabaseConnectionManager : IDatabaseConnectionManager
    {
        private String _connectionString;
        private MySqlConnection _connection;

        public string GetConnectionString { get { return _connectionString; } set { _connectionString = value; } }
        public MySqlConnection GetConnection { get { return _connection; } set { _connection = value; } }

        public void CloseConnection(IDatabaseConnectionManager dbManager)
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}
