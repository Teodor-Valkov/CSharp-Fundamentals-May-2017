namespace _07.SumBigNumbers
{
    using System;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            string secondNumber = Console.ReadLine().TrimStart('0');

            if (firstNumber.Length > secondNumber.Length)
            {
                secondNumber = secondNumber.PadLeft(firstNumber.Length, '0');
            }
            else
            {
                firstNumber = firstNumber.PadLeft(secondNumber.Length, '0');
            }

            StringBuilder result = new StringBuilder();
            int numberInMind = 0;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int sum = int.Parse(firstNumber[i].ToString()) + int.Parse(secondNumber[i].ToString()) + numberInMind;

                numberInMind = sum / 10;
                int reminder = sum % 10;

                result.Append(reminder);

                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }
            }

            char[] resultToChar = result.ToString().ToCharArray();
            Array.Reverse(resultToChar);

            Console.WriteLine(new string(resultToChar));
        }
    }
}