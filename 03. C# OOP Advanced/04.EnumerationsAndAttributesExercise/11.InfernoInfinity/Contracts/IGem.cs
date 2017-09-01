public interface IGem
{
    int Strength { get; }

    int Agility { get; }

    int Vitality { get; }

    ClarityLevel ClarityLevel { get; }

    void ModifyStats();
}