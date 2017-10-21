namespace _9.Book_Library
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class BookLibrary
    {
        public static void Main()
        {
            var library = new Library();
            var input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            for (int i = 1; i <= n; i++)
                library.Books.Add(new Book(input[i]));
            var authors = library.Books
                .GroupBy(book => book.Author)
                .Select(s => s.Key);
            var output = new List<string>();
            foreach (var author in authors
                .OrderByDescending(a => library.Books
                    .Where(book => book.Author == a)
                    .Sum(book => book.Price))
                .ThenBy(a => a))
            {
                double sum = library.Books
                    .Where(book => book.Author == author)
                    .Sum(book => book.Price);
                output.Add($"{author} -> {sum:f2}");
            }
            File.WriteAllLines("output.txt", output);
        }
    }

    public class Book
    {
        public string Title, Author, Publisher, ReleaseDate, Isbn;
        public double Price;

        public Book(string input)
        {
            var split = input.Split();
            Title = split[0];
            Author = split[1];
            Publisher = split[2];
            ReleaseDate = split[3];
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
