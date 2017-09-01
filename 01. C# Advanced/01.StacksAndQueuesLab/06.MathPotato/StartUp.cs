namespace _06.MathPotato
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int number = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(inputArgs);

            int counter = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine(IsPrime(counter)
                    ? $"Prime {queue.Peek()}"
                    : $"Removed {queue.Dequeue()}");

                counter++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }

                return false;
            }

            for (int i = 3; i * i <= candidate; i += 2)
            {
                if (candidate % i == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }
    }
}