using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;

namespace TMADapper.Repositories.Interfaces
{
    public interface ITutorRepository
    {
        public Tutor CreateTutor(Tutor tutor);
        public Tutor GetTutor(int id);
        public Tutor GetTutorByUserId(int userId);
        public List<Tutor> GetAllTutor();
    }
}