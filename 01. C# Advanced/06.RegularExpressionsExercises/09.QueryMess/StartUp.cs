namespace _09.QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class QueryMess
    {
        private static void Main()
        {
            List<string> result = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                Dictionary<string, List<string>> fieldValueDictionary = new Dictionary<string, List<string>>();

                string[] inputArgs = input.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string arg in inputArgs)
                {
                    if (!arg.Contains("="))
                        continue;

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