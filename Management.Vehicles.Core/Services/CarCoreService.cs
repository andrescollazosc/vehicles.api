using Management.Vehicles.Core.Contracts;
using Management.Vehicles.Core.Contracts.Repositories;
using Management.Vehicles.Core.Entities;
using Management.Vehicles.Core.Exceptions;

namespace Management.Vehicles.Core.Services;

public class CarCoreService : ICarCoreService
{
    private readonly ICarRepository _carRepository;

    public CarCoreService(ICarRepository carRepository)
        => _carRepository = carRepository;

    public async Task<Car> AddAsync(Car car)
    {
        car.Id = Guid.NewGuid();
        car.IsActive = true;
        car.CreateDate = DateTime.Now;

        await _carRepository.AddAsync(car);

        return car;
    }

    public async Task<IEnumerable<Car>> GetAllActiveCar()
        => await _carRepository.GetAllActiveCarsAsync();

    public async Task<Car> GetById(Guid id)
    {
        var car = await _carRepository.GetByIdAsync(id);

        if (car == null)
            throw new VehiclesNotFoundException($"This Id {id} was not found.");

        return car;
    }
}
