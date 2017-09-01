public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IArmyy army = new Army();
        IWare wareHouse = new WareHouse();

        ISoldierFactory soldierFactory = new SoldierFactory();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IMissionFactory missionFactory = new MissionFactory();

        IGameController gameController = new GameController(army, wareHouse, soldierFactory, ammunitionFactory, missionFactory);

        IEngine engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}