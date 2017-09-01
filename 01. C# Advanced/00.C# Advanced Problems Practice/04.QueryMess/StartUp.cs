namespace _04.QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class QueryMess
    {
        private static void Main()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                Dictionary<string, List<string>> fieldValueDictionary = new Dictionary<string, List<string>>();

                string[] inputArgs = input.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string arg in inputArgs)
                {
                    if (!arg.Contains("="))
                    {
                        continue;
                    }

                    string[] currentArgs = arg.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string curArg in currentArgs)
                    {
                        string[] fieldAndValue = curArg.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        string field = fieldAndValue[0];
                        string value = fieldAndValue[1];

                        field = Regex.Replace(field, @"(%20|\+)+", " ").Trim();
                        value = Regex.Replace(value, @"(%20|\+)+", " ").Trim();

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