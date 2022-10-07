using Management.Vehicles.Application;
using Management.Vehicles.Application.Abstractions;
using Management.Vehicles.Application.Mapping;
using Management.Vehicles.BusinessRules.Validations;
using Management.Vehicles.Core.Contracts;
using Management.Vehicles.Core.Contracts.Repositories;
using Management.Vehicles.Core.Services;
using Management.Vehicles.Infrastructure;
using Management.Vehicles.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Management.Vehicles.Api.IoC;

internal static class DependencyBuilder
{
    internal static void ConfigDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VehicleDBContext>(m =>
                m.UseSqlServer(configuration.GetConnectionString("vehicleDB")),
            ServiceLifetime.Singleton);
    }

    internal static void DependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICarApplicationService, CarApplicationService>();
        services.AddScoped<IMapper, Mapper>();
        services.AddScoped<ICarCoreService, CarCoreService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICarTypeValidation, CarTypeValidation>();
    }
}
