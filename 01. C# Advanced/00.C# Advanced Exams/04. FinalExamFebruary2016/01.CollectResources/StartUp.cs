namespace _01.CollectResources
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static string[] resources = { "stone", "gold", "wood", "food" };

        private static void Main()
        {
            string[] path = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int number = int.Parse(Console.ReadLine());

            int maxSum = int.MinValue;

            for (int i = 0; i < number; i++)
            {
                int[] indexAndStep = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int index = indexAndStep[0];
                int step = indexAndStep[1];

                int sum = 0;
                bool[] visitedCells = new bool[path.Length];

                while (true)
                {
                    index += step % path.Length;

                    if (index >= path.Length)
                    {
                        index -= path.Length;
                    }

                    string[] pathArgs = path[index].Split('_');
                    string resource = pathArgs[0];
                    int quantity = 1;

                    if (pathArgs.Length > 1)
                    {
                        quantity = int.Parse(pathArgs[1]);
                    }

                    if (visitedCells[index])
                    {
                        break;
                    }

                    if (!resources.Contains(resource))
                    {
                        continue;
                    }

                    visitedCells[index] = true;

                    sum += quantity;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}