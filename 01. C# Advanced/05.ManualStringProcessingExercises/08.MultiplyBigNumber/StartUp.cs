namespace _08.MultiplyBigNumber
{
    using System;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int numberInMind = 0;
            StringBuilder result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int product = int.Parse(firstNumber[i].ToString()) * secondNumber + numberInMind;

                numberInMind = product / 10;
                int remainder = product % 10;

                result.Append(remainder);

                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }
            }

            char[] resultToCharArr = result.ToString().ToCharArray();
            Array.Reverse(resultToCharArr);

            Console.WriteLine(new string(resultToCharArr));
        }
    }
}