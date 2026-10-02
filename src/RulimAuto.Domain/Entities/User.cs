using RulimAuto.Domain.Enum;

namespace RulimAuto.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirmation { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Listing> Listings { get; set; }
    
}