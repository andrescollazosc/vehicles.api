using Management.Vehicles.Core.Entities;

namespace Management.Vehicles.Core.Contracts.Repositories;

public interface ICarRepository : IRepository<Car>
{
    Task<IEnumerable<Car>> GetAllActiveCarsAsync();
}
