namespace _05.Short_Words_Sorted
{
    using System;
    using System.Linq;

    public static class ShortWordsSorted
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(", ",
                    Console.ReadLine()
                    .Split(new[]
                    {'.',',',':',';','(',')','[',']',
                        '"','\'','\\','/','!','?',' '},
                        StringSplitOptions.RemoveEmptyEntries)
                    .Where(s => s.Length < 5)
                    .Select(s => s.ToLower())
                    .Distinct()
                    .OrderBy(s => s)
                ));
        }
    }
}
