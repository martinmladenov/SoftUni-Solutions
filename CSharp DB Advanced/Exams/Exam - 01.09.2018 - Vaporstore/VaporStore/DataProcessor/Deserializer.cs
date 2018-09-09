namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Dtos.Import;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<GameDto[]>(jsonString);

            List<Game> validGames = new List<Game>();
            
            List<Developer> devs = new List<Developer>();
            
            List<Genre> genres = new List<Genre>();
            
            List<Tag> tags = new List<Tag>();

            StringBuilder sb = new StringBuilder();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Developer developer = devs
                    .FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    devs.Add(developer);
                }

                DateTime releaseDate = DateTime.ParseExact(gameDto.ReleaseDate,
                    "yyyy-MM-dd", CultureInfo.InvariantCulture);

                Genre genre = genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);
                }

                List<GameTag> gameTags = new List<GameTag>();

                foreach (var tagName in gameDto.Tags)
                {
                    Tag tag = tags
                        .FirstOrDefault(d => d.Name == tagName);

                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };

                        tags.Add(tag);
                    }

                    gameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
                }

                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    Developer = developer,
                    Genre = genre,
                    ReleaseDate = releaseDate,
                    GameTags = gameTags
                };

                validGames.Add(game);

                sb.AppendLine($"Added {gameDto.Name} ({gameDto.Genre}) with {gameTags.Count} tags");
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var validUsers = new List<User>();
            
            StringBuilder sb = new StringBuilder();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto) || userDto.Cards.Length == 0 
                                      || userDto.Cards.Any(c => !IsValid(c)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = Mapper.Map<User>(userDto);

                validUsers.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }
            
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(PurchaseDto[]),
                new XmlRootAttribute("Purchases"));

            var purchaseDtos = (PurchaseDto[])serializer.Deserialize(
                new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            
            List<Purchase> validPurchases = new List<Purchase>();
            
            StringBuilder sb = new StringBuilder();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game game = context.Games
                    .SingleOrDefault(g => g.Name == purchaseDto.Title);

                Card card = context.Cards
                        .Where(c => c.Number == purchaseDto.Card)
                        .Include(c => c.User)
                        .SingleOrDefault();
                
                if (game == null || card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime dateTime = DateTime.ParseExact(purchaseDto.Date,
                    "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                PurchaseType type = Enum.Parse<PurchaseType>(purchaseDto.Type);

                Purchase purchase = new Purchase
                {
                    Game = game,
                    Card = card,
                    ProductKey = purchaseDto.Key,
                    Date = dateTime,
                    Type = type
                };
                
                validPurchases.Add(purchase);

                sb.AppendLine($"Imported {purchaseDto.Title} for {card.User.Username}");
            }
            
            context.Purchases.AddRange(validPurchases);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj), new List<ValidationResult>(), true);
        }
    }
}