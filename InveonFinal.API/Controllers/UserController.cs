using InveonFinal.Service.Concretes;
using InveonFinal.Service.Dtos.AuthDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class UserController : ControllerBase
    //{
    //    private readonly AppUserRepository _appUserRepository;

    //    public UserController(AppUserRepository appUserRepository)
    //    {
    //        _appUserRepository = appUserRepository;
    //    }

    //    [HttpPost("register")]
    //    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest(ModelState);

    //        var result = await _appUserRepository.RegisterAsync(registerDto.);
    //        if (!result.Success)
    //            return BadRequest(result.Message);

    //        return Ok(result.Message);
    //    }

    //    [HttpPost("login")]
    //    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest(ModelState);

    //        var result = await _appUserRepository.LoginAsync(loginDto.);
    //        if (!result.Success)
    //            return Unauthorized(result.Message);

    //        return Ok(result.Data); // Contains JWT token and other response data
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetUserById(string id)
    //    {
    //        var user = await _appUserRepository.GetUserByIdAsync(id);
    //        if (user == null)
    //            return NotFound();

    //        return Ok(user);
    //    }
    //}
}
