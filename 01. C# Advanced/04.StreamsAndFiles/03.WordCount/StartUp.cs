namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            // Reading the 'words.txt'
            //
            try
            {
                using (StreamReader reader = new StreamReader(@"../../words.txt"))
                {
                    string input = string.Empty;
                    while ((input = reader.ReadLine()) != null)
                    {
                        wordsCount[input] = 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error related with 'words.txt'! Reason: {e.Message}");
                return;
            }

            // Reading the 'text.txt'
            //
            try
            {
                using (StreamReader reader = new StreamReader(@"../../text.txt"))
                {
                    string input = string.Empty;
                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] words = input
                                          .Split(new[] { ' ', '.', '!', '?', ',', '-' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(word => word.ToLower())
                                          .ToArray();

                        foreach (string word in words)
                        {
                            if (wordsCount.ContainsKey(word))
                            {
                                wordsCount[word]++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error related with 'text.txt'! Reason: {e.Message}");
                return;
            }

            // Writing the 'result.txt'
            //
            try
            {
                using (StreamWriter writer = new StreamWriter(@"../../result.txt"))
                {
                    foreach (KeyValuePair<string, int> pair in wordsCount.OrderByDescending(pair => pair.Value))
                    {
                        writer.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error related with 'result.txt'! Reason {e.Message}");
                throw;
            }

            // Printing the 'words', 'text', 'result' on the console
            //
            Console.WriteLine($"{Environment.NewLine}***'Words':");
            Console.WriteLine(File.ReadAllText(@"..\..\words.txt"));

            Console.WriteLine($"{Environment.NewLine}***'Text':");
            Console.WriteLine(File.ReadAllText(@"..\..\text.txt"));

            Console.WriteLine($"{Environment.NewLine}***'Result':");
            Console.WriteLine(File.ReadAllText(@"..\..\result.txt"));
        }
    }
}