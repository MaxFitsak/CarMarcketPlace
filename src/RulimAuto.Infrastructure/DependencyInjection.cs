using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulimAuto.Infrastructure.Contextes;

namespace RulimAuto.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqliteConnection");

        services.AddDbContext<CarContext>(options =>
            options.UseSqlite(connectionString));

        // Сюда же позже добавите регистрацию репозиториев и других сервисов

        return services;
    }
}