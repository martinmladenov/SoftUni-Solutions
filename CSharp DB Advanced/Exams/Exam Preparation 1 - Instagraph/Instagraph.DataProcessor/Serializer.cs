using System;
using Instagraph.Data;

namespace Instagraph.DataProcessor
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Dtos.Export;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .OrderBy(p => p.Id)
                .Select(p => new
                {
                    p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .ToList();

            var json = JsonConvert.SerializeObject(posts, Formatting.Indented);

            return json;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers.Any(f => f.Follower == c.User))))
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    u.Username,
                    Followers = u.Followers.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new UserDto
                {
                    Username = u.Username,
                    MostComments = u.Posts.Any() ? 
                        u.Posts.Max(p => p.Comments.Count)
                        : 0
                })
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToArray();

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), users,
                new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty}));

            return sb.ToString();
        }
    }
}