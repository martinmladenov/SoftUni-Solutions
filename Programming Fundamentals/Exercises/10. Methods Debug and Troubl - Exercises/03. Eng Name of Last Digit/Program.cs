namespace _03.Eng_Name_of_Last_Digit
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(GetNameOfLastDigit(long.Parse(Console.ReadLine())));
        }

        public static string GetNameOfLastDigit(long n)
        {
            long lastDigit = Math.Abs(n % 10);
            switch (lastDigit)
            {
                case 0:
                    return "zero";

                case 1:
                    return "one";

                case 2:
                    return "two";

                case 3:
                    return "three";

                case 4:
                    return "four";

                case 5:
                    return "five";

                case 6:
                    return "six";

                case 7:
                    return "seven";

                case 8:
                    return "eight";

                case 9:
                    return "nine";

                default:
                    return null;
            }
        }
    }
}
