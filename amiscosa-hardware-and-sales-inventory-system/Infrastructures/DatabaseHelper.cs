using MySql.Data.MySqlClient;
using amiscosa_hardware_and_sales_inventory_system.Configurations;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace amiscosa_hardware_and_sales_inventory_system.Infrastructures
{
    /// <summary>
    /// A utility class for interacting with the database, providing methods for CRUD operations.
    /// Implements the <see cref="IDisposable"/> interface to manage resources.
    /// </summary>
    /// <typeparam name="Entity">The type of entity used for database operations.</typeparam>
    public class DatabaseHelper<Entity> : IDisposable
    {
        private IDatabaseConnectionManager _connectionManager;
        private MySqlConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseHelper{Entity}"/> class.
        /// Configures the MySQL connection string and initializes the database connection.
        /// </summary>
        public DatabaseHelper()
        {
            Configuration.MySQL.ConnectionString = "server=26.223.107.167;port=3306;user=root;database=amiscosadatabase;password=;Convert Zero Datetime=True;"; //Temporary
            _connectionManager = new DatabaseConnectionManager(Configuration.MySQL.ConnectionString);
            _connection = _connectionManager.Connection;
        }

        /// <summary>
        /// Inserts a record into the specified table with the provided entity data.
        /// </summary>
        /// <param name="tableName">The name of the table to insert the record into.</param>
        /// <param name="entity">The entity representing the data to be inserted.</param>
        public void InsertRecord(string tableName, Entity entity)
        {
            _connection.Open();
            string querytype = "INSERT INTO ";
            string fields = this.GetInsertFields(tableName, entity);
            string recordValues = " VALUES ";
            List<string> values = this.GetInsertValues(tableName, new List<Entity> { entity });
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

        /// <summary>
        /// Retrieves a DataTable containing records from the specified table based on the provided constraints.
        /// </summary>
        /// <param name="tableName">The name of the table to select records from.</param>
        /// <param name="constraints">The conditions to filter the records.</param>
        /// <returns>A DataTable containing the selected records.</returns>
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

        /// <summary>
        /// Retrieves a DataTable containing all records from the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table to select all records from.</param>
        /// <returns>A DataTable containing all records from the specified table.</returns>
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

        /// <summary>
        /// Retrieves a DataTable containing all records from the specified table based on the provided constraints.
        /// </summary>
        /// <param name="tableName">The name of the table to select records from.</param>
        /// <param name="constraints">The conditions to filter the records.</param>
        /// <returns>A DataTable containing the selected records.</returns>
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

        /// <summary>
        /// Updates a record in the specified table with the provided entity data.
        /// </summary>
        /// <param name="tableName">The name of the table to update the record in.</param>
        /// <param name="entity">The entity representing the data to be updated.</param>
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

        /// <summary>
        /// Converts the values of an entity into a string format suitable for an UPDATE SQL query.
        /// </summary>
        /// <param name="entity">The entity whose values are to be converted.</param>
        /// <returns>A string representation of the entity's values for an UPDATE query.</returns>
        public string ConvertUpdateValuesToString(Entity entity)
        {
            Type type = entity!.GetType();
            List<string> output = new List<string>();
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string) && !(property.Name.EndsWith("ID")))
                {
                    output.Add(property.Name + " = \'" + property.GetValue(entity) + "\'");
                }
                else
                {
                    output.Add(property.Name + " = " + property.GetValue(entity));
                }
            }
            return String.Join(",", output);
        }

        /// <summary>
        /// Gets the ID-based constraint for an entity in the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table to get the constraint for.</param>
        /// <param name="entity">The entity for which the ID-based constraint is needed.</param>
        /// <returns>The ID-based constraint for the entity.</returns>
        public string GetIDConstraint (string tableName, Entity entity)
        {
            string output = "";
            Type type = entity!.GetType();
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name.EndsWith("ID") && property.Name.Contains(tableName.Substring(1, tableName.Length - 2)))
                {
                    output = property.Name + " = " + property.GetValue(entity);
                }
            }
            return output;
        }

        /// <summary>
        /// Gets the fields for an INSERT SQL query based on the entity and table name.
        /// </summary>
        /// <param name="tableName">The name of the table for which to get the fields.</param>
        /// <param name="entity">The entity for which to get the fields.</param>
        /// <returns>A string representing the fields for an INSERT query.</returns>
        public string GetInsertFields(string tableName, Entity entity)
        {
            Type type = entity!.GetType();
            List<string> fields = new List<string>(); 
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name.EndsWith("ID") && (property.Name.Contains(tableName.Substring(1, tableName.Length - 2))|| property.Name.Contains("TransactionDetail"))) continue;
                fields.Add(property.Name);
            }
            return "(" + String.Join(",", fields) + ")";
        }

        /// <summary>
        /// Gets the values for an INSERT SQL query based on the provided entities and table name.
        /// </summary>
        /// <param name="tableName">The name of the table for which to get the values.</param>
        /// <param name="entities">The list of entities for which to get the values.</param>
        /// <returns>A list of strings representing the values for an INSERT query.</returns>
        public List<string> GetInsertValues(String tableName, List<Entity> entities)
        {
            List<string> values = new List<string>();
            foreach (Entity? entity in entities)
            {
                if (entity != null)
                {
                    Type type = entity.GetType();
                    List<string> currentEntityValue = new List<string>();
                    List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
                    foreach (PropertyInfo property in properties)
                    {
                        object? value = property.GetValue(entity);
                        if (property.Name.EndsWith("ID") && (property.Name.Contains(tableName.Substring(1, tableName.Length - 2)) || property.Name.Contains("TransactionDetail"))) continue;
                        if (value != null)
                        {
                            if ((property.PropertyType == typeof(string) && !property.Name.EndsWith("ID")))
                            {
                                currentEntityValue.Add("\'"+value.ToString()!+ "\'");
                            }
                            else if ( property.Name.Contains("Date"))
                            {
                                DateTime date = (DateTime)value;
                                currentEntityValue.Add("\'"+ date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'");
                            }
                            else
                            {
                                currentEntityValue.Add(value.ToString()!);
                            }
                        }
                        else
                        {
                            currentEntityValue.Add("NULL");
                        }
                    }
                    values.Add("(" + string.Join(",", currentEntityValue) + ")");
                }
            }
            return values;
        }

        /// <summary>
        /// Disposes of the resources used by the database helper and closes the database connection.
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
