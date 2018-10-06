namespace SIS.IRunesApp.Controllers
{
    using System.Collections.Generic;
    using Extensions;
    using HTTP.Requests;
    using HTTP.Responses;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.View("Home/IndexLoggedOut", request);
            }

            var dict = new Dictionary<string, string>
            {
                {"Username", request.GetUsername()}
            };
            return this.View("Home/IndexLoggedIn", request, dict);

        }
    }
}