namespace _05.SequenceWithQueue2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            long num = long.Parse(Console.ReadLine());

            Queue<long> numbers = new Queue<long>();
            Queue<long> removedNumbers = new Queue<long>();

            numbers.Enqueue(num);

            while (numbers.Count + removedNumbers.Count < 50)
            {
                numbers.Enqueue(num + 1);
                numbers.Enqueue(2 * num + 1);
                numbers.Enqueue(num + 2);

                removedNumbers.Enqueue(numbers.Dequeue());
                num = numbers.Peek();
            }

            List<long> numbersToPrint = new List<long>();

            foreach (long removedNumber in removedNumbers)
            {
                numbersToPrint.Add(removedNumber);
            }

            foreach (long number in numbers)
            {
                numbersToPrint.Add(number);
            }

            Console.WriteLine($"{string.Join(" ", numbersToPrint.Take(50))}");
        }
    }
}