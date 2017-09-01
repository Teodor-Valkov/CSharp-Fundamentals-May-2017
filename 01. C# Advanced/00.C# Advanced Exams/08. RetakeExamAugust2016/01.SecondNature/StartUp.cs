namespace _01.SecondNature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] flowersArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bucketsArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> flowers = new List<int>(flowersArgs);
            Stack<int> buckets = new Stack<int>(bucketsArgs);

            List<int> specialFlowers = new List<int>();

            while (flowers.Any() && buckets.Any())
            {
                int currentFlower = flowers.First();
                int currentBucket = buckets.Pop();

                flowers.RemoveAt(0);

                if (currentFlower == currentBucket)
                {
                    specialFlowers.Add(currentFlower);
                }
                else if (currentBucket > currentFlower)
                {
                    if (buckets.Count == 0)
                    {
                        buckets.Push(currentBucket - currentFlower);
                    }
                    else if (buckets.Count > 0)
                    {
                        buckets.Push(buckets.Pop() + currentBucket - currentFlower);
                    }
                }
                else if (currentBucket < currentFlower)
                {
                    currentFlower -= currentBucket;
                    flowers.Insert(0, currentFlower);
                }
            }

            if (!flowers.Any())
            {
                Console.WriteLine($"{string.Join(" ", buckets)}");
            }

            if (!buckets.Any())
            {
                Console.WriteLine($"{string.Join(" ", flowers)}");
            }

            Console.WriteLine(specialFlowers.Any()
                ? $"{string.Join(" ", specialFlowers)}"
                : "None");
        }
    }
}