using CarShopFinal.Domain.Interfaces;
using CarShopFinal.Persistance.Context;
using CarShopFinal.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarShopFinal.Persistance.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CarDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<ICarInterface, CarRepository>();
        
        return services;
    }
}