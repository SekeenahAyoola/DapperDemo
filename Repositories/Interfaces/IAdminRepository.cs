using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;

namespace TMADapper.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        public Admin CreateAdmin(Admin admin);
        public Admin GetAdmin(int id);
        public Admin GetAdminByUserId(int userId);
        public List<Admin> GetAllAdmin();
    }
}