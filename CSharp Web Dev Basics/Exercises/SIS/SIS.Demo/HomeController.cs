namespace SIS.Demo
{
    using System;
    using System.Threading;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello, World!</h1>";

            content += $"<p>Start: {DateTime.Now:hh:mm:ss.fff}</p>";
            
            Thread.Sleep(5000);
            
            content += $"<p>End:   {DateTime.Now:hh:mm:ss.fff}</p>";

            //if (request.Cookies.ContainsCookie("kluch"))
            //    content += $"<p>kluch: {request.Cookies.GetCookie("kluch").Value}</p>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse SetCookies(IHttpRequest request)
        {
            RedirectResult result = new RedirectResult("/");
            //result.Cookies.Add(new HttpCookie("kluch", "stoinost"));
            return result;
        }
    }
}