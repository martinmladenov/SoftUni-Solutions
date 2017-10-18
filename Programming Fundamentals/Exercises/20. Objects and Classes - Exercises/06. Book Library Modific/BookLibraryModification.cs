namespace _06.Book_Library_Modific
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class BookLibraryModification
    {
        public static void Main()
        {
            var library = new Library();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                library.Books.Add(new Book(Console.ReadLine()));
            var after = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            foreach (var book in library.Books
                .Where(book => book.ReleaseDate > after)
                .OrderBy(book => book.ReleaseDate)
                .ThenBy(book => book.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)}");
            }
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
