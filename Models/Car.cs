namespace CarApi.Models
{
    public class Car
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
        public String Model { get; set; }=string.Empty;
        public DateOnly YearOfManufacture { get; set; }
    }
}
