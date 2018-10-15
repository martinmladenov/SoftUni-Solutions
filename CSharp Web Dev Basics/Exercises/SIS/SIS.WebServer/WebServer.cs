namespace SIS.WebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using Api;

    public class WebServer
    {
        private const string LocalhostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IHttpHandler[] handlers;

        private bool isRunning;

        public WebServer(int port, params IHttpHandler[] handlers)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);

            this.handlers = handlers;
        }

        public void Run()
        {
            this.listener.Start();

            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}/");

            this.ListenLoop();
        }

        public void ListenLoop()
        {
            while (this.isRunning)
            {
                var client = this.listener.AcceptSocketAsync().Result;

                Task.Run(() => this.ProcessClientAsync(client));
            }
        }

        public async Task ProcessClientAsync(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.handlers);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}