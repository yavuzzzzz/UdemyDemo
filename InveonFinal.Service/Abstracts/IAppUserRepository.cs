using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;

namespace InveonFinal.Service.Abstracts
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> GetUserByNameAsync(string firstName);
        Task<IEnumerable<AppUser>> GetUsersByRoleAsync(string roleName);
    }
}

