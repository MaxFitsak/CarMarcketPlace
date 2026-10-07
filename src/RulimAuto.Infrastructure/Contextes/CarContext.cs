using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RulimAuto.Domain.Entities;

public class CarContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public CarContext(DbContextOptions<CarContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarContext).Assembly);
    }
}