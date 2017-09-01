public class PartTimeEmploee : Employee
{
    private const int WorkHoursPerWeek = 20;

    public PartTimeEmploee(string name)
        : base(name, WorkHoursPerWeek)
    {
    }
}