namespace amiscosa_hardware_and_sales_inventory_system.Configurations
{
    public static class Configuration
    {
        public static class MySQL
        {
            private static String _connectionString = String.Empty;
            public static String ConnectionString {  get { return _connectionString; } set { _connectionString = value; } }
        }
    }
}
