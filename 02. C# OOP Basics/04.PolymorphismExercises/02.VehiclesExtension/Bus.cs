using System;

public class Bus : Vehicle
{
    private const double FullWithPeopleConsumption = 1.4;

    private bool isBusFull;

    public Bus(string type, double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
        : base(type, fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
    {
    }

    public void MakeBusFull()
    {
        this.isBusFull = true;
    }

    public override void Drive(double distanceToDrive)
    {
        if (this.isBusFull)
        {
            base.FuelConsumptionPerKilometer += FullWithPeopleConsumption;
        }

        base.Drive(distanceToDrive);

        this.isBusFull = false;
        base.FuelConsumptionPerKilometer -= FullWithPeopleConsumption;
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