namespace _09.QueryMess2
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class QueryMessRegex
    {
        private static void Main()
        {
            string pattern = @"([^&=?\s]+)=([^&=\s]+)";
            string spaces = @"((%20|\+)+)";

            Regex pairs = new Regex(pattern);
            List<string> result = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                Dictionary<string, List<string>> fieldValueDictionary = new Dictionary<string, List<string>>();

                MatchCollection matches = pairs.Matches(input);
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

                StringBuilder sb = new StringBuilder();

                foreach (KeyValuePair<string, List<string>> pair in fieldValueDictionary)
                {
                    sb.Append($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }

                result.Add(sb.ToString());
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}