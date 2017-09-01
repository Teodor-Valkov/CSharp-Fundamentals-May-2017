namespace _05.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    internal class ExtractEmails
    {
        private static void Main()
        {
            //Examples of valid emails:
            //info@softuni-bulgaria.org, kiki@hotmail.co.uk, no-reply@github.com, s.peterson@mail.uu.net, info-bg@softwareuniversity.software.academy.
            //
            //Examples of invalid emails:
            //--123@gmail.com, …@mail.bg, .info@info.info, _steve@yahoo.cn, mike@helloworld, mike@.unknown.soft., s.johnson@invalid-

            string input = Console.ReadLine();

            string pattern = @"(?<=\s|^)([A-Za-z0-9]+[_.-]?[A-Za-z0-9]+)@([A-Za-z]+(?:[.-][A-Za-z]+)*[.][A-Za-z]+)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}