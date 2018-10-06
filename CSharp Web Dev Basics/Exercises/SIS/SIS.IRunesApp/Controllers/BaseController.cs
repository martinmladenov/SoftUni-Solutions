namespace SIS.IRunesApp.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using Data;
    using Extensions;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using WebServer.Results;

    public abstract class BaseController
    {
        protected BaseController()
        {
            this.Db = new IRunesDbContext();
        }

        protected IRunesDbContext Db { get; }

        protected IHttpResponse View(string viewName, IHttpRequest request, IDictionary<string, string> viewBag = null)
        {
            if (viewBag == null)
            {
                viewBag = new Dictionary<string, string>();
            }

            var allContent = this.GetViewContent(viewName, viewBag, request);
            return new HtmlResult(allContent, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse Redirect(string location)
        {
            return new RedirectResult(location);
        }

        protected IHttpResponse Error(string errorMessage, HttpResponseStatusCode statusCode, IHttpRequest request)
        {
            var viewBag = new Dictionary<string, string>
            {
                {"Error", errorMessage}
            };
            var allContent = this.GetViewContent("Error", viewBag, request);

            return new HtmlResult(allContent, statusCode);
        }

        private string GetViewContent(string viewName, 
            IDictionary<string, string> viewBag, IHttpRequest request)
        {
            var layoutContent = File.ReadAllText("Views/_Layout.html");
            var content = File.ReadAllText("Views/" + viewName + ".html");
            var allContent = layoutContent.Replace("@RenderBody()", content);

            allContent = allContent.Replace("@Model.Navigation", this.GetNavigation(request));
            
            foreach (var item in viewBag)
            {
                allContent = allContent.Replace("@Model." + item.Key, item.Value);
            }

            return allContent;
        }

        private string GetNavigation(IHttpRequest request)
        {
            var fileName = request.IsLoggedIn()
                ? "NavigationLoggedIn" 
                : "NavigationLoggedOut";

            return File.ReadAllText("Views/Navigation/" + fileName + ".html");
        }

    }
}