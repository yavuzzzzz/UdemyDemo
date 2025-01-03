using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Data;
using InveonFinal.Data.Repositories;
using InveonFinal.Service.Abstracts;
using InveonFinal.Service.Dtos.AuthDtos;
using InveonFinal.Service.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InveonFinal.Service.Concretes
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserRepository(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task AddAsync(UserResponseDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> GetUserByFirstNameAsync(string firstName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseDto>> GetUsersByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }

        public Task<LoginDto> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> RegisterAsync(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserResponseDto entity)
        {
            throw new NotImplementedException();
        }

        public UserResponseDto Update(UserResponseDto entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserResponseDto>> IGenericRepository<UserResponseDto>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<UserResponseDto?> IGenericRepository<UserResponseDto>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //    public async Task<UserResponseDto> GetUserByNameAsync(string firstName)
        //    {
        //        var user = await _context.Users
        //                                 .FirstOrDefaultAsync(e => e.FirstName == firstName);
        //        return user;
        //    }

        //    public async Task<IEnumerable<AppUser>> GetUsersByRoleAsync(string roleName)
        //    {
        //        var role = await _context.Roles
        //                                 .FirstOrDefaultAsync(x => x.Name == roleName);

        //        if (role == null)
        //        {
        //            return new List<AppUser>();
        //        }

        //        var userIds = await _context.UserRoles
        //                                    .Where(x => x.RoleId == role.Id)
        //                                    .Select(x => x.UserId)
        //                                    .ToListAsync();

        //        return await _context.Users
        //                             .Where(u => userIds.Contains(u.Id))
        //                             .ToListAsync();
        //    }

        //    public async Task<AppUser> LoginAsync(string email, string password)
        //    {
        //        var user = await _userManager.FindByEmailAsync(email);
        //        if (user == null)
        //        {
        //            return null;
        //        }

        //        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        //        if (result.Succeeded)
        //        {
        //            return user;
        //        }

        //        return null;
        //    }

        //    public async Task<AppUser> RegisterAsync(AppUser appUser, string password)
        //    {
        //        var result = await _userManager.CreateAsync(appUser,password);
        //        if (result.Succeeded)
        //        {
        //            return appUser;
        //        }

        //        throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        //    }
        //}
    }
