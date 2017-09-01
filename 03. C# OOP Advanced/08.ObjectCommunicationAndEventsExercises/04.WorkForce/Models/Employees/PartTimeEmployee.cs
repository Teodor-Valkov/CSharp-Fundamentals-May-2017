public class PartTimeEmployee : Employee
{
    private const int StandartWorkedHoursPerWeek = 20;

    public PartTimeEmployee(string name)
        : base(name, StandartWorkedHoursPerWeek)
    {
    }
}