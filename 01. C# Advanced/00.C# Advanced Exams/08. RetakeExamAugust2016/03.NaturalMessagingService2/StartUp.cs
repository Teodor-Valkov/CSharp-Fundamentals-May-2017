namespace _03.NaturalMessagingService2
{
    using System;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            StringBuilder sb = new StringBuilder();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "---nms send---")
            {
                sb.Append(input);
            }

            StringBuilder result = new StringBuilder().Append(sb[0]);

            for (int i = 1; i < sb.Length; i++)
            {
                char previosLetter = sb[i - 1];
                char currentLetter = sb[i];

                if (char.ToLower(currentLetter) >= char.ToLower(previosLetter))
                {
                    result.Append(currentLetter);
                }

                if (char.ToLower(currentLetter) < char.ToLower(previosLetter))
                {
                    result.Append(" " + currentLetter);
                }
            }

            string separator = Console.ReadLine();

            Console.WriteLine($"{result.Replace(" ", separator)}");
        }
    }
}