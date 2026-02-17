using CarShopFinal.Application.Service;
using CarShopFinal.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShopFinal.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CarService _carService;

    [HttpPost]
    public async Task<IActionResult> CreateCar(string brand, string model, decimal price, int year, string vin)
    {
        var carId = await _carService.CreateCar(brand, model, price, year, new VIN(vin));
        return Ok(carId);
    }

}