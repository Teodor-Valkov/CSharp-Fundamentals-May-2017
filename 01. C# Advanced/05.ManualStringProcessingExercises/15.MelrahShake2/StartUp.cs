namespace _15.MelrahShake2
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, Regex.Escape(pattern));

            while (true)
            {
                if (matches.Count >= 2 && pattern.Length > 0)
                {
                    int firstIndex = input.IndexOf(pattern);
                    int lastIndex = input.LastIndexOf(pattern);

                    input = input.Remove(lastIndex, pattern.Length);
                    input = input.Remove(firstIndex, pattern.Length);

                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                matches = Regex.Matches(input, Regex.Escape(pattern));
            }

            Console.WriteLine(input);
        }
    }
}