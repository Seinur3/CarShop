using CarShopFinal.Domain.Interfaces;
using CarShopFinal.Domain.Models;
using CarShopFinal.Persistance.Context;

namespace CarShopFinal.Persistance.Repositories;

public class CustomerRepository:ICustomerRepository
{
    private readonly CarDbContext _context;
    
    public CustomerRepository(CarDbContext context)
    {
        _context = context;
    }
    public async Task<Customer?> GetById(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer?> GetByEmail(string email)
    {
        return await _context.Customers.FindAsync(email);
    }

    public async Task<Guid> AddAsync(Customer customer)
    {
        _context.Add(customer);
        await _context.SaveChangesAsync();
        return  customer.Id;
    }
}