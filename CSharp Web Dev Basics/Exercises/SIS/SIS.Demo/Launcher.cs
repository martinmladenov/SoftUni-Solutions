namespace SIS.Demo
{
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;

    public static class Launcher
    {
        public static void Main()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request); 
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/SetData"] = request => new HomeController().SetData(request);

            
            Server server = new Server(8000, serverRoutingTable);
            
            server.Run();
        }
    }
}