namespace _01.Reverse_String
{
    using System;
    using System.Text;

    public class ReverseString
    {
        public static void Main()
        {
            string str = Console.ReadLine();
            var sb = new StringBuilder(str.Length);
            for (int i = str.Length - 1; i >= 0; i--)
                sb.Append(str[i]);
            Console.WriteLine(sb.ToString());
        }
    }
}
