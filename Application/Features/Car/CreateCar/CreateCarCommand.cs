using CarShopFinal.Domain.Models;

namespace CarShopFinal.Application.Features.Car.CreateCar;

public record CreateCarCommand(string brand, string model, decimal price , int year , VIN vin);