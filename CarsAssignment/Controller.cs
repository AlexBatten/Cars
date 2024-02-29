namespace CarsAssignment;

using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Controller
{
    private List<Car> cars;
    
    public Controller()
    {
        cars = new List<Car>();
    }
    
    public void LoadJson(string filename)
    {
        string json = File.ReadAllText(filename);
        cars = JsonConvert.DeserializeObject<List<Car>>(json);
    }
    public void DisplayCars()
    {
        Console.WriteLine("TASK 1");
        
        foreach (Car car in cars)
        {
            Console.WriteLine(car.Name);
        }
    }
    
    // splits the name string of each car to find the make of the car, ignoring if appeared before, and then counts and prints make and number of cars for each make
    public void CountCarsByMake()
    {
        Console.WriteLine("TASK 2");
        
        Dictionary<string, int> makeCount = new Dictionary<string, int>();
        
        foreach (Car car in cars)
        {
            string[] make = car.Name.Split(' ');
            if (!makeCount.ContainsKey(make[0]))
            {
                makeCount.Add(make[0], 1);
            }
            else
            {
                makeCount[make[0]]++;
            }
        }
        
        foreach (KeyValuePair<string, int> make in makeCount)
        {
            Console.WriteLine($"{make.Key}: {make.Value}");
        }
    }
    
    // splits the year string which has the year, month, day values and counts amounts of cars with the make ford made after the year 1980, month 01 and day 01
    public void CountFordAfter1980JanFirst()
    {
        Console.WriteLine("TASK 3");
        
        int count = 0;
        
        foreach (Car car in cars)
        {
            string[] year = car.Year.Split('-');
            if (car.Name.Contains("ford") && int.Parse(year[0]) > 1980)
            {
                count++;
            }
            else if (car.Name.Contains("ford") && int.Parse(year[0]) == 1980)
            {
                if (int.Parse(year[1]) > 1)
                {
                    count++;
                } else if (int.Parse(year[1]) == 1 && int.Parse(year[2]) > 1)
                {
                    count++;
                }
            }
        }
        
        Console.WriteLine(count);
    }
    
    // Calculates the average horsepower for each Origin Country in the Origin Enum (USA, Europe, Japan), using the car list and prints the average and puts them in the same order as enum
    public void CalculateAverageHorsePower()
    {
        
        Console.WriteLine("TASK 4");
        
        foreach (Origin origin in Enum.GetValues(typeof(Origin)))
        {
            int count = 0;
            int total = 0;
            
            foreach (Car car in cars)
            {
                if (car.Origin == origin.ToString())
                {
                    if (car.Horsepower != null)
                    {
                        count++;
                        total += car.Horsepower.Value;
                    }
                    
                }
            }
            Console.WriteLine($"{origin}: {total / count}");
        }
    }
    
    
    // Calculates the kilometers per liter for each car using the miles per gallon variable and prints the name of the car and the kilometers per liter, there is 1.6 kilometers in a mile and 3.7 liters in a gallon
    public void CalculateKilometersPerLiterAllCars()
    {
        Console.WriteLine("TASK 5");

        foreach (Car car in cars)
        {
            if (car.Miles_per_Gallon != null)
            {
                double milesPerGallon = car.Miles_per_Gallon.Value;
                double kilometersPerLiter = milesPerGallon * 1.6 / 3.7;
                Console.WriteLine($"{car.Name}: {kilometersPerLiter}");
            }
            else if (car.Miles_per_Gallon == null)
            {
                Console.WriteLine($"{car.Name}: No miles per gallon data");
            }
        }

    }

}