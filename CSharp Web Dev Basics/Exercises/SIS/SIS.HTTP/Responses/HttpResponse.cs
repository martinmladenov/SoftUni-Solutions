namespace SIS.HTTP.Responses
{
    using System.Linq;
    using System.Text;
    using Common;
    using Enums;
    using Extensions;
    using Headers;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; set; }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
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
                .Append("\r\n") // Environment.NewLine returns only \n on Unix-like systems
                .Append(this.Headers)
                .Append("\r\n")
                .Append("\r\n");

            return result.ToString();
        }
    }
}