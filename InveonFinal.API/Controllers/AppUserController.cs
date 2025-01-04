using InveonFinal.Service.Dtos.AuthDtos;
using InveonFinal.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _appUserService.RegisterAsync(registerDto);
            if (result != null)
            {
                return BadRequest(result);
            }

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _appUserService.LoginAsync(loginDto);
            if (result != null)
            {
                return Unauthorized(result);
            }

            return Ok("Login successful");
        }
    }

}
