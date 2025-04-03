using App.Common.DomainModels;
using App.Database.Entities;

namespace App.Database.Mappers.CarMapper
{
    public interface ICarMapper
    {
        Car MapToCarEntity(DomainCreateCar domainCreateCar, Guid Id);
        DomainCar MapToDomainCar(Car car);
        List<DomainCar> MapToDomainCars(List<Car> cars);
    }
}
