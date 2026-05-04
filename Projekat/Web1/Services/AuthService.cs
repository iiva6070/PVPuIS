using Web1.Data;
using Web1.Models.Entities;
using Web1.Models.DTOs.Auth;
using BCrypt.Net;

namespace Web1.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwtService;

    public AuthService(AppDbContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto?> Register(RegisterRequestDto dto)
    {
        // provera da li postoji user
        if (_context.Users.Any(u => u.Email == dto.Email || u.Username == dto.Username))
            return null;

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            ImageUrl = dto.ImageUrl,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var token = _jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }

    public async Task<AuthResponseDto?> Login(LoginRequestDto dto)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Email == dto.UsernameOrEmail || u.Username == dto.UsernameOrEmail);

        if (user == null)
            return null;

        bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

        if (!isValid)
            return null;

        var token = _jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }
}
