using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();

        IFactory factory = new Factory();
        IRepository heroRepository = new HeroRepository(new Dictionary<string, IHero>());

        IHeroManager heroManager = new HeroManager(factory, heroRepository);

        IEngine engine = new Engine(reader, writer, heroManager);
        engine.Run();
    }
}