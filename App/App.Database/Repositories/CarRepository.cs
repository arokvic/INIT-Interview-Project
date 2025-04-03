using App.Common.DomainModels;
using App.Database.Mappers.CarMapper;
using App.Database.Storage;
using App.Domain.Ports.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Database.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;
        private readonly ICarMapper _carMapper;

        public CarRepository(AppDbContext context, ICarMapper carMapper)
        {
            _context = context;
            _carMapper = carMapper;
        }

        public async Task Create(DomainCreateCar domainCreateCar)
        {
            var car = _carMapper.MapToCarEntity(domainCreateCar, new Guid());

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid carId)
        {
            var car = await _context.Cars.FindAsync(carId);

            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Car with ID {carId} not found");
            }
        }

        public async Task<List<DomainCar>> GetAll(int? year)
        {
            var query = _context.Cars.AsQueryable();

            if (year.HasValue)
            {
                query = query.Where(c => c.Year == year.Value);
            }

            var cars = await query.ToListAsync();

            return _carMapper.MapToDomainCars(cars);
        }
    }
}
