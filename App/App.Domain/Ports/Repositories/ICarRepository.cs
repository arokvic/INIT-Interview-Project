using App.Common.DomainModels;

namespace App.Domain.Ports.Repositories
{
    public interface ICarRepository
    {
        Task<List<DomainCar>> GetAll(int? year);
        Task Create(DomainCreateCar domainCreateCar);
        Task Delete(Guid carId);
    }
}
