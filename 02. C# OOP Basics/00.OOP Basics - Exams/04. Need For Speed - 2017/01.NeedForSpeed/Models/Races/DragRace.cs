﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    public override void Start()
    {
        int place = 1;

        Dictionary<int, Car> orderedParticipants = this.Participants.OrderByDescending(x => x.Value.GetEnginePerformance()).ToDictionary(x => x.Key, x => x.Value);

        foreach (KeyValuePair<int, Car> orderedParticipant in orderedParticipants)
        {
            this.AddWinner(orderedParticipant.Value);

            if (place == Constants.NormalRaceMaximumWinners)
            {
                break;
            }

            place++;
        }
    }

    protected override string GetWinningStats()
    {
        StringBuilder sb = new StringBuilder();

        int place = 1;

        foreach (Car winner in this.Winners)
        {
            int price = this.GetPrice(place);

            sb.AppendLine($"{place}. {winner.Brand} {winner.Model} {winner.GetEnginePerformance()}PP - ${price}");

            place++;
        }

        return sb.ToString();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());

        sb.Append(this.GetWinningStats());

        return sb.ToString().Trim();
    }
}