namespace _07.Multiply_big_number
{
    using System;
    using System.Linq;
    using System.Text;

    public class MultiplyBigNumber
    {
        public static void Main()
        {
            string s = Console.ReadLine();
            int m = int.Parse(Console.ReadLine());
            if (m == 0)
            {
                Console.WriteLine("0");
                return;
            }
            s = s.TrimStart('0');
            int over = 0;
            var sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int n = (s[i] - '0') * m + over;
                sb.Append(n % 10);
                over = n / 10;
            }
            if (over > 0)
                sb.Append(over);
            string result = new string(sb.ToString().Reverse().ToArray());
            Console.WriteLine(result);
        }
    }
}
