using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        int cmp = x.Title.CompareTo(y.Title);

        if (cmp == 0)
        {
            cmp = y.Year.CompareTo(x.Year);
        }

        return cmp;
    }
}
