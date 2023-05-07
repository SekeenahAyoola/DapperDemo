using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;

namespace TMADapper.Repositories.Interfaces
{
    public interface ITuteeRepository
    {
        public Tutee CreateTutee(Tutee tutor);
        public Tutee GetTutee(int id);
        public Tutee GetTuteeByUserId(int userId);
        public List<Tutee> GetAllTutee();
    }
}