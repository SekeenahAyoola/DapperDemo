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
    public class TuteeService : ITuteeService
    {
        private readonly ITuteeRepository _tuteeRepository;
        private readonly IUserRepository _userRepository;
        public TuteeService(ITuteeRepository tuteeRepository, IUserRepository userRepository)
        {
            _tuteeRepository = tuteeRepository;
            _userRepository = userRepository;
        }
        public List<Tutee> GetAllTutees()
        {
            return _tuteeRepository.GetAllTutee();
        }

        public Tutee GetTutee(int id)
        {
            Tutee tutee  = _tuteeRepository.GetTutee(id);
            return tutee;
        }

        public Tutee GetTutee(string email)
        {
            User user = _userRepository.GetUser(email);
            if (user != null && !user.IsDeleted)
            {
                return _tuteeRepository.GetTuteeByUserId(user.Id);
            }
            return null;
        }

        public Tutee RegisterTutee(int userId, Level level)
        {
            Tutee tutee = new Tutee()
            {
                UserId = userId,
                TuteeLevel = level
            };
            return   _tuteeRepository.CreateTutee(tutee);
        }

        public Tutee UpdateTutee(Tutee Tutee)
        {
            throw new NotImplementedException();
        }
    }
}