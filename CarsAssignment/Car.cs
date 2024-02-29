namespace CarsAssignment;

public class Car
{
    public string Name { get; set; }
    public double? Miles_per_Gallon { get; set; }
    public int? Cylinders { get; set; }
    public double? Displacement { get; set; }
    public int? Horsepower { get; set; }
    public int? Weight_in_lbs { get; set; }
    public double? Acceleration { get; set; }
    public string? Year { get; set; }
    public string? Origin { get; set; }
    
    //TASK 6
    
    public double? Weight_in_kg => Weight_in_lbs * 0.45;
}