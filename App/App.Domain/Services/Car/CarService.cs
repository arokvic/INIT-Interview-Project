using App.Common.DomainModels;
using App.Domain.Ports.Repositories;

namespace App.Domain.Services.Car
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Create(DomainCreateCar domainCreateCar)
        {
            await _carRepository.Create(domainCreateCar);
        }

        public async Task Delete(Guid carId)
        {
            await _carRepository.Delete(carId);
        }

        public Task<List<DomainCar>> GetAll(int? year)
        {
            var cars = _carRepository.GetAll(year);
            return cars;
        }
    }
}
