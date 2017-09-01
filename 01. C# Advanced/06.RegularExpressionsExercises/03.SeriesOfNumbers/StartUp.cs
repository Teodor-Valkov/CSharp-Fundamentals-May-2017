namespace _03.SeriesOfNumbers
{
    using System;
    using System.Text.RegularExpressions;

    internal class SeriesOfNumbers
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([a-z])\1+";
            Regex regex = new Regex(pattern);

            //string result = regex.Replace(input, "$1");
            string result = regex.Replace(input, rgx => $"{rgx.Groups[1]}");

            Console.WriteLine(result);
        }
    }
}