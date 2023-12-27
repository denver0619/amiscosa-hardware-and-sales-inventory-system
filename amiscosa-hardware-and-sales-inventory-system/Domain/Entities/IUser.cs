namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Contains the data contained in T:amiscosa_hardware_and_sales_inventory_system.Models.User
    /// </summary>
    public interface IUser
    {
        public string? UserID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Hash { get; set; }
        public string? UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}
