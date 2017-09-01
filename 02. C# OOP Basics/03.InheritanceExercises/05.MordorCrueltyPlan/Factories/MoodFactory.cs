public class MoodFactory
{
    public Mood CreateMood(int points)
    {
        if (points < -5)
        {
            return new Angry();
        }

        if (points >= -5 && points < 0)
        {
            return new Sad();
        }

        if (points >= 0 && points < 15)
        {
            return new Happy();
        }

        return new JavaScript();
    }
}