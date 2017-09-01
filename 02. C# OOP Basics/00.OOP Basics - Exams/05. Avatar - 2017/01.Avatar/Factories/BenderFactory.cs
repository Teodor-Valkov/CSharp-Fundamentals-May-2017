using System;

public class BenderFactory
{
    public static Bender CreateBender(string type, string name, int power, double specialPower)
    {
        switch (type)
        {
            case "Air":
                return new AirBender(name, power, specialPower);

            case "Water":
                return new WaterBender(name, power, specialPower);

            case "Fire":
                return new FireBender(name, power, specialPower);

            case "Earth":
                return new EarthBender(name, power, specialPower);

            default:
                throw new ArgumentException();
        }
    }
}