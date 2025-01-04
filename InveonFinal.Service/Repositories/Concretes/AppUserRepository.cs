using InveonFinal.Core.Models;
using InveonFinal.Core.UnitOfWork;
using InveonFinal.Data.Repositories;
using InveonFinal.Data;
using InveonFinal.Service.Repositories.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace InveonFinal.Service.Repositories.Concretes
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserRepository(AppDbContext context, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(context, unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<AppUser>> GetUsersByRoleAsync(string role)
        {
            return await _userManager.GetUsersInRoleAsync(role);
        }

        public async Task<AppUser?> RegisterAsync(AppUser appUser, string password)
        {
            var result = await _userManager.CreateAsync(appUser, password);
            return result.Succeeded ? appUser : null;
        }

        public async Task<AppUser?> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            return result.Succeeded ? user : null;
        }
    }


}






