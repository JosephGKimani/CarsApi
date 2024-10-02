namespace CarApi.DTOs
{
    public class GetCarDto
    {
        public string Name { get; set; } = string.Empty;
        public String Model { get; set; } = string.Empty;
        public DateOnly YearOfManufacture { get; set; }
    }
}
