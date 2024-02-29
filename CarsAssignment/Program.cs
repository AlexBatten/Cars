// See https://aka.ms/new-console-template for more information

using CarsAssignment;

Controller controller = new Controller();

controller.LoadJson("cars.json");
//controller.DisplayCars();
controller.CountCarsByMake();
controller.CountFordAfter1980JanFirst();
controller.CalculateAverageHorsePower();
controller.CalculateKilometersPerLiterAllCars();


