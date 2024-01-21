using MySql.Data.MySqlClient;
using amiscosa_hardware_and_sales_inventory_system.Configurations;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Infrastructures
{
    /// <summary>
    /// Manages the connection to the database.
    /// Implements the <see cref="IDatabaseConnectionManager"/> interface.
    /// </summary>
    public class DatabaseConnectionManager : IDatabaseConnectionManager, IDisposable
    {
        internal string? _connectionString;
        internal MySqlConnection? _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnectionManager"/> class with the provided connection string.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        public DatabaseConnectionManager(string connectionString)
        {
            ConnectionString = connectionString;
            Connection = new MySqlConnection(ConnectionString);
        }

        /// <summary>
        /// Gets or sets the connection string to the database.
        /// </summary>
        public string ConnectionString { get { return _connectionString!; } set { _connectionString = value; } }

        /// <summary>
        /// Gets or sets the MySqlConnection object for the database connection.
        /// </summary>
        public MySqlConnection Connection { get { return _connection!; } set { _connection = value; } }

        /// <summary>
        /// Closes the database connection if it is not already closed.
        /// </summary>
        /// <param name="dbManager">The database connection manager instance.</param>
        public void CloseConnection(IDatabaseConnectionManager dbManager)
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Opens the database connection if it is currently closed.
        /// </summary>
        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        /// <summary>
        /// Disposes of the resources used by the database connection manager.
        /// </summary>
        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}
