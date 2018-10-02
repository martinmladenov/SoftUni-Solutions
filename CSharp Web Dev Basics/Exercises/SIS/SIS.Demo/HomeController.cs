namespace SIS.Demo
{
    using System;
    using System.Text;
    using System.Threading;
    using HTTP.Cookies;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>Hello, World!</h1>");

            sb.AppendLine("<b>Your cookies:</b>");
            sb.AppendLine("<ul>");
            foreach (var cookie in request.Cookies)
            {
                sb.AppendLine($"<li>{cookie.Key} = {cookie.Value}</li>");
            }
            
            sb.AppendLine("</ul>");

            string param = request.Session.ContainsParameter("example")
                ? (string)request.Session.GetParameter("example")
                : "None";
            
            sb.AppendLine($"<b>Your example session parameter: </b> {param}");
            
            
            
            sb.AppendLine("<a href=\"/SetData\">Set Cookies and session parameter</a>");

            return new HtmlResult(sb.ToString(), HttpResponseStatusCode.Ok);
        }

        public IHttpResponse SetData(IHttpRequest request)
        {
            RedirectResult result = new RedirectResult("/");
            result.Cookies.Add(new HttpCookie("cookie1", "value1", 1));
            result.Cookies.Add(new HttpCookie("cookie2", "value2"));
            request.Session.AddParameter("example", "testParamValue");
            return result;
        }
    }
}