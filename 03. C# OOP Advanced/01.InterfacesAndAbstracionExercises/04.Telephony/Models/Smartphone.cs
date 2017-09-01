namespace _04.Telephony.Models
{
    using Contracts;
    using System;
    using System.Linq;

    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone(string[] numbers, string[] websites)
        {
            this.Numbers = numbers;
            this.Websites = websites;
        }

        public string[] Numbers { get; private set; }

        public string[] Websites { get; private set; }

        public void Call()
        {
            foreach (string number in this.Numbers)
            {
                Console.WriteLine(number.All(char.IsDigit)
                    ? $"Calling... {number}"
                    : "Invalid number!");
            }
        }

        public void Browse()
        {
            foreach (string website in this.Websites)
            {
                Console.WriteLine(!website.Any(char.IsDigit)
                    ? $"Browsing: {website}!"
                    : "Invalid URL!");
            }
        }
    }
}