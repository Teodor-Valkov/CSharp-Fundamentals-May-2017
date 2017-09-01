public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        ISoldierFactory soldierFactory = new SoldierFactory();
        IMissionFactory missionFactory = new MissionFactory();

        IArmy army = new Army();
        IWareHouse warehouse = new WareHouse();
        IMissionController missionController = new MissionController(army, warehouse);

        IGameController gameController = new GameController(army, warehouse, writer, soldierFactory, missionFactory, missionController);

        IEngine engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}