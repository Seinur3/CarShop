using CarShopFinal.Application.Features.Car.CreateCar;
//using CarShopFinal.Application.Service;
using CarShopFinal.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShopFinal.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CreateCarHandler _createCarHandler;

    public CarsController(CreateCarHandler createCarHandler)
    {
        _createCarHandler = createCarHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(string brand, string model, decimal price, int year, string vin)
    {
        var command = new CreateCarCommand(brand, model, price, year, new VIN(vin));
        var carId = await _createCarHandler.Handle(command);
        return Ok(carId);
    }

}