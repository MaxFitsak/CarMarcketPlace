using Microsoft.AspNetCore.Identity;
using RulimAuto.Domain.Enum;

namespace RulimAuto.Domain.Entities;

// Наследуемся от IdentityUser<Guid>, чтобы Id стал Guid автоматически
public class User : IdentityUser<Guid>
{
    public string? Name { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Listing> Listings { get; set; } = new();
}