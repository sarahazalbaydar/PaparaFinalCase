using Application.Repositories;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.UpdateUser;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest, ApiResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChangePasswordCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ApiResponse> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        var userIdString = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdString) || !long.TryParse(userIdString, out var userId))
            return new ApiResponse("Unauthorized access");

        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null || !user.IsActive)
            return new ApiResponse("User not found or inactive");

        var isValid = BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.Password);
        if (!isValid)
            return new ApiResponse("Current password is incorrect");

        user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        var updated = _userRepository.Update(user);

        if (!updated)
            return new ApiResponse("Password change failed");

        await _userRepository.SaveChangesAsync();
        return new ApiResponse("Password changed successfully");

    }
}
