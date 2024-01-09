using MySql.Data.MySqlClient;
using amiscosa_hardware_and_sales_inventory_system.Configurations;
using System.Data;
using System.Reflection;

namespace amiscosa_hardware_and_sales_inventory_system.Infrastructures
{
    public class DatabaseHelper<Entity> : IDisposable
    {
        private IDatabaseConnectionManager _connectionManager;
        private MySqlConnection _connection;

        public DatabaseHelper()
        {
            Configuration.MySQL.ConnectionString = "server=26.92.41.207;user=root;database=amiscosadatabase;password="; //Temporary
            _connectionManager = new DatabaseConnectionManager(Configuration.MySQL.ConnectionString);
            _connection = _connectionManager.Connection;
        }

        /*public void InsertRecord(string tableName, string fields, List<string> values)*/
        public void InsertRecord(string tableName, Entity entity)
        {
            _connection.Open();
            string querytype = "INSERT INTO ";
            string fields = this.GetInsertFields(entity);
            string recordValues = " VALUES ";
            List<string> values = this.GetInsertValues(new List<Entity> { entity });
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

        /*public void UpdateRecord(string tableName, string values, string constraints)*/
        public void UpdateRecord(string tableName, Entity entity)
        {
            _connection.Open();
            string queryType = "UPDATE ";
            string setValues = " SET ";
            string values = this.ConvertUpdateValuesToString(entity);
            string whereClause = " WHERE ";
            string constraints = this.GetIDConstraint(tableName, entity);
            string terminator = ";";
            string query = queryType + tableName + setValues + values + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public string ConvertUpdateValuesToString(Entity entity)
        {
            Type type = entity!.GetType();
            List<string> output = new List<string>();
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                output.Add(property.Name + " = " + property.GetValue(entity));
            }
            return String.Join(",", output);
        }

        public string GetIDConstraint (string tableName, Entity entity)
        {
            string output = "";
            Type type = entity!.GetType();
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name.EndsWith("ID") && property.Name.Contains(tableName.Substring(1, tableName.Length - 1)))
                {
                    output = property.Name + " = " + property.GetValue(entity);
                }
            }
            return output;
        }

        public string GetInsertFields(Entity entity)
        {
            Type type = entity!.GetType();
            List<string> fields = new List<string>(); 
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name.Contains("ID")) continue;
                fields.Add(property.Name);
            }
            return "(" + String.Join(",", fields) + ")";
        }

        public List<string> GetInsertValues(List<Entity> entities)
        {
            List<string> values = new List<string>();
            foreach (Entity entity in entities)
            {
                Type type = entity!.GetType();
                List<string> currentEntityValue = new List<string>();
                List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
                foreach (PropertyInfo property in properties)
                {
                    currentEntityValue.Add(property!.GetValue(entity)!.ToString()!);
                }
                values.Add("(" + String.Join(",", currentEntityValue) + ")");
            }
            return values;
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
