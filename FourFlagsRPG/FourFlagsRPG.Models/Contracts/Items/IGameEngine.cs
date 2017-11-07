namespace FourFlagsRPG.Models.Contracts.Items
{
    using System.Collections.Generic;

    public interface IGameEngine
    {
        int NumberOfItems { get; }

        int NumberOfEnemies { get; }

        bool IsRunning { get; set; }

        IEnumerable<IGameItem> Items { get; }

        void AddItem(IGameItem itemToBeAdded);

        void RemoveItem(IGameItem itemToBeRemoved);

        void Run();
    }
}