

using App.Common.DomainModels;
using App.Database.Entities;

namespace App.Database.Mappers.CarMapper
{
    public class CarMapper : ICarMapper
    {
        public Car MapToCarEntity(DomainCreateCar domainCreateCar, Guid Id) => new Car
        {
            Id = Id,
            Manufacturer = domainCreateCar.Manufacturer,
            Model = domainCreateCar.Model,
            Year = domainCreateCar.Year,
        };


        public DomainCar MapToDomainCar(Car car) => new DomainCar
        {
            Year = car.Year,
            Id = car.Id,
            Manufacturer = car.Manufacturer,
            Model = car.Model,
        };
        

        public List<DomainCar> MapToDomainCars(List<Car> cars) => cars.Select(MapToDomainCar).ToList();

    }
}
