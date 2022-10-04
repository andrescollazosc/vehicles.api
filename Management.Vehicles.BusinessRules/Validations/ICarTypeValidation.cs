using Management.Vehicles.Core.Enums;

namespace Management.Vehicles.BusinessRules.Validations;
public interface ICarTypeValidation
{
    Guid ValidateVehicleType(CarType carType);
    CarType ValidateVehicleType(Guid vehicleTypeUid);
}
