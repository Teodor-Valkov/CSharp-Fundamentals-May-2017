namespace _02.CubicRube
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static int[,,] matrix;

        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            matrix = new int[number, number, number];
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    for (int z = 0; z < matrix.GetLength(2); z++)
                    {
                        matrix[x, y, z] = 0;
                    }
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "analyze")
            {
                int[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int x = inputArgs[0];
                int y = inputArgs[1];
                int z = inputArgs[2];
                int value = inputArgs[3];

                if (IsPointInMatrix(x, y, z))
                {
                    matrix[x, y, z] = value;
                }
            }

            long sum = 0;
            int unchanged = 0;

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    for (int z = 0; z < matrix.GetLength(2); z++)
                    {
                        if (matrix[x, y, z] != 0)
                        {
                            sum += matrix[x, y, z];
                        }

                        if (matrix[x, y, z] == 0)
                        {
                            unchanged++;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(unchanged);
        }

        private static bool IsPointInMatrix(int x, int y, int z)
        {
            if (x >= 0 && x < matrix.GetLength(0) &&
                y >= 0 && y < matrix.GetLength(1) &&
                z >= 0 && z < matrix.GetLength(2))
            {
                return true;
            }

            return false;
        }
    }
}