namespace SIS.HTTP.Headers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key) =>
            this.headers.ContainsKey(key);

        public HttpHeader GetHeader(string key)
        {
            var found = this.headers.TryGetValue(key, out HttpHeader header);

            if (!found)
            {
                return null;
            }

            return header;
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}