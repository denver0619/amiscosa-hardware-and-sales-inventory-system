namespace amiscosa_hardware_and_sales_inventory_system.Models
{
    /// <summary>
    /// Represents the User Entity
    /// </summary>
    public class User : IUser
    {
        private string? _userID;
        private string? _firstName;
        private string? _middleName;
        private string? _lastName;
        private string? _userName;
        private string? _hash;
        private string? _userRole;

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

        public String? UserID { get { return _userID; } set { _userID = value; } }
        public String? FirstName { get { return _firstName; } set { _firstName = value; } }
        public String? MiddleName { get { return _middleName; } set { _middleName = value; } }
        public String? LastName { get { return _lastName; } set { _lastName = value; } }
        public String? UserName { get { return _userName; } set { _userName = value; } }
        public String? Hash { get { return _hash; } set { _hash = value; } }
        public String? UserRole { get { return _userRole; } set { _userRole = value; } }
    }
}
