// CreateCarDto.cs або CreateCarCommand.cs
public class CreateCarDto
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string Vin { get; set; } = string.Empty;
}