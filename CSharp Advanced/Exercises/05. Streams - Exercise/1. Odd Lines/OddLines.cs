namespace _1._Odd_Lines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                string input;
                for (int line = 0; (input = reader.ReadLine()) != null; line++)
                {
                    if (line % 2 == 0)
                        continue;

                    Console.WriteLine(input);
                }
            }
        }
    }
}
