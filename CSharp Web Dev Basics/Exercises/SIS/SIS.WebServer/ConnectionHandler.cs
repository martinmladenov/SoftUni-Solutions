namespace SIS.WebServer
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Api;
    using HTTP.Cookies;
    using HTTP.Enums;
    using HTTP.Exceptions;
    using HTTP.Requests;
    using HTTP.Responses;
    using HTTP.Sessions;
    using Results;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IHttpHandler[] handlers;

        public ConnectionHandler(Socket client, params IHttpHandler[] handlers)
        {
            this.client = client;
            this.handlers = handlers;
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();

            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int bytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (bytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, bytesRead);
                result.Append(bytesAsString);

                if (bytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            foreach (var handler in this.handlers)
            {
                var response = handler.Handle(httpRequest);

                if (response != null)
                {
                    return response;
                }
            }

            return new HtmlResult("<h1>404 Not Found</h1>", HttpResponseStatusCode.NotFound);
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId;

            if (httpRequest.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
            }

            httpRequest.Session = HttpSessionStorage.GetSession(sessionId);

            return sessionId;
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();

            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            try
            {
                var httpRequest = await this.ReadRequest();

                if (httpRequest != null)
                {
                    string sessionId = this.SetRequestSession(httpRequest);

                    var httpResponse = this.HandleRequest(httpRequest);

                    this.SetResponseSession(httpResponse, sessionId);

                    await this.PrepareResponse(httpResponse);
                }
            }
            catch (BadRequestException e)
            {
                await this.PrepareResponse(new HtmlResult($"<h1>400 Bad Request</h1><p>{e.Message}</p>",
                    HttpResponseStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                await this.PrepareResponse(new HtmlResult($"<h1>500 Internal Server Error</h1><p>{e.Message}</p>",
                    HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if (sessionId != null)
            {
                httpResponse.Cookies.Add(new HttpCookie(HttpSessionStorage.SessionCookieKey, sessionId));
            }
        }
    }
}