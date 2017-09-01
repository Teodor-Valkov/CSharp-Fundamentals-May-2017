namespace _11.ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static Dictionary<int, HashSet<int>> parking;
        private static int rows;
        private static int cols;

        private static void Main()
        {
            parking = new Dictionary<int, HashSet<int>>();

            int[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            rows = rowsAndCols[0];
            cols = rowsAndCols[1];

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "stop")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int entryRow = int.Parse(inputArgs[0]);
                int targetRow = int.Parse(inputArgs[1]);
                int targetCol = int.Parse(inputArgs[2]);

                if (IsSpotTaken(targetRow, targetCol))
                {
                    targetCol = TryToFindFreeSpot(targetRow, targetCol);
                }

                if (targetCol > 0)
                {
                    MarkSpotAsTaken(targetRow, targetCol);

                    int distance = Math.Abs(targetRow - entryRow) + targetCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
            }
        }

        private static bool IsSpotTaken(int targetRow, int targetCol)
        {
            if (parking.ContainsKey(targetRow) && parking[targetRow].Contains(targetCol))
            {
                return true;
            }

            return false;
        }

        private static int TryToFindFreeSpot(int targetRow, int targetCol)
        {
            int newCol = 0;
            int minDistance = int.MaxValue;

            for (int col = 1; col < cols; col++)
            {
                if (!IsSpotTaken(targetRow, col))
                {
                    int distance = Math.Abs(targetCol - col);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        newCol = col;
                    }
                }
            }

            return newCol;
        }

        private static void MarkSpotAsTaken(int targetRow, int targetCol)
        {
            if (!parking.ContainsKey(targetRow))
            {
                parking[targetRow] = new HashSet<int>();
            }

            parking[targetRow].Add(targetCol);
        }
    }
}