namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < number; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                double fuelAmount = double.Parse(inputArgs[1]);
                double fuelPerKilometer = double.Parse(inputArgs[2]);

                Car car = new Car(model, fuelAmount, fuelPerKilometer);
                cars.Add(car);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[1];
                int distance = int.Parse(inputArgs[2]);

                Car currentCar = cars.First(car => car.Model == model);
                currentCar.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.Distance}");
            }
        }
    }
}