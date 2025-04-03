namespace App.Api.Dtos
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
