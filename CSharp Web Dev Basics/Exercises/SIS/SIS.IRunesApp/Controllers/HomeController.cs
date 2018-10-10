namespace SIS.IRunesApp.Controllers
{
    using System.Collections.Generic;
    using HTTP.Responses;
    using MvcFramework;
    using MvcFramework.Extensions;

    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IHttpResponse Index()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.View("Home/IndexLoggedOut");
            }

            var dict = new Dictionary<string, string>
            {
                {"Username", this.Request.GetUsername()}
            };
            return this.View("Home/IndexLoggedIn", dict);

        }
    }
}