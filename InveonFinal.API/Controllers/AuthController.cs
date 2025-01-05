using InveonFinal.Service.Auth;
using InveonFinal.Service.Dtos.AuthDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var token = await _authService.LoginAsync(loginDto);
                return Ok(new { Message = "Login successful", Token = token.AccessToken, Expiration = token.Expiration });
            }
            catch (Exception ex)
            {
                return Unauthorized(new ProblemDetails
                {
                    Title = "Login Failed",
                    Status = StatusCodes.Status401Unauthorized,
                    Detail = ex.Message,
                    Instance = HttpContext.Request.Path
                });
            }
        }
    }

}
