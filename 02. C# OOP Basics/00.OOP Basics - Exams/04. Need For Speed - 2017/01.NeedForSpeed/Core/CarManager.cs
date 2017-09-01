using System;
using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = this.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

        this.cars[id] = car;
    }

    public string Check(int id)
    {
        Car car = this.cars[id];

        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = this.CreateRace(type, length, route, prizePool);

        this.races[id] = race;
    }

    public void Open(int id, string type, int length, string route, int prizePool, int specialRaceParameter)
    {
        Race race = this.CreateRace(type, length, route, prizePool, specialRaceParameter);

        this.races[id] = race;
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.IsCarParkedInGarage(carId))
        {
            this.races[raceId].AddParticipantToRace(carId, this.cars[carId]);
        }
    }

    public string Start(int id)
    {
        string winners = string.Empty;

        if (this.races[id].Participants.Count > 0)
        {
            Race race = this.races[id];
            this.races.Remove(id);
            race.Start();
            winners = race.ToString();
        }
        else
        {
            winners = Constants.RaceHasNoParticipantsMessage;
        }

        return winners;
    }

    public void Park(int id)
    {
        if (!this.IsCarParticipatingInRace(id))
        {
            Car car = this.cars[id];
            this.garage.Park(id, car);
        }
    }

    public void Unpark(int id)
    {
        if (this.IsCarParkedInGarage(id))
        {
            this.garage.Unpark(id);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        this.garage.TuneParkedCars(tuneIndex, addOn);
    }

    private bool IsCarParkedInGarage(int id)
    {
        return this.garage.IsCarParked(id);
    }

    private bool IsCarParticipatingInRace(int id)
    {
        return this.races.Values.Any(race => race.Participants.ContainsKey(id));
    }

    private Car CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Performance":
                return CarFactory.CreatePerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

            case "Show":
                return CarFactory.CreateShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

            default:
                throw new ArgumentException();
        }
    }

    private Race CreateRace(string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                return RaceFactory.CreateCasualRace(length, route, prizePool);

            case "Drag":
                return RaceFactory.CreateDragRace(length, route, prizePool);

            case "Drift":
                return RaceFactory.CreateDriftRace(length, route, prizePool);

            default:
                throw new ArgumentException();
        }
    }

    private Race CreateRace(string type, int length, string route, int prizePool, int specialRaceParameter)
    {
        switch (type)
        {
            case "Circuit":
                return RaceFactory.CreateCircuitRace(length, route, prizePool, specialRaceParameter);

            case "TimeLimit":
                return RaceFactory.CreateTimeLimitRace(length, route, prizePool, specialRaceParameter);

            default:
                throw new ArgumentException();
        }
    }
}