namespace _05.SemanticHtml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class SemanticHtml
    {
        private static void Main()
        {
            string[] semanticTags = { "main", "header", "nav", "article", "section", "aside", "footer" };

            string openingTags = @"<div.*?((?:id|class)\s*=\s*""(.*?)"").*?>";
            Regex openingRegex = new Regex(openingTags);

            string closeTagsPattern = @"<\/div>\s.*?(\w+)\s*-->";
            Regex closingRegex = new Regex(closeTagsPattern);

            List<string> result = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                Match openingMatch = openingRegex.Match(input);
                if (openingMatch.Success)
                {
                    string attributeName = openingMatch.Groups[1].Value;
                    string attributeValue = openingMatch.Groups[2].Value;

                    if (semanticTags.Contains(attributeValue))
                    {
                        string replaceTag = Regex.Replace(openingMatch.Value, "div", attributeValue);
                        replaceTag = Regex.Replace(replaceTag, attributeName, "");
                        replaceTag = Regex.Replace(replaceTag, "\\s*>", ">");
                        replaceTag = Regex.Replace(replaceTag, "\\s{2,}", " ");

                        input = Regex.Replace(input, openingMatch.Value, replaceTag);
                    }
                }

                Match commentsMatch = closingRegex.Match(input);
                if (commentsMatch.Success)
                {
                    string commentValue = commentsMatch.Groups[1].Value;

                    if (semanticTags.Contains(commentValue))
                    {
                        input = Regex.Replace(input, commentsMatch.Value, string.Format("</" + commentValue + ">"));
                    }
                }

                result.Add(input);
            }

            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}