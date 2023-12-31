﻿using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface IUserRepository
    {
        public User GetUserByID(string id);
        public User GetUserByUserName(string username);
        public List<User> GetAllUser();
        public List<User> GetAllActiveUser();
        public List<User> GetAllInactiveUser();
        public void AddUser(User user, string password);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
