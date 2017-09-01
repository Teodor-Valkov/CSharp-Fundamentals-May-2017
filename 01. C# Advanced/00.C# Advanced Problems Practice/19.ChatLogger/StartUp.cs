namespace _19.ChatLogger
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security;
    using System.Threading;

    internal class StartUp
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            DateTime currentTime = DateTime.Parse(Console.ReadLine());

            SortedDictionary<DateTime, string> messages = new SortedDictionary<DateTime, string>();

            string input = String.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] inputArgs = input.Split(new[] { " / " }, StringSplitOptions.RemoveEmptyEntries);

                string message = inputArgs[0];
                DateTime date = DateTime.Parse(inputArgs[1]);

                messages[date] = message;
            }

            DateTime lastTimeSeen = messages.Last().Key;
            TimeSpan timeDiff = currentTime - lastTimeSeen;

            foreach (KeyValuePair<DateTime, string> pair in messages)
            {
                string message = pair.Value;
                Console.WriteLine($"<div>{SecurityElement.Escape(message)}</div>");
            }

            if (lastTimeSeen.Day < currentTime.Day - 1)
            {
                Console.WriteLine($"<p>Last active: <time>{lastTimeSeen:dd-MM-yyyy}</time></p>");
            }
            else if (lastTimeSeen.Day == currentTime.Day - 1)
            {
                Console.WriteLine("<p>Last active: <time>yesterday</time></p>");
            }
            else if (lastTimeSeen.Day == currentTime.Day && timeDiff.TotalHours >= 1)
            {
                Console.WriteLine($"<p>Last active: <time>{(int)timeDiff.TotalHours} hour(s) ago</time></p>");
            }
            else if (timeDiff.TotalHours < 1 && timeDiff.TotalMinutes >= 1)
            {
                Console.WriteLine($"<p>Last active: <time>{(int)timeDiff.TotalMinutes} minute(s) ago</time></p>");
            }
            else
            {
                Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
            }
        }
    }
}