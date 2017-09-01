namespace _01.PrimeFactorization
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<int> primeDivisors = new List<int>();
            int initialNumber = number;

            while (number >= 2)
            {
                int nextDivisor = 2;

                if (number % nextDivisor > 0)
                {
                    nextDivisor = 3;

                    while (nextDivisor < number)
                    {
                        if (number % nextDivisor == 0)
                        {
                            break;
                        }

                        nextDivisor += 2;
                    }
                }

                number /= nextDivisor;

                primeDivisors.Add(nextDivisor);
            }

            Console.WriteLine($"{initialNumber} = {string.Join(" * ", primeDivisors)}");
        }
    }
}