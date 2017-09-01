namespace SoftUniInjector
{
    using System.Reflection;
    using Core;
    using Core.RegisteringModules;
    using Repositories;
    using Resources;
    using Services;

    public class StartUp
    {
        public static void Main()
        {
            Container container = new Container(
                typeof(Vars).FullName,
                Assembly.GetEntryAssembly(),
                new ManualRegisteringModule()
                    .Register<ISoftUniRepository, DefaultSoftUniRepository>()
                    .Register<IPaymentsRepository, DefaultPaymentsRepository>()
                    .Register<IUserService, UserService>(),
                new AttributeRegisteringModule(Assembly.GetEntryAssembly())
            );

            IUserService userService = container.Get<IUserService>();
            userService.Rename();
        }
    }
}