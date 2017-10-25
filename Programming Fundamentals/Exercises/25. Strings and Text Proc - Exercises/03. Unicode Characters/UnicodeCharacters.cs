namespace _03.Unicode_Characters
{
    using System;
    using System.Text;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            string str = Console.ReadLine();
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                sb.Append($@"\u{(int)c:x4}");
            }
            Console.WriteLine(sb);
        }
    }
}
