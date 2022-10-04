using Management.Vehicles.Application.Abstractions;
using Management.Vehicles.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Management.Vehicles.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarApplicationService _carApplicationService;

    public CarController(ICarApplicationService carApplicationService)
    {
        _carApplicationService = carApplicationService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetAll()
    {
        try
        {
            var result = await _carApplicationService.GetAllActiveCar();

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{carUid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetById(Guid carUid)
    {
        try
        {
            var result = await _carApplicationService.GetById(carUid);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarDto>> Add(CarDto car)
    {
        try
        {
            var result = await _carApplicationService.AddAsync(car);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
