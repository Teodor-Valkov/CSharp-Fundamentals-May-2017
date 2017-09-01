namespace _03.FirstName
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] letters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(letter => letter).ToArray();

            bool hasResult = false;
            string name = string.Empty;

            foreach (string letter in letters)
            {
                name = names.FirstOrDefault(n => n.ToLower().StartsWith(letter.ToLower()));

                if (name != null)
                {
                    Console.WriteLine(name);
                    hasResult = true;
                    break;
                }
            }

            if (!hasResult)
            {
                Console.WriteLine("No match");
            }
        }
    }
}