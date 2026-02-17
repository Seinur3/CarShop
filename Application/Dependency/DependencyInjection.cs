using CarShopFinal.Application.Service;

namespace CarShopFinal.Application.Dependency;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CarService>();
        
        return services;
    }
}