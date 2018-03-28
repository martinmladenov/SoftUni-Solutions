namespace StrategyPattern
{
    using System.Collections.Generic;

    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int cmp = x.Name.Length.CompareTo(y.Name.Length);
            if (cmp == 0)
            {
                cmp = char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
            }

            return cmp;
        }
    }
}
