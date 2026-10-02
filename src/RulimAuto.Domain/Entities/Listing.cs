using RulimAuto.Domain.Enum;

namespace RulimAuto.Domain.Entities;

public class Listing
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ListingStatus Status { get; set; }
    public string City { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int Views { get; set; }
    public string Photo { get; set;  }
    
}