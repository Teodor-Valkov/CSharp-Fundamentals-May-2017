namespace _01.RecyclingStation
{
    using _01.RecyclingStation.Contracts.Core;
    using _01.RecyclingStation.Contracts.Factories;
    using _01.RecyclingStation.Contracts.IO;
    using _01.RecyclingStation.Core;
    using _01.RecyclingStation.Factories;
    using _01.RecyclingStation.IO;
    using _01.RecyclingStation.WasteDisposal;
    using _01.RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IWasteFactory wasteFactory = new WasteFactory();

            IStrategyHolder strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());
            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);

            IRecyclingStationManager recyclingStationManager = new RecyclingStationManager(garbageProcessor, wasteFactory);

            IEngine engine = new Engine(reader, writer, recyclingStationManager);
            engine.Run();
        }
    }
}