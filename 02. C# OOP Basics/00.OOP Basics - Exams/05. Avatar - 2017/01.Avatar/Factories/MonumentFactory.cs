using System;

public class MonumentFactory
{
    public static Monument CreateMonument(string type, string name, int affinity)
    {
        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);

            case "Water":
                return new WaterMonument(name, affinity);

            case "Fire":
                return new FireMonument(name, affinity);

            case "Earth":
                return new EarthMonument(name, affinity);

            default:
                throw new ArgumentException();
        }
    }
}