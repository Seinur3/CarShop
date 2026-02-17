using CarShopFinal.Domain.Interfaces;
using CarShopFinal.Domain.Models;
using CarShopFinal.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarShopFinal.Persistance.Repositories;

public class CarRepository : ICarInterface
{
    
    private readonly CarDbContext _context;
    
    public CarRepository(CarDbContext context)
    {
        _context = context;
    }
    
    public async Task<Car?> GetByIdAsync(Guid id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task<List<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task AddAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Car car)
    {
         _context.Cars.Remove(car);
    }
}

