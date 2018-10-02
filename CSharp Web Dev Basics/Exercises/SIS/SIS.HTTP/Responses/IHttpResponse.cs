namespace SIS.HTTP.Responses
{
    using Cookies;
    using Enums;
    using Headers;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        
        IHttpHeaderCollection Headers { get; }
        
        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}