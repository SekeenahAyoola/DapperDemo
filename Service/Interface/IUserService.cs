using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;
using TMADapper.Model.enums;

namespace TMADapper.Service.Interface
{
    public interface IUserService
    {
        public User RegisterUser(string firstName, string lastName, string email, string password, int age, Gender gender,string phoneNumber, string role);
        public User UpdateUser(User user);
        public User GetUser(int id);
        public User GetUser(string email);
        public List<User> GetAllUsers();
    }
}