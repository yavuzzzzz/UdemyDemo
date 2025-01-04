using InveonFinal.Core.Models;
using InveonFinal.Service.Dtos.AuthDtos;
using InveonFinal.Service.Dtos.UserDtos;
using InveonFinal.Service.Repositories.Abstracts;
using InveonFinal.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.Service.Services.Concretes
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<IEnumerable<UserResponseDto>> GetUsersByRoleAsync(string role)
        {
            var users = await _appUserRepository.GetUsersByRoleAsync(role);
            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            });
        }

        public async Task<ProblemDetails?> RegisterAsync(RegisterDto registerDto)
        {
            var newUser = new AppUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _appUserRepository.RegisterAsync(newUser, registerDto.Password);
            if (result == null)
            {
                return new ProblemDetails
                {
                    Title = "Registration Failed",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "User could not be created."
                };
            }

            return null;
        }

        public async Task<ProblemDetails?> LoginAsync(LoginDto loginDto)
        {
            var user = await _appUserRepository.LoginAsync(loginDto.Email, loginDto.Password);
            if (user == null)
            {
                return new ProblemDetails
                {
                    Title = "Unauthorized",
                    Status = StatusCodes.Status401Unauthorized,
                    Detail = "Invalid credentials."
                };
            }

            return null; 
        }
    }


}
