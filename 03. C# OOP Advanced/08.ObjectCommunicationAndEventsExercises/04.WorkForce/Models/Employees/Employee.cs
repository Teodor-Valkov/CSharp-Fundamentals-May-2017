public class Employee : IEmployee
{
    protected Employee(string name, int workedHoursPerWeek)
    {
        this.Name = name;
        this.WorkedHoursPerWeek = workedHoursPerWeek;
    }

    public string Name { get; private set; }

    public int WorkedHoursPerWeek { get; private set; }
}