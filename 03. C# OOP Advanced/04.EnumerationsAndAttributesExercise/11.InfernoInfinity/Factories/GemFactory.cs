using System;

public class GemFactory
{
    public static Gem CreateGem(string input)
    {
        string[] gemArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string gemClarity = gemArgs[0];
        string gemType = gemArgs[1];

        switch (gemType)
        {
            case "Ruby":
                return new Ruby((ClarityLevel)Enum.Parse(typeof(ClarityLevel), gemClarity));

            case "Emerald":
                return new Emerald((ClarityLevel)Enum.Parse(typeof(ClarityLevel), gemClarity));

            case "Amethyst":
                return new Amethyst((ClarityLevel)Enum.Parse(typeof(ClarityLevel), gemClarity));

            default:
                throw new Exception();
        }
    }
}