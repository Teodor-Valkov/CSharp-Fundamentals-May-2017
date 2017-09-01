namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            SortedSet<string> parking = new SortedSet<string>();

            while (input.ToLower() != "end")
            {
                string[] inputArgs = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string type = inputArgs[0];
                string car = inputArgs[1];

                if (type.ToLower() == "in")
                {
                    parking.Add(car);
                }

                if (type.ToLower() == "out")
                {
                    parking.Remove(car);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(parking.Any()
                ? $"{string.Join("\n", parking)}"
                : "Parking Lot is Empty");
        }
    }
}