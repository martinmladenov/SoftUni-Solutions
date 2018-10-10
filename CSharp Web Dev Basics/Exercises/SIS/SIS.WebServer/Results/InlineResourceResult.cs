namespace SIS.WebServer.Results
{
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;

    public class InlineResourceResult : HttpResponse
    {
        public InlineResourceResult(byte[] content, HttpResponseStatusCode statusCode)
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Length", content.Length.ToString()));
            this.Headers.Add(new HttpHeader("Content-Disposition", "inline"));
            this.Content = content;
        }
    }
}