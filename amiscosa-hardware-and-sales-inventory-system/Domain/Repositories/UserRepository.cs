using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Infrastructures;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DatabaseHelper databaseHelper;
        private readonly string tableName = "Users";
        private readonly string tableFields = "(user_id, user_fname, user_mname, user_lname, user_username, user_hash, user_role)";
        private readonly string tableUpdateFields = "(user_fname, user_mname, user_lname, user_username, user_hash, user_role)";

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
            User userData = new User(user);
            userData.IsActive = false;
            string values = "(" + userData.FirstName + "," + userData.MiddleName + "," + userData.LastName + "," + userData.UserName + "," + userData.Hash + "," + userData.UserRole + "," + userData.IsActive + ")";
            string constraints = "user_id = " + userData.UserID;
            databaseHelper.UpdateRecord(this.tableName, values, constraints);
        }

        public List<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserByID()
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(IUser user)
        {
            throw new NotImplementedException();
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
