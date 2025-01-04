using InveonFinal.Service.Dtos.AuthDtos;
using InveonFinal.Service.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.Service.Services.Abstract
{
    public interface IAppUserService
    {
        Task<IEnumerable<UserResponseDto>> GetUsersByRoleAsync(string role);
        Task<ProblemDetails?> RegisterAsync(RegisterDto registerDto);
        Task<ProblemDetails?> LoginAsync(LoginDto loginDto);
    }


}
