namespace amiscosa_hardware_and_sales_inventory_system.Constants
{
    public static class Constants
    {
        public static class Database
        {
            private static String? _connection_string;

            public static String? ConnectionString { get { return _connection_string; } set { _connection_string = value; } }

        }
    }
}
