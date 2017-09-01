namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int stations = int.Parse(Console.ReadLine());

            Queue<int[]> stationsElements = new Queue<int[]>();

            for (int i = 0; i < stations; i++)
            {
                string input = Console.ReadLine();
                int[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                stationsElements.Enqueue(inputArgs);
            }

            for (int i = 0; i < stations; i++)
            {
                int fuel = 0;
                bool reachedFinal = true;

                foreach (int[] currentStationElements in stationsElements)
                {
                    fuel += currentStationElements[0];
                    fuel -= currentStationElements[1];

                    if (fuel < 0)
                    {
                        reachedFinal = false;
                        break;
                    }
                }

                if (!reachedFinal)
                {
                    int[] stationElementsToEnqueue = stationsElements.Dequeue();
                    stationsElements.Enqueue(stationElementsToEnqueue);
                }

                if (reachedFinal)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}