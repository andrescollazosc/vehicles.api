using Management.Vehicles.Application.Abstractions;
using Management.Vehicles.Application.DTO;
using Management.Vehicles.Application.Mapping;
using Management.Vehicles.Core.Contracts;

namespace Management.Vehicles.Application;

public class CarApplicationService : ICarApplicationService
{
    private readonly ICarCoreService _carCoreService;
    private readonly IMapper _mapper;

    public CarApplicationService(ICarCoreService carCoreService, IMapper mapper)
    {
        _carCoreService = carCoreService;
        _mapper = mapper;
    }

    public async Task<CarDto> AddAsync(CarDto car)
    {
        var objetDomain = _mapper.Map(car);
        var carDto = await _carCoreService.AddAsync(objetDomain);
        
        return _mapper.Map(carDto);
    }

    public async Task<IEnumerable<CarDto>> GetAllActiveCar()
    {
        var cars = await _carCoreService.GetAllActiveCar();

        return cars.Select(car => _mapper.Map(car));
    }

    public async Task<CarDto> GetById(Guid id)
    {
        var car = await _carCoreService.GetById(id);

        return _mapper.Map(car);
    }
}
