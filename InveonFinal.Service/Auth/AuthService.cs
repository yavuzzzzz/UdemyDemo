using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Service.Dtos.AuthDtos;
using InveonFinal.Service.Dtos;
using Microsoft.AspNetCore.Identity;
using InveonFinal.Service.Utils;

namespace InveonFinal.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid email or password");
            }

            return _tokenHandler.CreateAccessToken(user);
        }
    }

}
