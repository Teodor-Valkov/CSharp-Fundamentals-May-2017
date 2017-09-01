using System;

public class Car : Vehicle
{
    private const double SummerConsumption = 0.9;

    public Car(string type, double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
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
        if (this.FuelQuantity + fuel > this.TankCapacity)
        {
            throw new ArgumentException("Cannot fit fuel in tank");
        }

        base.Refuel(fuel);
    }
}