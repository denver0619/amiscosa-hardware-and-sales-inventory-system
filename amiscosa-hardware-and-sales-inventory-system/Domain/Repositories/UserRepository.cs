using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DatabaseHelper<User> databaseHelper;
        private readonly string tableName = "Users";
        private readonly string tableFields = "(user_id, user_fname, user_mname, user_lname, user_username, user_hash, user_role, is_active)";
        private readonly string tableAddFields = "(user_fname, user_mname, user_lname, user_username, user_hash, user_role, is_active)";

        public UserRepository()
        {
            databaseHelper = new DatabaseHelper<User>();
        }

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

        public void DeleteUser(User user)
        {
            User userData = new User(user)
            {
                IsActive = false
            };
            databaseHelper.UpdateRecord(this.tableName, userData);
        }

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
        public List<User> GetAllActiveUser()
        {
            string constraints = "is_active = 1";
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

        public List<User> GetAllInactiveUser()
        {
            string constraints = "is_active = 0";
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

        public User GetUserByID(string id)
        {
            string constraints = "user_id = " + id;
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

        public User GetUserByUserName(string username)
        {
            string constraints = "user_username = " + username;
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

        public void UpdateUser(User user)
        {
            databaseHelper.UpdateRecord(this.tableName, user);
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
