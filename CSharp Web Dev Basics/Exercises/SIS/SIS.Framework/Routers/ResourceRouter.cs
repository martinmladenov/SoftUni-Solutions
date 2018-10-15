namespace SIS.Framework.Routers
{
    using System.IO;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using WebServer.Api;
    using WebServer.Results;

    public class ResourceRouter : IHttpHandler
    {
        private const string ResourcesFolderName = "Resources";

        public IHttpResponse Handle(IHttpRequest request)
        {
            string path = ResourcesFolderName + '/' + request.Path;

            if (path.Contains("..") || !File.Exists(path))
            {
                return null;
            }

            byte[] content = File.ReadAllBytes(path);

            return new InlineResourceResult(content, HttpResponseStatusCode.Ok);
        }
    }
}