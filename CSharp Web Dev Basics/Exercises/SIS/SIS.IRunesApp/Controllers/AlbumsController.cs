namespace SIS.IRunesApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data.Models;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using Microsoft.EntityFrameworkCore;
    using MvcFramework;
    using MvcFramework.Extensions;

    public class AlbumsController : BaseController
    {
        [HttpGet("/Albums/All")]
        public IHttpResponse All()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            StringBuilder sb = new StringBuilder();

            var albums = this.Db.Albums.ToArray();

            if (albums.Length > 0)
            {
                foreach (var album in albums)
                {
                    Dictionary<string, string> templateBag = new Dictionary<string, string>()
                    {
                        {"Id", album.Id},
                        {"Name", album.Name}
                    };

                    sb.AppendLine(this.GetTemplate("AllAlbumsTemplate", templateBag));
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

            return this.View("Albums/All", viewBag);
        }

        [HttpGet("/Albums/Create")]
        public IHttpResponse Create()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View("Albums/Create");
        }

        [HttpPost("/Albums/Create")]
        public IHttpResponse DoCreate()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string name = (string) this.Request.FormData["name"];
            string cover = (string) this.Request.FormData["cover"];

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(cover))
            {
                return this.Error("Name and cover cannot be empty", HttpResponseStatusCode.BadRequest);
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

        [HttpGet("/Albums/Details")]
        public IHttpResponse Details()
        {
            if (!this.Request.IsLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.Request.QueryData.ContainsKey("id"))
            {
                return this.Error("No album id specified", HttpResponseStatusCode.BadRequest);
            }

            var albumId = (string) this.Request.QueryData["id"];

            Album album = this.Db.Albums
                .Include(a => a.Tracks)
                .FirstOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                return this.Error("Album not found", HttpResponseStatusCode.NotFound);
            }

            StringBuilder sb = new StringBuilder();

            var tracks = album.Tracks.ToArray();

            if (tracks.Length > 0)
            {
                foreach (var track in tracks)
                {
                    var templateBag = new Dictionary<string, string>
                    {
                        {"Id", track.Id},
                        {"Name", track.Name}
                    };

                    sb.AppendLine(this.GetTemplate("SongInAlbumTemplate", templateBag));
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

            return this.View("Albums/Details", viewBag);
        }
    }
}