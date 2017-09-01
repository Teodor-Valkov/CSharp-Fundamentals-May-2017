namespace _07.ValidUsernames
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class ValidUsernames
    {
        private static void Main()
        {
            string[] validUsernames = Console.ReadLine()
                .Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(arg => Regex.IsMatch(arg, @"\b[A-Za-z]\w{2,24}\b"))
                .ToArray();

            int currentLengthSum = 0;
            int bestLengthSum = 0;
            string bestFirstUser = string.Empty;
            string bestSecondUser = string.Empty;

            for (int i = 0; i < validUsernames.Length - 1; i++)
            {
                string firstUser = validUsernames[i];
                string secondUser = validUsernames[i + 1];

                currentLengthSum = firstUser.Length + secondUser.Length;

                if (currentLengthSum > bestLengthSum)
                {
                    bestLengthSum = currentLengthSum;
                    bestFirstUser = firstUser;
                    bestSecondUser = secondUser;
                }
            }

            Console.WriteLine(bestFirstUser);
            Console.WriteLine(bestSecondUser);
        }
    }
}