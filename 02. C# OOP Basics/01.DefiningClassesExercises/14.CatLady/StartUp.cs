using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Cat> cats = new List<Cat>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string type = inputArgs[0];
            string name = inputArgs[1];

            switch (type)
            {
                case "Siamese":
                    int earSize = int.Parse(inputArgs[2]);
                    Siamese siamese = new Siamese(name, earSize);
                    cats.Add(siamese);
                    break;

                case "Cymric":
                    double furLength = double.Parse(inputArgs[2]);
                    Cymric cymric = new Cymric(name, furLength);
                    cats.Add(cymric);
                    break;

                case "StreetExtraordinaire":
                    int decibels = int.Parse(inputArgs[2]);
                    StreetExtraordinaire streetExtraordinaire = new StreetExtraordinaire(name, decibels);
                    cats.Add(streetExtraordinaire);
                    break;
            }
        }

        string neededCat = Console.ReadLine();
        Console.WriteLine(cats.First(cat => cat.Name == neededCat));
    }
}