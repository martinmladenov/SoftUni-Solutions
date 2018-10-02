namespace SIS.HTTP.Cookies
{
    using System;

    public class HttpCookie
    {
        private const int DefaultExpirationDays = 3;

        public HttpCookie(string key, string value, int expires = DefaultExpirationDays)
            : this(key, value, true, expires)
        {
        }

        public HttpCookie(string key, string value, bool isNew, int expires = DefaultExpirationDays)
        {
            this.Key = key;
            this.Value = value;
            this.IsNew = isNew;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; }

        public bool IsNew { get; }

        public override string ToString()
            => $"{this.Key}={this.Value}; Expires={this.Expires:R}";
    }
}