using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;
using TMADapper.Model.enums;
using TMADapper.Repositories.Interfaces;
using TMADapper.Service.Interface;

namespace TMADapper.Service.Implementation
{
    public class UserService : IUserService
    {
        public static List<User> listOfUsers = new List<User>();
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
           listOfUsers = _userRepository.GetAllUsers();
           return listOfUsers;
        }

        public User GetUser(int id)
        {
            User user = _userRepository.GetUser(id);
            return user;
        }

        public User GetUser(string email)
        {
            User user = _userRepository.GetUser(email);
            return user;
        }

        public User RegisterUser(string firstName, string lastName, string email, string password, int age, Gender gender,string phoneNumber, string role)
        {
            if (UserExists(email))
            {
                Console.WriteLine("User already exist");
                return null;
            }
            else
            {
                User user = new User();
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Age = age;
                user.Email = email;
                user.Gender = gender;
                user.Role = role;
                user.Password = password;
                user.PhoneNumber = phoneNumber;
                // user.DateCreated = DateTime.Now;
                // user.DateModified = DateTime.Now;
                user.IsDeleted = false;
                User newUser = _userRepository.CreateUser(user);
                return newUser;
            }

        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
        private bool UserExists (string email)
        {
            foreach (var item in listOfUsers)
            {
                if (email == item.Email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}