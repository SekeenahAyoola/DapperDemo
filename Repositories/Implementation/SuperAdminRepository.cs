using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;
using TMADapper.Repositories.Interfaces;

namespace TMADapper.Repositories.Implementation
{
    public class SuperAdminRepository : ISuperAdminRepository
    {
        public SuperAdmin GetSuperAdmin(string email)
        {
            throw new NotImplementedException();
        }
    }
}