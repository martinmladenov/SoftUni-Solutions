namespace SIS.HTTP.Responses
{
    using Enums;
    using Headers;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        
        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}