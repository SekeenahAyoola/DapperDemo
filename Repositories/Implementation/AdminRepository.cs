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
    public class AdminRepository : IAdminRepository
    {
        private readonly DbContext _context;
        public AdminRepository(DbContext context)
        {
            _context = context;
        }
        public Admin CreateAdmin(Admin admin)
        {
            _context.CreateAdminTable();
            string query = $"INSERT into Admin(UserId) values({admin.UserId})";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var a = connection.Execute(query);
                return admin;
            }
        }

        public Admin GetAdmin(int id)
        {
            string query = $"SELECT * From Admin where Id = {id}"; 
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var admin = connection.QueryFirstOrDefault<Admin>(query);
                return admin;
            }
        }

        public Admin GetAdminByUserId(int userId)
        {
            string query = $"SELECT * From Admin where Email = {userId}"; 
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var admin = connection.QueryFirstOrDefault<Admin>(query);
                return admin;
            }
        }

        public List<Admin> GetAllAdmin()
        {
            string query = $"SELECT * From Admin"; 
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var admin = connection.Query<Admin>(query).ToList();
                return admin;
            }
        }
    }
}