using MySql.Data.MySqlClient;
using amiscosa_hardware_and_sales_inventory_system.Configurations;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Infrastructures
{
    public class DatabaseHelper : IDisposable
    {
        private IDatabaseConnectionManager _connectionManager;
        private MySqlConnection _connection;

        public DatabaseHelper()
        {
            _connectionManager = new DatabaseConnectionManager(Configuration.MySQL.ConnectionString);
            _connection = _connectionManager.Connection;

        }

        public void InsertRecord(String tableName, String fields, List<String> values)
        {
            _connection.Open();
            String querytype = "INSERT INTO ";
            String recordValues = " VALUES ";
            String terminator = ";";
            foreach (String value in values)
            {
                recordValues += value + " ";
            }
            String query = querytype + tableName + " " + fields + recordValues + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public DataTable SelectRecord(String tableName, String constraints)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            String queryType = "SELECT * FROM ";
            String whereClause = " WHERE ";
            String terminator = ";";
            String query = queryType + tableName + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand( query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable SelectAllRecord(String tableName)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            String queryType = "SELECT * FROM ";
            String terminator = ";";
            String query = queryType + tableName + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void UpdateRecord(String tableName, String values, String constraints)
        {
            _connection.Open();
            String queryType = "UPDATE ";
            String setValues = " SET ";
            String whereClause = " WHERE ";
            String terminator = ";";
            String query = queryType+tableName + setValues + values + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Dispose ()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
