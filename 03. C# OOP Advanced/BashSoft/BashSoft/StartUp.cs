namespace BashSoft
{
    using BashSoft.Contracts;
    using IO;
    using Judge;
    using Repository;

    internal class StartUp
    {
        private static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager inputOutputManager = new IOManager();
            IDatabase repository = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            ICommandInterpreter currentInterpreter = new CommandInterpreter(tester, inputOutputManager, repository);
            IEngine engine = new Engine(currentInterpreter);

            engine.Run();
        }
    }
}