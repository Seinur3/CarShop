using CarShopFinal.Application.Features.Car.CreateCar;
using CarShopFinal.Application.Features.Car.GetAllCars;

//using CarShopFinal.Application;

namespace CarShopFinal.Application.Dependency;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateCarHandler>();
        services.AddScoped<GetAllCarsHandler>();
        
        return services;
    }
}