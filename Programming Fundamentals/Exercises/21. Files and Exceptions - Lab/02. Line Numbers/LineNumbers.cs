namespace _02.Line_Numbers
{
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        public static void Main()
        {
            var lines = File.ReadAllLines(@"..\..\Input.txt")
                .Select((i, index) => index + 1 + ". " + i);
            File.WriteAllLines(@"..\..\Output.txt", lines);
        }
    }
}
