namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int numbersToEnqueue = inputArgs[0];
            int numbersToDequeue = inputArgs[1];
            int numberToCheck = inputArgs[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbersToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numbersToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int min = int.MaxValue;

                foreach (int number in queue)
                {
                    if (min > number)
                    {
                        min = number;
                    }
                }

                Console.WriteLine(min);
            }
        }
    }
}