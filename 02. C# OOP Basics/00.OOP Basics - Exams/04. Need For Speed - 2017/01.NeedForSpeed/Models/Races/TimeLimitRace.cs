using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.goldTime = goldTime;
    }

    public override void AddParticipantToRace(int carId, Car car)
    {
        if (this.Participants.Count == 0)
        {
            base.AddParticipantToRace(carId, car);
        }
    }

    public override void Start()
    {
        this.AddWinner(this.Participants.First().Value);
    }

    private int GetTime(Car winner)
    {
        return base.Length * ((winner.Horsepower / Constants.MaximumPercentage) * winner.Acceleration);
    }

    private string GetTimeClassification(int time)
    {
        string result = string.Empty;

        if (time <= this.goldTime)
        {
            result = "Gold";
        }
        else if (time <= this.goldTime + Constants.TimeLimitRaceOffset)
        {
            result = "Silver";
        }
        else if (time > this.goldTime + Constants.TimeLimitRaceOffset)
        {
            result = "Bronze";
        }

        return result;
    }

    private int GetPlace(string winnerTimeClassification)
    {
        int place = 0;

        switch (winnerTimeClassification)
        {
            case "Gold":
                place = 1;
                break;

            case "Silver":
                place = 2;
                break;

            case "Bronze":
                place = 3;
                break;
        }

        return place;
    }

    protected override int GetPrice(int place)
    {
        int result = this.PrizePool;

        if (place == 1)
        {
            result = (result * Constants.TimeLimitRaceFirstPlacePercentage) / Constants.MaximumPercentage;
        }
        else if (place == 2)
        {
            result = (result * Constants.TimeLimitRaceSecondPlacePercentage) / Constants.MaximumPercentage;
        }
        else if (place == 3)
        {
            result = (result * Constants.TimeLimitRaceThirdPlacePercentage) / Constants.MaximumPercentage;
        }

        return result;
    }

    protected override string GetWinningStats()
    {
        StringBuilder sb = new StringBuilder();

        Car winner = this.Winners.First();
        int winnerTime = this.GetTime(winner);
        string winnerTimeClassification = this.GetTimeClassification(winnerTime);
        int place = this.GetPlace(winnerTimeClassification);
        int price = this.GetPrice(place);

        sb.AppendLine($"{winner.Brand} {winner.Model} - {winnerTime} s.");
        sb.AppendLine($"{winnerTimeClassification} Time, ${price}.");

        return sb.ToString().Trim();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());

        sb.AppendLine(this.GetWinningStats());

        return sb.ToString();
    }
}