using Management.Vehicles.Core.Contracts.Repositories;
using Management.Vehicles.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Vehicles.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(VehicleDBContext context) : base(context) { }

    public async Task<IEnumerable<Car>> GetAllActiveCarsAsync()
     => await _context.Cars.Where(car => car.IsActive).ToListAsync();

    //public async Task<IEnumerable<Car>> GetAllActiveCarsAsync()
    //{
    //    string text = @"sp_getAllCars @Velocity";

    //    var test = await _context.Cars.FromSqlRaw(text, new SqlParameter("Velocity", 260)).ToListAsync();

    //    return null;
    //}


}
