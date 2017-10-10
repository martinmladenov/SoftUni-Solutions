namespace _04.Split_by_Word_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(new[]
                { ',', ';', ':', '.', '!', '(', ')',
                '"', '\'', '\\', '/', '[', ']', ' '},
        StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
            var lowerCase = new List<string>();
            var mixedCase = new List<string>();
            var upperCase = new List<string>();
            foreach (var s in arr)
            {
                if (s.Any(c => c < 'A' || c > 'Z' && c < 'a' || c > 'z'))
                {
                    mixedCase.Add(s);
                    continue;
                }
                if (s.ToUpper() == s)
                    upperCase.Add(s);
                else if (s.ToLower() == s)
                    lowerCase.Add(s);
                else
                    mixedCase.Add(s);
            }
            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCase));
        }
    }
}
