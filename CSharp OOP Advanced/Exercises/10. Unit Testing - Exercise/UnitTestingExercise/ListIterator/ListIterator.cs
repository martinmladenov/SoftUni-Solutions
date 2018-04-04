namespace UnitTestingExercise.ListIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator
    {
        private string[] arr;
        private int currIndex;

        public ListIterator(IEnumerable<string> strings)
        {
            if (strings == null)
            {
                throw new ArgumentNullException();
            }

            arr = strings.ToArray();
            currIndex = 0;
        }

        public bool Move()
        {
            if (!HasNext())
            {
                return false;
            }

            currIndex++;

            return true;
        }

        public bool HasNext()
        {
            return currIndex < arr.Length - 1;
        }

        public void Print()
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(arr[currIndex]);
        }
    }
}
