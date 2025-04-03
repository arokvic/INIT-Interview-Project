using App.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Database.Storage
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Car> Cars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Car>().HasData(
                 new Car { Id = Guid.NewGuid(), Manufacturer = "Toyota", Model = "Camry", Year = 2020 },
                 new Car { Id = Guid.NewGuid(), Manufacturer = "Honda", Model = "Civic", Year = 2021 },
                 new Car { Id = Guid.NewGuid(), Manufacturer = "Ford", Model = "Mustang", Year = 2022 }
             );
        }
    }
}
