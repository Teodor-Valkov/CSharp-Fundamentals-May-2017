namespace _04.JedyDreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> methods = new Dictionary<string, List<string>>();

            StringBuilder inputStringBuilder = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                inputStringBuilder.Append(Console.ReadLine());
            }

            string input = inputStringBuilder.ToString();

            string patternDeclareMethod = @"static\s*(?:[\w\[\]])+\s*([A-Z]\w+)";
            string patternInvokeMethod = @"([A-Z]\w+)\s*(?:\()";

            MatchCollection declaredMethods = Regex.Matches(input, patternDeclareMethod);

            for (int i = 0; i < declaredMethods.Count; i++)
            {
                string method = declaredMethods[i].Groups[1].Value;

                methods[method] = new List<string>();

                string methodText = string.Empty;

                int startIndex = input.IndexOf(declaredMethods[i].Groups[0].Value) + declaredMethods[i].Groups[0].Value.Length;

                if (i < declaredMethods.Count - 1)
                {
                    int length = input.IndexOf(declaredMethods[i + 1].Groups[0].Value) - startIndex;
                    methodText = input.Substring(startIndex, length);
                }
                else
                {
                    methodText = input.Substring(startIndex);
                }

                MatchCollection invokedMethods = Regex.Matches(methodText, patternInvokeMethod);
                foreach (Match match in invokedMethods)
                {
                    methods[method].Add(match.Groups[1].Value);
                }
            }

            // Solution I
            //
            var results = methods
                    .OrderByDescending(pair => pair.Value.Count)
                    .ThenBy(pair => pair.Key)
                    .Select(pair => new
                    {
                        DeclaredMethodName = pair.Key,
                        InvokedMethodsCount = pair.Value.Count,
                        InvokedMethodsNames = string.Join(", ", pair.Value.OrderBy(im => im))
                    });

            foreach (var result in results)
            {
                Console.WriteLine(result.InvokedMethodsCount > 0
                    ? $"{result.DeclaredMethodName} -> {result.InvokedMethodsCount} -> {result.InvokedMethodsNames}"
                    : $"{result.DeclaredMethodName} -> None");
            }

            // Solution II
            //
            methods = methods
                .OrderByDescending(pair => pair.Value.Count)
                .ThenBy(pair => pair.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, List<string>> method in methods)
            {
                Console.WriteLine(method.Value.Count > 0
                    ? $"{method.Key} -> {method.Value.Count} -> {string.Join(", ", method.Value.OrderBy(im => im))}"
                    : $"{method.Key} -> None");
            }
        }
    }
}