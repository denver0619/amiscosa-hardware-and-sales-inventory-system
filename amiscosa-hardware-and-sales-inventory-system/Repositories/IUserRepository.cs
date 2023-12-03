using amiscosa_hardware_and_sales_inventory_system.Models;
namespace amiscosa_hardware_and_sales_inventory_system.Repositories
{
    public interface IUserRepository
    {
        public User GetUserByID();
        public User GetUserByUserName(string username);
        public List<User> GetAllUser();
        public void AddUser();
        public void UpdateUser();
        public void DeleteUser();
    }
}
