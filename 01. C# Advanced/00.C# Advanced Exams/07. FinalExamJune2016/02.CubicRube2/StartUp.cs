namespace _02.CubicRube2
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            long sum = 0;
            int changedCells = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "analyze")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int[] coordinates = new int[3];
                coordinates[0] = int.Parse(inputArgs[0]);
                coordinates[1] = int.Parse(inputArgs[1]);
                coordinates[2] = int.Parse(inputArgs[2]);

                if (coordinates.All(coordinate => coordinate >= 0 && coordinate < size))
                {
                    int value = int.Parse(inputArgs[3]);

                    if (value != 0)
                    {
                        sum += value;
                        changedCells++;
                    }
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(Math.Pow(size, 3) - changedCells);
        }
    }
}