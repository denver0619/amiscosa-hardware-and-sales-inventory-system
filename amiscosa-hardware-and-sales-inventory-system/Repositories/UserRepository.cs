using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;
using amiscosa_hardware_and_sales_inventory_system.Domain.Infrastructures;

namespace amiscosa_hardware_and_sales_inventory_system.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DatabaseHelper databaseHelper;
        private readonly String tableName = "Users";
        private readonly String tableFields = "(user_id, user_fname, user_mname, user_lname, user_username, user_hash, user_role)";

        public UserRepository()
        {
            databaseHelper = new DatabaseHelper();
        }

        public void AddUser(IUser user, String password)
        {
            //TODO: User hashing functions
            String userHash = "";
            String userValues = "(" +","+ user.UserID + "," + user.FirstName + "," + user.MiddleName + "," + user.LastName + "," + user.UserName + "," + userHash + "," + user.UserRole + ")";
            List<String> values = [userValues];
            databaseHelper.InsertRecord(tableName, tableFields, values);
        }

        public void DeleteUser(IUser user)
        {
            throw new NotImplementedException();
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
