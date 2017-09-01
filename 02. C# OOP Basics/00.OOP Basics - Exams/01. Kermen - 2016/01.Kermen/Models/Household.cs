namespace _01.Kermen.Models
{
    public abstract class Household
    {
        private decimal balance;
        private readonly decimal income;
        private int numberOfRooms;
        private decimal roomElectricity;

        protected Household(decimal income, int numberOfRooms, decimal roomElectricity)
        {
            this.balance = 0;
            this.income = income;
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
        }

        public virtual int Population
        {
            get
            {
                return 1;
            }
        }

        public virtual decimal Consumption
        {
            get
            {
                return this.numberOfRooms * this.roomElectricity;
            }
        }

        public void GetIncome()
        {
            this.balance += this.income;
        }

        public bool CanPayBill()
        {
            return this.balance >= this.Consumption;
        }

        public void PayBill()
        {
            this.balance -= this.Consumption;
        }
    }
}