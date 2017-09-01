public abstract class Food
{
    private int points;

    protected Food(int points)
    {
        this.Points = points;
    }

    public int Points
    {
        get
        {
            return this.points;
        }
        private set
        {
            this.points = value;
        }
    }
}