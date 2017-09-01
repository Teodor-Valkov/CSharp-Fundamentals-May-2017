namespace _01.Kermen.Models
{
    using System.Linq;

    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 30;

        private Child[] children;

        public YoungCoupleWithChildren(decimal firstSalary, decimal secondSalary, decimal tvConsumption, decimal fridgeConsumption, decimal laptopConsumption, Child[] children)
            : base(firstSalary + secondSalary, tvConsumption, fridgeConsumption, laptopConsumption, NumberOfRooms, RoomElectricity)
        {
            this.children = children;
        }

        public override int Population
        {
            get
            {
                return this.children.Length + base.Population;
            }
        }

        public override decimal Consumption
        {
            get
            {
                return this.children.Sum(child => child.GetTotalConsumption()) + base.Consumption;
            }
        }
    }
}