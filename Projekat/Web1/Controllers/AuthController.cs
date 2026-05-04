using Microsoft.AspNetCore.Mvc;
using Web1.Models.DTOs.Auth;
using Web1.Services;

namespace Web1.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        var result = await _authService.Register(dto);

        if (result == null)
            return BadRequest("Korisnik sa tim username-om ili email-om već postoji.");

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await _authService.Login(dto);

        if (result == null)
            return Unauthorized("Pogrešan username/email ili lozinka.");

        return Ok(result);
    }
}