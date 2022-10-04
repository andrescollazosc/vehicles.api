using Management.Vehicles.Application.DTO;

namespace Management.Vehicles.Application.Abstractions;

public interface ICarApplicationService
{
    Task<CarDto> AddAsync(CarDto car);
    Task<IEnumerable<CarDto>> GetAllActiveCar();
    Task<CarDto> GetById(Guid id);
}
