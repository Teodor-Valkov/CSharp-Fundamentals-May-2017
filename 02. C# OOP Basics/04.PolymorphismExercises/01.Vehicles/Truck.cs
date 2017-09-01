public class Truck : Vehicle
{
    private const double SummerConsumption = 1.6;
    private const double TankCapacityWithHole = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionPerKilometer)
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

    public override void Refuel(double fuel)
    {
        base.Refuel(fuel * TankCapacityWithHole);
    }
}