using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Service.Dtos;
using InveonFinal.Service.Dtos.AuthDtos;

namespace InveonFinal.Service.Auth
{
    public interface IAuthService
    {
        Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
    }

}
