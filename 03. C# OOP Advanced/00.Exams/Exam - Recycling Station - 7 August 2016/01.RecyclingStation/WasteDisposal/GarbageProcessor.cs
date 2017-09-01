namespace _01.RecyclingStation.WasteDisposal
{
    using _01.RecyclingStation.WasteDisposal.Attributes;
    using _01.RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Linq;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            DisposableAttribute disposalAttribute = (DisposableAttribute)garbage.GetType().GetCustomAttributes(typeof(DisposableAttribute), true).FirstOrDefault();
            if (disposalAttribute == null)
            {
                throw new ArgumentException("The passed in garbage does not implement a supported Disposable Strategy Attribute!");
            }

            Type typeOfAttribute = disposalAttribute.GetType();
            if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(typeOfAttribute))
            {
                Type typeOfCorrespondingStrategy = disposalAttribute.CorrespondingStrategyType;

                IGarbageDisposalStrategy strategyToAdd = (IGarbageDisposalStrategy)Activator.CreateInstance(typeOfCorrespondingStrategy);

                this.StrategyHolder.AddStrategy(typeOfAttribute, strategyToAdd);
            }

            IGarbageDisposalStrategy currentStrategy = this.StrategyHolder.GetDisposalStrategies[typeOfAttribute];

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}