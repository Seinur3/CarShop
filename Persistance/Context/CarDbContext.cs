using Microsoft.EntityFrameworkCore;
using CarShopFinal.Domain.Models;
namespace CarShopFinal.Persistance.Context;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Car> Cars => Set<Car>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarDbContext).Assembly);
    }
}