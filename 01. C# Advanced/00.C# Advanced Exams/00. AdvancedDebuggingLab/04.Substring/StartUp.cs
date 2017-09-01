namespace _04.Substring
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'p')
                {
                    hasMatch = true;
                    string matchedString = string.Empty;

                    if (i + jump < text.Length)
                    {
                        matchedString = text.Substring(i, jump + 1);
                        Console.WriteLine(matchedString);
                        i += jump;
                    }
                    else
                    {
                        matchedString = text.Substring(i);
                        Console.WriteLine(matchedString);
                    }
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}