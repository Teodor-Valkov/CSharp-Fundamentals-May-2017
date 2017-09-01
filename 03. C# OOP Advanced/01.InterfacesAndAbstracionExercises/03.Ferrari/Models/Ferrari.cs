namespace _03.Ferrari.Models
{
    using Contracts;

    public class Ferrari : ICar
    {
        public const string model = "488-Spider";

        public Ferrari(string driver)
        {
            this.Model = model;
            this.Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; private set; }

        public string HitBreak()
        {
            return "Brakes!";
        }

        public string HitGas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.HitBreak()}/{this.HitGas()}/{this.Driver}";
        }
    }
}