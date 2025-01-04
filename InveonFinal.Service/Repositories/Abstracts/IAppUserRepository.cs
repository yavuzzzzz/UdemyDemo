using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Service.Dtos.AuthDtos;
using InveonFinal.Service.Dtos.UserDtos;

namespace InveonFinal.Service.Repositories.Abstracts
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> GetUsersByRoleAsync(string role);
        Task<AppUser?> RegisterAsync(AppUser appUser, string password);
        Task<AppUser?> LoginAsync(string email, string password);
    }

}

