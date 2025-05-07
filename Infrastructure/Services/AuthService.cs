using Domain.Entities;
using Application.Abstractions.Services;
using Application.Abstractions.Token;
using Application.DTOs;
using Application.Repositories;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthService(IRepository<User> userRepository, IJwtTokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetSingleAsync(u => u.UserName == dto.UserName);
        if (existingUser != null)
            throw new Exception("This UserName already exits.");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var newUser = new User
        {
            UserName = dto.UserName,
            Password = hashedPassword,
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            IBAN = dto.IBAN,
            Role = dto.Role,
            IsActive = true
        };

        await _userRepository.AddAsync(newUser);

        await _userRepository.SaveChangesAsync();
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetSingleAsync(u => u.UserName == dto.UserName);
        if (user == null)
            throw new UnauthorizedAccessException("User not found.");


        var isValidPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
        if (!isValidPassword)
            throw new UnauthorizedAccessException("Password incorrect");

        return _tokenGenerator.GenerateToken(user);
    }
}
