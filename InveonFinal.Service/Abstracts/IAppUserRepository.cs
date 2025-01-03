using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Service.Dtos.AuthDtos;
using InveonFinal.Service.Dtos.UserDtos;

namespace InveonFinal.Service.Abstracts
{
    public interface IAppUserRepository : IGenericRepository<UserResponseDto>
    {
        Task<UserResponseDto> GetUserByFirstNameAsync(string firstName);
        Task<IEnumerable<UserResponseDto>> GetUsersByRoleAsync(string role);
        Task<RegisterDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginDto> LoginAsync(LoginDto loginDto);

    }
}

