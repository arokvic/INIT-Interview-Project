using App.Api.Dtos;
using App.Common.DomainModels;
using System.Reflection;

namespace App.Api.ApiMappers.CarApiMapper
{
    public class CarApiMapper : ICarApiMapper
    {
        public CarDto MapToCarDto(DomainCar domainCar) => new CarDto
        {
            Id = domainCar.Id,
            Manufacturer = domainCar.Manufacturer,
            Model = domainCar.Model,
            Year = domainCar.Year,
        };
       

        public List<CarDto> MapToCarDtos(List<DomainCar> domainCars) => domainCars.Select(MapToCarDto).ToList();

        public DomainCreateCar MapToDomainCreateCar(CreateCarDto createCarDto) => new DomainCreateCar
        {
            Manufacturer = createCarDto.Manufacturer,
            Model = createCarDto.Model,
            Year = createCarDto.Year,
        };
    }
}
