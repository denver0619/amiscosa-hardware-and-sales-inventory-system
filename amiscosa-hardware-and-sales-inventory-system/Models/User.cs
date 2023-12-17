using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    /// <summary>
    /// Represents the User Entity
    /// </summary>
    public class User : IUser
    {
        User(string userID, string firstName, string middleName, string lastName, string userName, string hash, string userRole)
        {
            UserID = userID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            UserName = userName;
            Hash = hash;
            UserRole = userRole;
        }

        [Required]
        public String? UserID { get; set; }
        [Required]
        public String? FirstName { get; set; }
        [Required]
        public String? MiddleName { get; set; }
        [Required]
        public String? LastName { get; set; }
        [Required]
        public String? UserName { get; set; }
        [Required]
        public String? Hash { get; set; }
        [Required]
        public String? UserRole { get; set; }
    }
}
