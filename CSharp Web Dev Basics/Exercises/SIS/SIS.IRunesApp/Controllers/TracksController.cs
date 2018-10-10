namespace SIS.IRunesApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using HTTP.Enums;
    using HTTP.Responses;
    using MvcFramework;
    using MvcFramework.Extensions;

    public class TracksController : BaseController
    {
        [HttpGet("/Tracks/Create")]
        public IHttpResponse Create()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.Request.QueryData.ContainsKey("albumId"))
            {
                return this.Error("No album id specified", HttpResponseStatusCode.BadRequest);
            }

            var albumId = (string) this.Request.QueryData["albumId"];

            if (!this.Db.Albums.Any(a => a.Id == albumId))
            {
                return this.Error("Album not found", HttpResponseStatusCode.NotFound);
            }

            var viewBag = new Dictionary<string, string>
            {
                {"AlbumId", albumId}
            };

            return this.View("Tracks/Create", viewBag);
        }

        [HttpPost("/Tracks/Create")]
        public IHttpResponse DoCreate()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.Request.QueryData.ContainsKey("albumId"))
            {
                return this.Error("No album id specified", HttpResponseStatusCode.BadRequest);
            }

            string name = (string) this.Request.FormData["name"];
            string link = (string) this.Request.FormData["link"];
            string priceStr = (string) this.Request.FormData["price"];

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(link) ||
                string.IsNullOrWhiteSpace(priceStr))
            {
                return this.Error("Name, link and price cannot be empty", HttpResponseStatusCode.BadRequest);
            }

            if (!decimal.TryParse(priceStr, out decimal price))
            {
                return this.Error("Invalid price", HttpResponseStatusCode.BadRequest);
            }

            var albumId = (string) this.Request.QueryData["albumId"];

            Album album = this.Db.Albums.FirstOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                return this.Error("Album not found", HttpResponseStatusCode.NotFound);
            }

            Track track = new Track
            {
                Name = name,
                Album = album,
                Link = link,
                Price = price
            };

            this.Db.Tracks.Add(track);
            this.Db.SaveChanges();

            return this.Redirect("/Albums/Details?id=" + albumId);
        }

        [HttpGet("/Tracks/Details")]
        public IHttpResponse Details()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.Request.QueryData.ContainsKey("id"))
            {
                return this.Error("No track id specified", HttpResponseStatusCode.BadRequest);
            }

            var albumId = (string) this.Request.QueryData["id"];

            Track track = this.Db.Tracks.FirstOrDefault(a => a.Id == albumId);

            if (track == null)
            {
                return this.Error("Track not found", HttpResponseStatusCode.NotFound);
            }

            var viewBag = new Dictionary<string, string>
            {
                {"Name", track.Name},
                {"Link", track.Link},
                {"AlbumId", track.AlbumId},
                {"Price", track.Price.ToString("F2")}
            };

            return this.View("Tracks/Details", viewBag);
        }
    }
}