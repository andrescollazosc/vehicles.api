using System.Globalization;
using Management.Vehicles.Core.Entities;
using Management.Vehicles.Core.Enums;
using Management.Vehicles.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Management.Vehicles.Infrastructure.IntegTests.Repositories;

public class CarRepositoryIntegTests
{
    //[Fact]
    [Fact(Skip = "")]
    public void GetAllActiveCarsAsync_CallMethod_ReturnData()
    {
        // Arrange
        var carRepository = new CarRepository(GetConfig().Value);

        // Act
        var result = carRepository.GetAllActiveCarsAsync().GetAwaiter().GetResult();

        // Assert
        Assert.True(result.Count() > 0);
    }

    //[Fact]
    [Fact(Skip = "")]
    public void GetAllAsync_CallMethod_ReturnData()
    {
        // Arrange
        var carRepository = new CarRepository(GetConfig().Value);

        // Act
        var result = carRepository.GetAllAsync().GetAwaiter().GetResult();

        // Assert
        Assert.True(result.Count() > 0);
    }

    //[Fact]
    [Fact(Skip = "")]
    public void GetByIdAsync_CallMethod_ReturnData()
    {
        // Arrange
        Guid vehicleUid =  Guid.Parse("27df51a8-cd2d-465a-9f2a-046c9f34b091");
        var carRepository = new CarRepository(GetConfig().Value);

        // Act
        var result = carRepository.GetByIdAsync(vehicleUid).GetAwaiter().GetResult();

        // Assert
        Assert.Equal(result.CarType, CarType.Truck);
    }

    //[Fact]
    [Fact(Skip = "")]
    public void AddAsync_CallMethod_ReturnData()
    {
        // Arrange
        var car = new Car
        {
            Id = Guid.NewGuid(),
            CarType = CarType.Motorcycle,
            Velocity = 300,
            Color = "Dark Green",
            Brand = "Honda",
            CubicCentimeters = "180",
            Model = "2002",
            CreatedBy = "acc"
        };
        var carRepository = new CarRepository(GetConfig().Value);

        // Act
        var result = carRepository.AddAsync(car).GetAwaiter().GetResult();

        // Assert
        Assert.Equal(result.CarType, CarType.Motorcycle);
    }

    //[Fact]
    [Fact(Skip = "")]
    public void UpdateAsync_CallMethod_ReturnData()
    {
        // Arrange
        var car = new Car
        {
            Id = Guid.Parse("4aa01dc3-4f74-4266-b5c8-03bcc574ee98"),
            CarType = CarType.Car,
            Velocity = 280,
            Color = "Machine gray",
            Brand = "Mazda",
            CubicCentimeters = "1998 CC",
            Model = "2022",
            CreateDate = DateTime.Now,
            CreatedBy = "acc"
        };
        var carRepository = new CarRepository(GetConfig().Value);

        // Act
        carRepository.UpdateAsync(car).GetAwaiter().GetResult();

    }

    #region Private methods
    private IOptions<VehicleDBContext> GetConfig()
    {
        var vehicleDbContextStub = new Mock<IOptions<VehicleDBContext>>();

        var assembly = typeof(CarRepositoryIntegTests).Assembly;
        var builder = new ConfigurationBuilder().AddUserSecrets(assembly, true);

        var config = builder.Build();
        var optionsBuilder = new DbContextOptionsBuilder<VehicleDBContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("vehicleDB"));
        var vehicleDBContext = new VehicleDBContext(optionsBuilder.Options);

        vehicleDbContextStub
            .Setup(d => d.Value)
            .Returns(vehicleDBContext);

        return vehicleDbContextStub.Object;
    }

    #endregion
}
