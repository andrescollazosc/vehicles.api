using Management.Vehicles.Application.DTO;
using Management.Vehicles.Core.Entities;

namespace Management.Vehicles.Application.Mapping;

public interface IMapper
{
    CarDto Map(Car car);
    Car Map(CarDto car);
}
