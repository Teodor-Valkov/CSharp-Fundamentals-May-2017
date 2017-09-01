using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelPerKilometer;
    private double distance;

    public Car(string model, double fuelAmount, double fuelPerKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelPerKilometer = fuelPerKilometer;
        this.Distance = 0;
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        private set
        {
            this.model = value;
        }
    }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }
        private set
        {
            this.fuelAmount = value;
        }
    }

    public double FuelPerKilometer
    {
        get
        {
            return this.fuelPerKilometer;
        }
        private set
        {
            this.fuelPerKilometer = value;
        }
    }

    public double Distance
    {
        get
        {
            return this.distance;
        }
        private set
        {
            this.distance = value;
        }
    }

    public void Drive(int distance)
    {
        double fuelNeeded = distance * this.FuelPerKilometer;

        if (this.FuelAmount >= fuelNeeded)
        {
            this.fuelAmount -= fuelNeeded;
            this.distance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}