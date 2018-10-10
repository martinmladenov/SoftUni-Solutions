namespace SIS.IRunesApp.Controllers
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Data.Models;
    using HTTP.Enums;
    using HTTP.Responses;
    using MvcFramework;
    using MvcFramework.Extensions;
    using MvcFramework.Services;

    public class UsersController : BaseController
    {
        private IHashService hashService;

        public UsersController()
        {
            this.hashService = new HashService();
        }

        [HttpGet("/Users/Login")]
        public IHttpResponse Login()
        {
            if (this.Request.IsLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View("Users/Login");
        }

        [HttpGet("/Users/Register")]
        public IHttpResponse Register()
        {
            if (this.Request.IsLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View("Users/Register");
        }

        [HttpPost("/Users/Login")]
        public IHttpResponse DoLogin()
        {
            if (this.Request.IsLoggedIn())
            {
                return this.Redirect("/");
            }

            var login = (string) this.Request.FormData["login"];
            var password = (string) this.Request.FormData["password"];

            User user = this.Db.Users.FirstOrDefault(u => u.Username.ToLower() == login || u.Email.ToLower() == login);

            if (user == null)
            {
                return this.Error("Invalid login or password", HttpResponseStatusCode.Forbidden);
            }

            var base64Hash = user.Password;

            if (!this.hashService.IsPasswordValid(password, base64Hash))
            {
                return this.Error("Invalid login or password", HttpResponseStatusCode.Forbidden);
            }

            this.Request.Session.AddParameter("username", user.Username);
            return this.Redirect("/");
        }

        [HttpPost("/Users/Register")]
        public IHttpResponse DoRegister()
        {
            if (this.Request.IsLoggedIn())
            {
                return this.Redirect("/");
            }

            var username = (string) this.Request.FormData["username"];
            var password = (string) this.Request.FormData["password"];
            var confirmPassword = (string) this.Request.FormData["confirmPassword"];
            var email = (string) this.Request.FormData["email"];

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(email))
            {
                return this.Error("All fields are required", HttpResponseStatusCode.BadRequest);
            }

            if (!Regex.IsMatch(username, "^[A-Za-z0-9_.-]+$"))
            {
                return this.Error("Username can only contain the following characters: A-Z a-z 0-9 - . _",
                    HttpResponseStatusCode.BadRequest);
            }

            if (password != confirmPassword)
            {
                return this.Error("Passwords do not match", HttpResponseStatusCode.BadRequest);
            }

            if (this.Db.Users.Any(u => u.Username.ToLower() == username))
            {
                return this.Error("Username is already taken", HttpResponseStatusCode.BadRequest);
            }

            if (this.Db.Users.Any(u => u.Email.ToLower() == email))
            {
                return this.Error("An account with this email already exists", HttpResponseStatusCode.BadRequest);
            }

            var base64Hash = this.hashService.HashPassword(password, this.hashService.GenerateSalt());

            User user = new User
            {
                Username = username,
                Email = email,
                Password = base64Hash
            };

            this.Db.Users.Add(user);
            this.Db.SaveChanges();

            this.Request.Session.AddParameter("username", user.Username);
            return this.Redirect("/");
        }

        [HttpGet("/Users/Logout")]
        public IHttpResponse Logout()
        {
            if (this.Request.IsLoggedIn())
            {
                this.Request.Session.RemoveParameter("username");
            }

            return this.Redirect("/");
        }
    }
}