namespace _13.TriFunction
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int minSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> validNamesFunc = (name, sum) =>
                name.ToCharArray().Sum(symbol => symbol) >= sum;
            //bool ValidNamesFunc(string name, int sum) => name.ToCharArray().Sum(symbol => symbol) >= sum;

            Func<string[], int, Func<string, int, bool>, string> firstValidNameFunc = (namesArray, sum, func) =>
                namesArray.FirstOrDefault(name => func(name, sum));
            //string FirstValidNameFunc(string[] namesArray, int sum, Func<string, int, bool> func) => namesArray.FirstOrDefault(name => func(name, sum));

            Console.WriteLine(firstValidNameFunc(names, minSum, validNamesFunc));
        }
    }
}