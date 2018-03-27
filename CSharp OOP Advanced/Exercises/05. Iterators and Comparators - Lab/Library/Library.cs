using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        Books = new List<Book>(books);
    }

    public List<Book> Books { get; }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(Books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public LibraryIterator(List<Book> books)
        {
            //this.books = books.OrderBy(x => x).ToList();

            this.books = books;
            books.Sort(new BookComparator());
            Reset();
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < books.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {
        }

        public Book Current => books[currentIndex];

        object IEnumerator.Current => Current;
    }
}
