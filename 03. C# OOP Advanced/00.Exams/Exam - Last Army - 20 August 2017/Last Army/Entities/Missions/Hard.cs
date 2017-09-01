public class Hard : Mission
{
    private const string NameConst = "Disposal of terrorists";
    private const double EnduranceRequiredConst = 80;
    private const double WearLevelDecrementConst = 70;

    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    {
        this.Name = NameConst;
        this.EnduranceRequired = EnduranceRequiredConst;
        this.WearLevelDecrement = WearLevelDecrementConst;
    }
}