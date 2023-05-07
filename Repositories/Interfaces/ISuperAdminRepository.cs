using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMADapper.Model.entities;

namespace TMADapper.Repositories.Interfaces
{
    public interface ISuperAdminRepository
    {
        SuperAdmin GetSuperAdmin(string email);
    }
}