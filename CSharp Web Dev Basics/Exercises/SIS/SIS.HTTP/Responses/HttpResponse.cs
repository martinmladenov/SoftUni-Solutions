namespace SIS.HTTP.Responses
{
    using System.Linq;
    using System.Text;
    using Common;
    using Cookies;
    using Enums;
    using Extensions;
    using Headers;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public byte[] Content { get; set; }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
            this.Cookies = new HttpCookieCollection();
        }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers)
                .Append(GlobalConstants.HttpNewLine);

            foreach (var cookie in this.Cookies)
            {
                result.Append($"Set-Cookie: {cookie}{GlobalConstants.HttpNewLine}");
            }

            result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}