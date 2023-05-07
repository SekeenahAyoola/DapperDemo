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
    public class TutorRepository : ITutorRepository
    {
        private readonly DbContext _context;
        public TutorRepository(DbContext context)
        {
            _context = context;
        }
        public Tutor CreateTutor(Tutor tutor)
        {
            _context.CreateTutorTable();
            string query = $"Insert into tutor (UserId, Qualification) values ({tutor.UserId}, '{tutor.Qualification}')";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                connection.Execute(query);
                return tutor;
            }
        }

        public List<Tutor> GetAllTutor()
        {
            string query = $"SELECT * From Tutor";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var tutors = connection.Query<Tutor>(query).ToList();
                return tutors;
            }
        }

        public Tutor GetTutor(int id)
        {
            string query = $"SELECT * FROM Tutor where id = {id}";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var tutor = connection.QueryFirstOrDefault<Tutor>(query);
                return tutor;
            }
        }

        public Tutor GetTutorByUserId(int userId)
        {
            string query = $"SELECT * FROM Tutor where userId = {userId}";
            using (var connection = new MySqlConnection(_context.connectionStrings))
            {
                connection.Open();
                var tutor = connection.QueryFirstOrDefault<Tutor>(query);
                return tutor;
            }
        }
    }
}