namespace _17.BiggestTableRow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static List<double> numbers = new List<double>();
        private static List<string> result = new List<string>();

        private static double maxSum = double.MinValue;

        private static void Main()
        {
            //string pattern = @"<td>([\d\.-]+)<\/td>";
            string pattern = @"<td>([-]?[\d]+|[-]?[\d]+[\.][\d]+)<\/td>";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "</table>")
            {
                FindMaxSum(regex, input);
            }

            Console.WriteLine(numbers.Any()
                ? $"{numbers.Sum()} = {string.Join(" + ", result)}"
                : "no data");
        }

        private static void FindMaxSum(Regex regex, string input)
        {
            List<double> tempNumbers = new List<double>();
            List<string> tempResult = new List<string>();

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                double number = 0;
                bool isNumberValid = double.TryParse(match.Groups[1].Value, out number);

                if (isNumberValid)
                {
                    tempNumbers.Add(number);
                    tempResult.Add(match.Groups[1].Value);
                }
            }

            if (tempNumbers.Any() && maxSum < tempNumbers.Sum())
            {
                numbers = tempNumbers;
                result = tempResult;
                maxSum = tempNumbers.Sum();
            }
        }
    }
}