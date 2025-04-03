using App.Common.DomainModels;

namespace App.Domain.Services.Car
{
    public interface ICarService
    {
        Task<List<DomainCar>> GetAll(int? year);
        Task Create(DomainCreateCar domainCar);
        Task Delete(Guid carId);
    }
}
