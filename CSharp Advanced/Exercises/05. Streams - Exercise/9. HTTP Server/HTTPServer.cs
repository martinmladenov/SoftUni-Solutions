namespace _9._HTTP_Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HttpServer
    {
        public static void Main()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 8080);
            tcpListener.Start();

            while (true)
            {
                using (var stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] requestBytes = new byte[4096];
                    stream.Read(requestBytes, 0, 4096);
                    string request = Encoding.UTF8.GetString(requestBytes);

                    string url = request.Split()[1];

                    string response;
                    switch (url)
                    {
                        case "/":
                            response = "HTTP/1.1 200 OK\nContent-Type:text\n\n" +
                                       "<!doctype html>\n" +
                                       "<html>\n" +
                                       "<head>\n" +
                                       "<title> Home Page </title>\n" +
                                       "</head>\n" +
                                       "<body>\n" +
                                       "<h1>Welcome to our test page.</h1>\n" +
                                       "<h4>You can check the server information <a href=\"/info\">here</a></h4>\n" +
                                       "<h5>Congratulations for creating your first web app :)</h5>\n" +
                                       "</body>\n" +
                                       "</html>\n";
                            break;
                        case "/info":
                            response = "HTTP/1.1 200 OK\nContent-Type:text\n\n" +
                                       "<!doctype html>" +
                                       "<html>" +
                                       "<head>" +
                                       "<title>Info Page</title>" +
                                       "</head>" +
                                       "<body>" +
                                       $"<h2>Current Time: {DateTime.Now.Hour:d2}:{DateTime.Now.Minute:d2}:{DateTime.Now.Second:d2}.{DateTime.Now.Millisecond:d3}</h2>" +
                                       $"<h2>Logical Processors: {Environment.ProcessorCount}<h2>" +
                                       "</body>" +
                                       "</html>";
                            break;
                        default:
                            response = "HTTP/1.1 200 OK\nContent-Type:text\n\n" +
                                       "<!doctype html>" +
                                       "<html>" +
                                       "<head>" +
                                       "<title>Error Page</title>" +
                                       "</head>" +
                                       "<body>" +
                                       "<h2 style=\"color:red\">Error! Try going to the <a href=\" / \">home page</a></h2>" +
                                       "</body>" +
                                       "</html>";
                            break;
                    }
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }

        }
    }
}
