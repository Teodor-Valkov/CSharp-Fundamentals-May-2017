namespace _01.Kermen.Models
{
    public class AloneOld : Single
    {
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 15;

        private decimal pension;

        public AloneOld(decimal pension)
            : base(pension, NumberOfRooms, RoomElectricity)
        {
            this.pension = pension;
        }
    }
}