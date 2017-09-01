﻿namespace RecyclingStation.WasteDisposal
{
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Linq;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public GarbageProcessor()
            : this(new StrategyHolder())
        {
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            DisposableAttribute disposalAttribute = (DisposableAttribute)garbage.GetType()
                .GetCustomAttributes(true)
                .FirstOrDefault(x => x.GetType().BaseType == typeof(DisposableAttribute));

            IGarbageDisposalStrategy currentStrategy;

            if (disposalAttribute == null || !this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(), out currentStrategy))
            {
                throw new ArgumentException("The passed in garbage does not implement a supported Disposable Strategy Attribute!");
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}