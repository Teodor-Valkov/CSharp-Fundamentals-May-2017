using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
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

    public Engine Engine
    {
        get
        {
            return this.engine;
        }
        private set
        {
            this.engine = value;
        }
    }

    public Cargo Cargo
    {
        get
        {
            return this.cargo;
        }
        private set
        {
            this.cargo = value;
        }
    }

    public List<Tire> Tires
    {
        get
        {
            return this.tires;
        }
        private set
        {
            this.tires = value;
        }
    }
}