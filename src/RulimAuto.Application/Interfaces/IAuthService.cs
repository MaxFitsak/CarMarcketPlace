using Microsoft.AspNetCore.Identity;
using RulimAuto.Application.DTOs.Auth;

namespace RulimAuto.Application.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(RegisterDto dto);
    Task LogoutAsync();
}