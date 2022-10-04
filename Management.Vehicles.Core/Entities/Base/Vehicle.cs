namespace Management.Vehicles.Core.Entities.Base;

public class Vehicle : Audit
{
    public Guid Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string CubicCentimeters { get; set; } = string.Empty;
}
