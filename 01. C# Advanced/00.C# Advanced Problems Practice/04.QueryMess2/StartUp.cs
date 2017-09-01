namespace _04.QueryMess2
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class QueryMessRegex
    {
        private static void Main()
        {
            string pattern = @"([^&=?\s]+)=([^&=\s]+)";
            string spaces = @"((%20|\+)+)";

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                Regex pairs = new Regex(pattern);
                MatchCollection matches = pairs.Matches(input);

                Dictionary<string, List<string>> fieldValueDictionary = new Dictionary<string, List<string>>();

                for (int i = 0; i < matches.Count; i++)
                {
                    string field = matches[i].Groups[1].Value;
                    field = Regex.Replace(field, spaces, " ").Trim();

                    string value = matches[i].Groups[2].Value;
                    value = Regex.Replace(value, spaces, " ").Trim();

                    if (fieldValueDictionary.ContainsKey(field))
                    {
                        fieldValueDictionary[field].Add(value);
                    }
                    else
                    {
                        fieldValueDictionary.Add(field, new List<string>());
                        fieldValueDictionary[field].Add(value);
                    }
                }

                foreach (KeyValuePair<string, List<string>> pair in fieldValueDictionary)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }

                Console.WriteLine();
            }
        }
    }
}