using Management.Vehicles.Core.Entities.Base;
using Management.Vehicles.Core.Enums;

namespace Management.Vehicles.Core.Entities;

public class Car : Vehicle
{
    public Guid VehicleTypeId { get; set; }
    public int Velocity { get; set; }
    public string Color { get; set; } = string.Empty;
    public CarType CarType { get; set; }
    public bool IsActive { get; set; }
    
}
