using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfEngines = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = inputArgs[0];
            int power = int.Parse(inputArgs[1]);
            int displacement = 0;
            string efficiency = string.Empty;

            Engine engine = null;

            switch (inputArgs.Length)
            {
                case 2:
                    engine = new Engine(model, power);
                    break;

                case 3:
                    bool isDigit = inputArgs[2].All(char.IsDigit);

                    if (isDigit)
                    {
                        displacement = int.Parse(inputArgs[2]);
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        efficiency = inputArgs[2];
                        engine = new Engine(model, power, efficiency);
                    }
                    break;

                case 4:
                    displacement = int.Parse(inputArgs[2]);
                    efficiency = inputArgs[3];
                    engine = new Engine(model, power, displacement, efficiency);
                    break;
            }

            engines.Add(engine);
        }

        int numberOFCars = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOFCars; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = inputArgs[0];
            string engineModel = inputArgs[1];
            Engine engine = engines.First(eng => eng.Model == engineModel);
            int weigth = 0;
            string color = string.Empty;

            Car car = null;

            switch (inputArgs.Length)
            {
                case 2:
                    car = new Car(carModel, engine);
                    break;

                case 3:
                    bool isDigit = inputArgs[2].All(char.IsDigit);

                    if (isDigit)
                    {
                        weigth = int.Parse(inputArgs[2]);
                        car = new Car(carModel, engine, weigth);
                    }
                    else
                    {
                        color = inputArgs[2];
                        car = new Car(carModel, engine, color);
                    }
                    break;

                case 4:
                    weigth = int.Parse(inputArgs[2]);
                    color = inputArgs[3];
                    car = new Car(carModel, engine, weigth, color);
                    break;
            }

            cars.Add(car);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}