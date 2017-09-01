namespace _01.Kermen.Models
{
    public class YoungCouple : Couple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 20;

        private decimal laptopConsumption;

        public YoungCouple(decimal firstSalary, decimal secondSalary, decimal tvConsumption, decimal fridgeConsumption, decimal laptopConsumption)
            : base(firstSalary + secondSalary, tvConsumption, fridgeConsumption, NumberOfRooms, RoomElectricity)
        {
            this.laptopConsumption = laptopConsumption;
        }

        protected YoungCouple(decimal income, decimal tvConsumption, decimal fridgeConsumption, decimal laptopConsumption, int numberOfRooms, decimal roomElectricity)
            : base(income, tvConsumption, fridgeConsumption, numberOfRooms, roomElectricity)
        {
            this.laptopConsumption = laptopConsumption;
        }

        public override decimal Consumption
        {
            get
            {
                return this.laptopConsumption * 2 + base.Consumption;
            }
        }
    }
}