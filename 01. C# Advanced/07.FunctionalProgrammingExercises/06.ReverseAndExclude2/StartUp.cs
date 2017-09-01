namespace _06.ReverseAndExclude2
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> isDivisable = num => num % divisor == 0;
            //bool IsDivisable(int num) => num % divisor != 0;

            Func<int[], int[]> filter = nums => nums.Where(num => !isDivisable(num)).ToArray();
            //int[] Filter(int[] nums) => nums.Where(num => !isDivisable(num)).ToArray();

            Func<int[], int[]> reverse = nums => nums.Reverse().ToArray();
            //int[] Reverse(int[] nums) => nums.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", filter(reverse(numbers))));
        }
    }
}