using Microsoft.EntityFrameworkCore;
using RulimAuto.Domain.Entities; // Подключаем сущности из Domain

namespace RulimAuto.Infrastructure.Contextes;

public class CarContext : DbContext
{
    // Конструктор принимает DbContextOptions, чтобы строку подключения можно было задать снаружи
    public CarContext(DbContextOptions<CarContext> options) : base(options)
    {
    }

    // Ваши таблицы (DbSet)
    public DbSet<Car> Cars => Set<Car>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Автоматически применяет все конфигурации (IEntityTypeConfiguration) из сборки Infrastructure
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarContext).Assembly);
    }
}