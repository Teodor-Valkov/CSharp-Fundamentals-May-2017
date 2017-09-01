using System;

public class StartUp
{
    public static void Main()
    {
        string[] carArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] truckArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] busArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Car car = new Car(carArgs[0], double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
        Truck truck = new Truck(truckArgs[0], double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
        Bus bus = new Bus(busArgs[0], double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];
            string vehicle = inputArgs[1];
            double distanceOrFuel = double.Parse(inputArgs[2]);

            try
            {
                switch (command)
                {
                    case "Drive":
                        switch (vehicle)
                        {
                            case "Car":
                                car.Drive(distanceOrFuel);
                                break;

                            case "Truck":
                                truck.Drive(distanceOrFuel);
                                break;

                            case "Bus":
                                bus.MakeBusFull();
                                bus.Drive(distanceOrFuel);
                                break;
                        }
                        break;

                    case "DriveEmpty":
                        bus.Drive(distanceOrFuel);
                        break;

                    case "Refuel":
                        switch (vehicle)
                        {
                            case "Car":
                                car.Refuel(distanceOrFuel);
                                break;

                            case "Truck":
                                truck.Refuel(distanceOrFuel);
                                break;

                            case "Bus":
                                bus.Refuel(distanceOrFuel);
                                break;
                        }
                        break;
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}