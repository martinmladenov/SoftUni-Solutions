namespace _12.Master_Number
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int max = int.Parse(Console.ReadLine());
            for (int i = 1; i <= max; i++)
            {
                if (IsPalindrome(i) && GetSumOfDigits(i) % 7 == 0 && ContainsEvenDigit(i))
                    Console.WriteLine(i);
            }
        }

        public static bool IsPalindrome(int n)
        {
            string str = n.ToString();
            for (int i = 0; i <= str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }
            return true;
        }

        public static int GetSumOfDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        public static bool ContainsEvenDigit(int n)
        {
            while (n > 0)
            {
                if (n % 10 % 2 == 0) return true;
                n /= 10;
            }
            return false;
        }
    }
}
