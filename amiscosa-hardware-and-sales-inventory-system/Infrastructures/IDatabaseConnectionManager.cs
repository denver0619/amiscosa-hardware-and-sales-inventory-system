using MySql.Data.MySqlClient;

namespace amiscosa_hardware_and_sales_inventory_system.Infrastructures
{
    public interface IDatabaseConnectionManager
    {
        public String ConnectionString { get; set; }
        public MySqlConnection Connection { get; set; }

        public void OpenConnection();
        public void CloseConnection(IDatabaseConnectionManager dbManager);
    }
}
