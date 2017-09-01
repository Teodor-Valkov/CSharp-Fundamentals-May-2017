namespace _04.JedyDreams2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> methods = new Dictionary<string, List<string>>();

            string patternDeclareMethod = @"static\s*(?:[\w\[\]])+\s*([A-Z]\w+)";
            Regex regexDeclareMethod = new Regex(patternDeclareMethod);

            string patternInvokeMethod = @"([A-Z]\w+)\s*(?:\()";
            Regex regexInvokeMethod = new Regex(patternInvokeMethod);

            string declaredMethod = string.Empty;

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                Match matchDeclareMethod = regexDeclareMethod.Match(input);
                if (matchDeclareMethod.Success)
                {
                    declaredMethod = matchDeclareMethod.Groups[1].Value;

                    if (!methods.ContainsKey(declaredMethod))
                    {
                        methods[declaredMethod] = new List<string>();
                    }

                    continue;
                }

                MatchCollection matchesInvokeMethods = regexInvokeMethod.Matches(input);
                if (matchesInvokeMethods.Count > 0)
                {
                    foreach (Match match in matchesInvokeMethods)
                    {
                        methods[declaredMethod].Add(match.Groups[1].Value);
                    }
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