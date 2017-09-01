namespace _01.ReverseString
{
    using System;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }

            Console.WriteLine(sb);
        }
    }
}