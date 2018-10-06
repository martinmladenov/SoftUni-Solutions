namespace SIS.HTTP.Cookies
{
    using System;
    using System.Text;

    public class HttpCookie
    {
        private const int DefaultExpirationDays = 3;

        public HttpCookie(string key, string value, int expires = DefaultExpirationDays, string path = "/")
            : this(key, value, true, expires, path)
        {
        }

        public HttpCookie(string key, string value, bool isNew, int expires = DefaultExpirationDays, string path = "/", bool httpOnly = true)
        {
            this.Key = key;
            this.Value = value;
            this.IsNew = isNew;
            this.Expires = DateTime.UtcNow.AddDays(expires);
            this.HttpOnly = httpOnly;
            this.Path = path;
        }

        public string Key { get; }

        public string Value { get; }

        public bool HttpOnly { get; }
        
        public string Path { get; }

        public DateTime Expires { get; }

        public bool IsNew { get; }

        public override string ToString()
        {
            var sb = new StringBuilder($"{this.Key}={this.Value}; Expires={this.Expires:R}; Path={this.Path}");
            
            if (this.HttpOnly)
            {
                sb.Append("; HttpOnly");
            }

            return sb.ToString();
        }
    }
}