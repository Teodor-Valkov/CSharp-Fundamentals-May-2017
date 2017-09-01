namespace _01.Kermen
{
    using Factories;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Household> kermen = new List<Household>();
            int counter = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Democracy")
            {
                counter++;

                try
                {
                    Household household = HouseholdFactory.CreateHousehold(input);
                    kermen.Add(household);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                if (counter % 3 == 0)
                {
                    kermen.ForEach(household => household.GetIncome());
                }

                switch (input)
                {
                    case "EVN bill":
                        kermen.RemoveAll(household => !household.CanPayBill());
                        kermen.ForEach(household => household.PayBill());
                        break;

                    case "EVN":
                        Console.WriteLine($"Total consumption: {kermen.Sum(household => household.Consumption)}");
                        break;
                }
            }

            Console.WriteLine($"Total population: {kermen.Sum(household => household.Population)}");
        }
    }
}