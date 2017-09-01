namespace _01.Kermen.Models
{
    public class OldCouple : Couple
    {
        private const int NumberOfRooms = 3;
        private const decimal RoomElectricity = 15;

        private decimal stoveConsumption;

        public OldCouple(decimal firstPension, decimal secondPension, decimal tvConsumption, decimal fridgeConsumption, decimal stoveConsumption)
            : base(firstPension + secondPension, tvConsumption, fridgeConsumption, NumberOfRooms, RoomElectricity)
        {
            this.stoveConsumption = stoveConsumption;
        }

        public override decimal Consumption
        {
            get
            {
                return this.stoveConsumption + base.Consumption;
            }
        }
    }
}