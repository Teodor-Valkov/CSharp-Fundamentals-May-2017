public class RaceFactory
{
    public static CasualRace CreateCasualRace(int length, string route, int prizePool)
    {
        return new CasualRace(length, route, prizePool);
    }

    public static DragRace CreateDragRace(int length, string route, int prizePool)
    {
        return new DragRace(length, route, prizePool);
    }

    public static DriftRace CreateDriftRace(int length, string route, int prizePool)
    {
        return new DriftRace(length, route, prizePool);
    }

    public static CircuitRace CreateCircuitRace(int length, string route, int prizePool, int laps)
    {
        return new CircuitRace(length, route, prizePool, laps);
    }

    public static TimeLimitRace CreateTimeLimitRace(int length, string route, int prizePool, int goldTime)
    {
        return new TimeLimitRace(length, route, prizePool, goldTime);
    }
}