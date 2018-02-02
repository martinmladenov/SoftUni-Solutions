namespace _2._Line_Numbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    string input;
                    for (int line = 0; (input = reader.ReadLine()) != null; line++)
                    {
                        writer.WriteLine($"Line {line}: {input}");
                    }
                }
            }
        }
    }
}
