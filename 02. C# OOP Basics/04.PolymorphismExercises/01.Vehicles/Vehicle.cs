using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKilometer;
    private double distanceTravelled;

    protected Vehicle(double fuelQuantity, double fuelConsumptionPerKilometer)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        this.DistanceTravelled = 0;
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        protected set
        {
            this.fuelQuantity = value;
        }
    }

    public virtual double FuelConsumptionPerKilometer
    {
        get
        {
            return this.fuelConsumptionPerKilometer;
        }
        protected set
        {
            this.fuelConsumptionPerKilometer = value;
        }
    }

    public double DistanceTravelled
    {
        get
        {
            return this.distanceTravelled;
        }
        protected set
        {
            this.distanceTravelled = value;
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
            this.FuelQuantity -= this.FuelConsumptionPerKilometer * distanceToDrive;
            this.DistanceTravelled += distanceToDrive;

            Console.WriteLine($"{this.GetType()} travelled {distanceToDrive} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType()} needs refueling");
        }
    }

    public virtual void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }
}