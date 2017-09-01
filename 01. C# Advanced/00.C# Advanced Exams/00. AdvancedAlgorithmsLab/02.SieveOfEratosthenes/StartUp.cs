namespace _02.SieveOfEratosthenes
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1];

            List<int> result = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;
            }

            for (int currentNumber = 2; currentNumber <= n; currentNumber++)
            {
                if (primes[currentNumber])
                {
                    result.Add(currentNumber);

                    for (int i = currentNumber * 2; i < primes.Length; i += currentNumber)
                    {
                        primes[i] = false;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}