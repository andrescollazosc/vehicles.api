using Management.Vehicles.Core.Constants;
using Management.Vehicles.Core.Enums;

namespace Management.Vehicles.BusinessRules.Validations;

public class CarTypeValidation : ICarTypeValidation
{
    public Guid ValidateVehicleType(CarType carType)
        => carType switch
        {
            CarType.Car => VehicleType.Car,
            CarType.Motorcycle => VehicleType.Motorcycle,
            CarType.Truck => VehicleType.Truck,
            _ => VehicleType.Default,
        };

    public CarType ValidateVehicleType(Guid vehicleTypeUid)
    {
        if (vehicleTypeUid == VehicleType.Car)
            return CarType.Car;
        if (vehicleTypeUid == VehicleType.Truck)
            return CarType.Truck;
        if (vehicleTypeUid == VehicleType.Motorcycle)
            return CarType.Motorcycle;

        return CarType.Default;
    }

}
