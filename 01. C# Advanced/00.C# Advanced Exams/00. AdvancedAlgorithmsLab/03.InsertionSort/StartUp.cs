namespace _03.InsertionSort
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 1; i < numbers.Length; i++)
            {
                int temp = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > temp)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = temp;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}