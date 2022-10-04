using Management.Vehicles.Application.DTO;
using Management.Vehicles.Application.Mapping;
using Management.Vehicles.Core.Contracts;
using Management.Vehicles.Core.Entities;
using Management.Vehicles.Core.Enums;
using Moq;
using Xunit;

namespace Management.Vehicles.Application.UnitTests;

public class CarApplicationServiceTests
{
    [Fact]
    public void AddAsync_IsCalled()
    {
        // Arrange
        var carCoreService = new Mock<ICarCoreService>();
        var mapper = new Mock<IMapper>();
        var carApplicationService = new CarApplicationService(carCoreService.Object, mapper.Object);

        // Act
        var result = carApplicationService.AddAsync(new CarDto
        {
            Id = Guid.NewGuid(),
            CarType = "Car",
            Brand = "Mazda",
            Model = "2021 CX-30",
            Color = "Red",
            CubicCentimeters = "1980",
            Velocity = 2500
        });

        // Assert
    }
}
