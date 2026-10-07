using Microsoft.AspNetCore.Identity;
using RulimAuto.Application.DTOs.Auth;
using RulimAuto.Application.Interfaces;
using RulimAuto.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace RulimAuto.Application.Services;

public class AuthService : IAuthService
{
    
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
        };
        
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        return result;
    }
    
    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
    
    
}