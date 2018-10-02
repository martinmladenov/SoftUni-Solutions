namespace SIS.HTTP.Cookies
{
    using System.Collections;
    using System.Collections.Generic;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            return this.cookies[key];
        }

        public bool HasCookies()
        {
            return this.cookies.Count > 0;
        }
        
        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}