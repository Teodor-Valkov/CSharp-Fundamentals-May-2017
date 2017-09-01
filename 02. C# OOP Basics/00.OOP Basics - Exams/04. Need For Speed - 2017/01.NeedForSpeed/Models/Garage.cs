using System.Collections.Generic;

public class Garage
{
    private Dictionary<int, Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new Dictionary<int, Car>();
    }

    public void Park(int id, Car car)
    {
        this.parkedCars[id] = car;
    }

    public void Unpark(int id)
    {
        this.parkedCars.Remove(id);
    }

    public bool IsCarParked(int id)
    {
        return this.parkedCars.ContainsKey(id);
    }

    public void TuneParkedCars(int tuneIndex, string addOn)
    {
        foreach (Car car in this.parkedCars.Values)
        {
            car.TuneCar(tuneIndex, addOn);
        }
    }
}