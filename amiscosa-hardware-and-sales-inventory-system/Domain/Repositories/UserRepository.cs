using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DatabaseHelper databaseHelper;
        private readonly string tableName = "Users";
        private readonly string tableFields = "(user_id, user_fname, user_mname, user_lname, user_username, user_hash, user_role, is_active)";
        private readonly string tableUpdateFields = "(user_fname, user_mname, user_lname, user_username, user_hash, user_role, is_active)";

        public UserRepository()
        {
            databaseHelper = new DatabaseHelper();
        }

        public void AddUser(IUser user, string password)
        {
            //TODO: User hashing functions
            string userHash = "";
            string userValues = "(" + "," + user.UserID + "," + user.FirstName + "," + user.MiddleName + "," + user.LastName + "," + user.UserName + "," + userHash + "," + user.UserRole + "," + user.IsActive +")";
            List<string> values = [userValues];
            databaseHelper.InsertRecord(tableName, tableFields, values);
        }

        public void DeleteUser(IUser user)
        {
            User userData = new User(user)
            {
                IsActive = false
            };
            string values = "(" + userData.FirstName + "," + userData.MiddleName + "," + userData.LastName + "," + userData.UserName + "," + userData.Hash + "," + userData.UserRole + "," + userData.IsActive + ")";
            string constraints = "user_id = " + userData.UserID;
            databaseHelper.UpdateRecord(this.tableName, values, constraints);
        }

        public List<User> GetAllUser()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<User> users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User(row["user_id"].ToString()!, row["user_fname"].ToString()!, row["user_mname"].ToString()!, row["user_lname"].ToString()!, row["user_username"].ToString()!, row["user_hash"].ToString()!, row["user_role"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_active"].ToString()!)));
                users.Add(user);
            }
            return users;
        }

        public User GetUserByID(string id)
        {
            string constraints = "user_id = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints); 
            DataRow row = dataTable.Rows[0];
            return new User(row["user_id"].ToString()!, row["user_fname"].ToString()!, row["user_mname"].ToString()!, row["user_lname"].ToString()!, row["user_username"].ToString()!, row["user_hash"].ToString()!, row["user_role"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_active"].ToString()!)));
        }

        public User GetUserByUserName(string username)
        {
            string constraints = "user_username = " + username;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new User(row["user_id"].ToString()!, row["user_fname"].ToString()!, row["user_mname"].ToString()!, row["user_lname"].ToString()!, row["user_username"].ToString()!, row["user_hash"].ToString()!, row["user_role"].ToString()!, Convert.ToBoolean(Int32.Parse(row["is_active"].ToString()!)));
        }

        public void UpdateUser(IUser user)
        {
            User userData = new User(user);
            string values = "(" + userData.FirstName + "," + userData.MiddleName + "," + userData.LastName + "," + userData.UserName + "," + userData.Hash + "," + userData.UserRole + "," + userData.IsActive + ")";
            string constraints = "user_id = " + userData.UserID;
            databaseHelper.UpdateRecord(this.tableName, values, constraints);
        }

        public void Dispose()
        {
            if (databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
