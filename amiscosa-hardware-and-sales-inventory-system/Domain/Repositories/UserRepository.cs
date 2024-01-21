using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;
using System.Xml.Linq;


namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    /// <summary>
    /// Represents a repository for managing user data in a database.
    /// Implements the <see cref="IUserRepository"/> interface.
    /// </summary>
    public class UserRepository : IUserRepository, IDisposable
    {
        private DatabaseHelper<User> databaseHelper;
        private readonly string tableName = "users";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        public UserRepository()
        {
            databaseHelper = new DatabaseHelper<User>();
        }

        /// <summary>
        /// Adds a new user to the database with the provided password.
        /// </summary>
        /// <param name="user">The user object to be added.</param>
        /// <param name="password">The password associated with the user.</param>
        public void AddUser(User user, string password)
        {
            //TODO: User hashing functions
            string userHash = "";
            User userWithHash = new User(user)
            {
                UserHash = userHash
            };
            databaseHelper.InsertRecord(tableName, userWithHash);
        }

        /// <summary>
        /// Deletes a user from the database by marking it as inactive.
        /// </summary>
        /// <param name="user">The user object to be marked as inactive.</param>
        public void DeleteUser(User user)
        {
            User userData = new User(user)
            {
                IsActive = false
            };
            databaseHelper.UpdateRecord(this.tableName, userData);
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        public List<User> GetAllUser()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<User> users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User(
                    row["UserID"].ToString()!, 
                    row["UserFName"].ToString()!, 
                    row["UserMName"].ToString()!,
                    row["UserLName"].ToString()!, 
                    row["UserUserame"].ToString()!, 
                    row["UserHash"].ToString()!, 
                    row["UserRole"].ToString()!, 
                    bool.Parse(row["IsActive"].ToString()!));
                users.Add(user);
            }
            return users;
        }

        /// <summary>
        /// Retrieves all active users from the database.
        /// </summary>
        /// <returns>A list of active user objects.</returns>
        public List<User> GetAllActiveUser()
        {
            string constraints = "IsActive = 1";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List <User> users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User(
                    row["UserID"].ToString()!,
                    row["UserFName"].ToString()!,
                    row["UserMName"].ToString()!,
                    row["UserLName"].ToString()!,
                    row["UserUserame"].ToString()!,
                    row["UserHash"].ToString()!,
                    row["UserRole"].ToString()!,
                    bool.Parse(row["IsActive"].ToString()!));
                users.Add(user);
            }
            return users;
        }

        /// <summary>
        /// Retrieves all inactive users from the database.
        /// </summary>
        /// <returns>A list of inactive user objects.</returns>
        public List<User> GetAllInactiveUser()
        {
            string constraints = "IsActive = 0";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<User> users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User(
                    row["UserID"].ToString()!,
                    row["UserFName"].ToString()!,
                    row["UserMName"].ToString()!,
                    row["UserLName"].ToString()!,
                    row["UserUserame"].ToString()!,
                    row["UserHash"].ToString()!,
                    row["UserRole"].ToString()!,
                    bool.Parse(row["IsActive"].ToString()!));
                users.Add(user);
            }
            return users;
        }

        /// <summary>
        /// Retrieves a user from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user object with the specified ID.</returns>
        public User GetUserByID(string id)
        {
            string constraints = "UserID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints); 
            DataRow row = dataTable.Rows[0];
            return new User(
                    row["UserID"].ToString()!,
                    row["UserFName"].ToString()!,
                    row["UserMName"].ToString()!,
                    row["UserLName"].ToString()!,
                    row["UserUserame"].ToString()!,
                    row["UserHash"].ToString()!,
                    row["UserRole"].ToString()!,
                    bool.Parse(row["IsActive"].ToString()!));
        }

        /// <summary>
        /// Retrieves a user from the database based on the provided username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user object with the specified username.</returns>
        public User GetUserByUserName(string username)
        {
            string constraints = "UserUsername = " + username;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new User(
                    row["UserID"].ToString()!,
                    row["UserFName"].ToString()!,
                    row["UserMName"].ToString()!,
                    row["UserLName"].ToString()!,
                    row["UserUserame"].ToString()!,
                    row["UserHash"].ToString()!,
                    row["UserRole"].ToString()!,
                    bool.Parse(row["IsActive"].ToString()!));
        }

        /// <summary>
        /// Updates the information of an existing user in the database.
        /// </summary>
        /// <param name="user">The updated user object.</param>
        public void UpdateUser(User user)
        {
            databaseHelper.UpdateRecord(this.tableName, user);
        }

        /// <summary>
        /// Disposes of the resources used by the repository.
        /// </summary>
        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
