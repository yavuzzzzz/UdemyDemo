using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Data;
using InveonFinal.Data.Repositories;
using InveonFinal.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InveonFinal.Service.Concretes
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly AppDbContext _context;

        public AppUserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<AppUser> GetUserByNameAsync(string firstName)
        {
            var user = await _context.Users
                                     .FirstOrDefaultAsync(u => u.FirstName == firstName);
            return user;
        }

        public async Task<IEnumerable<AppUser>> GetUsersByRoleAsync(string roleName)
        {
            var role = await _context.Roles
                                     .FirstOrDefaultAsync(r => r.Name == roleName);

            if (role == null)
            {
                return new List<AppUser>();
            }

            var userIds = await _context.UserRoles
                                        .Where(x => x.RoleId == role.Id)
                                        .Select(x => x.UserId)
                                        .ToListAsync();

            return await _context.Users
                                 .Where(u => userIds.Contains(u.Id))
                                 .ToListAsync();
        }
    }
}
