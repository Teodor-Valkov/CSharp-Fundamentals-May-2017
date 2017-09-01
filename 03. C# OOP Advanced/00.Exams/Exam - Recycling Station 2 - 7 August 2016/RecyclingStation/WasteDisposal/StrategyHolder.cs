namespace RecyclingStation.WasteDisposal
{
    using Attributes;
    using Models.Strategies;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Collections.Generic;

    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>()
            {
                { new RecyclableGarbageStrategyAttribute().GetType(), new RecyclableGarbageStrategy()},
                { new BurnableGarbageStrategyAttribute().GetType(), new BurnableGarbageStrategy()},
                { new StorableGarbageStrategyAttribute().GetType(), new StorableGarbageStrategy()}
            };
        }

        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            this.strategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            this.strategies.Remove(disposableAttribute);
            return true;
        }
    }
}