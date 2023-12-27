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

        public void InsertRecord(string tableName, string fields, List<string> values)
        {
            _connection.Open();
            string querytype = "INSERT INTO ";
            string recordValues = " VALUES ";
            string terminator = ";";
            foreach (string value in values)
            {
                recordValues += value + " ";
            }
            string query = querytype + tableName + " " + fields + recordValues + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public DataTable SelectRecord(string tableName, string constraints)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            string queryType = "SELECT * FROM ";
            string whereClause = " WHERE ";
            string terminator = ";";
            string query = queryType + tableName + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }
        public DataTable SelectAllRecord(string tableName)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            string queryType = "SELECT * FROM ";
            string terminator = ";";
            string query = queryType + tableName + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }
        public DataTable SelectAllRecordWith(string tableName, string constraints)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            string queryType = "SELECT * FROM ";
            string whereClause = " WHERE ";
            string terminator = ";";
            string query = queryType + tableName + whereClause + constraints + terminator;
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }

        public void UpdateRecord(string tableName, string values, string constraints)
        {
            _connection.Open();
            string queryType = "UPDATE ";
            string setValues = " SET ";
            string whereClause = " WHERE ";
            string terminator = ";";
            string query = queryType + tableName + setValues + values + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
