public class Truck : Vehicle
{
    private const double SummerConsumption = 1.6;
    private const double TankCapacityWithHole = 0.95;

    public Truck(string type, double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
        : base(type, fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
    {
    }

    protected override double FuelConsumptionPerKilometer
    {
        set
        {
            base.FuelConsumptionPerKilometer = value + SummerConsumption;
        }
    }

    public override void Refuel(double fuel)
    {
        base.Refuel(fuel * TankCapacityWithHole);
    }
}