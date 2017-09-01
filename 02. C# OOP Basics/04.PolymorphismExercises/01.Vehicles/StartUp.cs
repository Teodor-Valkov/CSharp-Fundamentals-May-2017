using System;

public class StartUp
{
    public static void Main()
    {
        string[] carArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] truckArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));
        Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];
            string vehicle = inputArgs[1];
            double distanceOrFuel = double.Parse(inputArgs[2]);

            switch (command)
            {
                case "Drive":
                    switch (vehicle)
                    {
                        case "Car":
                            car.Drive(distanceOrFuel);
                            break; ;
                        case "Truck":
                            truck.Drive(distanceOrFuel);
                            break;
                    }
                    break;

                case "Refuel":
                    switch (vehicle)
                    {
                        case "Car":
                            car.Refuel(distanceOrFuel);
                            break; ;
                        case "Truck":
                            truck.Refuel(distanceOrFuel);
                            break;
                    }
                    break;
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }
}