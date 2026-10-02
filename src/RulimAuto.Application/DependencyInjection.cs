using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace RulimAuto.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Автоматично знаходить і реєструє всі валідатори з поточної збірки
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}