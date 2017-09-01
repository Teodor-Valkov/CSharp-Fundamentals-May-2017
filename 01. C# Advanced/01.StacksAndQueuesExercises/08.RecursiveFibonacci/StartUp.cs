namespace _08.RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static long[] memoization;
        private static Dictionary<int, long> fibonacci = new Dictionary<int, long>();

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine(1);
                return;
            }

            // Simple calculations
            long numberToPrint1 = RecursiveFibonacciSimple(n);

            // With array as memoization
            memoization = new long[n];
            long numberToPrint2 = FibonacciArray(n);

            //With dictionary as memoization
            FibonacciDictionary(n);
            long numberToPrint3 = fibonacci[n];

            Console.WriteLine(numberToPrint1);
            Console.WriteLine(numberToPrint2);
            Console.WriteLine(numberToPrint3);
        }

        private static long RecursiveFibonacciSimple(int n)
        {
            long[] fibonacciNumbers = new long[n];

            fibonacciNumbers[0] = 1;
            fibonacciNumbers[1] = 1;

            for (long i = 2; i < n; i++)
            {
                fibonacciNumbers[i] = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
            }

            return fibonacciNumbers[n - 1];
        }

        private static long FibonacciArray(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memoization[n - 1] != 0)
            {
                return memoization[n - 1];
            }

            memoization[n - 1] = FibonacciArray(n - 1) + FibonacciArray(n - 2);
            return memoization[n - 1];
        }

        private static long FibonacciDictionary(int n)
        {
            if (n == 0)
            {
                if (!fibonacci.ContainsKey(0))
                {
                    fibonacci.Add(0, 0);
                }
                return fibonacci[0];
            }

            if (n == 1)
            {
                if (!fibonacci.ContainsKey(1))
                {
                    fibonacci.Add(1, 1);
                }
                return fibonacci[1];
            }

            if (fibonacci.ContainsKey(n))
            {
                return fibonacci[n];
            }

            fibonacci[n] = FibonacciDictionary(n - 1) + FibonacciDictionary(n - 2);

            return fibonacci[n];
        }
    }
}