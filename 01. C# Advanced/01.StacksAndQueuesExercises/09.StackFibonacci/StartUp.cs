namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Stack<long> fibonacciNumbers = new Stack<long>();

            fibonacciNumbers.Push(1);
            fibonacciNumbers.Push(1);

            for (int i = 2; i < number; i++)
            {
                long previousLastNumber = fibonacciNumbers.Pop();
                long currentLastNumber = previousLastNumber + fibonacciNumbers.Peek();

                fibonacciNumbers.Push(previousLastNumber);
                fibonacciNumbers.Push(currentLastNumber);
            }

            Console.WriteLine(fibonacciNumbers.Peek());
        }
    }
}