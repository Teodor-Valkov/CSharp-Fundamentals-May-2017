using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.laps = laps;
    }

    public override void Start()
    {
        List<Car> participantCars = new List<Car>(this.Participants.Values);

        for (int lap = 0; lap < this.laps; lap++)
        {
            foreach (Car participantCar in participantCars)
            {
                participantCar.DecreaseDurabilityPerLap(base.Length * base.Length);
            }
        }

        int place = 1;

        Dictionary<int, Car> orderedParticipants = this.Participants.OrderByDescending(x => x.Value.GetOverallPerformance()).ToDictionary(x => x.Key, x => x.Value);

        foreach (KeyValuePair<int, Car> orderedParticipant in orderedParticipants)
        {
            this.AddWinner(orderedParticipant.Value);

            if (place == Constants.CircuitRaceMaximumWinners)
            {
                break;
            }

            place++;
        }
    }

    protected override int GetPrice(int place)
    {
        int price = this.PrizePool;

        switch (place)
        {
            case 1:
                price = (price * Constants.CircuitRaceFirstPlacePercentage) / Constants.MaximumPercentage;
                break;

            case 2:
                price = (price * Constants.CircuitRaceSecondPlacePercentage) / Constants.MaximumPercentage;
                break;

            case 3:
                price = (price * Constants.CircuitRaceThirdPlacePercentage) / Constants.MaximumPercentage;
                break;

            case 4:
                price = (price * Constants.CircuitRaceFourthPlacePercentage) / Constants.MaximumPercentage;
                break;
        }

        return price;
    }

    protected override string GetWinningStats()
    {
        StringBuilder sb = new StringBuilder();

        int place = 1;

        foreach (Car winner in this.Winners)
        {
            int price = this.GetPrice(place);

            sb.AppendLine($"{place}. {winner.Brand} {winner.Model} {winner.GetOverallPerformance()}PP - ${price}");

            place++;
        }

        return sb.ToString().Trim();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length * this.laps}");
        sb.Append(this.GetWinningStats());

        return sb.ToString().Trim();
    }
}