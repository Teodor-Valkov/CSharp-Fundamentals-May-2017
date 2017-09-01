public class StandartEmployee : Employee
{
    private const int StandartWorkedHoursPerWeek = 40;

    public StandartEmployee(string name)
        : base(name, StandartWorkedHoursPerWeek)
    {
    }
}