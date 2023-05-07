using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;

namespace TMADapper.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User CreateUser(User user);
        public User UpdateUser(User user);
        public User GetUser(int id);
        public User GetUser(string email);
        public List<User> GetAllUsers();
        public User DeleteUser(User user);
    }
}