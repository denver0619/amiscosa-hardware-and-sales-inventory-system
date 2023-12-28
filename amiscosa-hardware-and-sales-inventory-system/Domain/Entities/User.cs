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
            UserFName = firstName;
            UserMName = middleName;
            UserLName = lastName;
            UserUserame = userName;
            UserHash = hash;
            UserRole = userRole;
            IsActive = isActive;
        }
        public User(IUser user)
        {
            UserID = user.UserID;
            UserFName = user.UserFName;
            UserMName = user.UserMName;
            UserLName = user.UserLName;
            UserUserame = user.UserUserame;
            UserHash = user.UserHash;
            UserRole = user.UserRole;
            IsActive = user.IsActive;
        }

        [Required]
        public string? UserID { get; set; }
        [Required]
        public string? UserFName { get; set; }
        [Required]
        public string? UserMName { get; set; }
        [Required]
        public string? UserLName { get; set; }
        [Required]
        public string? UserUserame { get; set; }
        [Required]
        public string? UserHash { get; set; }
        [Required]
        public string? UserRole { get; set; }
        [Required]
        public bool IsActive { get; set;}
    }
}
