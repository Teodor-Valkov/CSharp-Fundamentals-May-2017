public class Easy : Mission
{
    private const string NameConst = "Suppression of civil rebellion";
    private const double EnduranceRequiredConst = 20;
    private const double WearLevelDecrementConst = 30;

    public Easy(double scoreToComplete)
        : base(scoreToComplete)
    {
        this.Name = NameConst;
        this.EnduranceRequired = EnduranceRequiredConst;
        this.WearLevelDecrement = WearLevelDecrementConst;
    }
}