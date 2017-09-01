namespace _01.PawInc.Factories
{
    using Models;
    using Models.Centers;
    using System;

    public class CenterFactory
    {
        public static Center CreateCenter(string type, string name)
        {
            switch (type)
            {
                case "Cleansing":
                    return new CleansingCenter(name, type);

                case "Adoption":
                    return new AdoptionCenter(name, type);

                case "Castration":
                    return new CastrationCenter(name, type);

                default:
                    throw new ArgumentException("Invalid center!");
            }
        }
    }
}