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

        Task<IQueryable<UserResponseDto>> IGenericRepository<UserResponseDto>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<UserResponseDto?> IGenericRepository<UserResponseDto>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
