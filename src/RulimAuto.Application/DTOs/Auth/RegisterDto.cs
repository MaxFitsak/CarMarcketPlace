using System.ComponentModel.DataAnnotations;
using RulimAuto.Domain.Enum;

namespace RulimAuto.Application.DTOs.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "Ім'я обов'язкове")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Ім'я має бути від 2 до 50 символів")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Пароль обов'язковий")]
    [MinLength(6, ErrorMessage = "Пароль повинен бути від 6 символів")]
    public string Password { get; set; } = string.Empty;
    
    [Compare("Password", ErrorMessage = "Паролі не співпадають")]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "email обов'язковий")]
    [EmailAddress(ErrorMessage = "Не коректний email")]
    public string Email { get; set; } = string.Empty;
    public int Phone { get; set; }
}