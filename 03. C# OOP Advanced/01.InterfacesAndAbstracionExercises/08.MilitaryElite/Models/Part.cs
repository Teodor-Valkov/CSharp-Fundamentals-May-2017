namespace _08.MilitaryElite.Models
{
    using Contracts;

    public class Part : IPart
    {
        public Part(string name, int hoursWorked)
        {
            this.Name = name;
            this.HoursWorked = hoursWorked;
        }

        public string Name { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}