namespace _01.Kermen.Models
{
    public class AloneYoung : Single
    {
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 10;

        private decimal laptopConsumption;

        public AloneYoung(decimal income, decimal laptopConsumption)
            : base(income, NumberOfRooms, RoomElectricity)
        {
            this.laptopConsumption = laptopConsumption;
        }

        public override decimal Consumption
        {
            get
            {
                return this.laptopConsumption + base.Consumption;
            }
        }
    }
}