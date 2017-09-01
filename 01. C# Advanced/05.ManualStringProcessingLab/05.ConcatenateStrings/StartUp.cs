namespace _05.ConcatenateStrings
{
    using System;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                sb.Append($"{Console.ReadLine()} ");
            }

            Console.WriteLine(sb);
        }
    }
}