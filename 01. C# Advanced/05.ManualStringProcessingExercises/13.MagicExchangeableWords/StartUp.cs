namespace _13.MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            // Solution 1
            //
            string[] words1 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<char> list1 = new HashSet<char>(words1[0]);
            HashSet<char> list2 = new HashSet<char>(words1[1]);

            Console.WriteLine(list1.Count == list2.Count ? "true" : "false");

            // Solution 2
            //
            string[] words2 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            char[] first = words2[0].ToCharArray();
            char[] second = words2[1].ToCharArray();

            List<char> list3 = new List<char>();
            List<char> list4 = new List<char>();

            foreach (char letter in first)
            {
                if (list3.All(symbol => symbol != letter))
                {
                    list3.Add(letter);
                }
            }

            foreach (char letter in second)
            {
                if (list4.All(symbol => symbol != letter))
                {
                    list4.Add(letter);
                }
            }

            Console.WriteLine(list3.Count == list4.Count ? "true" : "false");
        }
    }
}