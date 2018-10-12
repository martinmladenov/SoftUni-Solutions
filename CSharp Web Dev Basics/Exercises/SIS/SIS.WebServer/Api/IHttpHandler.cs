namespace SIS.WebServer.Api
{
    using HTTP.Requests;
    using HTTP.Responses;

    public interface IHttpHandler
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}