namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Func<string, bool> func = word => char.IsUpper(word.First());

            Console.WriteLine(string.Join($"{Environment.NewLine}", Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(word => func(word))));
        }
    }
}