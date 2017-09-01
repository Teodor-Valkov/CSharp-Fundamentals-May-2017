﻿public class AutomaticMachine : Ammunition
{
    public const double WeightConst = 6.3;

    public AutomaticMachine(string name)
        : base(name)
    {
        this.Weight = WeightConst;
        this.WearLevel = this.Weight * 100;
    }
}