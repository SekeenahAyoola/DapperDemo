using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using TMADapper.Context;
using TMADapper.Model.entities;
using TMADapper.Repositories.Interfaces;

namespace TMADapper.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;
        public UserRepository(DbContext _context)
        {
            context = _context;
        }
        public User CreateUser(User user)
        {
            context.CreateUserTable();
            string query = $"insert into User (FirstName, LastName , Email, Password,PhoneNumber,Gender,Age,Role,IsDeleted,DateCreated,DateModified ) values('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}','{user.PhoneNumber}','{user.Gender}', {user.Age},'{user.Role}',{user.IsDeleted},'{user.DateCreated}','{user.DateModified}')";
            using(var connection = new MySqlConnection(context.connectionStrings))
            {
                connection.Open();
                var asd = connection.Execute(query);
                return user;
            } 
        }

        public User DeleteUser(User user)
        {
            string query = $"UPDATE user IsDeleted = {user.IsDeleted} DateModified = '{user.DateModified}' where Id = {user.Id}";
            using (var connection = new MySqlConnection(context.connectionStrings))
            {
                connection.Open();
                var a = connection.Execute(query);
                return user;
            }
        }

        public List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM user";
            using(var connection = new MySqlConnection(context.connectionStrings))
            {
                connection.Open();
                var users = connection.Query<User>(query);
                return users.ToList();
            }
        }

        public User GetUser(int id)
        {
            string query = $"SELECT * FROM user where id = {id}";
            using (var connection = new MySqlConnection(context.connectionStrings))
            {
                connection.Open();
                var user = connection.QueryFirstOrDefault<User>(query);
                return user;
            }
        }

        public User GetUser(string email)
        {
            string query = $"SELECT * FROM user where Email = '{email}'";
            using (var connection = new MySqlConnection(context.connectionStrings))
            {
                connection.Open();
                var user = connection.QueryFirstOrDefault<User>(query);
                return user;
            }
        }

        public User UpdateUser(User user)
        {
            string query = $"UPDATE user FirstName = '{user.FirstName}' LastName = '{user.LastName}' Age = {user.Age} DateModified = '{user.DateModified}'where Id = {user.Id}";
            using (var connection = new MySqlConnection(context.connectionStrings))
            {
                connection.Open();
                var updateUser = connection.Execute(query);
                return user;
            }
        }
    }
}