using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;

namespace TMADapper.Service.Interface
{
    public interface ITutorService
    {
        public Tutor RegisterTutor(int userId, string qualification);
        public Tutor UpdateTutor(Tutor tutor);
        public Tutor GetTutor(int id);
        public Tutor GetTutor(string email);
        public List<Tutor> GetAllTutors();
    }
}