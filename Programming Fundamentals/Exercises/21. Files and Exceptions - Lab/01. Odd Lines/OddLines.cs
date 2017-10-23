namespace _01.Odd_Lines
{
    using System.IO;
    using System.Linq;

    public class OddLines
    {
        public static void Main()
        {
            var lines = File.ReadAllLines(@"..\..\Input.txt")
                .Where((i, index) => index % 2 != 0);
            File.WriteAllLines(@"..\..\Output.txt", lines);
        }
    }
}
