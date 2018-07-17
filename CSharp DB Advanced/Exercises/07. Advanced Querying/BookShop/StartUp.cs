namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using BookShop.Data;
    using BookShop.Initializer;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(context);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction restriction = Enum.Parse<AgeRestriction>(command, true);

            return string.Join(Environment.NewLine,
                context.Books
                    .Where(x => x.AgeRestriction == restriction)
                    .OrderBy(x => x.Title)
                    .Select(x => x.Title));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            return string.Join(Environment.NewLine,
                context.Books
                    .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                    .OrderBy(x => x.BookId)
                    .Select(x => x.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            return string.Join(Environment.NewLine,
                context.Books
                    .Where(x => x.Price > 40)
                    .OrderByDescending(x => x.Price)
                    .Select(x => $"{x.Title} - ${x.Price:f2}"));
        }

        public static string /*GetBooksNotReleasedIn*/GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            return string.Join(Environment.NewLine,
                context.Books
                    .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                    .OrderBy(x => x.BookId)
                    .Select(x => x.Title));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var list = input.Split().Select(x => x.ToLower()).ToList();

            return string.Join(Environment.NewLine,
                context.Books
                    .Where(x => x.BookCategories.Any(c => list.Contains(c.Category.Name.ToLower())))
                    .OrderBy(x => x.Title)
                    .Select(x => x.Title));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string str)
        {
            DateTime date = DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return string.Join(Environment.NewLine,
                context.Books
                    .Where(x => x.ReleaseDate < date)
                    .OrderByDescending(x => x.ReleaseDate)
                    .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string str)
        {
            return string.Join(Environment.NewLine,
                context.Authors
                    .Where(x => x.FirstName.ToLower().EndsWith(str.ToLower()))
                    .Select(x => $"{x.FirstName} {x.LastName}")
                    .OrderBy(x => x));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine,
               context.Books
                   .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                   .Select(x => x.Title)
                   .OrderBy(x => x));
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine,
                context.Books
                    .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                    .OrderBy(x => x.BookId)
                    .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(x => x.Title.Length > lengthCheck);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            return string.Join(Environment.NewLine,
                context.Authors
                    .Select(x => new
                    {
                        Name = $"{x.FirstName} {x.LastName}",
                        Count = x.Books.Sum(b => b.Copies)
                    })
                    .OrderByDescending(x => x.Count)
                    .Select(x => $"{x.Name} - {x.Count}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            return string.Join(Environment.NewLine,
                context.Categories
                    .Select(x => new
                    {
                        Name = x.Name,
                        Profit = x.CategoryBooks
                            .Sum(b => b.Book.Price * b.Book.Copies)
                    })
                    .OrderByDescending(x => x.Profit)
                    .Select(x => $"{x.Name} ${x.Profit:f2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            return string.Join(Environment.NewLine,
                context.Categories
                    .Select(x => new
                    {
                        Name = x.Name,
                        Books = x.CategoryBooks
                            .OrderByDescending(b => b.Book.ReleaseDate)
                            .Take(3)
                            .Select(b => $"{b.Book.Title} ({b.Book.ReleaseDate.Value.Year})")

                    })
                    .OrderBy(x => x.Name)
                    .Select(x => $"--{x.Name}"
                                 + Environment.NewLine
                                 + string.Join(Environment.NewLine, x.Books)));
        }

        public static void IncreasePrices(BookShopContext context)
        {
            foreach (var book in context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010))
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Length;
        }
    }
}
