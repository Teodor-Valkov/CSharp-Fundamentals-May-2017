namespace _01.Kermen.Factories
{
    using Models;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal static class HouseholdFactory
    {
        public static Household CreateHousehold(string input)
        {
            string pattern = @"(\w+)\(([\d\s\.,]+)\)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            if (regex.IsMatch(input))
            {
                string householdType = matches[0].Groups[1].Value;

                if (householdType == "YoungCouple")
                {
                    return CreateYoungCouple(matches);
                }

                if (householdType == "YoungCoupleWithChildren")
                {
                    return CreateYoungCouplewithChildren(matches);
                }

                if (householdType == "OldCouple")
                {
                    return CreateOldCouple(matches);
                }

                if (householdType == "AloneYoung")
                {
                    return CreateAloneYoung(matches);
                }

                if (householdType == "AloneOld")
                {
                    return CreateAloneOld(matches);
                }

                throw new ArgumentException();
            }

            throw new ArgumentException("Invalid household");
        }

        private static Household CreateYoungCouple(MatchCollection matches)
        {
            decimal[] salaries = matches[0].Groups[2].Value.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal tvConsumption = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeConsumption = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopConsumption = decimal.Parse(matches[3].Groups[2].Value);

            return new YoungCouple(salaries[0], salaries[1], tvConsumption, fridgeConsumption, laptopConsumption);
        }

        private static Household CreateYoungCouplewithChildren(MatchCollection matches)
        {
            decimal[] salaries = matches[0].Groups[2].Value.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal tvConsumption = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeConsumption = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopConsumption = decimal.Parse(matches[3].Groups[2].Value);

            Child[] children = new Child[matches.Count - 4];
            for (int i = 4; i < matches.Count; i++)
            {
                decimal[] consumptions = matches[i].Groups[2].Value.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
                children[i - 4] = new Child(consumptions);
            }

            return new YoungCoupleWithChildren(salaries[0], salaries[1], tvConsumption, fridgeConsumption, laptopConsumption, children);
        }

        private static Household CreateOldCouple(MatchCollection matches)
        {
            decimal[] pensions = matches[0].Groups[2].Value.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal tvConsumption = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeConsumption = decimal.Parse(matches[2].Groups[2].Value);
            decimal stoveConsumption = decimal.Parse(matches[3].Groups[2].Value);

            return new OldCouple(pensions[0], pensions[1], tvConsumption, fridgeConsumption, stoveConsumption);
        }

        private static Household CreateAloneYoung(MatchCollection matches)
        {
            decimal salary = decimal.Parse(matches[0].Groups[2].Value);
            decimal laptopConsumption = decimal.Parse(matches[1].Groups[2].Value);

            return new AloneYoung(salary, laptopConsumption);
        }

        private static Household CreateAloneOld(MatchCollection matches)
        {
            decimal pension = decimal.Parse(matches[0].Groups[2].Value);

            return new AloneOld(pension);
        }
    }
}