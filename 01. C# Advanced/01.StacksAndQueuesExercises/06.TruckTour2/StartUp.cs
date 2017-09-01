namespace _06.TruckTour2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Station
    {
        public int FuelToAdd;
        public int DistanceToNext;
        public int IndexOfStation;
    }

    internal class StartUp
    {
        private static void Main()
        {
            int stationsCount = int.Parse(Console.ReadLine());

            Queue<Station> stations = new Queue<Station>();

            for (int i = 0; i < stationsCount; i++)
            {
                string input = Console.ReadLine();
                int[] pumpInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int amountOfGas = pumpInfo[0];
                int distanceToNext = pumpInfo[1];

                Station currentPump = new Station
                {
                    FuelToAdd = amountOfGas,
                    DistanceToNext = distanceToNext,
                    IndexOfStation = i
                };

                stations.Enqueue(currentPump);
            }

            bool reachedFinal = false;

            while (true)
            {
                Station currentStation = stations.Dequeue();
                stations.Enqueue(currentStation);

                Station starterStation = currentStation;
                int fuel = currentStation.FuelToAdd;

                while (fuel - currentStation.DistanceToNext >= 0)
                {
                    fuel -= currentStation.DistanceToNext;

                    currentStation = stations.Dequeue();
                    stations.Enqueue(currentStation);

                    if (currentStation == starterStation)
                    {
                        reachedFinal = true;
                        break;
                    }

                    fuel += currentStation.FuelToAdd;
                }

                if (reachedFinal)
                {
                    Console.WriteLine(currentStation.IndexOfStation);
                    break;
                }
            }
        }
    }
}