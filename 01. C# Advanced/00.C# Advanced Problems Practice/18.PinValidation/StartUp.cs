namespace _18.PinValidation
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static int[] multipliers = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        private static void Main()
        {
            string name = Console.ReadLine();
            string gender = Console.ReadLine();
            string pin = Console.ReadLine();

            if (!ValidateName(name))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            int genderNumber = int.Parse(pin[8].ToString());
            if (!ValidateGender(gender, genderNumber))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            int month = int.Parse(pin.Substring(2, 2));
            int year = int.Parse(pin.Substring(0, 2));

            if (!ValidateMonthAndYear(pin, ref month, ref year))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            int days = int.Parse(pin.Substring(4, 2));
            if (!ValidateDays(days, month, year))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            if (!ValidateChecksum(pin))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            Console.WriteLine($@"{{""name"":""{name}"",""gender"":""{gender}"",""pin"":""{pin}""}}");
        }

        private static bool ValidateName(string name)
        {
            string namePattern = "[A-Z][a-z]+\\s[A-Z][a-z]+";
            Regex regex = new Regex(namePattern);

            Match nameMatch = regex.Match(name);
            if (!nameMatch.Success)
            {
                return false;
            }

            return true;
        }

        private static bool ValidateGender(string gender, int genderNumber)
        {
            if (gender == "female" && genderNumber % 2 == 0 || gender == "male" && genderNumber % 2 == 1)
            {
                return false;
            }

            return true;
        }

        private static bool ValidateMonthAndYear(string pin, ref int month, ref int year)
        {
            if (month >= 20 && month <= 32)
            {
                year += 1800;
                month -= 20;
            }
            else if (month >= 1 && month <= 12)
            {
                year += 1900;
            }
            else if (month >= 40 && month <= 52)
            {
                year += 2000;
                month -= 40;
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool ValidateDays(int days, int month, int year)
        {
            if (days < 1 || days > DateTime.DaysInMonth(year, month))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateChecksum(string pin)
        {
            long sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(pin[i].ToString()) * multipliers[i];
            }

            long reminder = sum % 11;

            if (reminder == 10)
            {
                reminder = 0;
            }

            if (int.Parse(pin.Last().ToString()) != reminder)
            {
                return false;
            }

            return true;
        }
    }
}