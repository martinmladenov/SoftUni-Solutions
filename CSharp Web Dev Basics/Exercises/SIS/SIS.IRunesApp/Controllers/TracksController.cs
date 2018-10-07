namespace SIS.IRunesApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data.Models;
    using Extensions;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using Microsoft.EntityFrameworkCore;

    public class TracksController : BaseController
    {
        public IHttpResponse Create(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!request.QueryData.ContainsKey("albumId"))
            {
                return this.Error("No album id specified", HttpResponseStatusCode.BadRequest, request);
            }

            var albumId = (string) request.QueryData["albumId"];

            if (!this.Db.Albums.Any(a => a.Id == albumId))
            {
                return this.Error("Album not found", HttpResponseStatusCode.NotFound, request);
            }

            var viewBag = new Dictionary<string, string>
            {
                {"AlbumId", albumId}
            };

            return this.View("Tracks/Create", request, viewBag);
        }

        public IHttpResponse DoCreate(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!request.QueryData.ContainsKey("albumId"))
            {
                return this.Error("No album id specified", HttpResponseStatusCode.BadRequest, request);
            }

            string name = (string) request.FormData["name"];
            string link = (string) request.FormData["link"];
            string priceStr = (string) request.FormData["price"];

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(link) ||
                string.IsNullOrWhiteSpace(priceStr))
            {
                return this.Error("Name, link and price cannot be empty", HttpResponseStatusCode.BadRequest, request);
            }

            if (!decimal.TryParse(priceStr, out decimal price))
            {
                return this.Error("Invalid price", HttpResponseStatusCode.BadRequest, request);
            }

            var albumId = (string) request.QueryData["albumId"];

            Album album = this.Db.Albums.FirstOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                return this.Error("Album not found", HttpResponseStatusCode.NotFound, request);
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

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!request.QueryData.ContainsKey("id"))
            {
                return this.Error("No track id specified", HttpResponseStatusCode.BadRequest, request);
            }

            var trackId = (string) request.QueryData["id"];

            Track track = this.Db.Tracks.Include(t => t.Album).FirstOrDefault(a => a.Id == trackId);

            if (track == null)
            {
                return this.Error("Track not found", HttpResponseStatusCode.NotFound, request);
            }

            var viewBag = new Dictionary<string, string>
            {
                {"Name", track.Name},
                {"Link", track.Link},
                {"AlbumId", track.AlbumId},
                {"Price", track.Price.ToString("F2")},
                {"AlbumName", track.Album.Name}
            };

            return this.View("Tracks/Details", request, viewBag);
        }
    }
}