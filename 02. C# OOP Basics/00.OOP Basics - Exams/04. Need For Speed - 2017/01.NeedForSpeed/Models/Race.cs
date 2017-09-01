using System.Collections.Generic;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;
    private List<Car> winners;

    protected Race(int length, string route, int prizePool)
    {
        this.length = length;
        this.route = route;
        this.prizePool = prizePool;
        this.participants = new Dictionary<int, Car>();
        this.winners = new List<Car>();
    }

    public int Length
    {
        get
        {
            return this.length;
        }
    }

    public string Route
    {
        get
        {
            return this.route;
        }
    }

    public int PrizePool
    {
        get
        {
            return this.prizePool;
        }
    }

    public IReadOnlyDictionary<int, Car> Participants
    {
        get
        {
            return this.participants;
        }
    }

    protected IReadOnlyList<Car> Winners
    {
        get
        {
            return this.winners;
        }
    }

    public virtual void AddParticipantToRace(int carId, Car car)
    {
        this.participants[carId] = car;
    }

    protected void AddWinner(Car winner)
    {
        this.winners.Add(winner);
    }

    public abstract void Start();

    protected virtual int GetPrice(int place)
    {
        int price = this.PrizePool;

        switch (place)
        {
            case 1:
                price = (price * Constants.NormalRaceFirstPricePercentage) / Constants.MaximumPercentage;
                break;

            case 2:
                price = (price * Constants.NormalRaceSecondPricePercentage) / Constants.MaximumPercentage;
                break;

            case 3:
                price = (price * Constants.NormalRaceThirdPricePercentage) / Constants.MaximumPercentage;
                break;
        }

        return price;
    }

    protected abstract string GetWinningStats();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");

        return sb.ToString();
    }
}