namespace BookShop
{
    using System;

    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            Author = author;
            Title = title;
            Price = price;
        }

        public string Author
        {
            get => author;
            set
            {
                var split = value.Split();
                if (split.Length > 1 && char.IsDigit(split[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                author = value;
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                title = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: Book{Environment.NewLine}{GetBookInfo()}";

        }

        protected string GetBookInfo()
        {
            return $"Title: {Title}{Environment.NewLine}" +
                   $"Author: {Author}{Environment.NewLine}" +
                   $"Price: {Price:f2}";
        }
    }
}