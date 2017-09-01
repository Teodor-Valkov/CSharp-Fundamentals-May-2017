using System;

public abstract class Vehicle
{
    private string type;
    private double fuelQuantity;
    private double fuelConsumptionPerKilometer;
    private double tankCapacity;
    private double distanceTravelled;

    protected Vehicle(string type, double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
    {
        this.type = type;
        this.fuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        this.tankCapacity = tankCapacity;
    }

    protected double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
    }

    protected virtual double FuelConsumptionPerKilometer
    {
        get
        {
            return this.fuelConsumptionPerKilometer;
        }
        set
        {
            this.fuelConsumptionPerKilometer = value;
        }
    }

    protected double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }
    }

    private bool CanVehicleDrive(double distanceToDrive)
    {
        if (this.FuelQuantity >= this.FuelConsumptionPerKilometer * distanceToDrive)
        {
            return true;
        }
        return false;
    }

    public virtual void Drive(double distanceToDrive)
    {
        if (this.CanVehicleDrive(distanceToDrive))
        {
            this.fuelQuantity -= this.FuelConsumptionPerKilometer * distanceToDrive;
            this.distanceTravelled += distanceToDrive;

            Console.WriteLine($"{this.GetType()} travelled {distanceToDrive} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType()} needs refueling");
        }
    }

    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        this.fuelQuantity += fuel;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}