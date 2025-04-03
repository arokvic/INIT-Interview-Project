using App.Database.Mappers;
using App.Database.Storage;
using App.Api.ApiMappers;
using Microsoft.EntityFrameworkCore;
using App.Database.Repositories;
using App.Domain.Services;
using App.Database.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbMappers();
builder.Services.AddApiMappers();
builder.Services.AddRepsotiories();
builder.Services.AddServices();

var shouldUseInMemoryDb = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

if (shouldUseInMemoryDb)
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb"));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Seed data if the database is empty
    dbContext.Database.EnsureCreated();

    if (!dbContext.Cars.Any())
    {
        // Add the seed data if not already present
        dbContext.Cars.AddRange(
            new Car { Id = new Guid("b1efda78-d976-405c-9d3e-e8a51c91de00"), Manufacturer = "Toyota", Model = "Camry", Year = 2020 },
            new Car { Id = new Guid("c7b3bb28-77d5-4623-8816-bfa282f015bd"), Manufacturer = "Honda", Model = "Civic", Year = 2021 },
            new Car { Id = new Guid("aab6d4fe-bae8-4ce4-b9e4-86c6ef63f122"), Manufacturer = "Ford", Model = "Mustang", Year = 2022 }
        );
        dbContext.SaveChanges();
    }
}
app.Run();
