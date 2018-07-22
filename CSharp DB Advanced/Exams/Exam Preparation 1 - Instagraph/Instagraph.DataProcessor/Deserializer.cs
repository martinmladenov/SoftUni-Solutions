using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Instagraph.Data;
using Instagraph.Models;

namespace Instagraph.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Xml.Serialization;
    using AutoMapper;
    using Dtos.Import;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string InvalidDataMsg = "Error: Invalid data.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var pictureDtos = JsonConvert.DeserializeObject<PictureDto[]>(jsonString);

            var validPictures = new List<Picture>();

            StringBuilder sb = new StringBuilder();

            foreach (var pictureDto in pictureDtos)
            {
                if (!IsValid(pictureDto) ||
                    pictureDto.Size <= 0 ||
                    validPictures.Any(p => p.Path == pictureDto.Path))
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var picture = Mapper.Map<Picture>(pictureDto);

                validPictures.Add(picture);

                sb.AppendLine($"Successfully imported Picture {picture.Path}.");
            }

            context.Pictures.AddRange(validPictures);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var sb = new StringBuilder();

            var validUsers = new List<User>();


            foreach (var userDto in userDtos)
            {
                var picture = context.Pictures
                    .SingleOrDefault(p => p.Path == userDto.ProfilePicture);

                if (!IsValid(userDto) || picture == null)
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var user = Mapper.Map<User>(userDto);

                user.ProfilePicture = picture;

                sb.AppendLine($"Successfully imported User {user.Username}.");

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var userFollowerDtos = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);

            var sb = new StringBuilder();

            var validUserFollowers = new List<UserFollower>();

            foreach (var userFollowerDto in userFollowerDtos)
            {
                var user = context.Users
                    .SingleOrDefault(u => u.Username == userFollowerDto.User);

                var follower = context.Users
                    .SingleOrDefault(u => u.Username == userFollowerDto.Follower);

                if (!IsValid(userFollowerDto) || user == null || follower == null ||
                    validUserFollowers.Any(v => v.User == user && v.Follower == follower))
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var userFollower = new UserFollower
                {
                    User = user,
                    Follower = follower
                };

                validUserFollowers.Add(userFollower);

                sb.AppendLine($"Successfully imported Follower {follower.Username} to User {user.Username}.");
            }

            context.UsersFollowers.AddRange(validUserFollowers);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(PostDto[]), new XmlRootAttribute("posts"));
            var postDtos = (PostDto[]) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validPosts = new List<Post>();

            foreach (var postDto in postDtos)
            {
                var user = context.Users
                    .SingleOrDefault(u => u.Username == postDto.User);

                var picture = context.Pictures
                    .SingleOrDefault(p => p.Path == postDto.Picture);

                if (!IsValid(postDto) || user == null || picture == null)
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var post = new Post
                {
                    Caption = postDto.Caption,
                    User = user,
                    Picture = picture
                };

                validPosts.Add(post);

                sb.AppendLine($"Successfully imported Post {post.Caption}.");
            }

            context.Posts.AddRange(validPosts);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CommentDto[]), new XmlRootAttribute("comments"));
            var commentDtos =
                (CommentDto[]) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validComments = new List<Comment>();

            foreach (var commentDto in commentDtos)
            {
                var user = context.Users
                    .SingleOrDefault(u => u.Username == commentDto.User);


                if (!IsValid(commentDto) || user == null)
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var post = context.Posts.Find(commentDto.Post.Id);

                if (post == null)
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var comment = new Comment
                {
                    Content = commentDto.Content,
                    User = user,
                    Post = post
                };

                validComments.Add(comment);

                sb.AppendLine($"Successfully imported Comment {comment.Content}.");
            }

            context.Comments.AddRange(validComments);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj), new List<ValidationResult>(), true);
        }
    }
}