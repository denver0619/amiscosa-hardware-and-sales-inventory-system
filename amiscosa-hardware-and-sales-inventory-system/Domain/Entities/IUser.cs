namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Contains the data contained in T:amiscosa_hardware_and_sales_inventory_system.Models.User
    /// </summary>
    public interface IUser
    {
        public string? UserID { get; set; }
        public string? UserFName { get; set; }
        public string? UserMName { get; set; }
        public string? UserLName { get; set; }
        public string? UserUserame { get; set; }
        public string? UserHash { get; set; }
        public string? UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}
