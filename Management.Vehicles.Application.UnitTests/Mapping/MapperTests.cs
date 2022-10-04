using Management.Vehicles.Application.DTO;
using Management.Vehicles.Application.Mapping;
using Management.Vehicles.BusinessRules.Validations;
using Management.Vehicles.Core.Entities;
using Management.Vehicles.Core.Enums;
using Moq;
using Xunit;

namespace Management.Vehicles.Application.UnitTests.Mapping;

public class MapperTests
{
    [Fact]
    public void Map_WhenParameterIsDto_ThenReturnAObjectDomainNotNull()
    {
        // Arrange
        var carTypeValidationMock = new Mock<ICarTypeValidation>();
        IMapper mapper = new Mapper(carTypeValidationMock.Object);

        // Act
        var carObjectDomain = mapper.Map(new CarDto
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
        Assert.NotNull(carObjectDomain);
    }

    [Fact]
    public void Map_WhenParameterIsAObjectDomain_ReturnADtoLikeNotNull()
    {
        // Arrange
        var carTypeValidationMock = new Mock<ICarTypeValidation>();
        IMapper mapper = new Mapper(carTypeValidationMock.Object);

        // Act
        var carDto
            = mapper.Map(new Car
        {
            Id = Guid.NewGuid(),
            CarType = CarType.Truck,
            Brand = "Mazda",
            Model = "2021 CX-30",
            Color = "Red",
            CubicCentimeters = "1980",
            Velocity = 2500
        });

        // Assert
        Assert.NotNull(carDto);
        Assert.Contains("Truck", carDto.CarType);
    }
}
