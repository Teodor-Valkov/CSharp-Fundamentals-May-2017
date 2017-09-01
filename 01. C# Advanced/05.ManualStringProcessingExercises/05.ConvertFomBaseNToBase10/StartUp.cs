namespace _05.ConvertFomBaseNToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class StartUp
    {
        private static void Main()
        {
            BigInteger[] baseNumberAndNumber = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            BigInteger baseNumber = baseNumberAndNumber[0];

            string numberAsString = baseNumberAndNumber[1].ToString();

            BigInteger num = ToDecimalBase(numberAsString, baseNumber);

            Console.WriteLine(num);
        }

        private static BigInteger ToDecimalBase(string numberAsString, BigInteger baseNumber)
        {
            BigInteger number = 0;

            for (int i = 0; i < numberAsString.Length; i++)
            {
                BigInteger nextDigit = BigInteger.Parse(numberAsString[numberAsString.Length - i - 1].ToString());
                number += nextDigit * BigInteger.Pow(baseNumber, i);
            }

            return number;
        }
    }
}