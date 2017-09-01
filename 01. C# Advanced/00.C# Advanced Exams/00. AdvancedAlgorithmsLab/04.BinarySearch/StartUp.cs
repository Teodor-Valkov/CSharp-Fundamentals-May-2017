namespace _04.BinarySearch
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int element = int.Parse(Console.ReadLine());

            // For sorting the numbers in ascending order we can use the algorithm from '03.InsertionSort'
            //
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

            int index = BinarySearch(numbers, element, 0, numbers.Length);

            Console.WriteLine(index);
        }

        public static int BinarySearch(int[] numbers, int element, int left, int right)
        {
            int middle = (left + right) / 2;

            if (element > numbers[middle])
            {
                return BinarySearch(numbers, element, middle + 1, right);
            }

            if (element < numbers[middle])
            {
                return BinarySearch(numbers, element, left, middle - 1);
            }

            if (element == numbers[middle])
            {
                for (int i = left; i < right; i++)
                {
                    if (numbers[i] == element)
                    {
                        return i;
                    }
                }

                return middle;
            }

            return -1;
        }
    }
}