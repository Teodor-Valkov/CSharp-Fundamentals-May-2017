namespace _01.SecondNature2
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

            Queue<int> flowers = new Queue<int>(flowersArgs);
            Stack<int> buckets = new Stack<int>(bucketsArgs);

            List<int> specialFlowers = new List<int>();

            while (flowers.Any() && buckets.Any())
            {
                int currentBucket = buckets.Pop();
                int currentFlower = flowers.Dequeue();

                if (currentBucket == currentFlower)
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
                    int[] tempFlowers = flowers.ToArray();

                    flowers.Clear();
                    flowers.Enqueue(currentFlower - currentBucket);

                    foreach (int tempFlower in tempFlowers)
                    {
                        flowers.Enqueue(tempFlower);
                    }
                }
            }

            if (flowers.Any())
            {
                Console.WriteLine(string.Join(" ", flowers));
            }
            else if (buckets.Any())
            {
                Console.WriteLine(string.Join(" ", buckets));
            }

            Console.WriteLine(specialFlowers.Any()
                ? string.Join(" ", specialFlowers)
                : "None");
        }
    }
}