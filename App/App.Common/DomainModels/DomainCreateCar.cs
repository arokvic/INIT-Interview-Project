namespace App.Common.DomainModels
{
    public class DomainCreateCar
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
