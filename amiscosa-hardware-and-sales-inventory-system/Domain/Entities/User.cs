using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents the User Entity
    /// </summary>
    public class User : IUser
    {
        public User(string userID, string firstName, string middleName, string lastName, string userName, string hash, string userRole, bool isActive = true)
        {
            UserID = userID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            UserName = userName;
            Hash = hash;
            UserRole = userRole;
            IsActive = isActive;
        }
        public User(IUser user)
        {
            UserID = user.UserID;
            FirstName = user.FirstName;
            MiddleName = user.MiddleName;
            LastName = user.LastName;
            UserName = user.UserName;
            Hash = user.Hash;
            UserRole = user.UserRole;
            IsActive = user.IsActive;
        }

        [Required]
        public string? UserID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Hash { get; set; }
        [Required]
        public string? UserRole { get; set; }
        [Required]
        public bool IsActive { get; set;}
    }
}
