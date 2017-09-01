namespace _12.CharacterMultiplier
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string first = words[0];
            string second = words[1];

            long sum = 0;

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                sum += SumCurrentChars(first[i], second[i]);
            }

            if (first.Length == second.Length)
            {
                Console.WriteLine(sum);
            }
            else
            {
                if (first.Length > second.Length)
                {
                    for (int i = second.Length; i < first.Length; i++)
                    {
                        sum += first[i];
                    }
                }
                else
                {
                    for (int i = first.Length; i < second.Length; i++)
                    {
                        sum += second[i];
                    }
                }

                Console.WriteLine(sum);
            }
        }

        private static long SumCurrentChars(char firstSymbol, char secondSymbol)
        {
            return firstSymbol * secondSymbol;
        }
    }
}