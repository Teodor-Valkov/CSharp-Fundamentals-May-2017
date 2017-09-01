public class Car : Vehicle
{
    private const double SummerConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKilometer)
        : base(fuelQuantity, fuelConsumptionPerKilometer)
    {
    }

    public override double FuelConsumptionPerKilometer
    {
        protected set
        {
            base.FuelConsumptionPerKilometer = value + SummerConsumption;
        }
    }
}