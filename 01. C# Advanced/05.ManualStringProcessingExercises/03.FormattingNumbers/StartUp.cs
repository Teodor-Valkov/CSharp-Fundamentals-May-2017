namespace _03.FormattingNumbers
{
    using System;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            long firstNumber = long.Parse(input[0]);
            double secondNumber = double.Parse(input[1]);
            double thirdNumber = double.Parse(input[2]);

            StringBuilder sb = new StringBuilder();
            sb.Append($"|{firstNumber.ToString("X").PadRight(10)}");
            sb.Append($"|{Convert.ToString(firstNumber, 2).PadLeft(10, '0').Substring(0, 10)}");
            sb.Append($"|{secondNumber.ToString("0.00").PadLeft(10)}");
            sb.Append($"|{thirdNumber.ToString("0.000").PadRight(10)}|");

            Console.WriteLine(sb);
        }
    }
}