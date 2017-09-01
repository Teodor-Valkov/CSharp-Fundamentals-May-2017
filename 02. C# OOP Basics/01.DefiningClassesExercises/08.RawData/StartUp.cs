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

            Engine engine = GetEngine(inputArgs);
            Cargo cargo = GetCargo(inputArgs);
            List<Tire> tires = GetTires(inputArgs);

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        string result = Console.ReadLine();

        switch (result)
        {
            case "fragile":
                cars = cars
                    .Where(car => car.Cargo.Type == "fragile" && car.Tires.All(tire => tire.Pressure < 1))
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, cars.Select(car => car.Model)));
                break;

            case "flamable":
                cars = cars
                    .Where(car => car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, cars.Select(car => car.Model)));
                break;
        }
    }

    private static Engine GetEngine(string[] inputArgs)
    {
        int engineSpeed = int.Parse(inputArgs[1]);
        int enginePower = int.Parse(inputArgs[2]);

        return new Engine(engineSpeed, enginePower);
    }

    private static Cargo GetCargo(string[] inputArgs)
    {
        int cargoWeight = int.Parse(inputArgs[3]);
        string cargoType = inputArgs[4];

        return new Cargo(cargoWeight, cargoType);
    }

    private static List<Tire> GetTires(string[] inputArgs)
    {
        List<Tire> tires = new List<Tire>();

        for (int i = 5; i < 9; i += 2)
        {
            double pressure = double.Parse(inputArgs[i]);
            int age = int.Parse(inputArgs[i + 1]);

            Tire tire = new Tire(pressure, age);
            tires.Add(tire);
        }

        return tires;
    }
}