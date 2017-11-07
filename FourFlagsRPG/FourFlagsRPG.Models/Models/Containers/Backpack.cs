namespace FourFlagsRPG.Models.Models.Containers
{
    using FourFlagsRPG.Models.Contracts.IO;
    using FourFlagsRPG.Models.Contracts.Items;
    using FourFlagsRPG.Models.Models.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Backpack : IContainer
    {
        private const int BackPackSlots = 15;
        private const string BackpackIsEmpty = "Invalid operation. Your backpack is empty!";
        private const string BackpackIsFull = "Your backpack is full!";
        public const string EmptySlots = "Empty slots: {0}";

        private IWriter writer;
        private readonly List<ISlot> slotList;

        public Backpack()
        {
            this.writer = new ConsoleWriter();
            this.slotList = new List<ISlot>();

            for (int i = 0; i < BackPackSlots; i++)
            {
                this.slotList.Add(new Slot());
            }
        }

        public IEnumerable<ISlot> SlotList
        {
            get { return this.slotList; }
        }

        public void LootItem(IItem itemToBeLooted)
        {
            ISlot emptySlot = this.SlotList.FirstOrDefault(x => x.IsEmpty);

            if (emptySlot == null)
            {
                this.RemoveLastItemInternal();
            }

            emptySlot.Item = itemToBeLooted;
            emptySlot.IsEmpty = false;
        }

        public void RemoveItem(ISlot slot)
        {
            slot.Item = null;
            slot.IsEmpty = true;
        }

        public void RemoveLastItem()
        {
            this.RemoveLastItemInternal();
        }

        public void ListItems()
        {
            IEnumerable<ISlot> fullSlots = this.SlotList.Where(x => !x.IsEmpty);

            foreach (ISlot currentSlot in fullSlots)
            {
                this.writer.WriteLine(currentSlot.Item.ToString());
            }

            this.writer.WriteLine(string.Format(EmptySlots, this.SlotList.Count() - fullSlots.Count()));
        }

        private void RemoveLastItemInternal()
        {
            int indexOfElemenToRemove = slotList.IndexOf(slotList.FirstOrDefault(slot => slot.IsEmpty)) - 1;

            if (indexOfElemenToRemove == -1)
            {
                throw new ArgumentException(BackpackIsEmpty);
            }

            if (indexOfElemenToRemove == -2)
            {
                indexOfElemenToRemove = this.slotList.Count - 1;
            }

            this.slotList.RemoveAt(indexOfElemenToRemove);
            this.slotList.Insert(indexOfElemenToRemove, new Slot());
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (ISlot slot in this.slotList.Where(s => !s.IsEmpty).ToArray())
            {
                result.AppendLine(slot.Item.ToString());
            }

            result.AppendLine(string.Format(EmptySlots, this.SlotList.Count(s => s.IsEmpty)));

            return result.ToString().Trim();
        }
    }
}