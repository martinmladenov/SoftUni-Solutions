namespace _06.Sum_big_numbers
{
    using System;
    using System.Linq;
    using System.Text;

    public class SumBigNumbers
    {
        public static void Main()
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            if (s1.Length < s2.Length)
                s1 = new string('0', s2.Length - s1.Length) + s1;
            else if (s1.Length > s2.Length)
                s2 = new string('0', s1.Length - s2.Length) + s2;
            var sb = new StringBuilder();
            int over = 0;
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                int next = over + s2[i] + s1[i] - 2 * '0';
                over = next / 10;
                next %= 10;
                sb.Append(next);
            }
            sb.Append(over);
            string result = new string(sb.ToString().TrimEnd('0').Reverse().ToArray());
            Console.WriteLine(result.Length > 0 ? result : "0");
        }
    }
}
