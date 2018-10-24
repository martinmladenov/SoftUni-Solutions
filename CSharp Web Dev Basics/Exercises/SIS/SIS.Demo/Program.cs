namespace SIS.Demo
{
    using Framework;
    using Framework.Routers;
    using Framework.Services;
    using Services;
    using Services.Contracts;
    using WebServer;

    public static class Launcher
    {
        public static void Main()
        {
            var dependencyContainer = new DependencyContainer();

            dependencyContainer.RegisterDependency<IUserService, UserService>();
            
            var server = new WebServer(8000, new ControllerRouter(dependencyContainer), new ResourceRouter());
                    
            MvcEngine.Run(server);
        }
    }
}