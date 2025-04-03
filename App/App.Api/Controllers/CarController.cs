using App.Api.ApiMappers.CarApiMapper;
using App.Api.Dtos;
using App.Domain.Services.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private readonly ICarApiMapper _carApiMapper;
        private readonly ICarService _carService;

        public CarController(ICarApiMapper carApiMapper, ICarService carService)
        {
            _carApiMapper = carApiMapper;
            _carService = carService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? year)
        {
            var domainCars = await _carService.GetAll(year);

            var result = _carApiMapper.MapToCarDtos(domainCars);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto CreateCarDto)
        {
            var domainCreateCar = _carApiMapper.MapToDomainCreateCar(CreateCarDto);

            await _carService.Create(domainCreateCar);

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{carId}")]
        public async Task<IActionResult> Delete(Guid carId)
        {
            await _carService.Delete(carId);

            return Ok();
        }
    }
}
