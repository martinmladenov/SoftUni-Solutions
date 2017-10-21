namespace _10.BookLibrary_Modification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class BookLibraryModification
    {
        public static void Main()
        {
            var library = new Library();
            var input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            for (int i = 1; i <= n; i++)
                library.Books.Add(new Book(input[i]));
            var after = DateTime.ParseExact(input[n + 1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var output = library.Books
                .Where(book => book.ReleaseDate > after)
                .OrderBy(book => book.ReleaseDate)
                .ThenBy(book => book.Title)
                .Select(book => $"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)}")
                .ToList();
            File.WriteAllLines("output.txt", output);
        }
    }

    public class Book
    {
        public string Title, Author, Publisher, Isbn;
        public DateTime ReleaseDate;
        public double Price;

        public Book(string input)
        {
            var split = input.Split();
            Title = split[0];
            Author = split[1];
            Publisher = split[2];
            ReleaseDate = DateTime.ParseExact(split[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Isbn = split[4];
            Price = double.Parse(split[5]);
        }
    }

    public class Library
    {
        public List<Book> Books;

        public Library()
        {
            Books = new List<Book>();
        }
    }
}
