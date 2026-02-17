using CarShopFinal.Domain.Interfaces;
using CarShopFinal.Domain.Models;
using CarShopFinal.Domain.ValueObjects;
using CarShopFinal.Persistance.Context;

namespace CarShopFinal.Application.Service;

public class CarService
{
    private readonly ICarInterface _carInterface;
    public CarService(ICarInterface carInterface)
    {
        _carInterface = carInterface;
    }

    public async Task<Guid> CreateCar(string brand, string model, decimal price , int year , VIN vin)
    {
        var car = new Car(brand, model, year, vin,new Money(price, "USD"));
        
        await _carInterface.AddAsync(car);
        
        return car.Id;
    }
    
    public async Task<List<Car>> GetAllCars()
    {
        return await _carInterface.GetAllAsync();
    }
}