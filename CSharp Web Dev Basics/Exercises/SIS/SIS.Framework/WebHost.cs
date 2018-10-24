namespace SIS.Framework
{
    using Api;
    using Routers;
    using Services;
    using WebServer;
    using WebServer.Api;

    public static class WebHost
    {
        private const int DefaultHostingPort = 8000;

        public static void Start(IMvcApplication application, int hostingPort = DefaultHostingPort)
        {
            IDependencyContainer container = new DependencyContainer();
            application.ConfigureServices(container);

            IHttpHandler controllerRouter = new ControllerRouter(container);
            IHttpHandler resourceRouter = new ResourceRouter();

            application.Configure();

            WebServer server = new WebServer(hostingPort, controllerRouter, resourceRouter);
            server.Run();
        }
    }
}