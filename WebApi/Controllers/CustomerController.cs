using CarShopFinal.Application.Features.Customer.CreateCustomer;
using CarShopFinal.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShopFinal.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]

public class CustomerController:ControllerBase
{
    private readonly CreateCustomerHandler _createCustomerHandler;

    public CustomerController(CreateCustomerHandler createCustomerHandler)
    {
        _createCustomerHandler =  createCustomerHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand customer)
    {
        var newCustomer = await _createCustomerHandler.Handle(customer);
        return Ok(newCustomer);
    }
    
}