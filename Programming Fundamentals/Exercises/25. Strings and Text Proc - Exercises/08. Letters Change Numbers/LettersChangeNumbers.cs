namespace _08.Letters_Change_Numbers
{
    using System;

    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var split = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (var s in split)
            {
                double n = int.Parse(s.Substring(1, s.Length - 2));
                char c1 = s[0];
                char c2 = s[s.Length - 1];
                if (c1 >= 'A' && c1 <= 'Z')
                    n /= c1 - 'A' + 1;
                else if (c1 >= 'a' && c1 <= 'z')
                    n *= c1 - 'a' + 1;
                if (c2 >= 'A' && c2 <= 'Z')
                    n -= c2 - 'A' + 1;
                else if (c2 >= 'a' && c2 <= 'z')
                    n += c2 - 'a' + 1;
                sum += n;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
