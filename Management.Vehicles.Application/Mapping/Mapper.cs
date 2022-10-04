using Management.Vehicles.Application.DTO;
using Management.Vehicles.BusinessRules.Validations;
using Management.Vehicles.Core.Entities;
using Management.Vehicles.Core.Enums;

namespace Management.Vehicles.Application.Mapping;

public class Mapper : IMapper
{
    private readonly ICarTypeValidation _carTypeValidation;

    public Mapper(ICarTypeValidation carTypeValidation) 
        => _carTypeValidation = carTypeValidation;

    public CarDto Map(Car car)
        => new CarDto
        {
            Id = car.Id,
            Brand = car.Brand,
            CarType = car.CarType.ToString(),
            Model = car.Model,
            Color = car.Color,
            CubicCentimeters = car.CubicCentimeters,
            Velocity = car.Velocity
        };

    public Car Map(CarDto car)
        => new Car
        {
            Model = car.Model,
            Brand = car.Brand,
            CarType = ConvertStringToEnum(car.CarType),
            VehicleTypeId = MapVehicleType(ConvertStringToEnum(car.CarType)),
            Color = car.Color,
            CubicCentimeters = car.CubicCentimeters,
            Velocity = car.Velocity
        };

    private Guid MapVehicleType(CarType carType) 
        => _carTypeValidation.ValidateVehicleType(carType);

    private CarType ConvertStringToEnum(string carType)
    {
        var carTypeEnum = (CarType)Enum.Parse(typeof(CarType), carType);

        return carTypeEnum;
    }
}
