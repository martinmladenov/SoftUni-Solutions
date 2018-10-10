namespace SIS.MvcFramework
{
    using System.Collections.Generic;
    using System.IO;
    using Extensions;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using WebServer.Results;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Response = new HttpResponse(HttpResponseStatusCode.Ok);
        }

        public IHttpRequest Request { get; set; }

        public IHttpResponse Response { get; set; }

        protected IHttpResponse View(string viewName, IDictionary<string, string> viewBag = null)
        {
            if (viewBag == null)
            {
                viewBag = new Dictionary<string, string>();
            }

            var allContent = this.GetViewContent(viewName, viewBag);
            return new HtmlResult(allContent, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse Redirect(string location)
        {
            return new RedirectResult(location);
        }

        protected IHttpResponse Error(string errorMessage, HttpResponseStatusCode statusCode)
        {
            var viewBag = new Dictionary<string, string>
            {
                {"Error", errorMessage}
            };
            var allContent = this.GetViewContent("Error", viewBag);

            return new HtmlResult(allContent, statusCode);
        }

        private string GetViewContent(string viewName,
            IDictionary<string, string> viewBag)
        {
            var layoutContent = File.ReadAllText("Views/_Layout.html");
            var content = File.ReadAllText("Views/" + viewName + ".html");
            var allContent = layoutContent.Replace("@RenderBody()", content);

            allContent = allContent.Replace("@Model.Navigation", this.GetNavigation());

            foreach (var item in viewBag)
            {
                allContent = allContent.Replace("@Model." + item.Key, item.Value);
            }

            return allContent;
        }

        private string GetNavigation()
        {
            var fileName = this.Request.IsLoggedIn()
                ? "NavigationLoggedIn"
                : "NavigationLoggedOut";

            return File.ReadAllText("Views/Navigation/" + fileName + ".html");
        }

        protected string GetTemplate(string templateName, IDictionary<string, string> viewBag)
        {
            var content = File.ReadAllText("Views/Templates/" + templateName + ".html");

            foreach (var item in viewBag)
            {
                content = content.Replace("@Model." + item.Key, item.Value);
            }

            return content;
        }
    }
}