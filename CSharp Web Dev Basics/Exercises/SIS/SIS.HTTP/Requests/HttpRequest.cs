namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Common;
    using Cookies;
    using Enums;
    using Exceptions;
    using Extensions;
    using Headers;
    using Sessions;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }
        
        public IHttpCookieCollection Cookies { get; }
        
        public IHttpSession Session { get; set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(GlobalConstants.HttpNewLine);

            string[] requestLine = splitRequestContent[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();
            
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private bool IsValidRequestLine(string[] requestLine) =>
            requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment;

        private bool IsValidRequestQueryString(string queryString)
        {
            return !string.IsNullOrEmpty(queryString);
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var valid = Enum.TryParse(requestLine[0].Capitalize(),
                out HttpRequestMethod httpRequestMethod);

            if (!valid)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = httpRequestMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            var questionMarkIndex = this.Url.IndexOf('?');

            this.Path = questionMarkIndex == -1
                ? this.Url
                : this.Url.Substring(0, questionMarkIndex);
        }

        private void ParseHeaders(string[] headerStrings)
        {
            foreach (var headerString in headerStrings)
            {
                if (headerString.Length == 0)
                {
                    break;
                }

                var split = headerString.Split(": ");

                if (split.Length < 2)
                {
                    throw new BadRequestException();
                }
                
                HttpHeader header = new HttpHeader(split[0], split[1]);

                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsHeader("Host"))
            {
                throw new BadRequestException();
            }
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader("Cookie"))
            {
                return;
            }

            var cookieStrings = this.Headers.GetHeader("Cookie").Value.Split("; ");

            foreach (var cookieString in cookieStrings)
            {
                var split = cookieString.Split('=');
                if (split.Length != 2 || this.Cookies.ContainsCookie(split[0]))
                {
                    continue;
                }
                
                this.Cookies.Add(new HttpCookie(split[0], split[1]));
            }
        }

        private void ParseQueryParameters()
        {
            int questionMarkIndex = this.Url.IndexOf('?');

            if (questionMarkIndex == -1)
            {
                return;
            }
            
            string queryString = this.Url.Substring(questionMarkIndex + 1);

            var queries = queryString.Split('&');

            foreach (var query in queries)
            {
                var split = query.Split('=');

                if (split.Length != 2 || this.QueryData.ContainsKey(split[0]))
                {
                    throw new BadRequestException();
                }

                this.QueryData.Add(split[0], WebUtility.UrlDecode(split[1]));
            }
        }

        private void ParseFormDataParameters(string body)
        {
            if (body.Length == 0)
            {
                return;
            }

            var parameters = body.Split('&');

            foreach (var parameter in parameters)
            {
                var split = parameter.Split('=');

                if (split.Length != 2 || this.FormData.ContainsKey(split[0]))
                {
                    throw new BadRequestException();
                }

                this.FormData.Add(split[0], WebUtility.UrlDecode(split[1]));
            }
        }

        private void ParseRequestParameters(string body)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(body);
        }
    }
}