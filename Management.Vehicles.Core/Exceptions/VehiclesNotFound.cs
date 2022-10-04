namespace Management.Vehicles.Core.Exceptions;
public class VehiclesNotFoundException : Exception
{
    public VehiclesNotFoundException() : base() { }

    public VehiclesNotFoundException(string message) : base(message){}

    public VehiclesNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
}
