namespace SIS.HTTP.Headers
{
    using System.Collections.Generic;

    public interface IHttpHeaderCollection : IEnumerable<HttpHeader>
    {
        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}