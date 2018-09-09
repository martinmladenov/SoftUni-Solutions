namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Data.Models;
    using Dtos.Export;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .Include(g => g.Games)
                .ThenInclude(g => g.Developer)
                .Include(g => g.Games)
                .ThenInclude(g => g.GameTags)
                .ThenInclude(t => t.Tag)
                .Include(g => g.Games)
                .ThenInclude(g => g.Purchases)
                .ToArray()
                .Select(genre => new
                {
                    genre.Id,
                    Genre = genre.Name,
                    Games = genre.Games
                        .Where(game => game.Purchases.Any())
                        .Select(game => new
                        {
                            game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name)),
                            Players = game.Purchases.Count
                        })
                        .OrderByDescending(game => game.Players)
                        .ToArray(),
                    TotalPlayers = genre.Games.Sum(game => game.Purchases.Count)
                })
                .OrderByDescending(genre => genre.TotalPlayers)
                .ThenBy(genre => genre.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var type = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Include(u => u.Cards)
                .ThenInclude(c => c.Purchases)
                .ThenInclude(p => p.Game)
                .ThenInclude(g => g.Genre)
                .ToArray()
                .Select(user => new UserDto
                {
                    Username = user.Username,
                    Purchases = user.Cards
                        .SelectMany(card => card.Purchases)
                        .Where(p => p.Type == type)
                        .OrderBy(p => p.Date)
                        .Select(purchase => new PurchaseDto
                        {
                            Card = purchase.Card.Number,
                            Cvc = purchase.Card.Cvc,
                            Date = purchase.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameDto
                            {
                                Title = purchase.Game.Name,
                                Genre = purchase.Game.Genre.Name,
                                Price = purchase.Game.Price
                            }
                        })
                        .ToArray(),
                    TotalSpent = user.Cards.Sum(c => c.Purchases
                        .Where(p => p.Type == type)
                        .Sum(p => p.Game.Price))
                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(users.GetType(), new XmlRootAttribute("Users"));

            serializer.Serialize(new StringWriter(sb), users,
                new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty}));

            return sb.ToString();
        }
    }
}