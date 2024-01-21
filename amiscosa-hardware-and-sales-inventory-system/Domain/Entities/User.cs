using System.ComponentModel.DataAnnotations;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Entities
{
    /// <summary>
    /// Represents a user implementing the IUser interface.
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with specified details.
        /// </summary>
        /// <param name="userID">The unique identifier for the user.</param>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="middleName">The middle name of the user.</param>
        /// <param name="lastName">The last name of the user.</param>
        /// <param name="userName">The username of the user.</param>
        /// <param name="hash">The hash value associated with the user's password.</param>
        /// <param name="userRole">The role of the user.</param>
        /// <param name="isActive">Indicates whether the user is active (default is true).</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class using another user's information.
        /// </summary>
        /// <param name="user">An object implementing the IUser interface from which to copy information.</param>
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
