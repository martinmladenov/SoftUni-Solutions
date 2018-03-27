using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        Title = title;
        Year = year;
        Authors = new List<string>(authors);
    }

    public string Title { get; }
    public int Year { get; }
    public List<string> Authors { get; }

    public int CompareTo(Book other)
    {
        int cmp = this.Year.CompareTo(other.Year);

        if (cmp == 0)
        {
            cmp = this.Title.CompareTo(other.Title);
        }

        return cmp;
    }

    public override string ToString()
    {
        return $"{Title} - {Year}";
    }
}
