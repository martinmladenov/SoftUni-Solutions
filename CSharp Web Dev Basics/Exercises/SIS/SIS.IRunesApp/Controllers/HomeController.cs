namespace SIS.IRunesApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
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

            Album randomAlbum = this.Db.Albums.OrderBy(a => Guid.NewGuid()).FirstOrDefault();

            var albumCover = string.Empty;

            var albumName = string.Empty;

            var albumId = string.Empty;

            if (randomAlbum != null)
            {
                albumCover = randomAlbum.Cover;
                albumName = randomAlbum.Name;
                albumId = randomAlbum.Id;
            }

            var dict = new Dictionary<string, string>
            {
                {"Username", request.GetUsername()},
                {"AlbumCover", albumCover},
                {"AlbumName", albumName},
                {"AlbumId", albumId}
            };
            return this.View("Home/IndexLoggedIn", request, dict);

        }
    }
}