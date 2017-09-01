namespace _03.CustomMinFunction
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            // First solution
            //
            Func<int[], int> func = FindMinNumber;
            Console.WriteLine(func(numbers));

            // Second solution
            //
            Func<int[], int> func2 = number => numbers.Min();
            //int Func2(int[] number) => numbers.Min();
            Console.WriteLine(func2(numbers));
        }

        private static int FindMinNumber(int[] numbers)
        {
            int min = int.MaxValue;

            foreach (int number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        }
    }
}