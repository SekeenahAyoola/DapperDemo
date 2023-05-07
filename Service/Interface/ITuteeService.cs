using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;
using TMADapper.Model.enums;

namespace TMADapper.Service.Interface
{
    public interface ITuteeService
    {
        public Tutee RegisterTutee( int userId, Level level);
        public Tutee UpdateTutee(Tutee Tutee);
        public Tutee GetTutee(int id);
        public Tutee GetTutee(string email);
        public List<Tutee> GetAllTutees();
    }
}