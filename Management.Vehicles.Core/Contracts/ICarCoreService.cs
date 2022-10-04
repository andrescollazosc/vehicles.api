using Management.Vehicles.Core.Entities;

namespace Management.Vehicles.Core.Contracts;

public interface ICarCoreService
{
    Task<Car> AddAsync(Car car);
    Task<IEnumerable<Car>> GetAllActiveCar();
    Task<Car> GetById(Guid id);
}
