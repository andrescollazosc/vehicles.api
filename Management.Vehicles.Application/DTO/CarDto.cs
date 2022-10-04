namespace Management.Vehicles.Application.DTO;

public class CarDto
{
    public Guid Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string CarType { get; set; } = string.Empty;
    public int Velocity { get; set; }
    public string Color { get; set; } = string.Empty;
    public string CubicCentimeters { get; set; } = string.Empty;
}
