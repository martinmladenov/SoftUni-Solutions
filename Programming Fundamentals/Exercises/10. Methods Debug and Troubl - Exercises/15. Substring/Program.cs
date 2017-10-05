using System;

namespace _15.Substring
{
    public class Substring
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            const char search = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == search)
                {
                    hasMatch = true;

                    int length = jump + 1;

                    if (length + i >= text.Length)
                    {
                        length = text.Length - i;
                    }

                    string matchedString = text.Substring(i, length);
                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
