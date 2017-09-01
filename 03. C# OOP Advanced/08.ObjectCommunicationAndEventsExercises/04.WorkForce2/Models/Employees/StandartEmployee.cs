public class StandartEmploee : Employee
{
    private const int WorkHoursPerWeek = 40;

    public StandartEmploee(string name)
        : base(name, WorkHoursPerWeek)
    {
    }
}