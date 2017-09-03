namespace _01.Regeh
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(input.Length);
            string pattern = @"\[(?:[^[\s]+?)<(\d+)REGEH(\d+)>(?:[^]\s]+?)\]";
            Regex regex = new Regex(pattern);

            StringBuilder sb = new StringBuilder();
            int sumIndex = 0;
            int rounds = 0;

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                // Find first index of the current match and add it to the sum index
                int firstIndex = int.Parse(match.Groups[1].Value);
                sumIndex += firstIndex;

                rounds = 0;
                if (sumIndex >= input.Length)
                {
                    int tempSumIndex = sumIndex;

                    while (tempSumIndex >= input.Length)
                    {
                        tempSumIndex -= input.Length;
                        rounds++;
                    }
                }

                // Apply (if needed) additional rounds to the first index and append the symbol to the result
                sumIndex += rounds;
                sb.Append(input[sumIndex % input.Length]);

                // Find second index from the current match and add it to the sum index
                int secondIndex = int.Parse(match.Groups[2].Value);
                sumIndex += secondIndex;

                rounds = 0;
                if (sumIndex >= input.Length)
                {
                    int tempSumIndex = sumIndex;

                    while (tempSumIndex >= input.Length)
                    {
                        tempSumIndex -= input.Length;
                        rounds++;
                    }
                }

                // Apply (if needed) additional rounds to the second index and append the symbol to the result
                sumIndex += rounds;
                sb.Append(input[sumIndex % input.Length]);
            }

            Console.WriteLine(sb);
        }
    }
}