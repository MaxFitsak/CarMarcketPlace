using Microsoft.AspNetCore.Mvc;
using RulimAuto.Application.DTOs.Auth;
using RulimAuto.Application.Interfaces;

namespace RulimAuto.WebApi.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var result = await _authService.RegisterAsync(dto);

        if (result.Succeeded)
            return RedirectToAction("Index", "AutoRulim");

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return RedirectToAction("Index", "AutoRulim");
    }
    
}