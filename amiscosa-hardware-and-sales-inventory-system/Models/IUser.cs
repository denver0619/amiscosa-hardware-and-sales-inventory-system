namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    /// <summary>
    /// Contains the data contained in T:amiscosa_hardware_and_sales_inventory_system.Models.User
    /// </summary>
    public interface IUser
    {
        public String? UserID { get; set; }
        public String? FirstName { get; set; }
        public String? MiddleName { get; set; } 
        public String? LastName { get; set; }
        public String? UserName { get; set; }
        public String? Hash { get; set; }
        public String? UserRole { get; set; }
    }
}
