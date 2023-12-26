using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface IUserRepository
    {
        public User GetUserByID();
        public User GetUserByUserName(string username);
        public List<User> GetAllUser();
        public void AddUser(IUser user, string password);
        public void UpdateUser(IUser user);
        public void DeleteUser(IUser user);
    }
}
