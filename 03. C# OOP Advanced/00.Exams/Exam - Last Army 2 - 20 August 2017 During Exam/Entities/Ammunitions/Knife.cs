﻿public class Knife : Ammunition
{
    public const double WeightConst = 0.4;

    public Knife(string name)
        : base(name)
    {
        this.Weight = WeightConst;
        this.WearLevel = this.Weight * 100;
    }
}