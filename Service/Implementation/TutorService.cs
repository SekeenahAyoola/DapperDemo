using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;
using TMADapper.Repositories.Interfaces;
using TMADapper.Service.Interface;

namespace TMADapper.Service.Implementation
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly IUserRepository _userRepository;
        public TutorService(ITutorRepository tutorRepository, IUserRepository userRepository)
        {
            _tutorRepository = tutorRepository;
            _userRepository = userRepository;
        }
        public List<Tutor> GetAllTutors()
        {
            return _tutorRepository.GetAllTutor();
        }

        public Tutor GetTutor(int id)
        {
            Tutor tutor = _tutorRepository.GetTutor(id);
            return tutor;
        }

        public Tutor GetTutor(string email)
        {
            User user = _userRepository.GetUser(email);
            if (user != null && !user.IsDeleted)
            {
                return _tutorRepository.GetTutorByUserId(user.Id);
            }
            return null;
        }

        public Tutor RegisterTutor(int userId, string qualification)
        {
            Tutor tutor = new Tutor();
            tutor.UserId = userId;
            tutor.Qualification = qualification;
            return _tutorRepository.CreateTutor(tutor);
        }

        public Tutor UpdateTutor(Tutor tutor)
        {
            throw new NotImplementedException();
        }
    }
}