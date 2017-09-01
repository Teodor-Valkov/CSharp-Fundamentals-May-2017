namespace _01.Kermen.Models
{
    public abstract class Couple : Household
    {
        private decimal tvConsumption;
        private decimal fridgeConsumption;

        protected Couple(decimal income, decimal tvConsumption, decimal fridgeConsumption, int numberOfRooms, decimal roomElectricity)
            : base(income, numberOfRooms, roomElectricity)
        {
            this.tvConsumption = tvConsumption;
            this.fridgeConsumption = fridgeConsumption;
        }

        public override int Population
        {
            get
            {
                return 1 + base.Population;
            }
        }

        public override decimal Consumption
        {
            get
            {
                return this.tvConsumption + this.fridgeConsumption + base.Consumption;
            }
        }
    }
}