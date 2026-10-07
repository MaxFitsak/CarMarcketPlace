namespace RulimAuto.Domain.Entities;

public class Car
{
    public Guid Id { get; set; }
    public string? CarBrand { get; set; }
    public string? CarModel { get; set; }
    public string? CarColor { get; set; }
    public int CarYear { get; set; }
    public string? CarLicensePlate { get; set; }
    public int VinNumber { get; set; }
    public int HorsePower { get; set; }
    
    private Car() { }
    
    
}