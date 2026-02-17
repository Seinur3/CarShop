using CarShopFinal.Domain.Models;

namespace CarShopFinal.Domain.Interfaces;

public interface ICarInterface
{
    Task<Car?> GetByIdAsync(Guid id);
    Task<List<Car>> GetAllAsync();
    Task AddAsync(Car car);
        //Task UpdateAsync(Car car);
    Task DeleteAsync(Car car);
}