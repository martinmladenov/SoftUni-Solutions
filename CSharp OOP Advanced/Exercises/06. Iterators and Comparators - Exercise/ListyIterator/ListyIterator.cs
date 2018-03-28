namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(IEnumerable<T> elements)
        {
            this.list = new List<T>(elements);
            this.index = 0;
        }

        public bool HasNext => index + 1 < list.Count;

        public bool Move()
        {
            if (!HasNext)
            {
                return false;
            }

            index++;
            return true;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in list)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
