namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            long num = long.Parse(Console.ReadLine());

            List<long> result = new List<long>();
            Queue<long> numbers = new Queue<long>();

            result.Add(num);
            numbers.Enqueue(num);

            while (result.Count < 50)
            {
                num = numbers.Dequeue();
                long firstNum = num + 1;
                long secondNum = 2 * num + 1;
                long thirdNum = num + 2;

                numbers.Enqueue(firstNum);
                numbers.Enqueue(secondNum);
                numbers.Enqueue(thirdNum);

                result.Add(firstNum);
                result.Add(secondNum);
                result.Add(thirdNum);
            }

            Console.WriteLine($"{string.Join(" ", result.Take(50))}");
        }
    }
}