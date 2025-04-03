using App.Api.Dtos;
using App.Common.DomainModels;

namespace App.Api.ApiMappers.CarApiMapper
{
    public interface ICarApiMapper
    {
        CarDto MapToCarDto(DomainCar domainCar);
        List<CarDto> MapToCarDtos(List<DomainCar> domainCars);
        DomainCreateCar MapToDomainCreateCar(CreateCarDto createCarDto);

    }
}
