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

    public class AlbumsController : BaseController
    {
        public IHttpResponse All(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            StringBuilder sb = new StringBuilder();

            var albums = this.Db.Albums.Include(a => a.Tracks).ToArray();

            if (albums.Length > 0)
            {
                foreach (var album in albums)
                {
                    sb.AppendLine($@"
                    <div class=""col-md-4 col-sm-12"" style=""margin-bottom: 25px;"">
                    <div class=""card"">
                    <img class=""card-img-top"" style=""height: 180px; width: 100%; display: block; object-fit: cover;""
                    src=""{album.Cover}"" alt=""{album.Name}"">
                    <div class=""card-body"">
                    <h5 class=""card-title"">{album.Name}</h5>
                    <p class=""card-text"">${album.Price:F2}</p>
                    <a href=""/Albums/Details?id={album.Id}"" class=""btn btn-primary"">View</a>
                    </div>
                    </div>
                    </div>");
                }
            }
            else
            {
                sb.Append("<em>There are currently no albums.</em>");
            }

            var viewBag = new Dictionary<string, string>
            {
                {"Albums", sb.ToString()}
            };

            return this.View("Albums/All", request, viewBag);
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View("Albums/Create", request);
        }

        public IHttpResponse DoCreate(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string name = (string) request.FormData["name"];
            string cover = (string) request.FormData["cover"];

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(cover))
            {
                return this.Error("Name and cover cannot be empty", HttpResponseStatusCode.BadRequest, request);
            }

            Album album = new Album
            {
                Name = name,
                Cover = cover
            };

            this.Db.Albums.Add(album);
            this.Db.SaveChanges();

            return this.Redirect("/Albums/All");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!request.QueryData.ContainsKey("id"))
            {
                return this.Error("No album id specified", HttpResponseStatusCode.BadRequest, request);
            }

            var albumId = (string) request.QueryData["id"];

            Album album = this.Db.Albums
                .Include(a => a.Tracks)
                .FirstOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                return this.Error("Album not found", HttpResponseStatusCode.NotFound, request);
            }

            StringBuilder sb = new StringBuilder();

            if (album.Tracks.ToArray().Length > 0)
            {
                foreach (var track in album.Tracks)
                {
                    sb.AppendLine("<a class=\"list-group-item list-group-item-action\" href=\"/Tracks/Details?" +
                                  $"id={track.Id}\">{track.Name}</a>");
                }
            }
            else
            {
                sb.Append("<em>There are currently no tracks in this album.</em>");
            }

            var viewBag = new Dictionary<string, string>
            {
                {"CoverUrl", album.Cover},
                {"Name", album.Name},
                {"Price", album.Price.ToString("F2")},
                {"Tracks", sb.ToString()},
                {"AlbumId", albumId}
            };

            return this.View("Albums/Details", request, viewBag);
        }
    }
}