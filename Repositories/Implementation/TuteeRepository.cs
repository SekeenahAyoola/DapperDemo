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
    public class TuteeRepository : ITuteeRepository
    {

        private readonly DbContext _context;
        public TuteeRepository(DbContext context)
        {
            _context = context;
        }
        public Tutee CreateTutee(Tutee tutee)
        {
            _context.CreateTuteeTable();
            string query = $"Insert into tutee (UserId, TuteeLevel) values ({tutee.UserId}, '{tutee.TuteeLevel}')";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                connection.Execute(query);
                return tutee;
            }
        }

        public List<Tutee> GetAllTutee()
        {
            string query = $"SELECT * From Tutee";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var tutees = connection.Query<Tutee>(query).ToList();
                return tutees;
            }
        }

        public Tutee GetTutee(int id)
        {
            string query = $"SELECT * FROM Tutee where id = {id}";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var tutee = connection.QueryFirstOrDefault<Tutee>(query);
                return tutee;
            }
        }

        public Tutee GetTuteeByUserId(int userId)
        {
            string query = $"SELECT * FROM Tutee where userId = {userId}";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var tutee = connection.QueryFirstOrDefault<Tutee>(query);
                return tutee;
            }
        }
    }
}