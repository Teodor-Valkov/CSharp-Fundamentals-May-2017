﻿using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Models.Waste
{
    [StorableGarbageStrategy]
    public class StorableGarbage : Waste
    {
        public StorableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}