public class Medium : Mission
{
    private const string NameConst = "Capturing dangerous criminals";
    private const double EnduranceRequiredConst = 50;
    private const double WearLevelDecrementConst = 50;

    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    {
        this.Name = NameConst;
        this.EnduranceRequired = EnduranceRequiredConst;
        this.WearLevelDecrement = WearLevelDecrementConst;
    }
}