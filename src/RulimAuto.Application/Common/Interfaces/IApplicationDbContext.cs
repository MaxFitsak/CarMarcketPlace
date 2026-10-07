using Microsoft.EntityFrameworkCore;
using RulimAuto.Domain.Entities;

namespace RulimAuto.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Car> Cars { get; set; }
    DbSet<Listing> Listings { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}