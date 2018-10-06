namespace SIS.IRunesApp
{
    using System;
    using Controllers;
    using HTTP.Enums;
    using WebServer;
    using WebServer.Results;
    using WebServer.Routing;

    public static class Launcher
    {
        public static void Main()
        {
            ServerRoutingTable routingTable = new ServerRoutingTable();

            routingTable.Routes[HttpRequestMethod.Get]["/"] = req => new HomeController().Index(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Home/Index"] = req => new RedirectResult("/");
            routingTable.Routes[HttpRequestMethod.Get]["/Users/Login"] = req => new UsersController().Login(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Users/Register"] = req => new UsersController().Register(req);
            routingTable.Routes[HttpRequestMethod.Post]["/Users/Login"] = req => new UsersController().DoLogin(req);
            routingTable.Routes[HttpRequestMethod.Post]["/Users/Register"] =req => new UsersController().DoRegister(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Users/Logout"] = req => new UsersController().Logout(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Albums/All"] = req => new AlbumsController().All(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Albums/Create"] = req => new AlbumsController().Create(req);
            routingTable.Routes[HttpRequestMethod.Post]["/Albums/Create"] = req => new AlbumsController().DoCreate(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Albums/Details"] = req => new AlbumsController().Details(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Tracks/Create"] = req => new TracksController().Create(req);
            routingTable.Routes[HttpRequestMethod.Post]["/Tracks/Create"] = req => new TracksController().DoCreate(req);
            routingTable.Routes[HttpRequestMethod.Get]["/Tracks/Details"] = req => new TracksController().Details(req);

            Server server = new Server(8000, routingTable);

            server.Run();
        }
    }
}