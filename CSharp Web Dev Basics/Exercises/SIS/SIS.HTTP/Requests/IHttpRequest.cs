namespace SIS.HTTP.Requests
{
    using System.Collections.Generic;
    using Enums;
    using Headers;

    public interface IHttpRequest
    {
        string Path { get; }
        
        string Url { get; }
        
        Dictionary<string, object> FormData { get; }
        
        Dictionary<string, object> QueryData { get; }
        
        IHttpHeaderCollection Headers { get; }
        
        HttpRequestMethod RequestMethod { get; }
    }
}